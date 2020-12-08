using System.Collections.Generic;
using System.Threading.Tasks;
using MiniURL.Models;
namespace MiniURL
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Item>> GetItemsAsync(string query);
        Task<Item> GetItemAsync(string id);
        Task AddItemAsync(Item item);
        Task DeleteItemAsync(string id);
    }
}