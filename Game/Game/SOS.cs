using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class SOS : Game
    {
        public SOS(int _gameID) : base(_gameID) { }

        private string currentPlayer = "O";
        private int currentRow = 0;
        private int currentColumn = 0;
        private static string[,] board = new string[3, 3]
        {
            {"0", "1", "2" },
            {"3", "4", "5" },
            {"6", "7", "8" },
        };

        private void printBoard()
        {
            Console.WriteLine(currentPlayer + ", please make your move!");
            //print out rows and columns
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == currentRow && j == currentColumn)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
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
        protected override void displayGame()
        {
            bool playing = true;
            while (playing)
            {
                //Allow first player to choose their symbol
                bool incorrectPlayerChoice = false;
                do
                {
                    Console.WriteLine("Which player will go first?");
                    Console.WriteLine("1 for S");
                    Console.WriteLine("2 for 0");
                    string playerChoice = Console.ReadLine();

                    if (playerChoice.Trim().Equals("1"))
                    {
                        currentPlayer = "S";
                    }
                    else if (playerChoice.Trim().Equals("2"))
                    {
                        currentPlayer = "O";
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please select either 1 or 2.");
                    }
                } while (incorrectPlayerChoice);

                while (true)
                {
                    Console.Clear();
                    //Display the board
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
                                Console.Clear();
                                printBoard();
                                Console.WriteLine(currentPlayer + "wins!");
                                Task.Delay(1000).Wait();
                            }
                            else if (result == 1)
                            {
                                Console.Clear();
                                printBoard();
                                Console.WriteLine("Draw!");
                                Task.Delay(1000).Wait();
                            }
                            else
                            {
                                currentPlayer = (currentPlayer == "O") ? "S" : "O";
                                continue;
                            }

                            //Ask players if they want to continue playing after a Win or Draw
                            string replayChoice;
                            Console.WriteLine("Do you want to play SOS again?");
                            Console.WriteLine("1. Yes");
                            Console.WriteLine("2. No");
                            replayChoice = Console.ReadLine();
                            if (replayChoice.Equals("2"))
                            {
                                resetAll();
                                playing = false;
                            }
                            else
                            {
                                resetAll();
                                Console.Clear();
                            }
                            break;
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
        protected override int checkWin(string player)
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
        protected override int getRemainingMoves()
        {
            int count = 0;
            for (int i = 0; i < 3; i++)

                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == "0" || board[i, j] == "1" || board[i, j] == "2" || board[i, j] == "3" || board[i, j] == "4" || board[i, j] == "5" || board[i, j] == "6" || board[i, j] == "7" || board[i, j] == "8")
                    {
                        count++;
                    }
                }
            return count;
        }
        protected override void resetAll()
        {
            currentRow = 0;
            currentColumn = 0;
            board = new string[3, 3]
            {
                {"0", "1", "2" },
                {"3", "4", "5" },
                {"6", "7", "8" },
            };
        }
    }
}
