using System.Collections.Generic;
using Infrastructure.Models;

namespace Cooking.Readers
{
    public interface IDataReader
    {
        List<RecipeModel> Read(string path);
    }
}