using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
		static Cell [,] boardCell = new Cell [8, 8];
		public static void LoadResources ()
		{
			Bitmap Board = SwinGame.LoadBitmapNamed ("Board", "board.png");
		}

		public static void InitializeGame ()
		{
			int x = 0, y = 0;
			bool check = true;
			for (int i = 0; i < 8; i++) {
				for (int k = 0; k < 8; k++) {
					if (i % 2 == 0) {
						if (check) {
							boardCell [i, k] = new Cell (Color.White, x, y);
							check = false;
						} else {
							boardCell [i, k] = new Cell (Color.Brown, x, y);
							check = true;
						}
					} 
					else 
					{
						if (check) {
								boardCell [i, k] = new Cell (Color.Brown, x, y);
								check = false;
							} else {
								boardCell [i, k] = new Cell (Color.White, x, y);
								check = true;
							}
					}
					/*if ( i % 2 == 0 && k % 2 == 0) {
						boardCell [i, k] = new Cell (Color.White, x, y);
					} else {
						boardCell [i, k] = new Cell (Color.Brown, x , y);
					}*/
					boardCell [i, k].Draw ();
					x += 60;
				}
				x = 0;
				y += 60;
			}

		}


		public static void DrawGame ()
		{
			
		}
        public static void Main()
        {
			
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
				SwinGame.DrawBitmap ("board.png", 0, 0);
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