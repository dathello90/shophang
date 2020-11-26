using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shophang.Models;
using shophang.Data;

namespace shophang.Areas.AdminCP.Controllers
{
    [Area(nameof(AdminCP))]
    [Route("AdminCP/Categories")]
    public class CategoriesController : Controller
    {
        
        private ApplicationDbContext context;
        public CategoriesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        
        public IActionResult Index()
        {
            IEnumerable<Category> model = context.Categories.AsEnumerable();
            return View(model);
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(new Category { Status = true });
        }


        [HttpPost("Create")]
        public IActionResult Createnew(Category category)
        {
            // Nếu dữ liệu nhập vào không hợp lệ 
            if (!ModelState.IsValid)
                return View(nameof(Create));

            // Nếu OK, thêm vào CSDL
            context.Categories.Add(category);
            context.SaveChanges();

            // Chuyển hướng để hiển thị danh sách sau khi thêm
            return RedirectToAction(nameof(Index));
        }
    }
}
