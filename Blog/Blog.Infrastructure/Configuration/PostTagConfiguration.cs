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
    public class PostTagConfiguration : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.HasData(
                new PostTag
                {
                    Id = 1,
                    PostId = 1,
                    TagId = 1
                },
                new PostTag
                {
                    Id = 2,
                    PostId = 1,
                    TagId = 2
                },
                new PostTag
                {
                    Id = 3,
                    PostId = 1,
                    TagId = 3
                },
                new PostTag
                {
                    Id = 4,
                    PostId = 2,
                    TagId = 6
                },
                new PostTag
                {
                    Id = 5,
                    PostId = 2,
                    TagId = 4
                }
                );
        }
    }
}
