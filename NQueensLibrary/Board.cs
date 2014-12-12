using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueensLibrary
{
    public class Board
    {
        private int[,] m_grid;

        public Board(int w, int h)
        {
            m_grid = new int[w, h];
        }

        public int this[int x, int y]
        {
            get
            {
                return m_grid[x, y];
            }
        }

        public void Place(int x, int y, int n)
        {
            m_grid[x, y] = n;
        }

        public void Clear(int x, int y)
        {
            m_grid[x, y] = 0;
        }
    }
}
