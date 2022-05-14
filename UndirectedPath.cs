using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class UndirectedPath
    {
        private List<string[]> pairs = new List<string[]> {
            new string[]{ "i", "j" },
            new string[]{ "k", "i" },
            new string[]{ "m", "k" },
            new string[]{ "k", "l" },
            new string[]{ "o", "n" },
        };
        private Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        private string dst;
        private HashSet<string> visited = new HashSet<string>();

        public UndirectedPath()
        {
            foreach (var pair in pairs)
            {
                var a = pair[0];
                var b = pair[1];

                if (!graph.ContainsKey(a))
                    graph[a] = new List<string>();
                if (!graph.ContainsKey(b))
                    graph[b] = new List<string>();

                graph[a].Add(b);
                graph[b].Add(a);
            }

            foreach (var g in graph)
            {
                string output = "";

                output += $"{g.Key} = [{String.Join(", ", graph[g.Key])}]";
                Console.WriteLine(output);
            }

            solution("o", "n"); // can src reach dst?
        }

        private void solution(string src, string dst)
        {
            this.dst = dst;

            Console.WriteLine(Dfs(src));
            //Console.WriteLine(Bfs(src));

        }

        private bool Bfs(string src)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(src);

            while(queue.Count > 0)
            {
                string s = queue.Dequeue();

                if (visited.Contains(s))
                    continue;

                visited.Add(s);

                Console.WriteLine("Traversing " + s);

                if (s == dst)
                    return true;

                foreach (var child in graph[s])
                    queue.Enqueue(child);
            }

            return false;
        }

        private bool Dfs(string src)
        {
            if (visited.Contains(src))
                return false;

            visited.Add(src);

            Console.WriteLine($"traversing {src}");

            if (src == dst)
                return true;

            foreach (var neighbor in graph[src])
                if (Dfs(neighbor))
                    return true;

            return false;
        }
    }
}
