using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace shophang.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public string ProductImages { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
    }
}
