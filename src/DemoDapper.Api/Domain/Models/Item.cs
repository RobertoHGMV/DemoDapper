using System;

namespace DemoDapper.Api.Domain.Models
{
    public class Item
    {
        public Item(string title, bool done, DateTime date)
        {
            Title = title;
            Done = done;
            Date = date;
        }

        protected Item() { }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }
    }
}