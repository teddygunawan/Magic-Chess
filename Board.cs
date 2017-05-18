using System;
using SwinGameSDK;
namespace MyGame
{
	public class Board
	{
		static Cell [,] _cell = new Cell [8, 8];

		public Board ()
		{
			int x = 0, y = 0;
			bool check = true;

			for (int i = 0; i < 8; i++) {
				for (int k = 0; k < 8; k++) {
					if (i % 2 == 0) {
						if (check) {
							_cell [i, k] = new Cell (Color.White, x, y);
							check = false;
						} else {
							_cell [i, k] = new Cell (Color.DarkGray, x, y);
							check = true;
						}
					} else {
						if (check) {
							_cell [i, k] = new Cell (Color.DarkGray, x, y);
							check = false;
						} else {
							_cell [i, k] = new Cell (Color.White, x, y);
							check = true;
						}
					}
					x += 60;
				}
				x = 0;
				y += 60;
			}
		}

		public void InitializePiece ()
		{
			
		}


		public void Draw ()
		{
			foreach (Cell c in _cell)
				c.Draw();
		}


	}
}
