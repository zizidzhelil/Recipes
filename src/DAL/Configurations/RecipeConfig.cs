using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations
{
    public class RecipeConfig : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(s => s.Id)
                .HasColumnName("id");

            builder.Property(s => s.Name)
                .HasColumnName("name")
                .HasMaxLength(50);

            builder.Property(s => s.Instructions)
                .HasColumnName("instruction")
                .HasMaxLength(2000);

            builder.Property(s => s.Description)
                .HasColumnName("description")
                .HasMaxLength(1000);

            builder.Property(s => s.PreparationTime)
                .HasColumnName("preparation_time");

            builder.Property(s => s.NumberOfServings)
                .HasColumnName("number_of_servings");

            builder.Property(s => s.Calories)
                .HasColumnName("calories");
        }
    }
}