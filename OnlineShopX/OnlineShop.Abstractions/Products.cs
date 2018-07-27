using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Abstractions
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public int AvailabeSize { get; set; }
        public string AvailabeColor { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
        public int Discount { get; set; }
        public byte Picture { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
