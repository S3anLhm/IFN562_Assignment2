using System;
using System.Threading.Tasks;
namespace BoardGameAssignment2
{
    internal class Program
    {
        static string currentPlayer = "O";
        static int currentRow = 0;
        static int currentColumn = 0;
        static string[,] board = new string[3, 3]
        {
            {"0", "1", "2" },
            {"3", "4", "5" },
            {"6", "7", "8" },
        };
        static void printBoard()
        {
            //print out rows and columns
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == currentRow && j == currentColumn)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(board[i, j] + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(board[i, j] + " ");
                    }
                }
                //leave space
                Console.WriteLine();
            }
        }

        //win = 2; draw = 1; nothing = 0
        static int checkWin(string player)
        {

            int result = 0;
            //horizontal
            if (board[0, 0] == "S" && board[0, 1] == "O" && board[0, 2] == "S")
            {
                result = 2;
            }
            if (board[1, 0] == "S" && board[1, 1] == "O" && board[1, 2] == "S")
            {
                result = 2;
            }
            if (board[2, 0] == "S" && board[2, 1] == "O" && board[2, 2] == "S")
            {
                result = 2;
            }
            //vertical
            if (board[0, 0] == "S" && board[1, 0] == "O" && board[2, 0] == "S")
            {
                result = 2;
            }
            if (board[0, 1] == "S" && board[1, 1] == "O" && board[2, 1] == "S")
            {
                result = 2;
            }
            if (board[0, 2] == "S" && board[1, 2] == "O" && board[2, 2] == "S")
            {
                result = 2;
            }
            //diagonal
            if (board[0, 0] == "S" && board[1, 1] == "O" && board[2, 2] == "S")
            {
                result = 2;
            }
            if (board[0, 2] == "S" && board[1, 1] == "O" && board[2, 0] == "S")
            {
                result = 2;
            }
            //draw
            //if result is 0 and no moves then draw
            if (result == 0 && getRemainingMoves() == 0)
            {
                return 1;
            }
            return result;
        }
        static int getRemainingMoves()
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == "0" || board[i, j] == "1" || board[i, j] == "2" || board[i, j] == "3" || board[i, j] == "4" || board[i, j] == "5" || board[i, j] == "6" || board[i, j] == "7" || board[i, j] == "8")
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                printBoard();
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    currentColumn++;
                    currentColumn = (currentColumn >= 3) ? 0 : currentColumn;
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    currentColumn--;
                    currentColumn = (currentColumn < 0) ? 2 : currentColumn;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    currentRow--;
                    currentRow = (currentRow < 0) ? 2 : currentRow;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    currentRow++;
                    currentRow = (currentRow >= 3) ? 0 : currentRow;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    string value = board[currentRow, currentColumn];
                    if (value != "S" && value != "O")
                    {
                        board[currentRow, currentColumn] = currentPlayer;
                        int result = checkWin(currentPlayer);
                        if (result == 2)
                        {
                            Console.WriteLine(currentPlayer + "wins!");
                            Task.Delay(1000).Wait();
                            break;
                        }
                        else if (result == 1)
                        {
                            Console.WriteLine("Draw!");
                            Task.Delay(1000).Wait();
                            break;
                        }

                        currentPlayer = (currentPlayer == "O") ? "S" : "O";
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This already filled");
                        Console.ResetColor();
                        Task.Delay(2000).Wait();
                    }
                }
            }
        }
    }
}