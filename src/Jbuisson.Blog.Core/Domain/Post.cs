using System;
using System.Collections.Generic;
using System.Text;

namespace Jbuisson.Blog.Core.Domain
{
    public class Post : IDomain
    {
        public int Id { get; set; }

        public int? Id_LastComment { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string CanonicalTitle { get; set; }

        public string Preview { get; set; }

        public string Content { get; set; }

        public int ViewsCount { get; set; }

        public int CommentsCount { get; set; }

        public DateTime? PublishedAt { get; set; }

        public DateTime? LastCommentedAt { get; set; }

        public string LastCommentAuthor { get; set; }

        public ICollection<Post> Comments { get; set; }
    }
}
