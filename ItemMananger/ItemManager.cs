using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemMananger
{
    public sealed class ItemManager
    {
        Object o=new Object();
        private ConcurrentStack<Item> concurrentStackItems = new ConcurrentStack<Item>();


        public void AddItem(Item item)
        {
            concurrentStackItems.Push(item);
        }

        internal int Count()
        {  lock (o)
            {
            return concurrentStackItems.Count;
        }
        }

        public Item GetItem()
        {
           
            concurrentStackItems.TryPop(out Item item);
            return item;
                
        }


        public List<Item> GetItems()
        {
          
                 return concurrentStackItems.ToList();
           
         
        }

    }
}
