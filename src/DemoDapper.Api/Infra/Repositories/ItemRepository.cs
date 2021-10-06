using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DemoDapper.Api.Domain.Models;
using DemoDapper.Api.Domain.Repositories;
using DemoDapper.Api.Infra.Connections;

namespace DemoDapper.Api.Infra.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly DemoDapperContext _context;

        public ItemRepository(DemoDapperContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            using (var conn = _context.Connection)
            {
                 var query = "SELECT * FROM public.item";
                 var items = (await conn.QueryAsync<Item>(sql: query)).ToList();
                 return items;
            }
        }

        public async Task<Item> GetAsync(int id)
        {
            using (var conn = _context.Connection)
            {
                 var query = "SELECT * FROM public.item WHERE id=@id;";
                 var item = await conn.QueryFirstOrDefaultAsync<Item>(sql: query, param: new { id });
                 return item;
            }
        }

        public async Task<ItemResult> GetItemResultAsync()
        {
            using (var conn = _context.Connection)
            {
                 var query = @"SELECT cast(count(*) as int) FROM public.item; SELECT * FROM public.item;";

                 var reader = await conn.QueryMultipleAsync(sql: query);
                 
                 return new ItemResult
                 {
                     Count = (await reader.ReadAsync<int>()).FirstOrDefault(),
                     Items = (await reader.ReadAsync<Item>()).ToList()
                 };
            }
        }

        public async Task<int> AddAsync(Item item)
        {
            using (var conn = _context.Connection)
            {
                 var command = "INSERT INTO public.item (title, done, \"date\") VALUES (@title, @done, @date);";
                 return await conn.ExecuteAsync(sql: command, param: item);
            }
        }

        public async Task<int> UpdateAsync(int id, Item item)
        {
            using (var conn = _context.Connection)
            {
                 var command = "UPDATE public.item SET title=@title, done=@done, \"date\"=@date WHERE id=@id;";
                 return await conn.ExecuteAsync(sql: command, param: new { item.Title, item.Done, item.Date, id });
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = _context.Connection)
            {
                 var command = "DELETE FROM public.item WHERE id=@id;";
                 return await conn.ExecuteAsync(sql: command, param: new { id });
            }
        }
    }
}