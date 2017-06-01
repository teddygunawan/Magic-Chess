using System;
using SwinGameSDK;
namespace MyGame
{
	public class King: Piece
	{
		public King (Color clr, Cell cl): base(clr, cl)
		{
			
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
				if (destCell.X == Cell.X + 70 || destCell.X == Cell.X - 70)
					return true;
				else
					return false;
			} 
			else if (destCell.Y == Cell.Y + 70 || destCell.Y == Cell.Y - 70) {
				if (destCell.X == Cell.X + 70 || destCell.X == Cell.X - 70 || destCell.X == Cell.X)
					return true;
				else
					return false;
			}
			return false;
		}
	}
}
