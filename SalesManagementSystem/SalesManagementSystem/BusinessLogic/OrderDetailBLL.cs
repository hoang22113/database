using SalesManagementSystem.DataAccess;
using SalesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementSystem.BusinessLogic
{
    public class OrderDetailBLL
    {
        private readonly OrderDetailDAL dal = new OrderDetailDAL();

        public DataTable GetAllOrderDetails() => dal.GetAll();

        public bool AddOrderDetail(OrderDetail od)
        {
            if (od.OrderID <= 0 || od.ProductID <= 0 || od.Quantity <= 0 || od.Price <= 0)
                return false;

            return dal.Add(od);
        }

        public bool UpdateOrderDetail(OrderDetail od)
        {
            if (od.ID <= 0 || od.Quantity <= 0 || od.Price <= 0)
                return false;

            return dal.Update(od);
        }

        public bool DeleteOrderDetail(int id)
        {
            if (id <= 0) return false;
            return dal.Delete(id);
        }

        public DataTable GetDetailsByOrderID(int orderId) => dal.SearchByOrderID(orderId);
    }

}
