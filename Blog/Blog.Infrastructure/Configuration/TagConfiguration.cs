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
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder
                .HasMany(x => x.PostTags)
                .WithOne(x => x.Tag);

            builder
                .HasData(
                new Tag{
                    Id = 1,
                    Title = "iOS"
                     },
                new Tag
                {
                    Id = 2,
                    Title = "Android"
                },
                new Tag
                {
                    Id = 3,
                    Title = "Trends"
                },
                new Tag
                {
                    Id = 4,
                    Title = "innovation"
                },
                new Tag
                {
                    Id = 5,
                    Title = "AR"
                },
                new Tag
                {
                    Id = 6,
                    Title = "Gazzda"
                }

                );

        }
    }
}
