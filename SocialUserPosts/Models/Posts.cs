using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialUserPosts.Models
{
    public class Posts
    {
        public int id { get; set; }

        public string Tittle { get; set; }
        public string Description { get; set; }

        [ForeignKey("UserPosted")]
        public int UserId { get; set; }

        [JsonIgnore]
        public User UserPosted { get; set; }

        public DateTime DatePosted { get; set; }

        public int StatePosts { get; set; }
    }
}
