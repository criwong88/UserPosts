using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialUserPosts.Models
{
    public class User
    {
        public User()
        {
            UserPosts = new List<Posts>();
        }

        public int id { get; set; }

        [StringLength(30),Required]
        public string Name { get; set; }

        [StringLength(50), Required, EmailAddress]
        public string Email { get; set; }

        [StringLength(10), Required]
        public string Phone { get; set; }

        [StringLength(100), Required]
        public string Pass { get; set; }
        public string CripKey { get; set; }

        public List<Posts> UserPosts { get; set; }

    }
}
