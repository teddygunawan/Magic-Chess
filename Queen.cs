using System;
using SwinGameSDK;
namespace MyGame
{
	public class Queen: Piece
	{
		public Queen (Color clr, Cell cl): base(clr, cl)
		{

		}

		public override void Draw ()
		{
			if (Color == Color.White)
				SwinGame.DrawBitmap (GameResources.PieceImage ("QW"), Cell.X, Cell.Y);
			else
				SwinGame.DrawBitmap (GameResources.PieceImage ("QB"), Cell.X, Cell.Y);
		}

		public override bool MoveRestriction (Cell destCell, Player [] _player)
		{
			int x = destCell.X;
			int y = destCell.Y;


			if (Cell.Y == destCell.Y) {
				if (Cell.X > destCell.X) {
					do {
						for (int i = 0; i < 2; i++) {
							foreach (Piece c in _player [i].PieceList) {
								if (destCell.X == x && destCell.Y == y)
									break;
								else if (c.Cell.X == x && c.Cell.Y == destCell.Y)
									return false;
							}
						}
						x += 70;
					} while (Cell.X != x);
					return true;
				} else if (Cell.X < destCell.X) {
					do {
						for (int i = 0; i < 2; i++) {
							foreach (Piece c in _player [i].PieceList) {
								if (destCell.X == x && destCell.Y == y)
									break;
								else if (c.Cell.X == x && c.Cell.Y == destCell.Y)
									return false;
							}
						}
						x -= 70;
					} while (Cell.X != x);
					return true;
				}
			} 
			else if (destCell.X == Cell.X) {
				if (Cell.Y > destCell.Y) {
					do {
						for (int i = 0; i < 2; i++) {
							foreach (Piece c in _player [i].PieceList) {
								if (destCell.X == x && destCell.Y == y)
									break;
								else if (c.Cell.Y == y && c.Cell.X == destCell.X)
									return false;
							}
						}
						y += 70;
					} while (Cell.Y != y);
					return true;
				} else if (Cell.Y < destCell.Y) {
					do {
						for (int i = 0; i < 2; i++) {
							foreach (Piece c in _player [i].PieceList) {
								if (destCell.X == x && destCell.Y == y)
									break;
								else if (c.Cell.Y == y && c.Cell.X == destCell.X)
									return false;
							}
						}
						y -= 70;
					} while (Cell.Y != y);
					return true;
				}
			}
			else if (Cell.X > destCell.X) {
				if (Cell.Y > destCell.Y) {
					do {
						for (int i = 0; i < 2; i++) {
							foreach (Piece c in _player [i].PieceList) {
								if (destCell.X == x && destCell.Y == y)
									break;
								else if (c.Cell.X == x && c.Cell.Y == y)
									return false;
							}
						}
						x += 70;
						y += 70;
						if ((x == Cell.X && Cell.Y == y))
							return true;
					} while (Cell.X != x && Cell.Y != y);
					return false;
				} else if (Cell.Y < destCell.Y) {
					do {
						for (int i = 0; i < 2; i++) {
							foreach (Piece c in _player [i].PieceList) {
								if (destCell.X == x && destCell.Y == y)
									break;
								else if (c.Cell.X == x && c.Cell.Y == y)
									return false;
							}
						}
						x += 70;
						y -= 70;
						if (x == Cell.X && Cell.Y == y)
							return true;
					} while (Cell.X != x && Cell.Y != y);
					return false;
				}
			} 
			else if (Cell.X < destCell.X) {
				if (Cell.Y > destCell.Y) {
					do {
						for (int i = 0; i < 2; i++) {
							foreach (Piece c in _player [i].PieceList) {
								if (destCell.X == x && destCell.Y == y)
									break;
								else if (c.Cell.X == x && c.Cell.Y == y)
									return false;
							}
						}
						x -= 70;
						y += 70;
						if (x == Cell.X && Cell.Y == y)
							return true;
					} while (Cell.X != x && Cell.Y != y);
					return false;
				} else if (Cell.Y < destCell.Y) {
					do {
						for (int i = 0; i < 2; i++) {
							foreach (Piece c in _player [i].PieceList) {
								if (destCell.X == x && destCell.Y == y)
									break;
								else if (c.Cell.X == x && c.Cell.Y == y)
									return false;
							}
						}
						x -= 70;
						y -= 70;
						if (x == Cell.X && Cell.Y == y)
							return true;
					} while (Cell.X != x && Cell.Y != y);
					return false;
				}

			}
			return false;
		}
	}
}
