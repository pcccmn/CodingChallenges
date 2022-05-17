using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms
{
    class App
    {
        private static CancellationTokenSource cts = new CancellationTokenSource();
        public static void Main(string [] args)
        {
            StartTimer();

            /* Start of Algo */
            //new HasPath();
            //new UndirectedPath();
            //new ConnectedComponents();
            //new LargestComponents();
            new ShortestPath();
            /* End of Algo */

            //new RoadsAndLibraries();
            StopTimer();
            Console.ReadKey(); // prevent instant exit upon program end
        }

        private static async void StartTimer()
        {
            int timeElapsed = 0;

            try
            {
                while (true)
                {
                    await Task.Delay(100);

                    if (cts.Token.IsCancellationRequested)
                        cts.Token.ThrowIfCancellationRequested();

                    timeElapsed += 100;
                }
            }
            catch (Exception)
            {
                
            }
            finally
            {
                cts.Dispose();
                cts = null;
                Console.WriteLine($"Algorithm took {timeElapsed / 1000}s to complete");
            }

        }
        private static void StopTimer() => cts?.Cancel();
    }

}
