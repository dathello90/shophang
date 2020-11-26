using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shophang.Areas.AdminCP.DTOs
{
    public class UpdateCategoryDTO
    {
        [Required(ErrorMessage = "Không tìm thấy ID cần sửa")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Chưa nhập tên chuyên mục")]
        [MaxLength(50, ErrorMessage = "Tên chuyên mục quá dài, tối đa 50 ký tự")]
        [Display(Name = "Tên chuyên mục")]
        public string CategoryName { get; set; }


        [MaxLength(255, ErrorMessage = "Mô tả ngắn quá dài, tối đa 255 ký tự")]
        [Display(Name = "Mô tả danh mục")]
        public string Description { get; set; }

        [Display(Name = "Hoạt động")]
        public bool Status { get; set; }
    }
}
