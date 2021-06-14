using BookManagement.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Controllers
{
    [ApiController]
    public class HistoriesController : ControllerBase
    {
        private readonly BookManagementContext _context;

        public HistoriesController(BookManagementContext context)
        {
            _context = context;
        }

       /* [HttpGet]
        [Route("api/histories/search-histories")]
        public ActionResult SearchHistories()
        {
            var categoriess = _context.Histories
                .Select(c => new CategoryViewModel
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName
                }).ToList();

            if (categoriess.Any())
                return Ok(categoriess);

            return NotFound("No have any categoriess!");
        }*/
    }
}
