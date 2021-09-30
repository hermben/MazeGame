using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MazeGame
{
    class Game
    {
        private World MyWorld;
        private Player CurrentPlayer;
        public void Start()
        {



     //       setCursorPosition(4,2);
     //        write("x");


        string[,] grid =
        {
            {"=","=","=","=","=","=","="},
            {"="," ","=","="," "," ","X"},
            {"0"," ","="," ","=","=","="},
            {"="," ","=","=","=","=","="},
            {"="," ","=","=","=","=","="},
            {"=","=","=","=","=","=","="},
        };
            World myWorld = new World(grid);
            myWorld.draw();

             CurrentPlayer = new Player(0, 2);
            RunGameloop();
            //currentPlayer.Draw();

            private void DrawFrame()
            {
                Clear();
                MyWorld.draw();
                CurrentPlayer.Draw();
            }

            private void HandlePlayerInput()

            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                ConsoleKey Key = keyInfo.Key;
                    switch(Key)

                {
                    case ConsoleKey.UpArrow:
                        CurrentPlayer.Y -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        CurrentPlayer.Y += 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        CurrentPlayer.X -= 1;
                        break;
                    case ConsoleKey.RightArrow:
                        CurrentPlayer.X += 1;
                        break;
                    default:
                        break;
                }
            }
            //Console.WriteLine(myWorld.IsPositionWalkable(0, 0));
            //Console.WriteLine(myWorld.IsPositionWalkable(1, 1));
            //Console.WriteLine(myWorld.IsPositionWalkable(6, 1));

            // Console.WriteLine("\n\nPress any keys to exit....");

            Console.ReadKey(true);

        }

        private void RunGameloop()

        {

            while (true)
            {
                // Draw everything
                DrawFrame();

                // Check for player input from the keyboard and move the plaer
                HandlePlayerInput();
                //check if the player has reached the exit and end the game 

                //give the consolw as chance to render.
                System.Threading.Thread.Sleep(20);

                break;
            }
        }
    }
}
