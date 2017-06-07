using System;
using SwinGameSDK;
namespace MyGame
{
	public class Pawn: Piece
	{
		private bool firstMove;
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
			if (firstMove) {
				if (FirstMovement (destCell))
					return true;
			}
			if (GameMain.turn == 1) {
				foreach (Piece c in _player [0].PieceList) {
					if (c.Cell == destCell) {
						if (MoveAttack (destCell)) {
							if (destCell.Y == 490) {
								goto DoPromotion;
							} else
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
							if (destCell.Y == 0) {
								goto DoPromotion;
							}
							else
								return true;
						} else
							return false;
					}
				}
			}

			if (Color == Color.White) {
				if (destCell.Y == Cell.Y - 70 && destCell.X == Cell.X) {
					if (destCell.Y == 0) {
						goto DoPromotion;
					}
					else
						return true;
				}
			} 
			else {
				if (destCell.Y == Cell.Y + 70 && destCell.X == Cell.X)
					if (destCell.Y == 490) {
						goto DoPromotion;
					}
					else
						return true;
			}
			return false;

		DoPromotion:
			Move (destCell);
			Promotion (_player);
			return true;
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
			firstMove = false;
			return false;
		}

		public void Promotion (Player [] _player)
		{
			if (GameMain.turn == 1) {
				var RNG = new Random();
				int selectedPiece = RNG.Next (0, 1);

				if (selectedPiece == 0) 
					_player [1].AddPiece (new Queen (Color, Cell));
				else 
					_player [1].AddPiece (new Knight (Color, Cell));
				
				_player [1].PieceList.Remove (this);
				return;
			}
			SwinGame.FillRectangle (Color.SandyBrown, 140, 210, 280, 140);
			SwinGame.DrawRectangle (Color.Black, 140, 210, 280, 140);
			SwinGame.DrawBitmap (GameResources.PieceImage ("QW"), 145, 240);
			SwinGame.DrawBitmap (GameResources.PieceImage ("KnW"), 215, 240);
			SwinGame.DrawBitmap (GameResources.PieceImage ("RW"), 285, 240);
			SwinGame.DrawBitmap (GameResources.PieceImage ("BW"), 345, 240);

			while (false == SwinGame.WindowCloseRequested ()) {
				SwinGame.ProcessEvents ();
				if (SwinGame.MouseClicked (MouseButton.LeftButton) && SwinGame.MouseY () >= 250 && SwinGame.MouseY () <= 300) {
					if (SwinGame.MouseX () >= 150 && SwinGame.MouseX () <= 210) {
						_player [GameMain.turn].AddPiece(new Queen (Color, Cell));
						_player [GameMain.turn].PieceList.Remove (this);
						return;
					} else if (SwinGame.MouseX () >= 225 && SwinGame.MouseX () <= 275) {
						_player [GameMain.turn].AddPiece(new Knight (Color, Cell));
						_player [GameMain.turn].PieceList.Remove (this);
						return;
					} else if (SwinGame.MouseX () >= 300 && SwinGame.MouseX () <= 340) {
						_player [GameMain.turn].AddPiece (new Rook (Color, Cell));
						_player [GameMain.turn].PieceList.Remove (this);
						return;
					} else if (SwinGame.MouseX () >= 355 && SwinGame.MouseX () <= 405) {
						_player [GameMain.turn].AddPiece (new Bishop (Color, Cell));
						_player [GameMain.turn].PieceList.Remove (this);
						return;
					}
				}

				SwinGame.RefreshScreen (60);
			}
		}
	}
}
