﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Abstractions
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryDescription { get; set; }
        public byte CategoryPicture { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
