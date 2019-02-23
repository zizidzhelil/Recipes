using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class RecipeIngredientConfig : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.HasKey(x => new { x.RecipeId, x.IngredientId });

            builder.Property(s => s.RecipeId)
               .HasColumnName("recipe_id");

            builder.Property(s => s.IngredientId)
              .HasColumnName("ingredient_id");
        }
    }
}
