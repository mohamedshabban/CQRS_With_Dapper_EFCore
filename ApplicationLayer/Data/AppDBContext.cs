using DomainLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApplicationLayer.Data
{
	public class AppDBContext : DbContext
	{
		private readonly IConfiguration _configuration;

		public AppDBContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var connectionString = _configuration.GetConnectionString("DefaultConnection");
				optionsBuilder.UseSqlServer(connectionString);
			}
		}
	}
}
