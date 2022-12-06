using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            
            builder.HasData(
                new Comment
                {
                    Id = 1,
                    Body = "Great post.",
                    PostId = 1
                },
                new Comment
                {
                    Id = 2,
                    Body = "Great post 2.",
                    PostId = 2
                }
                );
        }
    }
}
