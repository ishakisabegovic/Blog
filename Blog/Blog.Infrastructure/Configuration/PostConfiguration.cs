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
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .HasMany(x => x.PostTags)
                .WithOne(x => x.Post);

            builder
                .HasMany(x => x.Comments)
                .WithOne(x => x.Post);

            builder.HasData
                (
                new Post
                {
                    Id = 1,
                    Title = "Augmented Reality iOS Application",
                    Slug = "augmented-reality-ios-application",
                    Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                    Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                    
                },
                new Post
                {
                    Id = 2,
                    Title = "Augmented Reality iOS Application 2",
                    Slug = "augmented-reality-ios-application-2",
                    Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                    Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                }
                );
        }
    }
}
