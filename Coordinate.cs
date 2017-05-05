using System;
using SwinGameSDK;
namespace MyGame
{
	public class Coordinate
	{
		private float x, y;
		private string c = "";
		public Coordinate (float corx, float cory)
		{
			x = corx;
			y = cory;
			c += x;
			c += ", " + y;
		}

		public float X {
			get { return x;}
		}

		public float Y { 
			get { return y;}
		}

		public void Draw ()
		{
			SwinGame.DrawText (c, Color.Black, x, y);

		}

	}
}
