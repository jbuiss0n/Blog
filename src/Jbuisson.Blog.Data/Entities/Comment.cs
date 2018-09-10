using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jbuisson.Blog.Data.Entities
{
    public class Comment : Entity
    {
        [Required]
        public int Id_Post { get; set; }

        [Required]
        public int Id_User { get; set; }

        public bool? IsVisible { get; set; }

        [Required]
        public string Content { get; set; }

        public Post Post { get; set; }

        public User User { get; set; }
    }
}
