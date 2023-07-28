using System;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore;

namespace WebApi.Extensions
{
	//Burada program.cs içinde yapacağımız olan konfigürasyonları yazıyoruz.
	//Bu tarz konfigürasyonların yazıldığı classlar static olmak zorunda ve içerik ise static olmalı. 
	public static class ServicesExtensions
	{
		public static void ConfigureSqlContext(this IServiceCollection services,IConfiguration configuration)
		=> services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("sqlConnection")));
        
	}
}

