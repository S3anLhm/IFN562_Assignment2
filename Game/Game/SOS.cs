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
            char[] gridNum = { '0','1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool[] combinationChecked = { false, false, false, false, false, false, false, false };
            bool playerScored = false;
            int player = 1;
            int p1Score = 0;
            int p2Score = 0;
            char ch;
            int choice;

            Console.WriteLine("Welcome to the game of SOS");
            Console.WriteLine("\n");

            do
            {
              
                //Player's turn
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2's turn");
                }
                else
                {
                    Console.WriteLine("Player 1's turn");
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
                            //If player 1 enter s or o 
                            Console.WriteLine("Please enter if you want to place the symbol 'S' or 'O' on the grid");
                            ch = Convert.ToChar(Console.ReadLine());
                            gridNum[choice] = ch;
                            

                        }
                        else
                        {
                            Console.WriteLine("Please enter if you want to place the symbol 'S' or 'O' on the grid");
                            ch = Convert.ToChar(Console.ReadLine());
                            gridNum[choice] = ch;
                            

                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, gridNum[choice]);
                        Console.WriteLine("\n");
                        Console.WriteLine("Please wait 2 second board is loading again.....");
                        Thread.Sleep(2000);
                    }
                
                //Check Move (Validity)
                //flag = CheckScore(gridNum,combinationChecked);

                if (ScoreNContinue(gridNum, combinationChecked)) //If result == true
                {
                    if (player % 2 == 0) // if player 1 -> addscore
                    {
                        p1Score++;
                        
                        Console.WriteLine("Player 2 Scored, they get a second move.");
                    }
                    else
                    {
                        p2Score++;
                        
                        Console.WriteLine("Player 1 Scored, they get a second move.");
                    }
                }
                else
                {
                    
                    Console.WriteLine("No Player Scored");
                    player++;
                }

                // choice = 2 or 1

                int x = getRemainingMoves(gridNum);
                Console.WriteLine(x);


                //Check RemainingMove and CheckWin
            } while (getRemainingMoves(gridNum) != 1);

            Console.Clear();
            printBoard(gridNum);

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


        public static int CheckScore(char[] gridNum, bool[] combinationsChecked)
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

         
            

            return result;
        }
        protected override int getRemainingMoves(char[] gridNum)
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

       public static bool ScoreNContinue(char[] gridNum, bool[] combinationChecked)
        {
            int result = CheckScore(gridNum, combinationChecked);   

            if(result == 2)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }

     

    }
}
