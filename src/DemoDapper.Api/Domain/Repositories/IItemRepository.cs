using System.Collections.Generic;
using System.Threading.Tasks;
using DemoDapper.Api.Domain.Models;

namespace DemoDapper.Api.Domain.Repositories
{
    public interface IItemRepository
    {
         Task<List<Item>> GetAllAsync();
         Task<Item> GetAsync(int id);
         Task<ItemResult> GetItemResultAsync();
         Task<int> AddAsync(Item item);
         Task<int> UpdateAsync(int id, Item item);
         Task<int> DeleteAsync(int id);
    }
}