using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Persistance.Configuration
{
    class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(a => a.Books)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId);
        }
    }
}
