using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExamApp
{
    class Program
    {
        private static vData vData = new vData();
        private static AutoResetEvent vEvent = new AutoResetEvent(true);

        static void Main(string[] args)
        {
            vData.vInputString = Console.ReadLine();
            Task.Run(() => Print());

            while (true)
            {
                if (Console.ReadLine() == "")
                {
                    vEvent.WaitOne();
                    vData.vInputString = Console.ReadLine();
                    vEvent.Set();
                }
            }
        }

        private static async Task Print()
        {
            while (true)
            {
                vEvent.WaitOne();
                Console.WriteLine(vData.vInputString);
                vEvent.Set();
                await Task.Delay(1000);
            }
        }
    }
}
