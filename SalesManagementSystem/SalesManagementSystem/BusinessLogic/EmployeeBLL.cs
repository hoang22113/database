using SalesManagementSystem.DataAccess;
using SalesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementSystem.BusinessLogic
{
    public class EmployeeBLL
    {
        private readonly EmployeeDAL dal = new EmployeeDAL();

        public DataTable GetAllEmployees() => dal.GetAll();

        public bool AddEmployee(Employee e)
        {
            if (string.IsNullOrWhiteSpace(e.FullName))
                return false;

            return dal.Add(e);
        }

        public bool UpdateEmployee(Employee e)
        {
            if (e.ID <= 0 || string.IsNullOrWhiteSpace(e.FullName))
                return false;

            return dal.Update(e);
        }

        public bool DeleteEmployee(int id)
        {
            if (id <= 0) return false;
            return dal.Delete(id);
        }

        public DataTable SearchEmployees(string keyword) => dal.SearchByName(keyword);
    }

}
