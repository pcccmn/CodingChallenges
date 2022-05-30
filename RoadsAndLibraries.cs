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
        private static int q;
        private static int n;
        private static int m;
        private static long cLib;
        private static long cRoad;
        private static List<List<int>> cities = new List<List<int>>();

        private static Dictionary<int, List<int>> graphs = new Dictionary<int, List<int>>();
        private static bool[] visited;
        private static long totalCost = 0;

        public RoadsAndLibraries()
        {
            //ReadInputFromCode();
            ReadInputFromFile();
        }

        private static void ReadInputFromCode()
        {
            n = 6;
            m = 0;
            cLib = 2;
            cRoad = 5;
            cities.Add(new List<int> { 1, 3 });
            cities.Add(new List<int> { 3, 4 });
            cities.Add(new List<int> { 2, 4 });
            cities.Add(new List<int> { 1, 2 });
            cities.Add(new List<int> { 2, 3 });
            cities.Add(new List<int> { 5, 6 });
        }

        private static void ReadInputFromFile()
        {
            var queue = FileParser.Read("RoadsAndLibrariesIO/input-4.txt");

            q = int.Parse(queue.Dequeue()); // no use

            var isNewSet = false;

            while(queue.Count > 0)
            {
                var line = queue.Dequeue();

                var split = line.Split(' ');

                if (split.Length == 4)
                {
                    if (isNewSet)
                    {
                        Console.WriteLine(Calculate());
                        isNewSet = false;
                    }
                    cities.Clear();

                    n = int.Parse(split[0]);
                    m = int.Parse(split[1]);
                    cLib = int.Parse(split[2]);
                    cRoad = int.Parse(split[3]);
                }
                else if (split.Length == 2)
                {
                    isNewSet = true;

                    var x = int.Parse(split[0]);
                    var y = int.Parse(split[1]);

                    cities.Add(new List<int> { x, y });

                    if (queue.Count == 0)
                        Console.WriteLine(Calculate());
                }
            }
        }

        private static long Calculate()
        {
            totalCost = 0;
            graphs.Clear();

            foreach (var city in cities)
            {
                if (!graphs.ContainsKey(city[0]))
                    graphs[city[0]] = new List<int>();

                if (!graphs.ContainsKey(city[1]))
                    graphs[city[1]] = new List<int>();

                graphs[city[0]].Add(city[1]);
                graphs[city[1]].Add(city[0]);
            }

            for (int i = 1; i <= n; i++)
                if (!graphs.ContainsKey(i))
                    graphs[i] = new List<int>();

            visited = new bool[graphs.Count+1];

            for (int i = 1; i <= graphs.Count; i++)
                visited[i] = false;

            return Calculate2();
        }

        private static long Calculate2()
        {
            if (cLib <= cRoad)
                return n * cLib;

            for (int i = 1; i <= graphs.Count; i++)
            {
                if (Recursion(i))
                {
                    //Console.WriteLine($"building library at city {i}");
                    totalCost += cLib;
                }
            }

            return totalCost;
        }


        private static bool Recursion(int node)
        {
            if (visited[node])
                return false;

            visited[node] = true;

            foreach (var neighbor in graphs[node])
            {
                if (!visited[neighbor])
                {
                    //Console.WriteLine($"building road connecting to {neighbor}");
                    totalCost += cRoad;
                    Recursion(neighbor);
                }
            }

            return true;
        }

        
    }
}
