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
    public class CategoryDAL
    {
        public DataTable GetAll() => DbHelper.ExecuteQuery("SELECT * FROM Category");

        public bool Add(Category c)
        {
            string query = "INSERT INTO Category (Name) VALUES (@Name)";
            SqlParameter[] p = { new SqlParameter("@Name", c.Name) };
            return DbHelper.ExecuteNonQuery(query, p) > 0;
        }

        public bool Update(Category c)
        {
            string query = "UPDATE Category SET Name=@Name WHERE ID=@ID";
            SqlParameter[] p = {
                new SqlParameter("@ID", c.ID),
                new SqlParameter("@Name", c.Name)
            };
            return DbHelper.ExecuteNonQuery(query, p) > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Category WHERE ID=@ID";
            SqlParameter[] p = { new SqlParameter("@ID", id) };
            return DbHelper.ExecuteNonQuery(query, p) > 0;
        }

        public DataTable SearchByName(string name)
        {
            string query = "SELECT * FROM Category WHERE Name LIKE @Name";
            SqlParameter[] p = { new SqlParameter("@Name", "%" + name + "%") };
            return DbHelper.ExecuteQuery(query, p);
        }

    }
}
