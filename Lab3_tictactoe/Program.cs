using System;

namespace Lab3_tictactoe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string cellinputs;

            //Checks the length of the arguments
            if (args.Length != 1) 
            {
                Console.WriteLine(Constants.ErrorInvalidInput);
            }
            else
            {
                cellinputs = args[0];
                Game Game = new Game();

                //Passing cell inputs string to Playnow method
                Game.Playnow(cellinputs);

                //Handling invalid winner
                if (Game.ValidWinner()) 
                {
                    Console.WriteLine(Constants.ErrorWinner);
                }
                else
                {
                    //Main outputs
                    Console.WriteLine(Game.LargeWin());
                    Console.WriteLine(Game.SmallWin());
                    Console.WriteLine(Game.WinCount());
                }
            }
        }
    }

}
