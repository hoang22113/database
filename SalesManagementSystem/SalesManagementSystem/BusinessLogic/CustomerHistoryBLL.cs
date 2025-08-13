using SalesManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementSystem.BusinessLogic
{
    public class CustomerHistoryBLL
    {
        private readonly CustomerHistoryDAL dal = new CustomerHistoryDAL();

        public DataTable GetOrderHistory(int customerId)
        {
            if (customerId <= 0) return null;
            return dal.GetOrderHistory(customerId);
        }
    }

}
