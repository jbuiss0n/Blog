using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jbuisson.Blog.Data.Entities
{
    public abstract class Entity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Entity()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
