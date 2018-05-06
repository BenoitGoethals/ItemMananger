using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemMananger
{
   public class Consumer
    {
       
        public Guid IDGUID { get; private set; } = Guid.NewGuid();

        private ConcurrentBag<Item> concurrentBag = new ConcurrentBag<Item>();

        public ItemManager itemManager { get; set; }


        public void Start()
        {
            Consume();
        }

        public void Consume()
        {
            while(true)
            {
                Item item = itemManager.GetItem();
                if (item == null) break;
                concurrentBag.Add(item);
                Task.Delay(TimeSpan.FromMilliseconds(10000));
            }
        }


        public List<Item> GetAllItems()
        {
            return concurrentBag.ToList<Item>();
        }


    }
}
