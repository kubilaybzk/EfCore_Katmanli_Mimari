using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore.Config;

namespace Repositories.EFCore
{
	
        public class RepositoryContext : DbContext
        {
            public DbSet<Book> Books { get; set; }

            /* 
             Modelimizi oluşturduk ve Veri tabanımızı bir üst sayfada tanımladık şimdi veri tabanı ile bağlantımızı yapmamız gerkiyor burada yapmamoz gereken işlem burada tanımladığımız bu RepositoryContext classımızın veri tabanı ile bağlantısını sağlamak.

                Bunu constroctor üzerinden yapacağız 
             */

            public RepositoryContext(DbContextOptions options) : base(options) { }

            /* 
             Şimdi burada amacımız ben sana connection string vereceğim sen bu connection stringi kullanarak,
                burada sql bağlantısını base olan class'a yolla yani DbContext'e yolla  ve orada işlemleri yap.


                Şimdi appsettings içine connection string dosyamızı yazmamız gerekiyor.

                Daha sonra bunu bizim program.cs içinde yapılandırma ayaları yapmamız gerekiyor.
                    Burada 
            */

            protected override void OnModelCreating(ModelBuilder builder)
            {
                builder.ApplyConfiguration(new BookConfig());
            }
        }
    
}

