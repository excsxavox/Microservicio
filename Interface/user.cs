using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Interface
{
    public interface user
    {
        public string Username { get; set; }
        public int PendingItemsCount { get; set; }
        public int PriorityItemsCount { get; set; }
        public int CompletedItemsCount { get; set; }
        public List<Item> Items { get; set; }
    }
}