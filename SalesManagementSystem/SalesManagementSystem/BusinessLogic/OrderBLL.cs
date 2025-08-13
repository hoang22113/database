using SalesManagementSystem.DataAccess;
using SalesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SalesManagementSystem.DataAccess.OrderDAL;

namespace SalesManagementSystem.BusinessLogic
{
    public class OrderBLL
    {
        private readonly OrderDAL dal = new OrderDAL();

        public DataTable GetAllOrders() => dal.GetAll();
        public Order GetOrderByid(int id) => dal.GetById(id);
        public List<RevenueByMonth> GetRevenueByMonth(DateTime fromDate, DateTime toDate) => dal.GetRevenueByMonth(fromDate, toDate);
        public bool AddOrder(Order o)
        {
            if (o.CustomerID <= 0 || o.EmployeeID <= 0 || o.TotalAmount <= 0 || string.IsNullOrEmpty(o.Status))
                return false;

            return dal.Add(o);
        }

        public bool UpdateOrder(Order o)
        {
            if (o.ID <= 0 || o.TotalAmount <= 0 || string.IsNullOrEmpty(o.Status))
                return false;

            return dal.Update(o);
        }


        public bool DeleteOrder(int id)
        {
            if (id <= 0) return false;
            return dal.Delete(id);
        }

        public DataTable SearchOrders(string customerName, DateTime? date) => dal.Search(customerName, date);
    }

}
