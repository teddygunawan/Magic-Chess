using System;
using SwinGameSDK;
namespace MyGame
{
	public class Knight: Piece
	{
		
		public Knight (Color clr, Cell cl): base(clr, cl)
		{
			
		}

		public override void Draw ()
		{
			if (Color == Color.White)
				SwinGame.DrawBitmap (GameResources.PieceImage ("KnW"), Cell.X, Cell.Y);
			else
				SwinGame.DrawBitmap (GameResources.PieceImage ("KnB"), Cell.X, Cell.Y);
		}

		public override bool MoveRestriction (Cell destCell, Player [] _player)
		{
			if (destCell.Y == Cell.Y + 70 || destCell.Y == Cell.Y - 70) {
				if (destCell.X == Cell.X + 140 || destCell.X == Cell.X - 140)
					return true;
				else
					return false;
			} else if (destCell.Y == Cell.Y + 140 || destCell.Y == Cell.Y - 140) {
				if (destCell.X == Cell.X + 70 || destCell.X == Cell.X - 70)
					return true;
				else
					return false;
			}
			return false;
		}


	}
}
