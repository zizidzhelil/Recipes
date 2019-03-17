using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Infrastructure.Models;

namespace Cooking.Readers.Implementation
{
    public class DataReader : IDataReader
    {
        List<RecipeModel> IDataReader.Read(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<RecipeModel>>(json);
            }
        }
    }
}