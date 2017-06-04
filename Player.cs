using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
	public class Player
	{
		private List<Piece> _piece = new List<Piece> ();
		private Piece _lastRemoved;
		private string _playerName;
		public Player (string name)
		{
			_playerName = name;
			_lastRemoved = null;
		}

		public void AddPiece (Piece piece)
		{
			_piece.Add (piece);
		}

		public void RemovePiece (Piece piece)
		{
			_lastRemoved = piece;
			_piece.Remove (piece);
		}

		public List<Piece> PieceList { 
			get { return _piece;}
		}

		public Piece LastRemoved{
			get { return _lastRemoved;}
			set { _lastRemoved = value;}
		}

		public string PlayerName { 
			get { return _playerName;}
			set { _playerName = value;}
		}
	}
}
