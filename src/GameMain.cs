using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
		public static void LoadResources ()
		{
			
		}

		public static void InitializeGame ()
		{
			
		}


		public static void DrawGame ()
		{
			
		}

        public static void Main()
        {
			Board gameBoard = new Board ();
			List<Coordinate> someCoordinate = new List<Coordinate>();
			//Open the game window
			SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
			//SwinGame.ShowSwinGameSplashScreen ();

            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
				LoadResources ();
                //Clear the screen and draw the framerate
				SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0,0);

				InitializeGame ();
				gameBoard.Draw ();
				foreach (Coordinate c in someCoordinate)
					c.Draw ();

				if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
					Coordinate xy = new Coordinate (SwinGame.MouseX (), SwinGame.MouseY ());
					someCoordinate.Add (xy);
				}

                //Draw onto the screen
                SwinGame.RefreshScreen(60);

            }
        }
    }
}