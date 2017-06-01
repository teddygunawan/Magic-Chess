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
			return true;
		}
	}
}
