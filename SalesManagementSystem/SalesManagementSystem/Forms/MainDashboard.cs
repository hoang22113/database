using SalesManagementSystem.BusinessLogic;
using SalesManagementSystem.DataAccess;
using SalesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagementSystem
{
    public partial class MainDashboard : Form
    {
        EmployeeBLL employeeBLL = new EmployeeBLL();
        CustomerBLL customerBLL = new CustomerBLL();
        SupplierBLL supplierBLL = new SupplierBLL();
        CategoryBLL categoryBLL = new CategoryBLL();
        ProductBLL productBLL = new ProductBLL();
        OrderBLL orderBLL = new OrderBLL();


        public MainDashboard()
        {
            InitializeComponent();
        }
        private void LoadEmployeeData()
        {
            dgvEmployees.DataSource = employeeBLL.GetAllEmployees();
        }
        private void LoadCustomerData()
        {
            dgvCustomers.DataSource = customerBLL.GetAllCustomers();
        }
        private void LoadSupplierData()
        {
            dgvSuppliers.DataSource = supplierBLL.GetAllSuppliers();
        }
        private void LoadCategoryData()
        {
            dgvCategories.DataSource = categoryBLL.GetAllCategories();
        }
        private void LoadProductData()
        {
            dgvProducts.DataSource = productBLL.GetAllProducts();
        }

        private void LoadOrderData()
        {
            dgvOrders.DataSource = orderBLL.GetAllOrders();
        }


        private void tabManageCategory_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabManageEmployee_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            dgvEmployees.DataSource = employeeBLL.SearchEmployees(keyword);

        }

        private void btnMeRefresh_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
            txtPosition.Clear();
            txtLevel.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtSearch.Clear();
            LoadEmployeeData();

        }

        private void btnMeAdd_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee
            {
                FullName = txtName.Text.Trim(),
                Position = txtPosition.Text.Trim(),
                Level = int.Parse(txtLevel.Text.Trim()),
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim()
            };

            if (employeeBLL.AddEmployee(emp))
            {
                MessageBox.Show("Thêm nhân viên thành công!");
                LoadEmployeeData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại. Kiểm tra dữ liệu.");
            }

        }

        private void btnMeUpdate_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee
            {
                ID = int.Parse(txtID.Text),
                FullName = txtName.Text.Trim(),
                Position = txtPosition.Text.Trim(),
                Level = int.Parse(txtLevel.Text.Trim()),
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim()
            };

            if (employeeBLL.UpdateEmployee(emp))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadEmployeeData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.");
            }

        }

        private void btnMeDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (employeeBLL.DeleteEmployee(id))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadEmployeeData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }
            }

        }

        private void dgvEmployees_Click(object sender, EventArgs e)
        {

        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtName.Text = row.Cells["FullName"].Value.ToString();
                txtPosition.Text = row.Cells["Position"].Value.ToString();
                txtLevel.Text = row.Cells["Level"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
            }

        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];

                txtCustomerID.Text = row.Cells["CustomerID"].Value?.ToString();
                txtCustomerName.Text = row.Cells["CustomerName"].Value?.ToString();
                txtAddress.Text = row.Cells["Address"].Value?.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
            }

        }

        private void btnMcSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtMcSearch.Text.Trim();
            dgvCustomers.DataSource = customerBLL.SearchCustomers(keyword);

        }

        private void btnMcRefresh_Click(object sender, EventArgs e)
        {
            txtCustomerID.Clear();
            txtCustomerName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtMcSearch.Clear();
            LoadCustomerData();

        }

        private void btnMcAdd_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer
            {
                Name = txtCustomerName.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            if (customerBLL.AddCustomer(customer))
            {
                MessageBox.Show("Thêm khách hàng thành công!");
                LoadCustomerData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại. Kiểm tra dữ liệu.");
            }

        }

        private void btnMcUpdate_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer
            {
                ID = int.Parse(txtCustomerID.Text),
                Name = txtCustomerName.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            if (customerBLL.UpdateCustomer(customer))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadCustomerData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.");
            }

        }

        private void btnMcDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCustomerID.Text);
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (customerBLL.DeleteCustomer(id))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadCustomerData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtSupplierID.Clear();
            txtSupplierName.Clear();
            txtSupplierAddress.Clear();
            txtSupplierPhone.Clear();
            txtSupplierEmail.Clear();
            txtSupplierSearch.Clear();
            LoadSupplierData();

        }

        private void btnSupplierSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSupplierSearch.Text.Trim();
            dgvSuppliers.DataSource = supplierBLL.SearchSuppliers(keyword);

        }

        private void btnSpAdd_Click(object sender, EventArgs e)
        {
            Supplier s = new Supplier
            {
                Name = txtSupplierName.Text.Trim(),
                Address = txtSupplierAddress.Text.Trim(),
                Phone = txtSupplierPhone.Text.Trim(),
                Email = "" // nếu có thêm TextBox Email thì dùng txtSupplierEmail.Text
            };

            if (supplierBLL.AddSupplier(s))
            {
                MessageBox.Show("Thêm nhà cung cấp thành công!");
                LoadSupplierData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại.");
            }

        }

        private void btnSpUpdate_Click(object sender, EventArgs e)
        {
            Supplier s = new Supplier
            {
                ID = int.Parse(txtSupplierID.Text),
                Name = txtSupplierName.Text.Trim(),
                Address = txtSupplierAddress.Text.Trim(),
                Phone = txtSupplierPhone.Text.Trim(),
                Email = "" // nếu có
            };

            if (supplierBLL.UpdateSupplier(s))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadSupplierData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.");
            }

        }

        private void btnSpDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSupplierID.Text);
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (supplierBLL.DeleteSupplier(id))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadSupplierData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }
            }

        }

        private void dgvSuppliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSuppliers.Rows[e.RowIndex];

                txtSupplierID.Text = row.Cells["ID"].Value?.ToString();
                txtSupplierName.Text = row.Cells["Name"].Value?.ToString();
                txtSupplierAddress.Text = row.Cells["Address"].Value?.ToString();
                txtSupplierPhone.Text = row.Cells["Phone"].Value?.ToString();
                txtSupplierEmail.Text = row.Cells["Email"].Value?.ToString();
            }

        }

        private void btnMctRefresh_Click(object sender, EventArgs e)
        {
            txtCategoryID.Clear();
            txtCategoryName.Clear();
            txtCategorySearch.Clear();
            LoadCategoryData();

        }

        private void btnMctAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category
            {
                Name = txtCategoryName.Text.Trim()
            };

            if (categoryBLL.AddCategory(category))
            {
                MessageBox.Show("Thêm danh mục thành công!");
                LoadCategoryData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại. Kiểm tra dữ liệu.");
            }

        }

        private void btnMctUpdate_Click(object sender, EventArgs e)
        {
            Category category = new Category
            {
                ID = int.Parse(txtCategoryID.Text),
                Name = txtCategoryName.Text.Trim()
            };

            if (categoryBLL.UpdateCategory(category))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadCategoryData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.");
            }

        }

        private void btnMctDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryID.Text);
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa danh mục này?", "Xác nhận", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (categoryBLL.DeleteCategory(id))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadCategoryData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }
            }

        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];

                txtCategoryID.Text = row.Cells["ID"].Value?.ToString();
                txtCategoryName.Text = row.Cells["Name"].Value?.ToString();
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            string keyword = txtCategorySearch.Text.Trim();
            dgvCategories.DataSource = categoryBLL.SearchCategories(keyword);

        }

        private void btnPrSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtProductSearch.Text.Trim();
            dgvProducts.DataSource = productBLL.SearchProducts(keyword);

        }

        private void btnMpRefresh_Click(object sender, EventArgs e)
        {
            txtProductID.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtStockQuantity.Clear();
            txtDescription.Clear();
            txtProductSearch.Clear();
            cboCategory.SelectedIndex = -1;
            LoadProductData();

        }

        private void btnMpAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Name = txtProductName.Text.Trim(),
                Price = decimal.Parse(txtPrice.Text),
                StockQuantity = int.Parse(txtStockQuantity.Text),
                Description = txtDescription.Text.Trim(),
                CategoryID = (int)cboCategory.SelectedValue
            };

            if (productBLL.AddProduct(product))
            {
                MessageBox.Show("Thêm sản phẩm thành công!");
                LoadProductData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại. Kiểm tra dữ liệu.");
            }

        }

        private void btnMpUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                ID = int.Parse(txtProductID.Text),
                Name = txtProductName.Text.Trim(),
                Price = decimal.Parse(txtPrice.Text),
                StockQuantity = int.Parse(txtStockQuantity.Text),
                Description = txtDescription.Text.Trim(),
                CategoryID = (int)cboCategory.SelectedValue
            };

            if (productBLL.UpdateProduct(product))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadProductData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.");
            }

        }

        private void btnMpDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductID.Text);
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (productBLL.DeleteProduct(id))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadProductData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }
            }

        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                txtProductID.Text = row.Cells["ID"].Value?.ToString();
                txtProductName.Text = row.Cells["Name"].Value?.ToString();
                txtPrice.Text = row.Cells["Price"].Value?.ToString();
                txtStockQuantity.Text = row.Cells["StockQuantity"].Value?.ToString();
                txtDescription.Text = row.Cells["Description"].Value?.ToString();
                cboCategory.SelectedValue = row.Cells["CategoryID"].Value;
            }

        }
        private void LoadCustomerComboBox()
        {
            cboCustomer.DataSource = customerBLL.GetAllCustomers();
            cboCustomer.DisplayMember = "Name";
            cboCustomer.ValueMember = "ID";
            cboCustomer.SelectedIndex = -1;
        }
        private void LoadStatusComboBox()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.AddRange(new string[] { "Pending", "Shipped", "Cancelled" });
            cboStatus.SelectedIndex = -1;
        }
        private void ClearOrderFields()
        {
            txtOrderID.Clear();
            txtTotalAmount.Clear();
            cboCustomer.SelectedIndex = -1;
            cboEmployee.SelectedIndex = -1;
            cboStatus.SelectedIndex = -1;
            dtpOrderDate.Value = DateTime.Today;
        }
        private void InitOrderPage()
        {
            LoadOrderData();
            LoadCustomerComboBox();
            LoadStatusComboBox();
            ClearOrderFields();
        }

        private void tabManageOrder_Click(object sender, EventArgs e)
        {
            InitOrderPage();
        }

        private void btnMoAdd_Click(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedIndex == -1 || cboEmployee.SelectedIndex == -1 || cboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin khách hàng, nhân viên và trạng thái.");
                return;
            }

            Order newOrder = new Order
            {
                CustomerID = (int)cboCustomer.SelectedValue,
                EmployeeID = (int)cboEmployee.SelectedValue,
                OrderDate = dtpOrderDate.Value,
                Status = cboStatus.SelectedItem.ToString(),
                TotalAmount = CalculateTotalFromDetails(GetOrderDetailsByOrderId(int.Parse(txtOrderID.Text)))
            };

            // Thêm chi tiết đơn hàng nếu có
            newOrder.OrderDetails = GetOrderDetailsFromGrid();

            bool result = orderBLL.AddOrder(newOrder);
            if (result)
            {
                MessageBox.Show("Thêm đơn hàng thành công!");
                LoadOrderData();
                ClearOrderFields();
            }
            else
            {
                MessageBox.Show("Thêm đơn hàng thất bại.");
            }


        }

        private void btnMoUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOrderID.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn hàng để sửa.");
                return;
            }

            Order updatedOrder = new Order
            {
                ID = int.Parse(txtOrderID.Text),
                CustomerID = (int)cboCustomer.SelectedValue,
                EmployeeID = (int)cboEmployee.SelectedValue,
                OrderDate = dtpOrderDate.Value,
                Status = cboStatus.SelectedItem.ToString(),
                TotalAmount = CalculateTotalFromDetails(GetOrderDetailsByOrderId(int.Parse(txtOrderID.Text))),
                OrderDetails = GetOrderDetailsFromGrid()
            };

            bool result = orderBLL.UpdateOrder(updatedOrder);
            if (result)
            {
                MessageBox.Show("Cập nhật đơn hàng thành công!");
                LoadOrderData();
                ClearOrderFields();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.");
            }

        }

        private void btnMoDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOrderID.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn hàng để xóa.");
                return;
            }

            int orderId = int.Parse(txtOrderID.Text);
            DialogResult confirm = MessageBox.Show("Bạn có chắc muốn xóa đơn hàng này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                bool result = orderBLL.DeleteOrder(orderId);
                if (result)
                {
                    MessageBox.Show("Xóa đơn hàng thành công!");
                    LoadOrderData();
                    ClearOrderFields();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }
            }

        }
        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return orderBLL.GetOrderByid(orderId).OrderDetails;
        }

        private void btnMoSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            DateTime? date = dtpSearchDate.Value.Date;

            dgvOrders.DataSource = orderBLL.SearchOrders(keyword, date);

        }
        private decimal CalculateTotalFromDetails(List<OrderDetail> details)
        {
            return details.Sum(d => d.Subtotal);
        }

        private List<OrderDetail> GetOrderDetailsFromGrid()
        {
            var details = new List<OrderDetail>();
            foreach (DataGridViewRow row in dgvOrderDetails.Rows)
            {
                if (row.IsNewRow) continue;

                details.Add(new OrderDetail
                {
                    ProductID = Convert.ToInt32(row.Cells["ProductID"].Value),
                    Quantity = Convert.ToInt32(row.Cells["Quantity"].Value),
                    Price = Convert.ToDecimal(row.Cells["UnitPrice"].Value)
                });
            }
            return details;
        }
        private void SetupOrderDetailGrid()
        {
            dgvOrderDetails.Columns.Clear();

            dgvOrderDetails.Columns.Add("ProductID", "Mã SP");
            dgvOrderDetails.Columns.Add("ProductName", "Tên SP");
            dgvOrderDetails.Columns.Add("Quantity", "Số lượng");
            dgvOrderDetails.Columns.Add("UnitPrice", "Đơn giá");
            dgvOrderDetails.Columns.Add("Subtotal", "Thành tiền");

            dgvOrderDetails.Columns["Subtotal"].ReadOnly = true;
        }



        private void btnModAdd_Click(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtQuantity.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm.");
                return;
            }

            int productId = (int)cboProduct.SelectedValue;
            string productName = cboProduct.Text;
            int quantity = int.Parse(txtQuantity.Text);
            decimal price = decimal.Parse(txtOdPrice.Text);
            decimal subtotal = quantity * price;

            dgvOrderDetails.Rows.Add(productId, productName, quantity, price, subtotal);
            UpdateTotalAmount();

        }

        private void btnModUpdate_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetails.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa.");
                return;
            }

            int rowIndex = dgvOrderDetails.CurrentRow.Index;
            dgvOrderDetails.Rows[rowIndex].Cells["ProductID"].Value = cboProduct.SelectedValue;
            dgvOrderDetails.Rows[rowIndex].Cells["ProductName"].Value = cboProduct.Text;
            dgvOrderDetails.Rows[rowIndex].Cells["Quantity"].Value = int.Parse(txtQuantity.Text);
            dgvOrderDetails.Rows[rowIndex].Cells["UnitPrice"].Value = decimal.Parse(txtPrice.Text);
            dgvOrderDetails.Rows[rowIndex].Cells["Subtotal"].Value = int.Parse(txtQuantity.Text) * decimal.Parse(txtPrice.Text);

            UpdateTotalAmount();

        }

        private void btnModDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetails.CurrentRow != null)
            {
                dgvOrderDetails.Rows.RemoveAt(dgvOrderDetails.CurrentRow.Index);
                UpdateTotalAmount();
            }

        }

        private void btnModRefresh_Click(object sender, EventArgs e)
        {
            dgvOrderDetails.Rows.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
            cboProduct.SelectedIndex = -1;
            UpdateTotalAmount();

        }
        private void UpdateTotalAmount()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvOrderDetails.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }
            txtTotalAmount.Text = total.ToString("N2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

        }
    }
}
