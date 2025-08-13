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
    public class CustomerBLL
    {
        private readonly CustomerDAL dal = new CustomerDAL();

        public DataTable GetAllCustomers() => dal.GetAll();

        public bool AddCustomer(Customer c)
        {
            if (string.IsNullOrWhiteSpace(c.Name) || string.IsNullOrWhiteSpace(c.Email))
                return false;

            return dal.Add(c);
        }

        public bool UpdateCustomer(Customer c)
        {
            if (c.ID <= 0 || string.IsNullOrWhiteSpace(c.Name))
                return false;

            return dal.Update(c);
        }

        public bool DeleteCustomer(int id)
        {
            if (id <= 0) return false;
            return dal.Delete(id);
        }

        public DataTable SearchCustomers(string keyword) => dal.SearchByName(keyword);
    }

}
