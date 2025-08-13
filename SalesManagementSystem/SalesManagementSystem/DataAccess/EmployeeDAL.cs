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
    public class EmployeeDAL
    {
        public DataTable GetAll()
        {
            return DbHelper.ExecuteQuery("SELECT * FROM Employee");
        }

        public bool Add(Employee emp)
        {
            string query = "INSERT INTO Employee (FullName, Position, Level, Username, Password) VALUES (@Name, @Pos, @Lvl, @User, @Pass)";
            SqlParameter[] p = {
                new SqlParameter("@Name", emp.FullName),
                new SqlParameter("@Pos", emp.Position),
                new SqlParameter("@Lvl", emp.Level),
                new SqlParameter("@User", emp.Username),
                new SqlParameter("@Pass", emp.Password)
            };
            return DbHelper.ExecuteNonQuery(query, p) > 0;
        }

        public bool Update(Employee emp)
        {
            string query = "UPDATE Employee SET FullName=@Name, Position=@Pos, Level=@Lvl, Username=@User, Password=@Pass WHERE ID=@ID";
            SqlParameter[] p = {
                new SqlParameter("@ID", emp.ID),
                new SqlParameter("@Name", emp.FullName),
                new SqlParameter("@Pos", emp.Position),
                new SqlParameter("@Lvl", emp.Level),
                new SqlParameter("@User", emp.Username),
                new SqlParameter("@Pass", emp.Password)
            };
            return DbHelper.ExecuteNonQuery(query, p) > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Employee WHERE ID=@ID";
            SqlParameter[] p = { new SqlParameter("@ID", id) };
            return DbHelper.ExecuteNonQuery(query, p) > 0;
        }

        public DataTable SearchByName(string name)
        {
            string query = "SELECT * FROM Employee WHERE FullName LIKE @Name";
            SqlParameter[] p = { new SqlParameter("@Name", "%" + name + "%") };
            return DbHelper.ExecuteQuery(query, p);
        }
    }

}
