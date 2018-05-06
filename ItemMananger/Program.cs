using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ItemMananger
{
    class Program
    {
        static void Main(string[] args)
        {

            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            ItemManager itemManager = new ItemManager();
            //Producer producer = new Producer();

            List<Task<Producer>> taksProd = new List<Task<Producer>>();
            List<Task<Consumer>> taksCons = new List<Task<Consumer>>();
            for (int i = 0; i < 100; i++)
            {
                taksProd.Add(new Task<Producer>(() =>
                {
                    Producer producer = new Producer(20000) { itemManager = itemManager };
                    producer.Start();
                  
                    return producer;
                }));

            }

            for (int i = 0; i < 10; i++)
            {
                taksCons.Add(new Task<Consumer>(() =>
                {
                    Consumer consumer = new Consumer() { itemManager = itemManager };
                    consumer.Start();
                   

                    return consumer;
                }));

            }
            Task watch = new Task(() => {

                Watcher watcher = new Watcher(itemManager, token);
                watcher.PrintCount();
            });

            watch.Start();
          
            foreach (var task in taksProd)
            {
                task.Start();
                Task.Delay(25000);
            }
            foreach (var task in taksCons)
            {
                task.Start();
                //Task.Delay(2500);
            }

         //   Task.WaitAll(taksProd.ToArray());

           Task.WaitAll(taksCons.ToArray());

            source.Cancel(false);

            Console.WriteLine("Consumers");
            int tot = 0;
            foreach (var item in taksCons)
            {
             
                Console.WriteLine("Comsumer " +item.Result.IDGUID+ " -> count" + item.Result.GetAllItems().Count());
              
                tot += item.Result.GetAllItems().Count();
            }
          
            Console.WriteLine("totaal : "+tot);


            Console.WriteLine("ItemManger");
            itemManager.GetItems().ForEach(c => Console.WriteLine(c.Nbr));
            Console.ReadLine();

        }
    }
}
