using System;

namespace Project1
{
    class Program
    {
        static void printBoard(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write($"{board[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите кол-во столбцов доски:");
            int col = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите кол-во строк доски:");
            int row = Convert.ToInt32(Console.ReadLine());
            int[,] board = new int[row, col];
            //заполнение точек исключений
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = 1;
                }
            }

            board[1, 1] = 0;
            board[3, 1] = 0;
            board[2, 3] = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if(board[i, j]==0)
                    {
                        continue;
                    }
                    else if (i == 0 || j == 0)
                    {
                        board[i, j] = 1;
                        continue;
                    }
                    else
                    {
                        board[i, j] = board[i - 1, j] + board[i, j - 1];
                    }
                }
            }
            printBoard(board);
        }
    }
}
