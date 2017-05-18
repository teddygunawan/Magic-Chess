using System;
using SwinGameSDK;
namespace MyGame
{
	public class Rook: Piece
	{
		public Rook (Color clr, Cell cl): base(clr, cl)
		{

		}

		public override void Draw ()
		{

		}

		public override bool MoveRestriction (Point2D pt1, Point2D pt2)
		{
			return true;
		}
	}
}
