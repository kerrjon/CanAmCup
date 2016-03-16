using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CanAmCup.Models;

namespace CanAmCup.DAL
{
  public class CanAmContext : DbContext
  {
    public CanAmContext() : base("CanAmContext")
    {
      Database.SetInitializer(new SeedInitializer());
    }

    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<MatchPlayer> MatchPlayers { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Hole> Holes { get; set; }
    public DbSet<Score> Scores { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {

      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

      modelBuilder.Entity<Score>().HasKey(x => new { x.HoleId, x.MatchId });
      modelBuilder.Entity<Score>()
               .HasRequired(t => t.Holes)
               .WithMany()
               .HasForeignKey(c => c.HoleId)
               .WillCascadeOnDelete(false);

      modelBuilder.Entity<Score>()
               .HasRequired(t => t.Matches)
               .WithMany()
               .HasForeignKey(c => c.MatchId)
               .WillCascadeOnDelete(false);

      modelBuilder.Entity<MatchPlayer>().HasKey(x => new { x.MatchId, x.PlayerId });
      modelBuilder.Entity<MatchPlayer>()
               .HasRequired(t => t.Matches)
               .WithMany()
               .HasForeignKey(c => c.MatchId)
               .WillCascadeOnDelete(false);

      modelBuilder.Entity<MatchPlayer>()
               .HasRequired(t => t.Players)
               .WithMany()
               .HasForeignKey(c => c.PlayerId)
               .WillCascadeOnDelete(false);


      //modelBuilder.Entity<MatchPlayer>().HasKey(x => new { x.MatchId, x.PlayerId });

      //  modelBuilder.Entity<Match>()
      //           .HasRequired(a => a.Course)
      //           .WithMany()
      //           .HasForeignKey(u => u.CourseId);

      //  modelBuilder.Entity<Match>()
      //           .HasRequired(a => a.Tournament)
      //           .WithMany()
      //           .HasForeignKey(u => u.TournamentId);
      //}
    }
  }
}
