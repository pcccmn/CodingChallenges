using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class ShortestPath
    {
        private List<Dictionary<string, string>> edges = new List<Dictionary<string, string>>()
        {
            new Dictionary<string, string>{{ "w","x" }},
            new Dictionary<string, string>{{ "x","y" }},
            new Dictionary<string, string>{{ "z","y" }},
            new Dictionary<string, string>{{ "z","v" }},
            new Dictionary<string, string>{{ "w","v" }},
        };

        private Dictionary<string, HashSet<string>> graph = new Dictionary<string, HashSet<string>>();

        private Dictionary<string, int> nodeCost = new Dictionary<string, int>();
        private HashSet<string> visited = new HashSet<string>();

        public ShortestPath()
        {
            foreach (var edge in edges)
            {
                var e = edge.ElementAt(0);

                if (!graph.ContainsKey(e.Key))
                    graph[e.Key] = new HashSet<string>();
                if (!graph.ContainsKey(e.Value))
                    graph[e.Value] = new HashSet<string>();

                graph[e.Key].Add(e.Value);
                graph[e.Value].Add(e.Key);
            }

            Bfs();
        }

        private void Bfs()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("w");
            visited.Add("w");
            nodeCost["w"] = 0; 

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var neighbor in graph[node])
                {
                    if (visited.Contains(neighbor))
                        continue;

                    visited.Add(neighbor);

                    if (!nodeCost.ContainsKey(neighbor))
                        nodeCost[neighbor] = nodeCost[node];

                    nodeCost[neighbor] += 1;

                    if (neighbor == "z")
                    {
                        Console.WriteLine("shortest distance is = " + nodeCost[neighbor]);
                        return;
                    }

                    queue.Enqueue(neighbor);
                }
            }
            
            
        }

    }
}
