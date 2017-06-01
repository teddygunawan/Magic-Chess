using System;
using SwinGameSDK;
namespace MyGame
{
	public class Cell
	{
		private Color _clr;
		private int _x;
		private int _y;
		private int [] z;

		public Cell (Color clr, int x, int y)
		{
			_clr = clr;
			_x = x;
			_y = y;
		}

		public void Draw ()
		{
			SwinGame.FillRectangle (Color, X, Y, 70, 70);
			SwinGame.DrawRectangle (Color.Black, X, Y, 70, 70);
		}

		public void SelectedCell (Point2D clicked)
		{
		}

		public Color Color { 
			get { return _clr;}
			set { _clr = value;}
		}

		public int X { 
			get { return _x;}
			set { _x = value;}
		}

		public int Y {
			get { return _y; }
			set { _y = value; }
		}
	}
}
