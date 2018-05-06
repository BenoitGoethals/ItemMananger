using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemMananger
{
  public  class Producer
    {

        private int Count;

        public Producer(int count)
        {
            this.Count = count;
        }

        public ItemManager itemManager { private get; set; }


        public void Start()
        {
            PushItem();
        }

        public void PushItem()
        {
            for (int i = 0; i < Count; i++)
            {
                Item item = ItemFactory.GetInstance().CreateItem();
                itemManager.AddItem(item);
                Task.Delay(TimeSpan.FromMilliseconds(10000));

            }
         
        }



    }
}
