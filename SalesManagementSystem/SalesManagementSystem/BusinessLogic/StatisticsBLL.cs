using SalesManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementSystem.BusinessLogic
{
    public class StatisticsBLL
    {
        private readonly StatisticsDAL dal = new StatisticsDAL();

        public DataTable GetMonthlyRevenue() => dal.GetRevenueByMonth();

        public DataTable GetLowStockProducts(int threshold = 10) => dal.GetLowStockProducts(threshold);

        public DataTable GetReport(DateTime from, DateTime to) => dal.GetReportByDateRange(from, to);
    }

}
