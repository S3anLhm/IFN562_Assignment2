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

        protected override void displayGame()
        {
            char[] gridNum = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool[] combinationChecked = { false, false, false, false, false, false, false, false };
            bool playerScored = false;
            int player = 1;
            int p1Score = 0;
            int p2Score = 0;
            char ch;
            int choice;
            bool flag = true;
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
            do
            {
        

                if (player2 is HumanPlayer)
                {
                   
        
                    //Player's turn
                    if (player % 2 == 0)
                    {
                        Console.WriteLine("Player 2's turn");
                        menu();

                    }
                    else
                    {
                        Console.WriteLine("Player 1's turn");
                        menu();

                    }

                    Console.WriteLine("\n");

                    //Display Board
                    printBoard(gridNum);

                    Console.WriteLine("Please enter the index of the grid where you want to place a symbol: ");
                    string input = Console.ReadLine();

                    bool success = int.TryParse(input, out choice);

                    if (success && (gridNum[choice] != 'S' && gridNum[choice] != 'O'))
                    {
                        if (player % 2 == 0)
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
                                    gridNum[choice] = ch;
                                    Console.WriteLine("Player {0} has enter {1} at grid {2}.", player2._PlayerID, ch, choice);
                                    break;
                                }

                            }

                        }
                        else
                        {
                            Console.WriteLine("Please enter if you want to place the symbol 'S' or 'O' on the grid");
                            ch = Convert.ToChar(Console.ReadLine());

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
                                    gridNum[choice] = ch;
                                    Console.WriteLine("Player {0} has enter {1} at grid {2}.", player1._PlayerID, ch, choice);
                                    break;
                                }

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, gridNum[choice]);
                        Console.WriteLine("\n");
                        Console.WriteLine("Please wait 2 second board is loading again.....");
                        Thread.Sleep(2000);
                    }


                    if (ScoreNContinue(gridNum, combinationChecked)) //If result == true
                    {
                        if (player % 2 == 0) // if player 1 -> addscore
                        {
                            p2Score++;
                            printBoard(gridNum);
                            Console.WriteLine("Player 2 Scored, they get a second move.");
                        }
                        else
                        {
                            p1Score++;
                            printBoard(gridNum);
                            Console.WriteLine("Player 1 Scored, they get a second move.");
                        }
                    }
                    else
                    {

                        Console.WriteLine("No Player Scored");
                        printBoard(gridNum);
                        player++;
                    }

                    // choice = 2 or 1

                    int x = getRemainingMoves(gridNum);




                }

                if (player2 is ComputerPlayer)
                {



                    //Player's turn
                    if (player % 2 == 0)
                    {
                        Console.WriteLine("Player 2,Computer's turn");
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        Console.WriteLine("Player 1,Human Player's turn");
                        menu();
                        Console.WriteLine("\n");
                    }

                    Console.WriteLine("\n");

                    //Display Board
                    printBoard(gridNum);

                    if (player % 2 != 0)
                    {
                        Console.WriteLine("Please enter the index of the grid where you want to place a symbol: ");
                        string input = Console.ReadLine();

                        bool success = int.TryParse(input, out choice);



                        if (success && (gridNum[choice] != 'S' && gridNum[choice] != 'O'))
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
                                    gridNum[choice] = ch;
                                    Console.WriteLine("Player {0} has enter {1} at grid {2}.", player1._PlayerID, ch, choice);
                                    break;
                                }

                            }

                        }

                        else
                        {
                            Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, gridNum[choice]);
                            Console.WriteLine("\n");
                            Console.WriteLine("Please wait 2 second board is loading again.....");
                            Thread.Sleep(2000);
                        }

                    }
                    else
                    {
                        Console.Clear();
                        ComputerPlayer computerPlayer = (ComputerPlayer)player2;
                        computerPlayer.randomMoveSOS(gridNum);

                    }


                    if (ScoreNContinue(gridNum, combinationChecked)) //If result == true
                    {
                        if (player % 2 == 0) // if player 1 -> addscore
                        {
                            p2Score++;

                            Console.WriteLine("Computer player Scored, they get a second move.");
                            printBoard(gridNum);
                            Console.WriteLine("\n");
                        }
                        else
                        {
                            p1Score++;
                            Console.WriteLine("Human player Scored, they get a second move.");
                            printBoard(gridNum);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {

                        Console.WriteLine("No Player Scored");
                        Console.WriteLine("\n");
                        printBoard(gridNum);
                        player++;
                    }

                    // choice = 2 or 1

                    int x = getRemainingMoves(gridNum);




                }


            } while (getRemainingMoves(gridNum) != 1);

            Console.Clear();
            printBoard(gridNum);

            if (playerChoice == 1)
            {
                if (p1Score > p2Score)
                {
                    Console.WriteLine("Player 1 Wins with a score of {0}.", p1Score);
                }
                else if (p2Score > p1Score)
                {
                    Console.WriteLine("Player 2 Wins with a score of {0}.", p2Score);
                }
                else
                {
                    Console.WriteLine("Draw. P1 : {0}, P2 : {1}.", p1Score, p2Score);
                }
            }

            if (playerChoice == 2)
            {
                if (p1Score > p2Score)
                {
                    Console.WriteLine("Player 1 Wins with a score of {0}.", p1Score);
                }
                else if (p2Score > p1Score)
                {
                    Console.WriteLine("Computer Wins with a score of {0}.", p2Score);
                }
                else
                {
                    Console.WriteLine("Draw. P1 : {0}, P2 : {1}.", p1Score, p2Score);
                }
            }



        }

        private void printBoard(char[] gridNum)
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", gridNum[1], gridNum[2], gridNum[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", gridNum[4], gridNum[5], gridNum[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", gridNum[7], gridNum[8], gridNum[9]);
            Console.WriteLine("     |     |      ");
        }


        public int CheckScore(char[] gridNum, bool[] combinationsChecked)
        {
            int result = 0;

            // Horizontal combinations
            if (!combinationsChecked[0] && gridNum[1] == 'S' && gridNum[2] == 'O' && gridNum[3] == 'S')
            {
                result = 2;
                combinationsChecked[0] = true;
            }
            else if (!combinationsChecked[1] && gridNum[4] == 'S' && gridNum[5] == 'O' && gridNum[6] == 'S')
            {
                result = 2;
                combinationsChecked[1] = true;
            }
            else if (!combinationsChecked[2] && gridNum[7] == 'S' && gridNum[8] == 'O' && gridNum[9] == 'S')
            {
                result = 2;
                combinationsChecked[2] = true;
            }

            // Vertical combinations
            if (result != 2)
            {
                if (!combinationsChecked[3] && gridNum[1] == 'S' && gridNum[4] == 'O' && gridNum[7] == 'S')
                {
                    result = 2;
                    combinationsChecked[3] = true;
                }
                else if (!combinationsChecked[4] && gridNum[2] == 'S' && gridNum[5] == 'O' && gridNum[8] == 'S')
                {
                    result = 2;
                    combinationsChecked[4] = true;
                }
                else if (!combinationsChecked[5] && gridNum[3] == 'S' && gridNum[6] == 'O' && gridNum[9] == 'S')
                {
                    result = 2;
                    combinationsChecked[5] = true;
                }
            }

            // Diagonal combinations
            if (result != 2)
            {
                if (!combinationsChecked[6] && gridNum[1] == 'S' && gridNum[5] == 'O' && gridNum[9] == 'S')
                {
                    result = 2;
                    combinationsChecked[6] = true;
                }
                else if (!combinationsChecked[7] && gridNum[3] == 'S' && gridNum[5] == 'O' && gridNum[7] == 'S')
                {
                    result = 2;
                    combinationsChecked[7] = true;
                }
            }

            // Diagonal combinations
            if (result != 2)
            {
                if (!combinationsChecked[6] && gridNum[1] == 'S' && gridNum[5] == 'O' && gridNum[9] == 'S')
                {
                    result = 2;
                    combinationsChecked[6] = true;
                }
                else if (!combinationsChecked[7] && gridNum[3] == 'S' && gridNum[5] == 'O' && gridNum[7] == 'S')
                {
                    result = 2;
                    combinationsChecked[7] = true;
                }
            }

         
            

            return result;
        }
        public int getRemainingMoves(char[] gridNum)
        {
            if (gridNum[1] != '1' && gridNum[2] != '2' && gridNum[3] != '3' && gridNum[4] != '4' && gridNum[5] != '5' && gridNum[6] != '6' && gridNum[7] != '7' && gridNum[8] != '8' && gridNum[9] != '9')
            {
                //No More Moves
                return 1;
            }
            else
            {
                return 0;
            }
        }

       public bool ScoreNContinue(char[] gridNum, bool[] combinationChecked)
        {
            int result = CheckScore(gridNum, combinationChecked);

            if (result == 2)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public static void menu()
        {
            while (true)
            {
                int choice;
                Console.WriteLine("Please enter an option: 1) Display Help 2) Continue Game");
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out choice);
                if (success && choice == 1)
                {
                    HelpSystem i = new HelpSystem(1);
                    i.displaySOSBoard();

                }
                else if (success && choice == 2)
                {
                  
                    Console.WriteLine("Continuing game..");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter the correct option.");
                }

            }
        }



            }
}
