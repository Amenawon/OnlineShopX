using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Abstractions
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int OrderNumber { get; set; }
        public int TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public Boolean Delivered { get; set; }
    }
}
