using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueensLibrary
{
    public class Solver
    {
        private int m_n;

        private Board m_board;

        public Solver(int n)
        {
            m_n = n;
            m_board = new Board(n, n);
        }

        public void Solve()
        {
            placeQueenOptim(m_n);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int y = 0; y < m_n; y++)
            {
                for (int x = 0; x < m_n; x++)
                {
                    if (m_board[x, y] > 0)
                    {
                        builder.Append(m_board[x, y]);
                    }
                    else
                    {
                        builder.Append(" ");
                    }
                }
                builder.Append("\r\n");
            }
            return builder.ToString();
        }

        private bool placeQueenForce(int queen)
        {
            if (queen == 0)
            {
                return true;
            }
            Console.WriteLine("Placing: {0}", queen);
            for (int y = 0; y < m_n; y++)
            {
                for (int x = 0; x < m_n; x++)
                {
                    if (validateLocation(x, y))
                    {
                        m_board.Place(x, y, queen);
                        if (placeQueenForce(queen-1))
                        {
                            return true;
                        }
                        else
                        {
                            m_board.Clear(x, y);
                        }
                    }
                }
            }
            return false;
        }

        private bool placeQueenOptim(int queen)
        {
            if (queen == 0)
            {
                return true;
            }
            Console.WriteLine("Placing: {0}", queen);
            int y = m_n - queen;
            for (int x = 0; x < m_n; x++)
            {
                if (validateLocation(x, y))
                {
                    m_board.Place(x, y, queen);
                    if (placeQueenOptim(queen-1))
                    {
                        return true;
                    }
                    else
                    {
                        m_board.Clear(x, y);
                    }
                }
            }
            return false;
        }

        private bool validateLocation(int x, int y)
        {
            // check cell
            if (m_board[x, y] > 0)
            {
                return false;
            }
            // check cols
            for (int b = 0; b < m_n; b++)
            {
                if (m_board[x, b] > 0)
                {
                    return false;
                }
            }
            // check cols
            for (int a = 0; a < m_n; a++)
            {
                if (m_board[a, y] > 0)
                {
                    return false;
                }
            }
            for (int b = 0; b < m_n; b++)
            {
                for (int a = 0; a < m_n; a++)
                {
                    if (x != a && y != b && m_board[a, b] > 0)
                    {
                        if (Math.Abs(a-x) == Math.Abs(b-y))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
