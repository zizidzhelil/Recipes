using Core.Entities;
using DAL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
   public class RecipeContext : DbContext
   {
      private readonly string connectionString;

      public RecipeContext(string connectionString)
      {
         this.connectionString = connectionString;

         Database.EnsureCreated();
      }

      public DbSet<Category> Categories { get; set; }

      public DbSet<Ingredient> Ingredients { get; set; }

      public DbSet<Measurement> Measurements { get; set; }

      public DbSet<Recipe> Recipes { get; set; }

      public DbSet<RecipeIngredient> RecipesIngredients { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseSqlite(connectionString);
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         // TODO: Make this for all classes and all properties inside them.
         modelBuilder.ApplyConfiguration(new CategoryConfig());

         // TODO: Seed the nomenclatures in the database.
         modelBuilder.Entity<Category>().HasData(
            new Category() { Id = 1, Name = "Soup" },
            new Category() { Id = 2, Name = "Main" });
      }
   }
}
