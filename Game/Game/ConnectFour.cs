using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class ConnectFour : Game
    {
        public ConnectFour(int _gameID) : base(_gameID) { }
        private int currentRow = 0;
        private int currentColumn = 0;
        private string currentPlayer = "O";
        private string[,] board = new string[6, 7]
        {
                {"-", "-", "-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-", "-", "-"},
        };
        private void printBoard()
        {
            Console.WriteLine(currentPlayer + ", please make your move!");
            //print out rows and columns
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
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
                Console.WriteLine();
            }
        }

        private void chooseOpponent(out Player player1, out Player player2)
        {
            while (true)
            {
                //Ask first player for opponent choice
                //bool QUIT = true;
                //string opponentChoice = "1";
                Console.WriteLine("Please choose your opponent, 1.Human Player or 2. Computer");
                int opponentChoice;
                bool success = int.TryParse(Console.ReadLine(), out opponentChoice);

                if (success && opponentChoice == 1)
                {
                    player1 = new HumanPlayer(1);
                    player2 = new HumanPlayer(2);
                    break;

                }
                else if (success && opponentChoice == 2)
                {
                    player1 = new HumanPlayer(1);
                    player2 = new ComputerPlayer(2);
                    break;
                }
                else
                {
                    Console.WriteLine("Not a valid option. Try again.");
                    player1 = null;
                    player2 = null;
                }
            }
            resetAll();
        }
        private void assignSymbols(out string player1Symbol, out string player2Symbol)
        {
            //Allow first player to choose their symbol

            bool incorrectPlayerChoice = true;
            do
            {
                Console.WriteLine("First player please choose your symbol");
                Console.WriteLine("1 for X");
                Console.WriteLine("2 for 0");
                string playerChoice = Console.ReadLine();

                if (playerChoice.Trim().Equals("1"))
                {
                    player1Symbol = "X";
                    player2Symbol = "O";
                    incorrectPlayerChoice = false;
                }
                else if (playerChoice.Trim().Equals("2"))
                {
                    player1Symbol = "O";
                    player2Symbol = "X";
                    incorrectPlayerChoice = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please select either 1 or 2.");
                    player1Symbol = null;
                    player2Symbol = null;
                }
            } while (incorrectPlayerChoice);
        }
        protected override void displayGame()
        {
            Player player1;
            Player player2;
            string player1Symbol;
            string player2Symbol;
            chooseOpponent(out player1, out player2);
            assignSymbols(out player1Symbol, out player2Symbol);
            string currentPlayer = player1Symbol;
            bool gameInProgress = true;
            while (gameInProgress)
            {
                Console.Clear();
                printBoard();
                if (currentPlayer == player1Symbol)
                {
                    ConsoleKeyInfo KeyInfo = Console.ReadKey();
                    if (KeyInfo.Key == ConsoleKey.RightArrow)
                    {
                        currentColumn++;
                        currentColumn = (currentColumn >= 7) ? 0 : currentColumn;
                    }
                    else if (KeyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        currentColumn--;
                        currentColumn = (currentColumn < 0) ? 6 : currentColumn;
                    }
                    else if (KeyInfo.Key == ConsoleKey.Enter)
                    {
                        int row;
                        // Find the first available row bottom to top
                        for (row = 5; row >= 0; row--)
                        {
                            if (board[row, currentColumn] != "X" && board[row, currentColumn] != "O")
                            {
                                break;
                            }
                        }
                        if (row >= 0)
                        {
                            board[row, currentColumn] = currentPlayer;
                        }
                        else
                        {
                            currentPlayer = (currentPlayer == "O") ? "X" : "O";
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This already filled");
                        Console.ResetColor();
                        Task.Delay(2000).Wait();
                    }
                }
                else if (currentPlayer == player2Symbol)
                {
                    if (player2 is HumanPlayer)
                    {
                        ConsoleKeyInfo KeyInfo = Console.ReadKey();
                        if (KeyInfo.Key == ConsoleKey.RightArrow)
                        {
                            currentColumn++;
                            currentColumn = (currentColumn >= 7) ? 0 : currentColumn;
                        }
                        else if (KeyInfo.Key == ConsoleKey.LeftArrow)
                        {
                            currentColumn--;
                            currentColumn = (currentColumn < 0) ? 6 : currentColumn;
                        }
                        else if (KeyInfo.Key == ConsoleKey.Enter)
                        {
                            int row;
                            // Find the first available row bottom to top
                            for (row = 5; row >= 0; row--)
                            {
                                if (board[row, currentColumn] != "X" && board[row, currentColumn] != "O")
                                {
                                    break;
                                }
                            }
                            if (row >= 0)
                            {
                                board[row, currentColumn] = currentPlayer;
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
                    else if (player2 is ComputerPlayer)
                    {
                        ComputerPlayer computerPlayer = (ComputerPlayer)player2;
                        ConsoleKeyInfo simulatedKeyPress = computerPlayer.SimulateRandomKeyPress();
                        if (simulatedKeyPress.Key == ConsoleKey.RightArrow)
                        {
                            currentColumn++;
                            currentColumn = (currentColumn >= 7) ? 0 : currentColumn;
                        }
                        else if (simulatedKeyPress.Key == ConsoleKey.LeftArrow)
                        {
                            currentColumn--;
                            currentColumn = (currentColumn < 0) ? 6 : currentColumn;
                        }
                        else if (simulatedKeyPress.Key == ConsoleKey.Enter)
                        {
                            int row;
                            // Find the first available row bottom to top
                            for (row = 5; row >= 0; row--)
                            {
                                if (board[row, currentColumn] != "X" && board[row, currentColumn] != "O")
                                {
                                    break;
                                }
                            }
                            if (row >= 0)
                            {
                                board[row, currentColumn] = currentPlayer;
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
                //Replay option
                int result = checkWin(currentPlayer);
                if (result == 2)
                {
                    Console.Clear();
                    printBoard();
                    Console.WriteLine(currentPlayer + " wins!");
                    Task.Delay(1000).Wait();
                    askForReplay(ref gameInProgress);
                }
                else if (result == 1)
                {
                    Console.Clear();
                    printBoard();
                    Console.WriteLine("Draw!");
                    Task.Delay(1000).Wait();
                    askForReplay(ref gameInProgress);
                }
                else
                {
                    currentPlayer = (currentPlayer == player1Symbol) ? player2Symbol : player1Symbol;
                }
            }
        }
        //end of display game

        private void askForReplay(ref bool gameInProgress)
        {
            string replayChoice;
            Console.WriteLine("Do you want to play Connect Four again?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            replayChoice = Console.ReadLine();
            if (replayChoice.Equals("2"))
            {
                resetAll();
                gameInProgress = false;
            }
            else
            {
                resetAll();
                Console.Clear();
            }
        }
        //win = 2; draw = 1; nothing = 0
        protected override int checkWin(string symbol)
        {
            int result = 0;
            //horizontal
            for (int j = 0; j < 7 - 3; j++)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (board[i, j] == symbol && board[i, j + 1] == symbol && board[i, j + 2] == symbol && board[i, j + 3] == symbol)
                    {
                        return result = 2;
                    }
                }
            }
            //vertical
            for (int i = 0; i < 6 - 3; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (board[i, j] == symbol && board[i + 1, j] == symbol && board[i + 2, j] == symbol && board[i + 3, j] == symbol)
                    {
                        return result = 2;
                    }
                }
            }
            //ascending diagonal
            for (int i = 3; i < 6; i++)  // Loop through rows 3 to 5
            {
                for (int j = 0; j < 7 - 3; j++)  // Loop through columns 0 to 3
                {
                    if (board[i, j] == symbol && board[i - 1, j + 1] == symbol && board[i - 2, j + 2] == symbol && board[i - 3, j + 3] == symbol)
                    {
                        return result = 2;
                    }
                }
            }
            //descending diagonal
            for (int i = 0; i < 3; i++)  // Loop through rows 0 to 2
            {
                for (int j = 0; j < 7 - 3; j++)  // Loop through columns 0 to 3
                {
                    if (board[i, j] == symbol && board[i + 1, j + 1] == symbol && board[i + 2, j + 2] == symbol && board[i + 3, j + 3] == symbol)
                    {
                        return result = 2;
                    }
                }
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
            for (int i = 0; i < 6; i++)

                for (int j = 0; j < 7; j++)
                {
                    if (board[i, j] == "-")
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
            board = new string[6, 7]
            {
                {"-", "-", "-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-", "-", "-"},
                {"-", "-", "-", "-", "-", "-", "-"},
            };
        }
        //public void handlePlayerMove(ref string playerSymbol, ref bool continueGame, ref int currentColumn)
        //{
        //    ConsoleKeyInfo keyInfo = Console.ReadKey();
        //    if (keyInfo.Key == ConsoleKey.RightArrow)
        //    {
        //        currentColumn++;
        //        currentColumn = (currentColumn >= 7) ? 0 : currentColumn;
        //    }
        //    else if (keyInfo.Key == ConsoleKey.LeftArrow)
        //    {
        //        currentColumn--;
        //        currentColumn = (currentColumn < 0) ? 6 : currentColumn;
        //    }
        //    else if (keyInfo.Key == ConsoleKey.Enter)
        //    {
        //        bool invalidMove = true;
        //        while (invalidMove)
        //        {
        //            for (int row = 5; row >= 0; row--)
        //            {
        //                if (board[row, currentColumn] != "X" && board[row, currentColumn] != "O")
        //                {
        //                    board[row, currentColumn] = playerSymbol;
        //                    int result = checkWin(playerSymbol);

        //                    if (result == 2)
        //                    {
        //                        Console.Clear();
        //                        printBoard();
        //                        Console.WriteLine(playerSymbol + " wins!");
        //                        break;
        //                    }
        //                    else if (result == 1)
        //                    {
        //                        Console.Clear();
        //                        printBoard();
        //                        Console.WriteLine("Draw!");
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        playerSymbol = (playerSymbol == "O") ? "X" : "O";
        //                        continue;
        //                    }
        //                }
        //                else if (board[0, currentColumn] == "X" || board[0, currentColumn] == "O")
        //                {
        //                    Console.ForegroundColor = ConsoleColor.Red;
        //                    Console.WriteLine("This column is already full so please choose another one!");
        //                    Console.ResetColor();
        //                    Task.Delay(2000).Wait();
        //                    break;
        //                }
        //            }
        //            invalidMove = false;
        //        }
        //    }
        //}
        //public void handleComputerMove(Player computer, ref string playerSymbol, ref bool continueGame)
        //{
        //    ComputerPlayer computerPlayer = (ComputerPlayer)computer;
        //    ConsoleKeyInfo simulatedKeyPress = computerPlayer.SimulateRandomKeyPress();
        //    if (simulatedKeyPress.Key == ConsoleKey.RightArrow)
        //    {
        //        currentColumn++;
        //        currentColumn = (currentColumn >= 7) ? 0 : currentColumn;
        //    }
        //    else if (simulatedKeyPress.Key == ConsoleKey.LeftArrow)
        //    {
        //        currentColumn--;
        //        currentColumn = (currentColumn < 0) ? 6 : currentColumn;
        //    }
        //    else if (simulatedKeyPress.Key == ConsoleKey.Enter)
        //    {
        //        for (int row = 5; row >= 0; row--)
        //        {
        //            if (board[row, currentColumn] != "X" && board[row, currentColumn] != "O")
        //            {
        //                board[row, currentColumn] = playerSymbol;
        //                int result = checkWin(playerSymbol);

        //                if (result == 2)
        //                {
        //                    Console.Clear();
        //                    printBoard();
        //                    Console.WriteLine(playerSymbol + " wins!");
        //                    break;
        //                }
        //                else if (result == 1)
        //                {
        //                    Console.Clear();
        //                    printBoard();
        //                    Console.WriteLine("Draw!");
        //                    break;
        //                }
        //                else
        //                {
        //                    playerSymbol = (playerSymbol == "O") ? "X" : "O";
        //                    break;
        //                }
        //            }
        //            else if (board[0, currentColumn] == "X" || board[0, currentColumn] == "O")
        //            {
        //                Console.ForegroundColor = ConsoleColor.Red;
        //                Console.WriteLine("This column is already full so please choose another one!");
        //                Console.ResetColor();
        //                Task.Delay(2000).Wait();
        //            }
        //        }
        //        Console.WriteLine("Do you want to continue playing ConnectFour");
        //        Console.WriteLine("1. Yes");
        //        Console.WriteLine("2. No");
        //        string strChoiceContinute = Console.ReadLine();
        //        if (strChoiceContinute.Equals("2"))
        //        {
        //            resetAll();
        //            continueGame = false;
        //        }
        //        else
        //        {
        //            resetAll();
        //            Console.Clear();
        //        }
        //    }
        //}
    }
}
