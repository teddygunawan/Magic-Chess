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
			NewPiece ("Q", "Queen.png");
		}

		public static void NewPiece (string pieceName, string fileName)
		{
			_Pieces.Add (pieceName, SwinGame.LoadBitmap (SwinGame.PathToResource (fileName, ResourceKind.BitmapResource)));
			SwinGame.MakeOpaque (_Pieces [pieceName]);
		}

		public static Bitmap PieceImage (string image)
		{
			return _Pieces [image];
		}
	}
}
