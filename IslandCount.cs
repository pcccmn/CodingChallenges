using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class IslandCount
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

        public IslandCount() => Dfs();

        private void Dfs()
        {
            for (int r = 0; r < grid.GetLength(0); r++)
                for (int c = 0; c < grid.GetLength(1); c++)
                    visited[r, c] = false;

            int totalIsland = 0;

            for (int r = 0; r < 6; r++)
                for (int c = 0; c < 5; c++)
                    if (explore(r, c))
                        totalIsland++;

            Console.WriteLine($"There are " + totalIsland + " islands");
        }

        private bool explore(int r, int c)
        {
            // out of bounds check
            if (r == -1 || r == grid.GetLength(0) || c == -1 || c == grid.GetLength(1))
                return false;

            string v = grid[r, c];

            if (visited[r, c] || v == "w")
                return false;

            visited[r, c] = true;

            Console.WriteLine($"visited [{r},{c}] = {v}");

            explore(r - 1, c);
            explore(r + 1, c);
            explore(r, c + 1);
            explore(r, c - 1);

            return true;


        }
    }
}
