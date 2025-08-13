using SalesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementSystem.DataAccess
{
    public class CustomerDAL
    {
        public DataTable GetAll() => DbHelper.ExecuteQuery("SELECT * FROM Customer");

        public bool Add(Customer c)
        {
            string query = "INSERT INTO Customer (Name, Address, Phone, Email) VALUES (@Name, @Addr, @Phone, @Email)";
            SqlParameter[] p = {
                new SqlParameter("@Name", c.Name),
                new SqlParameter("@Addr", c.Address),
                new SqlParameter("@Phone", c.Phone),
                new SqlParameter("@Email", c.Email)
            };
            return DbHelper.ExecuteNonQuery(query, p) > 0;
        }

        public bool Update(Customer c)
        {
            string query = "UPDATE Customer SET Name=@Name, Address=@Addr, Phone=@Phone, Email=@Email WHERE ID=@ID";
            SqlParameter[] p = {
                new SqlParameter("@ID", c.ID),
                new SqlParameter("@Name", c.Name),
                new SqlParameter("@Addr", c.Address),
                new SqlParameter("@Phone", c.Phone),
                new SqlParameter("@Email", c.Email)
            };
            return DbHelper.ExecuteNonQuery(query, p) > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Customer WHERE ID=@ID";
            SqlParameter[] p = { new SqlParameter("@ID", id) };
            return DbHelper.ExecuteNonQuery(query, p) > 0;
        }

        public DataTable SearchByName(string name)
        {
            string query = "SELECT * FROM Customer WHERE Name LIKE @Name";
            SqlParameter[] p = { new SqlParameter("@Name", "%" + name + "%") };
            return DbHelper.ExecuteQuery(query, p);
        }
    }

}
