using SalesManagementSystem.DataAccess;
using SalesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementSystem.BusinessLogic
{
    public class ProductBLL
    {
        private readonly ProductDAL dal = new ProductDAL();

        public DataTable GetAllProducts() => dal.GetAll();

        public bool AddProduct(Product p)
        {
            if (string.IsNullOrWhiteSpace(p.Name) || p.Price <= 0)
                return false;

            return dal.Add(p);
        }

        public bool UpdateProduct(Product p)
        {
            if (p.ID <= 0 || string.IsNullOrWhiteSpace(p.Name))
                return false;

            return dal.Update(p);
        }

        public bool DeleteProduct(int id)
        {
            if (id <= 0) return false;
            return dal.Delete(id);
        }

        public DataTable SearchProducts(string name) => dal.SearchByName(name);
    }
}
