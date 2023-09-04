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
        SOSGameState gameState;
        protected override void displayGame()
        {
            bool playerScored = false;
            char ch;
            int choice;
            int playerChoice;
            Player player1 = null;
            Player player2 = null;
            int i = 0;

            Console.WriteLine("Welcome to the game of SOS.");

            //Choosing between Human Player or Computer
            while (true)
            {
                Console.WriteLine("Please choose your opponent, 1.Human Player or 2.Computer");
                string playerInput = Console.ReadLine();


                bool successInput = int.TryParse(playerInput, out playerChoice);

                if (successInput)
                {
                    if (playerChoice == 1)
                    {
                        player1 = new HumanPlayer(1);
                        player2 = new HumanPlayer(2);
                        Console.WriteLine("You have chosen to play with human.");

                    }
                    else if (playerChoice == 2)
                    {
                        player1 = new HumanPlayer(1);
                        player2 = new ComputerPlayer(2);
                        Console.WriteLine("You have chosen to play with computer.");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid option.Please only enter 1 or 2 to choose your opponent");
                }

                break;

            }

            Console.Clear();
            //create instance for saving game
            gameState = new SOSGameState();
            SOSGameSaveLoad saveLoadHandler = new SOSGameSaveLoad(gameState);
            do
            {
                if (player2 is HumanPlayer)
                {


                    //Player's turn
                    if (gameState.player % 2 == 0)
                    {
                        Console.WriteLine("Player 2's turn");
                        Menu(ref gameState, ref saveLoadHandler);

                    }
                    else
                    {
                        Console.WriteLine("Player 1's turn");
                        Menu(ref gameState, ref saveLoadHandler);

                    }

                    Console.WriteLine("\n");

                    //Display Board
                    printBoard(gameState);

                    Console.WriteLine("Please enter the index of the grid where you want to place a symbol: ");
                    string input = Console.ReadLine();

                    bool success = int.TryParse(input, out choice);

                    if (success && (gameState.gridNum[choice] != 'S' && gameState.gridNum[choice] != 'O'))
                    {
                        if (gameState.player % 2 == 0)
                        {
                            //If player 2 enter s or o 
                            /*  Console.WriteLine("Please enter if you want to place the symbol 'S' or 'O' on the grid");
                              ch = Convert.ToChar(Console.ReadLine());
                              gridNum[choice] = ch;
                              Console.WriteLine("Player {0} has enter {1} at grid {2}.", player2._PlayerID, ch, choice);*/

                            Console.WriteLine("Please enter if you want to place the symbol 'S' or 'O' on the grid");
                            ch = Convert.ToChar(Console.ReadLine().ToUpper());

                            while (true)
                            {
                                if (ch != 'S' && ch != 'O')
                                {
                                    Console.WriteLine("Invalid Symbol. Please enter only 'S' or 'O'.");
                                    ch = Convert.ToChar(Console.ReadLine().ToUpper());
                                }
                                else
                                {
                                    Console.Clear();
                                    gameState.gridNum[choice] = ch;
                                    Console.WriteLine("Player {0} has enter {1} at grid {2}.", player2._PlayerID, ch, choice);
                                    break;
                                }

                            }

                        }
                        else
                        {
                            Console.WriteLine("Please enter if you want to place the symbol 'S' or 'O' on the grid");
                            ch = Convert.ToChar(Console.ReadLine().ToUpper());

                            while (true)
                            {
                                if (ch != 'S' && ch != 'O')
                                {
                                    Console.WriteLine("Invalid Symbol. Please enter only 'S' or 'O'.");
                                    ch = Convert.ToChar(Console.ReadLine().ToUpper());
                                }
                                else
                                {
                                    Console.Clear();
                                    gameState.gridNum[choice] = ch;
                                    Console.WriteLine("Player {0} has enter {1} at grid {2}.", player1._PlayerID, ch, choice);
                                    break;
                                }

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, gameState.gridNum[choice]);
                        Console.WriteLine("\n");
                        Console.WriteLine("Please wait 2 second board is loading again.....");
                        Thread.Sleep(2000);
                    }


                    if (ScoreNContinue(gameState)) //If result == true
                    {
                        if (gameState.player % 2 == 0) // if player 1 -> addscore
                        {
                            gameState.p2Score++;
                            printBoard(gameState);
                            Console.WriteLine("Player 2 Scored, they get a second move.");
                        }
                        else
                        {
                            gameState.p1Score++;
                            printBoard(gameState);
                            Console.WriteLine("Player 1 Scored, they get a second move.");
                        }
                    }
                    else
                    {

                        Console.WriteLine("No Player Scored");
                        printBoard(gameState);
                        gameState.player++;
                    }

                    // choice = 2 or 1

                    int x = getRemainingMoves(gameState);




                }

                if (player2 is ComputerPlayer)
                {
                    //Player's turn
                    if (gameState.player % 2 == 0)
                    {
                        Console.WriteLine("Player 2,Computer's turn");
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        Console.WriteLine("Player 1,Human Player's turn");
                        Menu(ref gameState, ref saveLoadHandler);
                        Console.WriteLine("\n");
                    }

                    Console.WriteLine("\n");

                    //Display Board
                    printBoard(gameState);

                    if (gameState.player % 2 != 0)
                    {
                        Console.WriteLine("Please enter the index of the grid where you want to place a symbol: ");
                        string input = Console.ReadLine();

                        bool success = int.TryParse(input, out choice);



                        if (success && (gameState.gridNum[choice] != 'S' && gameState.gridNum[choice] != 'O'))
                        {
                            Console.WriteLine("Please enter if you want to place the symbol 'S' or 'O' on the grid");
                            ch = Convert.ToChar(Console.ReadLine().ToUpper());

                            while (true)
                            {
                                if (ch != 'S' && ch != 'O')
                                {
                                    Console.WriteLine("Invalid Symbol. Please enter only 'S' or 'O'.");
                                    ch = Convert.ToChar(Console.ReadLine().ToUpper());
                                }
                                else
                                {
                                    Console.Clear();
                                    gameState.gridNum[choice] = ch;
                                    Console.WriteLine("Player {0} has enter {1} at grid {2}.", player1._PlayerID, ch, choice);
                                    break;
                                }

                            }

                        }

                        else
                        {
                            Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, gameState.gridNum[choice]);
                            Console.WriteLine("\n");
                            Console.WriteLine("Please wait 2 second board is loading again.....");
                            Thread.Sleep(2000);
                        }

                    }
                    else
                    {
                        Console.Clear();
                        ComputerPlayer computerPlayer = (ComputerPlayer)player2;
                        computerPlayer.randomMoveSOS(gameState);

                    }


                    if (ScoreNContinue(gameState)) //If result == true
                    {
                        if (gameState.player % 2 == 0) // if player 1 -> addscore
                        {
                            gameState.p2Score++;

                            Console.WriteLine("Computer player Scored, they get a second move.");
                            printBoard(gameState);
                            Console.WriteLine("\n");
                        }
                        else
                        {
                            gameState.p1Score++;
                            Console.WriteLine("Human player Scored, they get a second move.");
                            printBoard(gameState);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {

                        Console.WriteLine("No Player Scored");
                        Console.WriteLine("\n");
                        printBoard(gameState);
                        gameState.player++;
                    }

                    // choice = 2 or 1

                    int x = getRemainingMoves(gameState);



                }
            } while (getRemainingMoves(gameState) != 1);

            Console.Clear();
            printBoard(gameState);

            if (playerChoice == 1)
            {
                if (gameState.p1Score > gameState.p2Score)
                {
                    Console.WriteLine("Player 1 Wins with a score of {0}.", gameState.p1Score);
                }
                else if (gameState.p2Score > gameState.p1Score)
                {
                    Console.WriteLine("Player 2 Wins with a score of {0}.", gameState.p2Score);
                }
                else
                {
                    Console.WriteLine("Draw. P1 : {0}, P2 : {1}.", gameState.p1Score, gameState.p2Score);
                }
            }

            if (playerChoice == 2)
            {
                if (gameState.p1Score > gameState.p2Score)
                {
                    Console.WriteLine("Player 1 Wins with a score of {0}.", gameState.p1Score);
                }
                else if (gameState.p2Score > gameState.p1Score)
                {
                    Console.WriteLine("Computer Wins with a score of {0}.", gameState.p2Score);
                }
                else
                {
                    Console.WriteLine("Draw. P1 : {0}, P2 : {1}.", gameState.p1Score, gameState.p2Score);
                }
            }
        }

        private static void printBoard(SOSGameState gameState)
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", gameState.gridNum[1], gameState.gridNum[2], gameState.gridNum[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", gameState.gridNum[4], gameState.gridNum[5], gameState.gridNum[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", gameState.gridNum[7], gameState.gridNum[8], gameState.gridNum[9]);
            Console.WriteLine("     |     |      ");
        }

        public static int CheckScore(SOSGameState gameState)
        {
            int result = 0;

            // Horizontal combinations
            if (!gameState.combinationsChecked[0] && gameState.gridNum[1] == 'S' && gameState.gridNum[2] == 'O' && gameState.gridNum[3] == 'S')
            {
                result = 2;
                gameState.combinationsChecked[0] = true;
            }
            else if (!gameState.combinationsChecked[1] && gameState.gridNum[4] == 'S' && gameState.gridNum[5] == 'O' && gameState.gridNum[6] == 'S')
            {
                result = 2;
                gameState.combinationsChecked[1] = true;
            }
            else if (!gameState.combinationsChecked[2] && gameState.gridNum[7] == 'S' && gameState.gridNum[8] == 'O' && gameState.gridNum[9] == 'S')
            {
                result = 2;
                gameState.combinationsChecked[2] = true;
            }

            // Vertical combinations
            if (result != 2)
            {
                if (!gameState.combinationsChecked[3] && gameState.gridNum[1] == 'S' && gameState.gridNum[4] == 'O' && gameState.gridNum[7] == 'S')
                {
                    result = 2;
                    gameState.combinationsChecked[3] = true;
                }
                else if (!gameState.combinationsChecked[4] && gameState.gridNum[2] == 'S' && gameState.gridNum[5] == 'O' && gameState.gridNum[8] == 'S')
                {
                    result = 2;
                    gameState.combinationsChecked[4] = true;
                }
                else if (!gameState.combinationsChecked[5] && gameState.gridNum[3] == 'S' && gameState.gridNum[6] == 'O' && gameState.gridNum[9] == 'S')
                {
                    result = 2;
                    gameState.combinationsChecked[5] = true;
                }
            }

            // Diagonal combinations
            if (result != 2)
            {
                if (!gameState.combinationsChecked[6] && gameState.gridNum[1] == 'S' && gameState.gridNum[5] == 'O' && gameState.gridNum[9] == 'S')
                {
                    result = 2;
                    gameState.combinationsChecked[6] = true;
                }
                else if (!gameState.combinationsChecked[7] && gameState.gridNum[3] == 'S' && gameState.gridNum[5] == 'O' && gameState.gridNum[7] == 'S')
                {
                    result = 2;
                    gameState.combinationsChecked[7] = true;
                }
            }
            return result;
        }
        private int getRemainingMoves(SOSGameState gameState)
        {
            if (gameState.gridNum[1] != '1' && gameState.gridNum[2] != '2' && gameState.gridNum[3] != '3' && gameState.gridNum[4] != '4' && gameState.gridNum[5] != '5' && gameState.gridNum[6] != '6' && gameState.gridNum[7] != '7' && gameState.gridNum[8] != '8' && gameState.gridNum[9] != '9')
            {
                //No More Moves
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static bool ScoreNContinue(SOSGameState gameState)
        {
            int result = CheckScore(gameState);

            if (result == 2)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Menu(ref SOSGameState gameState, ref SOSGameSaveLoad saveLoadHandler)
        {
            while (true)
            {
                int choice;
                string fileName = "savedSOSGame.json";
                Console.WriteLine("Please enter an option: 1) Display Help 2) Continue Game 3) Save Game 4) Load Game");
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out choice);
                if (success && choice == 1)
                {
                    HelpSystem i = new HelpSystem(2);
                    i.displaySOSBoard();

                }
                else if (success && choice == 2)
                {

                    Console.WriteLine("Continuing game..");
                    break;
                }
                else if (success && choice == 3)
                {
                    saveLoadHandler.Save(fileName);
                }
                else if (success && choice == 4)
                {
                    saveLoadHandler.Load(fileName);
                    printBoard(gameState);
                }
                else
                {
                    Console.WriteLine("Please enter the correct option.");
                }

            }
        }

    }
}
