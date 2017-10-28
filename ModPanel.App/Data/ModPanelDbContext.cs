namespace ModPanel.App.Data
{
   using EntityModels;
   using Microsoft.EntityFrameworkCore;

   public class ModPanelDbContext : DbContext
   {
      public DbSet<User> Users { get; set; }

      public DbSet<Post> Posts { get; set; }


      protected override void OnConfiguring(DbContextOptionsBuilder builder)
      {
         builder
            .UseSqlServer(@"Server=.\SQL;Database=MoPDb;Integrated security=True;");
      }

      protected override void OnModelCreating(ModelBuilder builder)
      {
         
     builder
            .Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

         builder
             .Entity<User>()
             .HasMany(u => u.Posts)
             .WithOne(p => p.User)
             .HasForeignKey(p => p.UserId);
      }

   }
}
