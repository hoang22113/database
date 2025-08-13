using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementSystem.DataAccess
{
    public class CustomerHistoryDAL
    {
        public DataTable GetOrderHistory(int customerId)
        {
            string query = @"SELECT o.OrderDate, o.TotalAmount, p.Name AS ProductName, od.Quantity, od.Price
                             FROM [Order] o
                             JOIN OrderDetail od ON o.ID = od.OrderID
                             JOIN Product p ON od.ProductID = p.ID
                             WHERE o.CustomerID = @CustomerID";
            SqlParameter[] param = { new SqlParameter("@CustomerID", customerId) };
            return DbHelper.ExecuteQuery(query, param);
        }
    }

}
