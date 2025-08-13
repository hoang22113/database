using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementSystem.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public int Level { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
