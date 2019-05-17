using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Abstractions
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
