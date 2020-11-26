using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shophang.Models;
using shophang.Data;
using Microsoft.AspNetCore.Authorization;
using shophang.Areas.AdminCP.DTOs;
using AutoMapper;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace shophang.Areas.AdminCP.Controllers
{
    [Area(nameof(AdminCP))]
    [Route("AdminCP/Categories")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CategoriesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> model = _context.Categories.AsEnumerable();
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
            _context.Categories.Add(category);
            _context.SaveChanges();

            // Chuyển hướng để hiển thị danh sách sau khi thêm
            return RedirectToAction(nameof(Index));
        }
        // GET: Categories/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            UpdateCategoryDTO CategoryDTO = _mapper.Map<UpdateCategoryDTO>(category);
            return View(CategoryDTO);
        }
        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit/{id}")]
        
        public async Task<IActionResult> Edit(int id, UpdateCategoryDTO CategoryDTO)
        {
            if (id != CategoryDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Category postCategory = _context.Categories.FirstOrDefault(pc => pc.Id == id);
                    Category CategoryToUpdate = _mapper.Map<UpdateCategoryDTO, Category>(CategoryDTO, postCategory);
                    CategoryToUpdate.CategoryName = CategoryDTO.CategoryName.Trim();
                    _context.Update(CategoryToUpdate);
                    var result = await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(CategoryDTO.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(CategoryDTO);
        }
        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
