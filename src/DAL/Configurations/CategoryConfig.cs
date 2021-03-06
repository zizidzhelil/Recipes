﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(s => s.Id)
                .HasColumnName("id");

            builder.Property(s => s.Name)
                .HasColumnName("name")
                .HasMaxLength(200);

            builder.HasMany(s => s.Recipes)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.CategoryId);
        }
    }
}
