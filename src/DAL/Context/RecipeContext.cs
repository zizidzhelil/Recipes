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
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new IngredientConfig());
            modelBuilder.ApplyConfiguration(new MeasurementConfig());
            modelBuilder.ApplyConfiguration(new RecipeConfig());
            modelBuilder.ApplyConfiguration(new RecipeIngredientConfig());

            modelBuilder.Entity<Category>().HasData(
               new Category() { Id = 1, Name = "Soup" },
               new Category() { Id = 2, Name = "Main" },
               new Category() { Id = 3, Name = "Chicken" },
               new Category() { Id = 4, Name = "Cake" },
               new Category() { Id = 5, Name = "Pasta and Noodles" });

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient() { Id = 1, Name = "Milk" },
                new Ingredient() { Id = 2, Name = "Egg" },
                new Ingredient() { Id = 3, Name = "Sugar" },
                new Ingredient() { Id = 4, Name = "Apple" },
                new Ingredient() { Id = 5, Name = "Banana" },
                new Ingredient() { Id = 6, Name = "Water" },
                new Ingredient() { Id = 7, Name = "Garlic" },
                new Ingredient() { Id = 8, Name = "Bean" },
                new Ingredient() { Id = 9, Name = "Macaroni" },
                new Ingredient() { Id = 10, Name = "Butter" },
                new Ingredient() { Id = 11, Name = "White sugar" },
                new Ingredient() { Id = 12, Name = "Chocolate" },
                new Ingredient() { Id = 13, Name = "Chicken thighs" },
                new Ingredient() { Id = 14, Name = "Mayonnaise" },
                new Ingredient() { Id = 15, Name = "Sausage" },
                new Ingredient() { Id = 16, Name = "Peppers" },
                new Ingredient() { Id = 17, Name = "Potatoes" });

            modelBuilder.Entity<Measurement>().HasData(
                new Measurement() { Id = 1, Name = string.Empty },
                new Measurement() { Id = 2, Name = "Tablespoon" },
                new Measurement() { Id = 3, Name = "Pound" },
                new Measurement() { Id = 4, Name = "Clove" },
                new Measurement() { Id = 5, Name = "Cup" },
                new Measurement() { Id = 6, Name = "Teaspoon" });

            modelBuilder.Entity<Recipe>().HasData(
                new Recipe()
                {
                    Id = 1,
                    Name = "Refried Beans",
                    Instructions = "Place beans in a slow cooker and cover with 8 cups water; soak for 8 to 10 hours. Drain and rinse beans and return to slow cooker; top with 8 cups fresh water. Cook beans on Low for 8 to 10 hours.Drain.",
                    Description = "Delicious baked beans.",
                    CategoryId = 2,
                    NumberOfServings = 3,
                    PreparationTime = 16.15f,
                    Calories = 160
                },
                new Recipe()
                {
                    Id = 2,
                    Name = "Macaroni",
                    Instructions = "Preheat an oven to 350 degrees F (175 degrees C). Grease a 9x13 inch glass baking dish. Fill a large pot with lightly salted water and bring to a rolling boil over high heat.Once the water is boiling, stir in the macaroni, and return to a boil.",
                    Description = "Delicious macaroni casserole",
                    CategoryId = 5,
                    NumberOfServings = 12,
                    PreparationTime = 1.15f,
                    Calories = 286
                },
                new Recipe()
                {
                    Id = 3,
                    Name = "German Marble Cake",
                    Instructions = "Preheat oven to 175 degrees C. Grease and flour one 10 inch tube pan. In a large bowl, cream the butter with the sugar.Beat in the eggs, then the milk and almond extract. In another bowl, stir together the flour,baking powder and salt.Beat the flour mixture into the creamed mixture.Turn half of the batter into another bowl and stir in the cocoa and rum. Layer the light and dark batters by large spoonfuls and then swirl slightly with a knife.Bake the cake in at 350 degree F(175 degree C) for about 70 minutes, or until it tests done with a toothpick.Transfer to a rack to cool.Makes about 14 to 16 servings.",
                    Description = "This is a lovely cake with the taste of almond and chocolate.",
                    CategoryId = 4,
                    NumberOfServings = 14,
                    PreparationTime = 1.30f,
                    Calories = 346
                },
                new Recipe()
                {
                    Id = 4,
                    Name = "Too Much Chocolate Cake",
                    Instructions = "Preheat oven to 175 degrees C.In a large bowl, mix together the cake and pudding mixes, sour cream, oil, beaten eggs and water. Stir in the chocolate chips and pour batter into a well greased 12 cup bundt pan.Bake for 50 to 55 minutes, or until top is springy to the touch and a wooden toothpick inserted comes out clean. Cool cake thoroughly in pan at least an hour and a half before inverting onto a plate If desired, dust the cake with powdered sugar.",
                    Description = "This cake won me First Prize at the county fair last year. It is very chocolaty.",
                    CategoryId = 4,
                    NumberOfServings = 12,
                    PreparationTime = 0.50f,
                    Calories = 600
                },
                new Recipe()
                {
                    Id = 5,
                    Name = "Rusty Chicken Thighs",
                    Instructions = "Mash garlic to a paste with a mortar and pestle. Mix chile pepper sauce, maple syrup, soy sauce, mayonnaise, and rice vinegar into garlic until marinade is thoroughly combined.Transfer chicken thighs to a large flat container(such as a baking dish) and pour marinade over chicken; stir until chicken is coated.Cover dish with plastic wrap and refrigerate about 3 hours; if preferred, let stand about 30 minutes at room temperature. Unwrap dish and sprinkle with salt.Preheat charcoal grill to high heat.Place chicken thighs onto the hot grill with smooth sides down.Cook until chicken shows grill marks, about 3 minutes.Turn chicken over and cook until other side shows grill marks, about 5 minutes.Continue to cook, moving them occasionally and turning over every 2 minutes, until meat is no longer pink inside and the thighs are golden brown, 10 to 12 minutes.",
                    Description = "It's so perfect and juicy and flavorful. It's an overall gorgeous way to grill chicken.",
                    CategoryId = 3,
                    NumberOfServings = 8,
                    PreparationTime = 3.40f,
                    Calories = 194
                },
                new Recipe()
                {
                    Id = 6,
                    Name = "Chicken, Sausage, Peppers, and Potatoes",
                    Instructions = "Preheat oven to 450 degrees F (230 degrees C).Heat olive oil in a skillet over medium heat.Cook sausage links until browned and oil begins to render, about 3 minutes per side.While sausages are cooking, pierce them lightly here and there with the tip of a sharp knife so some fats and juices are released. Remove from heat and let cool slightly.When sausages are cool enough to handle, cut them into serving pieces,about 2 - inch slices.Transfer back to pan along with any accumulated juices from the cutting board.",
                    Description = "You'll need a large, heavy-duty roasting pan (or a couple of smaller ones) and a very hot oven for this delicious dish. ",
                    CategoryId = 3,
                    NumberOfServings = 10,
                    PreparationTime = 1.30f,
                    Calories = 664
                });

            modelBuilder.Entity<RecipeIngredient>().HasData(
                new RecipeIngredient()
                {
                    Id = 1,
                    RecipeId = 1,
                    IngredientId = 8,
                    Amount = 5,
                    MeasurementId = 3
                },
                new RecipeIngredient()
                {
                    Id = 1,
                    RecipeId = 1,
                    IngredientId = 3,
                    Amount = 1,
                    MeasurementId = 1
                },
                new RecipeIngredient()
                {
                    Id = 1,
                    RecipeId = 1,
                    IngredientId = 2,
                    Amount = 5,
                    MeasurementId = 4
                },
                new RecipeIngredient()
                {
                    Id = 2,
                    RecipeId = 2,
                    IngredientId = 9,
                    Amount = 1,
                    MeasurementId = 5
                },
                new RecipeIngredient()
                {
                    Id = 3,
                    RecipeId = 3,
                    IngredientId = 10,
                    Amount = 1,
                    MeasurementId = 5
                },
                new RecipeIngredient()
                {
                    Id = 3,
                    RecipeId = 2,
                    IngredientId = 1,
                    Amount = 1,
                    MeasurementId = 5
                },
                new RecipeIngredient()
                {
                    Id = 3,
                    RecipeId = 3,
                    IngredientId = 2,
                    Amount = 4,
                    MeasurementId = 1
                },
                new RecipeIngredient()
                {
                    Id = 3,
                    RecipeId = 3,
                    IngredientId = 11,
                    Amount = 1,
                    MeasurementId = 5
                },
                new RecipeIngredient()
                {
                    Id = 4,
                    RecipeId = 4,
                    IngredientId = 2,
                    Amount = 4,
                    MeasurementId = 1
                },
                new RecipeIngredient()
                {
                    Id = 4,
                    RecipeId = 4,
                    IngredientId = 12,
                    Amount = 2,
                    MeasurementId = 5
                },
                new RecipeIngredient()
                {
                    Id = 4,
                    RecipeId = 4,
                    IngredientId = 6,
                    Amount = 2,
                    MeasurementId = 5
                },
                new RecipeIngredient()
                {
                    Id = 5,
                    RecipeId = 5,
                    IngredientId = 7,
                    Amount = 2,
                    MeasurementId = 4
                },
                new RecipeIngredient()
                {
                    Id = 5,
                    RecipeId = 5,
                    IngredientId = 14,
                    Amount = 2,
                    MeasurementId = 2
                },
                new RecipeIngredient()
                {
                    Id = 5,
                    RecipeId = 5,
                    IngredientId = 13,
                    Amount = 2,
                    MeasurementId = 3
                },
                new RecipeIngredient()
                {
                    Id = 6,
                    RecipeId = 6,
                    IngredientId = 13,
                    Amount = 6,
                    MeasurementId = 1
                },
                new RecipeIngredient()
                {
                    Id = 6,
                    RecipeId = 6,
                    IngredientId = 15,
                    Amount = 4,
                    MeasurementId = 1
                },
                new RecipeIngredient()
                {
                    Id = 6,
                    RecipeId = 6,
                    IngredientId = 16,
                    Amount = 2,
                    MeasurementId = 1
                },
                 new RecipeIngredient()
                 {
                     Id = 6,
                     RecipeId = 6,
                     IngredientId = 17,
                     Amount = 5,
                     MeasurementId = 1
                 });
        }
    }
}