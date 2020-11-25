using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shophang.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string TagName { get; set; }
        public virtual ICollection<NewTag> NewTags { get; set; }
        public virtual ICollection<New> News { get; set; }
    }
}
