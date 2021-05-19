using BookManagement.Entities;
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
    public class LanguagesController : ControllerBase
    {
        private readonly BookManagementContext _context;

        public LanguagesController(BookManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/Languages/SearchLanguages")]
        public ActionResult SearchLanguages()
        {
            var languages = _context.Languages
                .Where(l => l.IsActived == true)
                .Select(l => new LanguageViewModel
                {
                    LanguageId = l.LanguageId,
                    LanguageName = l.LanguageName
                }).ToList();

            if (languages.Any())
                return Ok(languages);

            return NotFound("No have any languages!");
        }

        [HttpPost]
        [Route("api/Languages/CreateLanguage")]
        public ActionResult CreateLanguage(string languageName)
        {
            var existedLanguage = _context.Languages
                .Where(o => o.LanguageName.ToLower().Equals(languageName.ToLower()));

            if (!existedLanguage.Any())
            {
                _context.Languages.Add(new Language
                {
                    LanguageName = Guid.NewGuid(),
                    LanguageId = languageName,
                    IsActived = true
                });

                _context.SaveChanges();
            }
            else
            {
                var language = existedLanguage.Select(c => new Language
                {
                    LanguageId = c.LanguageId,
                    LanguageName = c.LanguageName,
                    IsActived = true
                }).FirstOrDefault();

                _context.Update(language);

                _context.SaveChanges();
            }
            return Ok("Created a new language successfully !");
        }
    }
}
