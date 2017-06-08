using System;
using SwinGameSDK;
namespace MyGame
{
	public class King: Piece
	{
		private bool _castling;
		public King (Color clr, Cell cl): base(clr, cl)
		{
			_castling = true;
		}

		public override void Draw ()
		{
			if (Color == Color.White)
				SwinGame.DrawBitmap (GameResources.PieceImage ("KW"), Cell.X, Cell.Y);
			else
				SwinGame.DrawBitmap (GameResources.PieceImage ("KB"), Cell.X, Cell.Y);
		}

		public override bool MoveRestriction (Cell destCell, Player [] _player)
		{
			if (destCell.Y == Cell.Y) {
				if (destCell.X == Cell.X + 70 || destCell.X == Cell.X - 70) {
					_castling = false;
					return true;
				}
				else
					return false;
			} 
			else if (destCell.Y == Cell.Y + 70 || destCell.Y == Cell.Y - 70) {
				if (destCell.X == Cell.X + 70 || destCell.X == Cell.X - 70 || destCell.X == Cell.X) {
					_castling = false;
					return true;
				}
				else
					return false;
			}
			return false;
		}

		public bool DoCastling (Cell destCell, Player [] _player, Cell[,] cell)
		{
			if (destCell.X == Cell.X + 140 && destCell.Y == Cell.Y) {
				foreach (Piece c in _player [GameMain.turn].PieceList) {
					if (c.GetType () == typeof (Rook) && (c as Rook).Castling) {
						foreach (Cell d in cell) {
							if (d.Y == c.Cell.Y && d.X == c.Cell.X - 140) {
								foreach (Piece e in _player [GameMain.turn].PieceList) {
									if (e.Cell.X == d.X && e.Cell.Y == d.Y) {
										return false;
									}
								}
								c.Cell = d;
								_castling = false;
								return true;
							}
						}
					}
				}
			} else if (destCell.X == Cell.X - 140 && destCell.Y == Cell.Y) {
				foreach (Piece c in _player [GameMain.turn].PieceList) {
					if (c.GetType () == typeof (Rook) && (c as Rook).Castling) {
						foreach (Cell d in cell) {
							if (d.Y == c.Cell.Y && d.X == c.Cell.X + 210) { 
								foreach (Piece e in _player [GameMain.turn].PieceList) {
									if (e.Cell.X == d.X && e.Cell.Y == d.Y) {
										return false;
									}
								}
								c.Cell = d;
								_castling = false;
								return true;
							}
						}
					}
				}
			}

			return false;
		}

		public bool Castling { 
			get { return _castling;}
		}
	}
}
