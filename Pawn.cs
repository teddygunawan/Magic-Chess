using System;
using SwinGameSDK;
namespace MyGame
{
	public class Pawn: Piece
	{
		public Pawn (Color clr, Cell cl): base(clr, cl)
		{

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
				if (destCell.Y == Cell.Y - 70 && destCell.X == Cell.X)
					return true;
				} 
			else {
				if (destCell.Y == Cell.Y + 70 && destCell.X == Cell.X)
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
	}
}
