using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shophang.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Tên danh mục")]
        public string CategoryName { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<New> News { get; set; }
      
    }
}
