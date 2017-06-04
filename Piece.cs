using System;
using SwinGameSDK;
namespace MyGame
{
	public abstract class Piece
	{
		private Color _clr;
		private Cell _cell;
		private bool _immunity;
		public Piece (Color clr, Cell cl)
		{
			_clr = clr;
			_cell = cl;
		}

		public abstract void Draw ();

		public abstract bool MoveRestriction (Cell destCell, Player[] _player);

		public void Move (Cell cl)
		{
			_cell = cl;
		}
		public Color Color{
			get { return _clr;}
			set { _clr = value;}
		}

		public Cell Cell { 
			get { return _cell;}
			set { _cell = value;}
		}

		public bool Immunity { 
			get { return _immunity;}
			set { _immunity = value;}
		}
	}
}
