using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Abstractions
{
    public enum Gender
    {
        Female,
        Male
    }
    public class Users
    {
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int City { get; set; }
        public Gender Gender { get; set; }
    }
}
