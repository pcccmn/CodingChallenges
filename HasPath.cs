using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class HasPath
    {
        private Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        private string dst;
        private HashSet<string> visited = new HashSet<string>();

        public HasPath()
        {
            graph["f"] = new List<string> { "g", "i" };
            graph["g"] = new List<string> { "h" };
            graph["h"] = new List<string> { };
            graph["i"] = new List<string> { "g", "k" };
            graph["j"] = new List<string> { "i" };
            graph["k"] = new List<string> { };

            solution("f", "k"); // can src reach dst?
        }

        private void solution(string src, string dst)
        {
            this.dst = dst;

            //Console.WriteLine(Dfs(src));
            Console.WriteLine(Bfs(src));
            
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
