using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
		static Board gameBoard;
		static int turn = 0;
		public static void LoadResources ()
		{
			
		}

		public static void InitializeGame ()
		{
			gameBoard = new Board ();
			GameResources.LoadPieces ();
		}


		public static void DrawGame ()
		{
			
		}

		public static void HandleMoveInput ()
		{
			gameBoard.SelectCell (SwinGame.MousePosition (), turn);
			while (false == SwinGame.WindowCloseRequested ()) {
				SwinGame.ProcessEvents ();

				if(SwinGame.MouseClicked(MouseButton.LeftButton))
					
				SwinGame.RefreshScreen (60);
			}
		}

        public static void Main()
        {
			List<Coordinate> someCoordinate = new List<Coordinate>();
			InitializeGame ();

			//Open the game window
			SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
			//SwinGame.ShowSwinGameSplashScreen ();

            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                //Clear the screen and draw the framerate
				SwinGame.ClearScreen(Color.Black);
                SwinGame.DrawFramerate(0,0);

				gameBoard.Draw ();
				SwinGame.DrawBitmap (GameResources.PieceImage ("QW"), 140, 140);
				foreach (Coordinate c in someCoordinate)
					c.Draw ();
				
				if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
					HandleMoveInput();
				}


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