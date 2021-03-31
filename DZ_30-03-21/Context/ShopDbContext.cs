using DZ_30_03_21.Models;
using Microsoft.EntityFrameworkCore;

namespace DZ_30_03_21.Context
{

	public class ShopDbContext : DbContext
	{
		public ShopDbContext(DbContextOptions options) : base(options)
		{
		}
		protected ShopDbContext()
		{
		}
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories{ get; set; }

	}
}