using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {

        private readonly RepositoryContext _context;
        private readonly ILogger<BookController> _logger;

        public BookController(RepositoryContext context, ILogger<BookController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllBook()
        {
            var books = _context.Books.ToList();

            return (Ok(books));
        }

        [HttpGet("{gelenid:int}")]
        public IActionResult GetSingleBook([FromRoute(Name = "gelenid")] int gelenid)
        {
            try
            {
                var Onebook = _context.Books.Where(id => id.Id == gelenid).SingleOrDefault();

                if (Onebook is null)
                {
                    return NotFound();
                    _logger.LogInformation("Bulunamadı !! ");
                }
                else
                {
                    return Ok(Onebook);
                    _logger.LogInformation("${gelenid} değeri yazdırıldı", gelenid);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                _logger.LogInformation(e.Message);

            }
        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                {
                    return BadRequest();
                }
                else
                {
                    _context.Books.Add(book);
                    _context.SaveChanges();
                    return StatusCode(201, book);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        [HttpPut("{gelenid:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "gelenid")] int gelenid, [FromBody] Book gelenbook)
        {

            try
            {

                var degisecek = _context.Books.Where(x => x.Id == gelenid).SingleOrDefault();

                if (gelenbook is null)
                {
                    return BadRequest();
                }

                if (degisecek is null)
                {
                    return NotFound();
                }

                if (degisecek.Id != gelenid)
                {
                    return BadRequest();
                }

                degisecek.Title = gelenbook.Title;
                degisecek.Price = gelenbook.Price;
                _context.SaveChanges();
                return Ok(degisecek);






            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        [HttpDelete("{removeid:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "removeid")] int removeid)
        {

            var result = _context.Books.Where(x => x.Id == removeid).SingleOrDefault();

            if (result is null) { return NotFound(); }


            else
            {
                _context.Books.Remove(result);
                _context.SaveChanges();
                return Ok(result);
            }
        }

    }
}

