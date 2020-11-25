using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shophang.Models
{
    public class Slide
    {
        [Key]
        public int Id { get; set; }
        public string Images { get; set; }
        public string Links { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
