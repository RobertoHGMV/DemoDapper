using System.Collections.Generic;

namespace DemoDapper.Api.Domain.Models
{
    public class ItemResult
    {
        public int Count { get; set; }
        public IList<Item> Items { get; set; }
    }
}