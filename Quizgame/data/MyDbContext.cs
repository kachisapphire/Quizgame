using Microsoft.EntityFrameworkCore;
using Quizgame.Entities;

namespace Quizgame.data
{
	public class MyDbContext:DbContext
	{
		public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
		{

		}
		public DbSet<Quiz> quizgames { get; set; }
		public DbSet<QuizOption> quizoptions { get; set; }
		/*protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Quiz>()
				.HasMany(q => q.Options)
				.WithOne(o => o.Quiz)
				.HasForeignKey(o => o.QuizId);

			base.OnModelCreating(modelBuilder);
		}*/
	}
}
