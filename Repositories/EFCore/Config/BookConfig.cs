using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                 new Book()
                 {
                     Id = 1,
                     Title = "Selam",
                     Price = 12
                 }, new Book()
                 {
                     Id = 2,
                     Title = "Selam2",
                     Price = 122
                 }, new Book()
                 {
                     Id = 3,
                     Title = "Selam3",
                     Price = 123
                 });
        }
    }
}

