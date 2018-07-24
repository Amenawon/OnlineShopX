using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Abstractions
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }
        public Boolean Allowed { get; set; }
    }
}