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
    public class OrderDAL
    {
        public DataTable GetAll()
        {
            string query = @"SELECT o.*, c.Name AS CustomerName, e.FullName AS EmployeeName
                             FROM [Order] o
                             JOIN Customer c ON o.CustomerID = c.ID
                             JOIN Employee e ON o.EmployeeID = e.ID";
            return DbHelper.ExecuteQuery(query);
        }
        public Order GetById(int id)
        {
            string query = @"SELECT o.*
                             FROM [Order] o
                             JOIN Customer c ON o.CustomerID = c.ID
                             JOIN Employee e ON o.EmployeeID = e.ID
                             WHERE o.ID = @ID";
            SqlParameter[] param = { new SqlParameter("@ID", id) };
            DataTable dt = DbHelper.ExecuteQuery(query, param);
            if (dt.Rows.Count > 0)
            {
                return new Order
                {
                    ID = Convert.ToInt32(dt.Rows[0]["ID"]),
                    CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"]),
                    EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]),
                    OrderDate = Convert.ToDateTime(dt.Rows[0]["OrderDate"]),
                    TotalAmount = Convert.ToDecimal(dt.Rows[0]["TotalAmount"])
                };
            }
            return null;
        }

        public bool Add(Order o)
        {
            string query = "INSERT INTO [Order] (CustomerID, EmployeeID, OrderDate, TotalAmount) VALUES (@Cus, @Emp, @Date, @Total)";
            SqlParameter[] param = {
                new SqlParameter("@Cus", o.CustomerID),
                new SqlParameter("@Emp", o.EmployeeID),
                new SqlParameter("@Date", o.OrderDate),
                new SqlParameter("@Total", o.TotalAmount)
            };
            return DbHelper.ExecuteNonQuery(query, param) > 0;
        }

        public bool Update(Order o)
        {
            string query = "UPDATE [Order] SET CustomerID=@Cus, EmployeeID=@Emp, OrderDate=@Date, TotalAmount=@Total WHERE ID=@ID";
            SqlParameter[] param = {
                new SqlParameter("@ID", o.ID),
                new SqlParameter("@Cus", o.CustomerID),
                new SqlParameter("@Emp", o.EmployeeID),
                new SqlParameter("@Date", o.OrderDate),
                new SqlParameter("@Total", o.TotalAmount)
            };
            return DbHelper.ExecuteNonQuery(query, param) > 0;
        }

        public bool Delete(int id)
        {   
            string query = "DELETE FROM [Order] WHERE ID=@ID";
            SqlParameter[] param = { new SqlParameter("@ID", id) };
            return DbHelper.ExecuteNonQuery(query, param) > 0;
        }

        public DataTable Search(string customerName, DateTime? date)
        {
            string query = @"SELECT o.*, c.Name AS CustomerName, e.FullName AS EmployeeName
                             FROM [Order] o
                             JOIN Customer c ON o.CustomerID = c.ID
                             JOIN Employee e ON o.EmployeeID = e.ID
                             WHERE c.Name LIKE @Name AND (@Date IS NULL OR CAST(o.OrderDate AS DATE) = @Date)";
            SqlParameter[] param = {
                new SqlParameter("@Name", "%" + customerName + "%"),
                new SqlParameter("@Date", (object)date ?? DBNull.Value)
            };
            return DbHelper.ExecuteQuery(query, param);
        }
        public List<RevenueByMonth> GetRevenueByMonth(DateTime fromDate, DateTime toDate)
        {
            var result = new List<RevenueByMonth>();
            string query = @"
        SELECT 
            FORMAT(OrderDate, 'MM/yyyy') AS Month,
            SUM(TotalAmount) AS Total
        FROM [Order]
        WHERE OrderDate BETWEEN @From AND @To
        GROUP BY FORMAT(OrderDate, 'MM/yyyy')
        ORDER BY MIN(OrderDate)";

            SqlParameter[] param = {
        new SqlParameter("@From", fromDate),
        new SqlParameter("@To", toDate)
    };

            DataTable dt = DbHelper.ExecuteQuery(query, param);
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new RevenueByMonth
                {
                    Month = row["Month"].ToString(),
                    Total = Convert.ToDecimal(row["Total"])
                });
            }

            return result;
        }
        public class RevenueByMonth
        {
            public string Month { get; set; }
            public decimal Total { get; set; }
        }

    }

}
