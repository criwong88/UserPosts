using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SocialUserPosts.Models;

namespace SocialUserPosts.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {

        private readonly AppDBContext context;
        public UserController(AppDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return context.User.ToList();
        }

        [HttpGet("{id}", Name = "UsuarioCreado")]
        public IActionResult GetUsersById(int id)
        {
            var user = context.User.Include(x => x.UserPosts).FirstOrDefault(x => x.id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                context.User.Add(user);
                context.SaveChanges();
                return new CreatedAtRouteResult("UsuarioCreado", new { id = user.id });
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UdatetUser([FromBody] User user, int id)
        {

            if (user.id != id)
            {
                return BadRequest();
            }

            context.Entry(User).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletetUser(int id)
        {
            var user = context.User.FirstOrDefault(x => x.id == id);

            if (user == null)
            {
                return NotFound();
            }

            context.User.Remove(user);
            context.SaveChanges();
            return Ok(user);
        }
    }
}
