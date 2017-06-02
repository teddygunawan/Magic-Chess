using System;
using SwinGameSDK;
namespace MyGame
{
	public class Board
	{
		private Cell [,] _cell = new Cell [8, 8];
		private Player [] _player = new Player[2];
		private Char text = 'A';
		private int num = 0;
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
				_player [0].AddPiece (new Pawn (Color.White, _cell [6, i]));
				_player [1].AddPiece (new Pawn (Color.Black, _cell [1, i]));
				}
			for (int i = 0; i < 8; i += 7) {
				_player [0].AddPiece (new Rook (Color.White, _cell [7, i]));
				_player [1].AddPiece (new Rook (Color.Black, _cell [0, i]));
			}
			for (int i = 1; i < 8; i += 5) { 
				_player [0].AddPiece (new Knight (Color.White, _cell [7, i]));
				_player [1].AddPiece (new Knight (Color.Black, _cell [0, i]));
			}

			for (int i = 2; i < 8; i += 3) {
				_player [0].AddPiece (new Bishop (Color.White, _cell [7, i]));
				_player [1].AddPiece (new Bishop (Color.Black, _cell [0, i]));
			}
			_player [0].AddPiece (new Queen (Color.White, _cell [7, 3]));
			_player [1].AddPiece (new Queen (Color.Black, _cell [0, 3]));
			_player [0].AddPiece (new King (Color.White, _cell [7, 4]));
			_player [1].AddPiece (new King (Color.Black, _cell [0, 4]));
		}


		public void Draw ()
		{
			SwinGame.DrawRectangle (Color.Black, 0, 0, 600, 600);
			SwinGame.FillRectangle (Color.White, 0, 0, 600, 600);

			int x = 35, y = 35;
			for (int i = 0; i < 8; i++) {
				SwinGame.DrawText (text.ToString(),Color.Black, x, 580);
				SwinGame.DrawText (num.ToString (), Color.Black, 580, y);
				text++;
				num++;
				x += 70;
				y += 70;
			}
				
			foreach (Cell c in _cell)
				c.Draw();
			foreach (Piece c in _player [0].PieceList)
				c.Draw ();
			foreach (Piece c in _player [1].PieceList)
				c.Draw ();
			text = 'A';
			num = 0;
		}

		public void SelectCell (Point2D clicked)
		{
			foreach (Piece c in _player[GameMain.turn].PieceList) {
				if (clicked.X > c.Cell.X && clicked.X < c.Cell.X + 70) {
					if (clicked.Y > c.Cell.Y && clicked.Y < c.Cell.Y + 70) {
						SwinGame.FillRectangle (Color.Yellow, c.Cell.X, c.Cell.Y, 70, 70);
						c.Draw ();
						MovePiece (c);
						return;
					}
				}
			}
		}

		public void MovePiece (Piece selectedPiece)
		{
			while (false == SwinGame.WindowCloseRequested ()) {
				SwinGame.ProcessEvents ();

				if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
					foreach (Cell b in _cell) {
						if ((SwinGame.MouseX () > b.X && SwinGame.MouseX () < b.X + 70) && (SwinGame.MouseY () > b.Y && SwinGame.MouseY () < b.Y + 70)) {
							foreach (Piece c in _player [GameMain.turn].PieceList) {
								if (c.Cell == b)
									return;
							}

							if (GameMain.turn == 1 && selectedPiece.MoveRestriction (b, _player)) {
								selectedPiece.Move (b);
								GameMain.turn = 0;
							} 
							else if (GameMain.turn == 0 && selectedPiece.MoveRestriction (b, _player)) {
								selectedPiece.Move (b);
								GameMain.turn = 1;
							}

							foreach (Piece c in _player [GameMain.turn].PieceList) {
								if (c.Cell == b) {
									_player [GameMain.turn].RemovePiece (c);
									break;
								}
							}
							return;
						}
					}
				}
				SwinGame.RefreshScreen (60);
			}
		}
	}
}
