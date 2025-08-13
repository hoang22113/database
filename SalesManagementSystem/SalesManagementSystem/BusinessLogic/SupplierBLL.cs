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
    public class SupplierBLL
    {
        private SupplierDAL dal = new SupplierDAL();

        public DataTable GetAllSuppliers()
        {
            return dal.GetAll();
        }

        public bool AddSupplier(Supplier supplier)
        {
            return dal.Add(supplier);
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            return dal.Update(supplier);
        }

        public bool DeleteSupplier(int supplierId)
        {
            return dal.Delete(supplierId);
        }

        public DataTable SearchSuppliers(string name)
        {
            return dal.SearchByName(name);
        }
    }


}
