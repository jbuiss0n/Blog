using System;
using System.Collections.Generic;
using System.Text;

namespace Jbuisson.Blog.Core.Domain
{
    public class Comment : IDomain
    {
        public int Id { get; set; }

        public int Id_Post { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
