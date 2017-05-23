using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
	public static class GameResources
	{
		private static Dictionary<string, Bitmap> _Pieces = new Dictionary<string, Bitmap> ();

		public static void LoadPieces ()
		{
			NewPiece ("QW", "QueenW.png");
			NewPiece ("KW", "KingW.png");
			NewPiece ("KnW", "KnightW.png");
			NewPiece ("PW", "PawnW.png");
			NewPiece ("RW", "RookW.png");
			NewPiece ("BW", "BishopW.png");

			NewPiece ("QB", "QueenB.png");
			NewPiece ("KB", "KingB.png");
			NewPiece ("KnB", "KnightB.png");
			NewPiece ("PB", "PawnB.png");
			NewPiece ("RB", "RookB.png");
			NewPiece ("BB", "BishopB.png");
		}

		public static void NewPiece (string pieceName, string fileName)
		{
			_Pieces.Add (pieceName, SwinGame.LoadBitmap (SwinGame.PathToResource (fileName, ResourceKind.BitmapResource)));
		}

		public static Bitmap PieceImage (string image)
		{
			return _Pieces [image];
		}
	}
}
