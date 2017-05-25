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

		public override bool MoveRestriction (Point2D pt1, Point2D pt2)
		{
			return true;
		}
	}
}
