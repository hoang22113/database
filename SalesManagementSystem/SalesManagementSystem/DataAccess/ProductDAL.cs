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
    public class ProductDAL
    {
        public DataTable GetAll()
        {
            string query = "SELECT p.*, c.Name AS CategoryName FROM Product p JOIN Category c ON p.CategoryID = c.ID";
            return DbHelper.ExecuteQuery(query);
        }

        public bool Add(Product p)
        {
            string query = "INSERT INTO Product (Name, Price, StockQuantity, Description, CategoryID) VALUES (@Name, @Price, @Stock, @Desc, @Cat)";
            SqlParameter[] param = {
                new SqlParameter("@Name", p.Name),
                new SqlParameter("@Price", p.Price),
                new SqlParameter("@Stock", p.StockQuantity),
                new SqlParameter("@Desc", p.Description),
                new SqlParameter("@Cat", p.CategoryID)
            };
            return DbHelper.ExecuteNonQuery(query, param) > 0;
        }

        public bool Update(Product p)
        {
            string query = "UPDATE Product SET Name=@Name, Price=@Price, StockQuantity=@Stock, Description=@Desc, CategoryID=@Cat WHERE ID=@ID";
            SqlParameter[] param = {
                new SqlParameter("@ID", p.ID),
                new SqlParameter("@Name", p.Name),
                new SqlParameter("@Price", p.Price),
                new SqlParameter("@Stock", p.StockQuantity),
                new SqlParameter("@Desc", p.Description),
                new SqlParameter("@Cat", p.CategoryID)
            };
            return DbHelper.ExecuteNonQuery(query, param) > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Product WHERE ID=@ID";
            SqlParameter[] param = { new SqlParameter("@ID", id) };
            return DbHelper.ExecuteNonQuery(query, param) > 0;
        }

        public DataTable SearchByName(string name)
        {
            string query = "SELECT p.*, c.Name AS CategoryName FROM Product p JOIN Category c ON p.CategoryID = c.ID WHERE p.Name LIKE @Name";
            SqlParameter[] param = { new SqlParameter("@Name", "%" + name + "%") };
            return DbHelper.ExecuteQuery(query, param);
        }
    }


}
