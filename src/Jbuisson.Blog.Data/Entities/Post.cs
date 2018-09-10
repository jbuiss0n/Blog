using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jbuisson.Blog.Data.Entities
{
    public class Post : Entity
    {
        [Required]
        public int Id_User { get; set; }

        public int? Id_LastComment { get; set; }

        [Required]
        public bool IsPublished { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string CanonicalTitle { get; set; }

        [Required]
        public string Preview { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int ViewsCount { get; set; }

        [Required]
        public int CommentsCount { get; set; }

        public DateTime? PublishedAt { get; set; }

        public DateTime? LastCommentedAt { get; set; }

        public User User { get; set; }

        public Comment LastComment { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
