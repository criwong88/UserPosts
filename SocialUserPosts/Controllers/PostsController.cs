using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialUserPosts.Models;

namespace SocialUserPosts.Controllers
{
    [Produces("application/json")]
    [Route("api/User/{UserId}/Posts")]
    public class PostsController : Controller
    {
        private readonly AppDBContext context;
        public PostsController(AppDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Posts> GetPosts(int UserId)
        {
            return context.Posts.Where(x => x.UserId == UserId).ToList();
        }

        [HttpGet("{id}", Name = "PostsCreado")]
        public IActionResult GetPostsById(int id)
        {
            var posts = context.Posts.FirstOrDefault(x => x.id == id);

            if (posts == null)
            {
                return NotFound();
            }

            return Ok(posts);
        }

        [HttpPost]
        public IActionResult PostPosts([FromBody] Posts posts, int UserId)
        {
            posts.UserId = UserId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Posts.Add(posts);
            context.SaveChanges();
            return new CreatedAtRouteResult("PostsCreado", new { id = posts.id,desc = posts.Description, idUser = UserId });
            
        }

        [HttpPut("{id}")]
        public IActionResult UdatetPosts([FromBody] Posts posts, int id)
        {

            if (posts.id != id)
            {
                return BadRequest();
            }

            context.Entry(posts).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletetPosts(int id)
        {
            var posts = context.Posts.FirstOrDefault(x => x.id == id);

            if (posts == null)
            {
                return NotFound();
            }

            context.Posts.Remove(posts);
            context.SaveChanges();
            return Ok(posts);
        }
    }
}
