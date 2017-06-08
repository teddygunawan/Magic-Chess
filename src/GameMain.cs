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
			SwinGame.DrawRectangle (Color.White, 600, 270, 300, 190);
			SwinGame.DrawBitmap (GameResources.SideBarIcon ("AI"), 605, 10);
			SwinGame.DrawBitmap (GameResources.SideBarIcon ("Human"), 590, 470);
			SwinGame.DrawBitmap (GameResources.SideBarIcon ("Revive"), 605, 150);
			SwinGame.DrawBitmap (GameResources.SideBarIcon ("Invulnerability"), 780, 150);
			SwinGame.DrawText ("Computer Level 0", Color.White, 750, 50);
			SwinGame.DrawText ("You", Color.White, 700, 510);
		}

        public static void Main()
        {
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
				SwinGame.ClearScreen(Color.DarkGray);
                SwinGame.DrawFramerate(0,0);
				gameBoard.Draw ();
				DrawSideBar ();
				if (turn == 1)
					gameBoard.AIMove ();

				if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
					gameBoard.SelectCell (SwinGame.MousePosition ());
				}

				if ((SwinGame.MouseX () >= 604 && SwinGame.MouseX () <= 705) && (SwinGame.MouseY () >= 150 && SwinGame.MouseY () <= 250)) {
					SwinGame.DrawText ("Revive", Color.Green, SwinGame.MouseX(), SwinGame.MouseY() + 20);
					if (SwinGame.MouseClicked (MouseButton.LeftButton)) { 
						gameBoard.CastMagic (MagicType.Revive);
					}
				} else if ((SwinGame.MouseX () >= 794 && SwinGame.MouseX () <= 865) && (SwinGame.MouseY () >= 165 && SwinGame.MouseY () <= 235)) { 
					SwinGame.DrawText ("Invulnerability", Color.Green, SwinGame.MouseX() - 40, SwinGame.MouseY() + 20);
					if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
						gameBoard.CastMagic (MagicType.Invulnerability);
					}
				}


				if (SwinGame.MouseClicked (MouseButton.RightButton)){
					SwinGame.DrawText (SwinGame.MouseX ().ToString () + "," + SwinGame.MouseY ().ToString (), Color.Black, SwinGame.MouseX() + 10, SwinGame.MouseY());
					//SwinGame.Delay (50);
				}

                //Draw onto the screen
                SwinGame.RefreshScreen(60);

            }
        }
    }
}