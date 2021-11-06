using HorseRacingBettingAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HorseRacingBettingAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<RaceBettorModel> RaceBettors { get; set; }
        public DbSet<RaceHorseModel> RaceHorses { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RaceHorseModel>()
                .HasMany(pl => pl.RaceBettors)
                .WithOne()
                .HasForeignKey(p => p.HorseId);
        }
    }
}
