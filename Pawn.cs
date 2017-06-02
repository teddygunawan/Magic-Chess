using System;
using SwinGameSDK;
namespace MyGame
{
	public class Pawn: Piece
	{
		bool firstMove;
		public Pawn (Color clr, Cell cl): base(clr, cl)
		{
			firstMove = true;
		}

		public override void Draw ()
		{
			if (Color == Color.White)
				SwinGame.DrawBitmap (GameResources.PieceImage ("PW"), Cell.X, Cell.Y);
			else
				SwinGame.DrawBitmap (GameResources.PieceImage ("PB"), Cell.X, Cell.Y);
		}

		public override bool MoveRestriction (Cell destCell, Player [] _player)
		{
			if (firstMove)
				return FirstMovement (destCell);
			
			if (GameMain.turn == 1) {
				foreach (Piece c in _player [0].PieceList) {
					if (c.Cell == destCell) {
						if (MoveAttack (destCell)) {
							return true;
						} else
							return false;
					}
				}
			}
			else {
				foreach (Piece c in _player [1].PieceList) {
					if (c.Cell == destCell) {
						if (MoveAttack (destCell)) {
							return true;
						} else
							return false;
						}
				}
			}

			if (Color == Color.White) {
				if (destCell.Y == Cell.Y - 70 && destCell.X == Cell.X) {
					if (destCell.Y == 0) {
						Promotion (_player);
						return true;
					}
					else
						return true;
				}
			} 
			else {
				if (destCell.Y == Cell.Y + 70 && destCell.X == Cell.X)
					if (destCell.Y == 490) {
						Move (destCell);
						Promotion (_player);
						return true;
					}
					else
						return true;
			}
			return false;
		}

		bool MoveAttack (Cell destCell)
		{
			if (Color == Color.White) {
				if (destCell.Y == Cell.Y - 70 && (destCell.X == Cell.X - 70 || destCell.X == Cell.X + 70))
					return true;
			} else {
				if (destCell.Y == Cell.Y + 70 && (destCell.X == Cell.X - 70 || destCell.X == Cell.X + 70))
					return true;
			}

			return false;
		}

		bool FirstMovement (Cell destCell)
		{
			if (Color == Color.White) {
				if ((destCell.Y == Cell.Y - 70 || destCell.Y == Cell.Y - 140) && destCell.X == Cell.X) {
					firstMove = false;
					return true;
				}
			} 
			else {
				if ((destCell.Y == Cell.Y + 70 || destCell.Y == Cell.Y + 140) && destCell.X == Cell.X) {
					firstMove = false;
					return true;
				}
			}


			return false;
		}

		public void Promotion (Player [] _player)
		{
			SwinGame.FillRectangle (Color.SandyBrown, 140, 210, 280, 140);
			SwinGame.DrawRectangle (Color.Black, 140, 210, 280, 140);

			if (GameMain.turn == 1) {
				SwinGame.DrawBitmap (GameResources.PieceImage ("QB"), 145, 240);
				SwinGame.DrawBitmap (GameResources.PieceImage ("KnB"), 215, 240);
				SwinGame.DrawBitmap (GameResources.PieceImage ("RB"), 285, 240);
				SwinGame.DrawBitmap (GameResources.PieceImage ("BB"), 345, 240);
			} 
			else { 
				SwinGame.DrawBitmap (GameResources.PieceImage ("QW"), 145, 240);
				SwinGame.DrawBitmap (GameResources.PieceImage ("KnW"), 215, 240);
				SwinGame.DrawBitmap (GameResources.PieceImage ("RW"), 285, 240);
				SwinGame.DrawBitmap (GameResources.PieceImage ("BW"), 345, 240);
			}
				

			while (false == SwinGame.WindowCloseRequested ()) {
				SwinGame.ProcessEvents ();
				if (SwinGame.MouseClicked (MouseButton.LeftButton) && SwinGame.MouseY () >= 250 && SwinGame.MouseY () <= 300) {
					if (SwinGame.MouseX () >= 150 && SwinGame.MouseX () <= 210) {
						_player [GameMain.turn].PieceList.Add (new Queen (Color, Cell));
						_player [GameMain.turn].PieceList.Remove (this);
						return;
					} else if (SwinGame.MouseX () >= 225 && SwinGame.MouseX () <= 275) {
						_player [GameMain.turn].PieceList.Add (new Knight (Color, Cell));
						_player [GameMain.turn].PieceList.Remove (this);
						return;
					} else if (SwinGame.MouseX () >= 300 && SwinGame.MouseX () <= 340) {
						_player [GameMain.turn].PieceList.Add (new Rook (Color, Cell));
						_player [GameMain.turn].PieceList.Remove (this);
						return;
					} else if (SwinGame.MouseX () >= 355 && SwinGame.MouseX () <= 405) {
						_player [GameMain.turn].PieceList.Add (new Bishop (Color, Cell));
						_player [GameMain.turn].PieceList.Remove (this);
						return;
					}
				}

				if (SwinGame.MouseClicked (MouseButton.RightButton)){
					SwinGame.DrawTextOnScreen (SwinGame.MouseX ().ToString (), Color.Black, SwinGame.MouseX (), SwinGame.MouseY());
				}
				if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
					SwinGame.DrawTextOnScreen (SwinGame.MouseY ().ToString (), Color.Black, SwinGame.MouseX (), SwinGame.MouseY ());
				}


				SwinGame.RefreshScreen (60);
			}
		}
	}
}
