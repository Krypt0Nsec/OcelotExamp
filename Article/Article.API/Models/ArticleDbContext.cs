using Microsoft.EntityFrameworkCore;

namespace Article.API.Models
{
	public class ArticleDbContext : DbContext
	{
		public DbSet<Article> Article { get; set; }
		public ArticleDbContext(DbContextOptions<ArticleDbContext> options) : base(options)
		{
		}




		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Article>().ToTable("Article");
		}

		
	}
}
