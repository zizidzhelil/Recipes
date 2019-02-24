using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ICategoryService
    {
        Task<List<string>> GetAllCategoryNamesAsync();
    }
}