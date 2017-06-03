using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
    public static class GameMain
    {
		static Board gameBoard;
		public static int turn = 0;
		public static void InitializeGame ()
		{
			GameResources.LoadPieces ();

			gameBoard = new Board ();
			gameBoard.InitializePlayer ("Player");
		}


		public static void DrawSideBar ()
		{
			SwinGame.DrawLine (Color.Black, 600, 140, 900, 140);
			SwinGame.DrawLine (Color.Black, 600, 460, 900, 460);
		}

        public static void Main()
        {
			List<Coordinate> someCoordinate = new List<Coordinate>();
			InitializeGame ();

			//Open the game window
			SwinGame.OpenGraphicsWindow("GameMain", 900, 600);
			//SwinGame.ShowSwinGameSplashScreen ();

            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                //Clear the screen and draw the framerate
				SwinGame.ClearScreen(Color.Lavender);
                SwinGame.DrawFramerate(0,0);
				gameBoard.CheckWin();
				gameBoard.Draw ();
				DrawSideBar ();
				if (turn == 1)
					gameBoard.AIMove ();
				if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
					gameBoard.SelectCell (SwinGame.MousePosition ());
				}

				foreach (Coordinate c in someCoordinate)
					c.Draw ();

				if (SwinGame.MouseClicked (MouseButton.RightButton)) {
					Coordinate xy = new Coordinate (SwinGame.MouseX (), SwinGame.MouseY ());
					someCoordinate.Add (xy);
				}

                //Draw onto the screen
                SwinGame.RefreshScreen(60);

            }
        }
    }
}