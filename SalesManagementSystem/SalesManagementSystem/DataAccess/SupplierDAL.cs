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
    public class SupplierDAL
    {
        public DataTable GetAll() => DbHelper.ExecuteQuery("SELECT * FROM Supplier");

        public bool Add(Supplier s)
        {
            string query = "INSERT INTO Supplier (Name, Address, Phone, Email) VALUES (@Name, @Addr, @Phone, @Email)";
            SqlParameter[] p = {
                new SqlParameter("@Name", s.Name),
                new SqlParameter("@Addr", s.Address),
                new SqlParameter("@Phone", s.Phone),
                new SqlParameter("@Email", s.Email)
            };
            return DbHelper.ExecuteNonQuery(query, p) > 0;
        }

        public bool Update(Supplier s)
        {
            string query = "UPDATE Supplier SET Name=@Name, Address=@Addr, Phone=@Phone, Email=@Email WHERE ID=@ID";
            SqlParameter[] p = {
                new SqlParameter("@ID", s.ID),
                new SqlParameter("@Name", s.Name),
                new SqlParameter("@Addr", s.Address),
                new SqlParameter("@Phone", s.Phone),
                new SqlParameter("@Email", s.Email)
            };
            return DbHelper.ExecuteNonQuery(query, p) > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Supplier WHERE ID=@ID";
            SqlParameter[] p = { new SqlParameter("@ID", id) };
            return DbHelper.ExecuteNonQuery(query, p) > 0;
        }

        public DataTable SearchByName(string name)
        {
            string query = "SELECT * FROM Supplier WHERE Name LIKE @Name";
            SqlParameter[] p = { new SqlParameter("@Name", "%" + name + "%") };
            return DbHelper.ExecuteQuery(query, p);
        }
    }

}
