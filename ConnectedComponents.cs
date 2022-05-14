using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class ConnectedComponents
    {
        private Dictionary<int, int[]> graph = new Dictionary<int, int[]>();
        private HashSet<int> visited = new HashSet<int>();

        public ConnectedComponents()
        {
            graph[3] = new int[] { };
            graph[4] = new int[] { 6 };
            graph[6] = new int[] { 4, 5, 7, 8 };
            graph[8] = new int[] { 6 };
            graph[7] = new int[] { 6 };
            graph[5] = new int[] { 6 };
            graph[1] = new int[] { 2 };
            graph[2] = new int[] { 1 };

            Dfs();
        }

        private void Dfs()
        {
            int count = 0;

            foreach (var item in graph)
                if (Recursive(item.Key))
                    count++;

            Console.WriteLine(count);
        }

        private bool Recursive(int key)
        {
            if (visited.Contains(key))
                return false;

            visited.Add(key);

            Console.WriteLine($"Traversing {key}");

            foreach (var item in graph[key])
                Recursive(item); // the return value here is irrelevant. Job is to mark nodes as visited

            return true;
        }
    }
}
