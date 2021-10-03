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
        private Position GetPosition;
        private Player CurrentPlayer;
        public void Start()
        {
            Title = "Welcome to the Maze!";
            CursorVisible = false;


        string[,] grid =
            {   {" ","=","=","=","=","=","="},
                {" ","=","=","="," ","=","="},
                {" "," ","=","="," "," ","X"},
                {" "," ","="," ","="," ","="},
                {" "," "," "," "," "," ","="},
                {"="," ","=","=","="," ","="},
                {"=","=","=","=","=","=","="},
            };

            GetPosition = new Position(grid);
            //GetPosition.Draw();
            
            
            CurrentPlayer = new Player(0,2);
            // CurrentPlayer.Draw();
           // ReadKey(true);
            RunGameloop();
            // CurrentPlayer.Draw();
        }
        
   
        private void DrawFrame()
        {  
            Clear();
            GetPosition.Draw();
            CurrentPlayer.Draw();
        }

        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey Key = keyInfo.Key;
            switch (Key)
            {
                case ConsoleKey.UpArrow:
                    if (GetPosition.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }

                    break;
                case ConsoleKey.DownArrow:
                    if (GetPosition.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (GetPosition.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (GetPosition.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                default:
                    break;
            }
        }
      
        // Console.WriteLine("\n\nPress any keys to exit....");
        private void RunGameloop()
        {
           
            while (true)
            {
                // Draw everything
                DrawFrame();

                // Check for player input from the keyboard and move the player
                HandlePlayerInput();
                //check if the player has reached the exit and end the game 
                string elementAtplayerPos = GetPosition.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtplayerPos == "X")
                {
                    break;
                }
                //allows the console to render display.
                System.Threading.Thread.Sleep(20);
            }
           
        }
    }
}
