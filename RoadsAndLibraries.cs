using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class RoadsAndLibraries
    {
        public readonly Dictionary<int, bool> cityHasAccessToLibrary = new Dictionary<int, bool>();
        public readonly Dictionary<int, List<int>> cityLinks = new Dictionary<int, List<int>>();
        private bool isStartTimer;
        private float timeElapsed; // ms

        public RoadsAndLibraries()
        {
            isStartTimer = true;
            StartTimer();

            List<string> list = File.ReadLines("test-0.txt").ToList();

            int q = int.Parse(list[0]);
            int n = -1;
            int m = -1;
            int c_lib = -1;
            int c_road = -1;
            List<List<int>> cities = new List<List<int>>();

            list.RemoveAt(0); // remove q;

            for (int i = 0; i < q; i++)
            {
                var arr = list[0].Split(' ');

                n = int.Parse(arr[0]);
                c_lib = int.Parse(arr[2]);
                c_road = int.Parse(arr[3]);

                list.RemoveAt(0); // remove 4 digits

                int maxRange = 0;
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[(int)j].Split(' ').Length == 4)
                    {
                        maxRange = j;
                        break;
                    }

                    var arr2 = list[j].Split(' ');
                    cities.Add(new List<int> { int.Parse(arr2[0]), int.Parse(arr2[1]) });
                }

                list.RemoveRange(0, maxRange);

                //Result.roadsAndLibraries(n, c_lib, c_road, cities);
                //Result.Bfs(n, cities);
                Solution();

                cities.Clear();
            }

            isStartTimer = false;
            Console.ReadKey();
        }

        private async void StartTimer()
        {
            while (isStartTimer)
            {
                await Task.Delay(100);
                timeElapsed += 100;
            }

            Console.WriteLine($"Algorithm took {timeElapsed / 1000} seconds to complete"); // converting to con
        }
        
        private void Solution()
        {
            Console.WriteLine("To do..");
        }
    }
}
