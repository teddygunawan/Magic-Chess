using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
	public class Player
	{
		List<Piece> _piece = new List<Piece> ();
		string _name;
		Piece _lastRemoved;

		public Player (string name)
		{
			_name = name;
			_lastRemoved = null;
		}

		public void AddPiece (Piece piece)
		{
			_piece.Add (piece);
		}

		public void RemovePiece (Piece piece)
		{
			_piece.Remove (piece);
			_lastRemoved = piece;
		}

		public List<Piece> PieceList { 
			get { return _piece;}
		}

		public Piece LastRemoved{
			get { return _lastRemoved;}
			set { _lastRemoved = value;}
		}
	}
}
