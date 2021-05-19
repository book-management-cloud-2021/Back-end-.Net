using BookManagement.Models;
using BookManagement.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Controllers
{
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly BookManagementContext _context;

        public CategoriesController(BookManagementContext context)
        {
            _context = context;
        }
/*
        [HttpGet]
        [Route("api/Categories/SearchCategories")]
        public ActionResult SearchCategories()
        {
            var categoriess = _context.Categories
                .Where(c => c.IsActived == true)
                .Select(c => new CategoryViewModel
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                }).ToList();

            if (categoriess.Any())
                return Ok(categoriess);

            return NotFound("No have any categoriess!");
        }*/

        [HttpPost]
        [Route("api/Categories/CreateCategory")]
        public ActionResult CreateCategory(string categoryName)
        {
            var existedCategory = _context.Categories
                .Where(o => o.CategoryName.ToLower().Equals(categoryName.ToLower()));

            if (!existedCategory.Any())
            {
                _context.Categories.Add(new Category
                {
                    CategoryId = Guid.NewGuid(),
                    CategoryName = categoryName,
                    IsActived = true
                });

                _context.SaveChanges();
            }
            else
            {
                var category = existedCategory.Select(c => new Category
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    IsActived = true
                }).FirstOrDefault();

                _context.Update(category);

                _context.SaveChanges();
            }
            return Ok("Created a new categories successfully !");
        }
    }
}
