using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class MinIslandCount
    {
        private string[,] grid = new string[,] {

            { "w", "l", "w", "w", "w"}, // 0
            { "w", "l", "w", "w", "w"}, // 1
            { "w", "w", "w", "l", "w"}, // .
            { "w", "w", "l", "l", "w"}, // .
            { "l", "w", "w", "l", "l"}, // .
            { "l", "l", "w", "w", "w"}, // 5

        };

        private bool[,] visited = new bool[6, 5];

        public MinIslandCount() => Dfs();

        private void Dfs()
        {
            for (int r = 0; r < grid.GetLength(0); r++)
                for (int c = 0; c < grid.GetLength(1); c++)
                    visited[r, c] = false;

            int minIslandSize = -1; // initial value (also undef)

            for (int r = 0; r < 6; r++)
                for (int c = 0; c < 5; c++)
                {
                    int size = explore(r, c);

                    if (minIslandSize == -1)
                    {
                        if (size > 0)
                            minIslandSize = size;                    
                    }
                    else if (size < minIslandSize && size != 0)
                            minIslandSize = size;
                }

            Console.WriteLine($"Mininum Island Size is " + minIslandSize);
        }

        private int explore(int r, int c)
        {
            // out of bounds check
            if (r == -1 || r == grid.GetLength(0) || c == -1 || c == grid.GetLength(1))
                return 0;

            string v = grid[r, c];

            if (visited[r, c] || v == "w")
                return 0;

            visited[r, c] = true;

            Console.WriteLine($"visited [{r},{c}] = {v}");

            int size = 1;

            size += explore(r - 1, c);
            size += explore(r + 1, c);
            size += explore(r, c + 1);
            size += explore(r, c - 1);

            return size;


        }
    }
}
