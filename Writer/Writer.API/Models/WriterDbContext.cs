using Microsoft.EntityFrameworkCore;

namespace Writer.API.Models
{
	public class WriterDbContext : DbContext
	{

		public DbSet<Writer> Writer { get; set; }
		public WriterDbContext(DbContextOptions<WriterDbContext> options) : base(options) 
		{
		}

		
		

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Writer>().ToTable("Writer");
		}
	}
}
