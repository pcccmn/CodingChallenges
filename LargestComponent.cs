using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class LargestComponents
    {
        private Dictionary<int, int[]> graph = new Dictionary<int, int[]>();
        private HashSet<int> visited = new HashSet<int>();

        public LargestComponents()
        {
            graph[0] = new int[] { 8, 1, 5 };
            graph[1] = new int[] { 0 };
            graph[5] = new int[] { 0, 8 };
            graph[8] = new int[] { 0, 5 };
            graph[2] = new int[] { 3, 4 };
            graph[3] = new int[] { 2, 4 };
            graph[4] = new int[] { 3, 2 };

            Dfs();
        }

        private void Dfs()
        {
            int count = 0;

            foreach (var kvp in graph)
            {
                var value = Recursion(kvp.Key);

                if (value > count)
                    count = value;
            }

            Console.WriteLine(count);
        }

        private int Recursion(int key)
        {
            if (visited.Contains(key))
                return 0;

            visited.Add(key);

            int count = 1;

            foreach (var e in graph[key])
                count += Recursion(e);

            return count;
        }
    }
}
