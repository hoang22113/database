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
    public class CategoryBLL
    {
        private CategoryDAL dal = new CategoryDAL();

        public DataTable GetAllCategories()
        {
            return dal.GetAll();
        }

        public bool AddCategory(Category category)
        {
            return dal.Add(category);
        }

        public bool UpdateCategory(Category category)
        {
            return dal.Update(category);
        }

        public bool DeleteCategory(int categoryId)
        {
            return dal.Delete(categoryId);
        }

        public DataTable SearchCategories(string name)
        {
            return dal.SearchByName(name);
        }
    }

}
