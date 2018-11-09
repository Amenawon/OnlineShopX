using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Abstractions
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        public int OrderNumber { get; set; }
        public int TotalPrice { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public int SalesTax { get; set; }
        public DateTime TimeStamp { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime PaymentDate { get; set; }

        public Payment Payment { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
