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
    public class OrderDetailDAL
    {
        public DataTable GetAll()
        {
            string query = @"SELECT od.*, p.Name AS ProductName, o.OrderDate
                             FROM OrderDetail od
                             JOIN Product p ON od.ProductID = p.ID
                             JOIN [Order] o ON od.OrderID = o.ID";
            return DbHelper.ExecuteQuery(query);
        }

        public bool Add(OrderDetail od)
        {
            string query = "INSERT INTO OrderDetail (OrderID, ProductID, Quantity, Price) VALUES (@Order, @Prod, @Qty, @Price)";
            SqlParameter[] param = {
                new SqlParameter("@Order", od.OrderID),
                new SqlParameter("@Prod", od.ProductID),
                new SqlParameter("@Qty", od.Quantity),
                new SqlParameter("@Price", od.Price)
            };
            return DbHelper.ExecuteNonQuery(query, param) > 0;
        }

        public bool Update(OrderDetail od)
        {
            string query = "UPDATE OrderDetail SET OrderID=@Order, ProductID=@Prod, Quantity=@Qty, Price=@Price WHERE ID=@ID";
            SqlParameter[] param = {
                new SqlParameter("@ID", od.ID),
                new SqlParameter("@Order", od.OrderID),
                new SqlParameter("@Prod", od.ProductID),
                new SqlParameter("@Qty", od.Quantity),
                new SqlParameter("@Price", od.Price)
            };
            return DbHelper.ExecuteNonQuery(query, param) > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM OrderDetail WHERE ID=@ID";
            SqlParameter[] param = { new SqlParameter("@ID", id) };
            return DbHelper.ExecuteNonQuery(query, param) > 0;
        }

        public DataTable SearchByOrderID(int orderId)
        {
            string query = @"SELECT od.*, p.Name AS ProductName
                             FROM OrderDetail od
                             JOIN Product p ON od.ProductID = p.ID
                             WHERE od.OrderID = @OrderID";
            SqlParameter[] param = { new SqlParameter("@OrderID", orderId) };
            return DbHelper.ExecuteQuery(query, param);
        }
    }

}
