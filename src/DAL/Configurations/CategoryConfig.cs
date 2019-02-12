using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
   public class CategoryConfig : IEntityTypeConfiguration<Category>
   {
      public void Configure(EntityTypeBuilder<Category> builder)
      {
         builder.HasKey(x => x.Id);
      }
   }
}
