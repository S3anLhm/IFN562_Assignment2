using PlayerToWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PlayerToWork
{
    public class HumanPlayer : Player
    {
        //storing an instance of the game
        public int _PlayerID { get; private set; }
        public string Symbol { get; private set; }
        public HumanPlayer(int _playerID) : base(_playerID)
        {
            _PlayerID = _playerID;
        }
    }
}
//private void makeMove(Player player)
//{
//    bool moveChosen = false;
//    while (!moveChosen)
//    {
//        ConsoleKeyInfo keyInfo = Console.ReadKey();
//        if (keyInfo.Key == ConsoleKey.RightArrow)
//        {
//            IncreaseCurrentColumn();
//        }
//        else if (keyInfo.Key == ConsoleKey.LeftArrow)
//        {
//            DecreaseCurrentColumn();
//        }
//        else if (keyInfo.Key == ConsoleKey.Enter)
//        {
//            int chosenColumn = GetCurrentColumn();
//            // Find the first available row bottom to top
//            for (int row = 5; row >= 0; row--)
//            {
//                if (board[row, chosenColumn] != "X" && board[row, chosenColumn] != "O")
//                {
//                    board[row, chosenColumn] = player.Symbol;
//                    int result = checkWin(player.Symbol);
//                    if (result == 2)
//                    {
//                        Console.Clear();
//                        printBoard();
//                        Console.WriteLine(player._PlayerID + " wins!");
//                        Task.Delay(1000).Wait();
//                    }
//                    else if (result == 1)
//                    {
//                        Console.Clear();
//                        printBoard();
//                        Console.WriteLine("Draw!");
//                        Task.Delay(1000).Wait();
//                    }
//                    else
//                    {
//                        player = (player == player1) ? player2 : player1;
//                        break;
//                    }
//                    //Ask players if they want to continue playing after a Win or Draw
//                    string replayChoice;
//                    Console.WriteLine("Do you want to play Connect Four again?");
//                    Console.WriteLine("1. Yes");
//                    Console.WriteLine("2. No");
//                    replayChoice = Console.ReadLine();
//                    if (replayChoice.Equals("2"))
//                    {
//                        resetAll();
//                        break;
//                    }
//                    else
//                    {
//                        resetAll();
//                        Console.Clear();
//                    }
//                    break;
//                }
//                else if (row == 0 && (board[0, chosenColumn] == "X" || board[0, chosenColumn] == "O"))
//                {
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.WriteLine("This already filled");
//                    Console.ResetColor();
//                    Task.Delay(2000).Wait();
//                }
//                //end of row iteration
//            }
//            moveChosen = true;
//        }
//    }
//}
