using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shophang.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
    }
}
