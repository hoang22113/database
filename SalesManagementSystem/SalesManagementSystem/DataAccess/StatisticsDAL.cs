using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementSystem.DataAccess
{
    public class StatisticsDAL
    {
        public DataTable GetRevenueByMonth()
        {
            string query = @"SELECT MONTH(OrderDate) AS Month, SUM(TotalAmount) AS Revenue
                             FROM [Order]
                             GROUP BY MONTH(OrderDate)";
            return DbHelper.ExecuteQuery(query);
        }

        public DataTable GetLowStockProducts(int threshold = 10)
        {
            string query = "SELECT * FROM Product WHERE StockQuantity < @Threshold";
            SqlParameter[] param = { new SqlParameter("@Threshold", threshold) };
            return DbHelper.ExecuteQuery(query, param);
        }

        public DataTable GetReportByDateRange(DateTime from, DateTime to)
        {
            string query = @"SELECT o.OrderDate, c.Name AS CustomerName, o.TotalAmount
                             FROM [Order] o
                             JOIN Customer c ON o.CustomerID = c.ID
                             WHERE o.OrderDate BETWEEN @From AND @To";
            SqlParameter[] param = {
                new SqlParameter("@From", from),
                new SqlParameter("@To", to)
            };
            return DbHelper.ExecuteQuery(query, param);
        }
    }

}
