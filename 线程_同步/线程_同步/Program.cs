using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 线程_同步
{
    class Program
    {
        static void Main(string[] args)
        {
            //var task = Task.Factory.StartNew(() => {
            //    for (int i = 0; i < 500; i++)
            //    {
            //        Console.WriteLine(i);
            //    }
            //    return 1;
            //});

            //var task = new Task<int>(() =>
            //{
            //    for (int i = 0; i < 500; i++)
            //    {
            //        Console.WriteLine(i);
            //    }

            //    return 1;
            //});
            //task.Start();

            //Console.WriteLine(task.Result);

            

            try
            {
                var task = Task.Factory.StartNew(() => { throw new ApplicationException("Error!!!"); });
                task.Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.Read();
            }


        }
    }
}
