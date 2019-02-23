﻿using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IRecipeService
    {
        Task<List<RecipeModel>> GetRecipesAsync(string recipeName);
    }
}
