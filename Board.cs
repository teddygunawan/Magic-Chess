using System;
using SwinGameSDK;
namespace MyGame
{
	public class Board
	{
		private Cell [,] _cell = new Cell [8, 8];
		private Player [] _player = new Player [2];
		private Magic playerMagic = new Magic ();
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
			SwinGame.FillRectangle (Color.White, 0, 0, 600, 600);
			SwinGame.DrawRectangle (Color.Black, 0, 0, 600, 600);
			int x = 35, y = 35;
			for (int i = 0; i < 8; i++) {
				SwinGame.DrawText (text.ToString (), Color.Black, x, 580);
				SwinGame.DrawText (num.ToString (), Color.Black, 580, y);
				text++;
				num++;
				x += 70;
				y += 70;
			}

			foreach (Cell c in _cell)
				c.Draw ();
			foreach (Piece c in _player [0].PieceList)
				c.Draw ();
			foreach (Piece c in _player [1].PieceList)
				c.Draw ();
			text = 'A';
			num = 0;
		}

		public void SelectCell (Point2D clicked)
		{
			foreach (Piece c in _player [GameMain.turn].PieceList) {
				if (clicked.X > c.Cell.X && clicked.X < c.Cell.X + 70) {
					if (clicked.Y > c.Cell.Y && clicked.Y < c.Cell.Y + 70) {
						SwinGame.FillRectangle (Color.Yellow, c.Cell.X, c.Cell.Y, 70, 70);
						c.Draw ();
						CheckMovePiece (c);
						return;
					}
				}
			}
		}

		public void CheckMovePiece (Piece selectedPiece)
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

							if (selectedPiece.MoveRestriction (b, _player)) {
								MovePiece (selectedPiece, b);
							}


							return;
						}
					}
				}
				SwinGame.RefreshScreen (60);
			}
		}

		private void MovePiece (Piece selectedPiece, Cell destCell)
		{
			
			if (GameMain.turn == 1)
				GameMain.turn = 0;
			else
				GameMain.turn = 1;
			
			foreach (Piece c in _player [GameMain.turn].PieceList) {
				if (c.Cell == destCell) {
					if (c.Immunity == true) {
						while (false == SwinGame.WindowCloseRequested ()) {
							SwinGame.ProcessEvents ();
							SwinGame.DrawText ("Your soldier no longer immune!", Color.Black, 605, 280);
							c.Immunity = false;
							if (SwinGame.MouseClicked (MouseButton.LeftButton))
								return;
							SwinGame.RefreshScreen (60);
						}
					} else {
						_player [GameMain.turn].RemovePiece (c);
						break;
					}
				}
			}
			selectedPiece.Move (destCell);
			return;
		}

		public void AIMove ()
		{
			Random RNG = new Random ();
			int randNum;

			do {
				foreach (Piece c in _player [1].PieceList) {
					randNum = RNG.Next (0, _player [1].PieceList.Count - 1);
					foreach (Cell b in _cell) {
						foreach (Piece d in _player [1].PieceList) {
							if (d.Cell == b)
								goto NextLoop;
							else
								continue;
						}

						if (_player [1].PieceList [randNum].GetType () == typeof (Pawn)) {
							if ((_player [1].PieceList [randNum] as Pawn).MoveRestriction (b, _player)) {
								MovePiece (_player [1].PieceList [randNum], b);
								return;
							}
						} else if (_player [1].PieceList [randNum].GetType () == typeof (Knight)) {
							if ((_player [1].PieceList [randNum] as Knight).MoveRestriction (b, _player)) {
								MovePiece (_player [1].PieceList [randNum], b);
								return;
							}
						} else if (_player [1].PieceList [randNum].GetType () == typeof (King)) {
							if ((_player [1].PieceList [randNum] as King).MoveRestriction (b, _player)) {
								MovePiece (_player [1].PieceList [randNum], b);
								return;
							}
						} else if (_player [1].PieceList [randNum].GetType () == typeof (Bishop)) {
							if ((_player [1].PieceList [randNum] as Bishop).MoveRestriction (b, _player)) {
								MovePiece (_player [1].PieceList [randNum], b);
								return;
							}
						} else if (_player [1].PieceList [randNum].GetType () == typeof (Rook)) {
							if ((_player [1].PieceList [randNum] as Rook).MoveRestriction (b, _player)) {
								MovePiece (_player [1].PieceList [randNum], b);
								return;
							}
						} else if (_player [1].PieceList [randNum].GetType () == typeof (Queen)) {
							if ((_player [1].PieceList [randNum] as Queen).MoveRestriction (b, _player)) {
								MovePiece (_player [1].PieceList [randNum], b);
								return;
							}
						}
					NextLoop:
						continue;
					}
				}
			} while (GameMain.turn == 1);
		}

		public void CheckWin ()
		{
			bool gameFinished = true;
			string text;
			foreach (Piece c in _player [GameMain.turn].PieceList) {
				if (c.GetType () == typeof (King)){
					gameFinished = false;
				}
			}


			if (gameFinished) {
				if (GameMain.turn == 1) {
					text = "You Win!";
					goto GameEnded;
				} else {
					text = "You Lose!";
					goto GameEnded;
				}
			}
			return;

		GameEnded:
			while (false == SwinGame.WindowCloseRequested ()) {
				SwinGame.ClearScreen (Color.Black);
				SwinGame.ProcessEvents ();
				SwinGame.DrawText (text, Color.White, 400, 250);
				SwinGame.RefreshScreen (60);
			}
		}

		public void CastMagic (MagicType castedMagic)
		{
			if (castedMagic == MagicType.Revive)
				playerMagic.Revive (_player);
			else
				playerMagic.Invulnerability (_player);
		}
	}
}
