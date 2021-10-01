using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;



namespace MazeGame 
{
   public class Game 
    {
        private World GetWorld;
        private Player CurrentPlayer;
        public void Start()
        {
            Title = "Welcome to the Maze!";
            CursorVisible = false;
        
        // private World MyWorld;
        // private Player CurrentPlayer;


             // setCursorPosition(4,2);
             //   write("x");


        string[,] grid =
            {
                {" ","=","=","=","=","=","="},
                {"="," ","=","="," "," ","X"},
                {" "," ","="," ","="," ","="},
                {" "," "," "," "," "," ","="},
                {"="," ","=","=","="," ","="},
                {"=","=","=","=","=","=","="},
            };

            GetWorld = new World(grid);
            //GetWorld.Draw();
            
            
            CurrentPlayer = new Player(0,2);
             CurrentPlayer.Draw();
           // ReadKey(true);
            RunGameloop();
            // CurrentPlayer.Draw();
        }
        
        private void DisplayIntro()
        {


        }

        private void Displayoutro()

        {



        }
        private void DrawFrame()
        {  
            Clear();
            GetWorld.Draw();
            CurrentPlayer.Draw();
        }

        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey Key = keyInfo.Key;
            switch (Key)
            {
                case ConsoleKey.UpArrow:
                    if (GetWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }

                    break;
                case ConsoleKey.DownArrow:
                    if (GetWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (GetWorld.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (GetWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                default:
                    break;
            }
        }
        //Console.WriteLine(myWorld.IsPositionWalkable(0, 0));
        //Console.WriteLine(myWorld.IsPositionWalkable(1, 1));
        //Console.WriteLine(myWorld.IsPositionWalkable(6, 1));

        // Console.WriteLine("\n\nPress any keys to exit....");
        private void RunGameloop()
        {
            DisplayIntro();
            while (true)
            {
                // Draw everything
                DrawFrame();

                // Check for player input from the keyboard and move the player
                HandlePlayerInput();
                //check if the player has reached the exit and end the game 
                string elementAtplayerPos = GetWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtplayerPos == "X")
                {
                    break;
                }
                //give the console as chance to render.
                System.Threading.Thread.Sleep(20);
            }
            Displayoutro();
        }
    }
}
