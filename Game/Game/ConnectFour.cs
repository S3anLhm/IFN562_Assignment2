using System;
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

        protected override void chooseOpponent(out Player player1, out Player player2)
        {
            //Ask first player for opponent choice
            bool QUIT = true;
            //string opponentChoice = "1";
            Console.WriteLine("Please choose your opponent, 1.Human Player or 2. Computer");

            int opponentChoice = int.Parse(Console.ReadLine());


            //player1 = null;
            //player2 = null;

            while (!QUIT)
            {
                if (opponentChoice == 1)
                {
                    player1 = new HumanPlayer(1);
                    player2 = new HumanPlayer(2);
                    assignSymbols(ref player1, ref player2);
                    QUIT = true;
                }
                else if (opponentChoice == 2)
                {
                    player1 = new HumanPlayer(1);
                    player2 = new ComputerPlayer(2);
                    assignSymbols(ref player1, ref player2);
                    QUIT = true;
                }
                else
                {
                    Console.WriteLine("Not a valid option. Try again.");
                }
            }
        }
        private void assignSymbols(ref Player player1, ref Player player2)
        {
            //Allow first player to choose their symbol
            bool incorrectPlayerChoice = false;
            do
            {
                Console.WriteLine("First player please choose your symbol");
                Console.WriteLine("1 for X");
                Console.WriteLine("2 for 0");
                string playerChoice = Console.ReadLine();

                if (playerChoice.Trim().Equals("1"))
                {
                    player1.Symbol = "X";
                    player2.Symbol = "O";
                    incorrectPlayerChoice = false;
                }
                else if (playerChoice.Trim().Equals("2"))
                {
                    player1.Symbol = "O";
                    player2.Symbol = "X";
                    incorrectPlayerChoice = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please select either 1 or 2.");
                }
            } while (incorrectPlayerChoice);
        }
        protected override void displayGame(Player player1, Player player2)
        {
            string currentPlayer = player1.Symbol;
            bool scenarioHuman = true;
            bool scenarioComputer = true;
            while (scenarioComputer)
            {
                if (player2 is ComputerPlayer)
                {
                    if (currentPlayer == player1.Symbol)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        if (keyInfo.Key == ConsoleKey.RightArrow)
                        {
                            player1.moveRightConnectFour(ref currentColumn);
                        }
                        else if (keyInfo.Key == ConsoleKey.LeftArrow)
                        {
                            player1.moveLeftConnectFour(ref currentColumn);
                        }
                        else if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            player1.makeMoveConnectFour(ref currentColumn, ref board, ref currentPlayer);
                            int result = checkWin(currentPlayer);
                            if (result == 2)
                            {
                                Console.Clear();
                                printBoard();
                                Console.WriteLine(currentPlayer + " wins!");
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
                                currentPlayer = (currentPlayer == player1.Symbol) ? player2.Symbol : player1.Symbol;
                                break;
                            }
                            //Ask players if they want to continue playing after a Win or Draw
                            string replayChoice;
                            Console.WriteLine("Do you want to play Connect Four again?");
                            Console.WriteLine("1. Yes");
                            Console.WriteLine("2. No");
                            replayChoice = Console.ReadLine();
                            if (replayChoice.Equals("2"))
                            {
                                resetAll();
                                break;
                            }
                            else
                            {
                                resetAll();
                                Console.Clear();
                            }
                        }
                    }
                    if (currentPlayer == player2.Symbol)
                    {
                        ComputerPlayer computerPlayer = (ComputerPlayer)player2;
                        ConsoleKeyInfo simulatedKeyPress = computerPlayer.SimulateRandomKeyPress();
                        if (simulatedKeyPress.Key == ConsoleKey.RightArrow)
                        {
                            player2.moveRightConnectFour(ref currentColumn);
                        }
                        else if (simulatedKeyPress.Key == ConsoleKey.LeftArrow)
                        {
                            player2.moveLeftConnectFour(ref currentColumn);
                        }
                        else if (simulatedKeyPress.Key == ConsoleKey.Enter)
                        {
                            player2.makeMoveConnectFour(ref currentColumn, ref board, ref currentPlayer);
                            int result = checkWin(currentPlayer);
                            if (result == 2)
                            {
                                Console.Clear();
                                printBoard();
                                Console.WriteLine(currentPlayer + " wins!");
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
                                currentPlayer = (currentPlayer == player1.Symbol) ? player2.Symbol : player1.Symbol;
                                break;
                            }
                            //Ask players if they want to continue playing after a Win or Draw
                            string replayChoice;
                            Console.WriteLine("Do you want to play Connect Four again?");
                            Console.WriteLine("1. Yes");
                            Console.WriteLine("2. No");
                            replayChoice = Console.ReadLine();
                            if (replayChoice.Equals("2"))
                            {
                                resetAll();
                                break;
                            }
                            else
                            {
                                resetAll();
                                Console.Clear();
                            }
                        }
                    }
                    scenarioComputer = false;
                }
            }
            while (scenarioHuman)
            {
                if (player2 is HumanPlayer && (currentPlayer == player1.Symbol || currentPlayer == player2.Symbol))
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        player2.moveRightConnectFour(ref currentColumn);
                    }
                    else if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        player2.moveLeftConnectFour(ref currentColumn);
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        player2.makeMoveConnectFour(ref currentColumn, ref board, ref currentPlayer);
                        int result = checkWin(currentPlayer);
                        if (result == 2)
                        {
                            Console.Clear();
                            printBoard();
                            Console.WriteLine(currentPlayer + " wins!");
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
                            currentPlayer = (currentPlayer == player1.Symbol) ? player2.Symbol : player1.Symbol;
                            break;
                        }
                        //Ask players if they want to continue playing after a Win or Draw
                        string replayChoice;
                        Console.WriteLine("Do you want to play Connect Four again?");
                        Console.WriteLine("1. Yes");
                        Console.WriteLine("2. No");
                        replayChoice = Console.ReadLine();
                        if (replayChoice.Equals("2"))
                        {
                            resetAll();
                            break;
                        }
                        else
                        {
                            resetAll();
                            Console.Clear();
                        }
                    }
                }
                scenarioHuman = false;
            }
        }
        //end of display game

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
    }
}
