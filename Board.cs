using System;
using SwinGameSDK;
namespace MyGame
{
	public class Board
	{
		static Cell [,] _cell = new Cell [8, 8];
		static Player [] _player = new Player[2];

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
					x += 70;
				}
				x = 0;
				y += 70;
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

		public void SelectCell (Point2D clicked, int p)
		{
			foreach (Piece c in _player[p].PieceList) {
				if (clicked.X > c.Cell.X && clicked.X < c.Cell.X + 70) {
					if (clicked.Y > c.Cell.Y && clicked.Y < c.Cell.Y + 70) {
						SwinGame.FillRectangle (Color.Yellow, c.Cell.X, c.Cell.Y, 70, 70);
					}
				}
			}
			/*
			foreach (Cell c in _cell) {
				if (clicked.X > c.X && clicked.X < c.X + 70) {
					if (clicked.Y > c.Y && clicked.Y < c.Y + 70) {
						SwinGame.FillRectangle (Color.Yellow, c.X, c.Y, 70, 70);
					}
				}
			}*/
		}
	}
}
