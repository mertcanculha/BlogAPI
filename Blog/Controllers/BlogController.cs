using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogAPI;
using BlogAPI.Models;
using System.Net;

namespace BlogAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly BlogContext _context;

        public BlogController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/Blog
        [HttpGet]
        public ActionResult<IEnumerable<BlogItem>> GetBlogItems()
        {
            return Ok(_context.BlogItems.ToList());
        }

        // GET: api/Blog/5
        [HttpGet("{id}")]
        public ActionResult<BlogItem> GetBlogItem(int id)
        {
            var blogItem = _context.BlogItems.Find(id);

            if (blogItem == null)
            {
                return NotFound();
            }

            return Ok(blogItem);
        }

        // POST: api/Blog -- blog itemi ekleme
        [HttpPost]
        public ActionResult AddBlogItem(BlogItem blogItem)
        {
            _context.BlogItems.Add(blogItem);
            _context.SaveChanges();

            return Ok();
        }
        [HttpPost("updateblogitem")]
        public ActionResult UpdateBlogItem(BlogItem blogItem)
        {
            var existingBlogItem = _context.BlogItems.Find(blogItem.Id);
            existingBlogItem.Yazi = blogItem.Yazi;

            _context.Update(existingBlogItem);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE: api/Blog/5
        [HttpDelete("{id}")]
        public ActionResult DeleteBlogItem(int id)
        {
            var blogItem = _context.BlogItems.Find(id);
            if (blogItem == null)
            {
                return NotFound();
            }

            _context.BlogItems.Remove(blogItem);
            _context.SaveChanges();

            return Ok();
        }
    }
}
