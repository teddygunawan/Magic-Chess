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

		public void InitializePlayer (string name)
		{
			_player [0] = new Player (name);
			_player [1] = new Player ("Computer");

			for (int i = 0; i < 8; i++) {
				_player [0].AddPiece (new Pawn (Color.Black, _cell [1, i]));
				_player [1].AddPiece (new Pawn (Color.White, _cell [6, i]));
				}
			for (int i = 0; i < 8; i += 7) {
				_player [0].AddPiece (new Knight (Color.Black, _cell [0, i]));
				_player [1].AddPiece (new Knight (Color.White, _cell [7, i]));
			}
		}


		public void Draw ()
		{
			foreach (Cell c in _cell)
				c.Draw();

			foreach (Piece c in _player [0].PieceList)
				c.Draw ();
			foreach (Piece c in _player [1].PieceList)
				c.Draw ();
		}

		public void SelectCell (Point2D clicked, int turn)
		{
			foreach (Piece c in _player[turn].PieceList) {
				if (clicked.X > c.Cell.X && clicked.X < c.Cell.X + 70) {
					if (clicked.Y > c.Cell.Y && clicked.Y < c.Cell.Y + 70) {
						SwinGame.FillRectangle (Color.Yellow, c.Cell.X, c.Cell.Y, 70, 70);

						while (false == SwinGame.WindowCloseRequested ()) {
							SwinGame.ProcessEvents ();
							if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
								foreach (Cell b in _cell) {
									if (SwinGame.MouseX () > b.X && SwinGame.MouseX () < b.X + 70) {
										if (SwinGame.MouseY () > b.Y && SwinGame.MouseY () < b.Y + 70) {
											c.Move (b);
											return;
										}
									}
								}
							}
							SwinGame.RefreshScreen (60);
						}
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
