using System;
using SwinGameSDK;
namespace MyGame
{
	public class Magic
	{
		private bool reviveUsed;
		private bool invulnerabilityUsed;
		public Magic ()
		{
			reviveUsed = false;
			invulnerabilityUsed = false;
		}

		public void Revive (Player[] _player)
		{
			string textBoxMessage = "";
			if (reviveUsed) {
				textBoxMessage = "You have already used your Revive!";
				goto CastMessage;
			}else if (_player[GameMain.turn].LastRemoved == null ) {
				textBoxMessage = "There is no piece to revive!";
				goto CastMessage;
			}
			for (int i = 0; i < 2; i++) {
				foreach (Piece c in _player [i].PieceList) {
					if (_player [GameMain.turn].LastRemoved.Cell == c.Cell) {
						textBoxMessage = "There is a piece on top of the cell!";
						goto CastMessage;
					}
				}
			}

			_player [GameMain.turn].AddPiece (_player [GameMain.turn].LastRemoved);
			textBoxMessage = "Soldier Revived!";
			GameMain.turn = 1;
			reviveUsed = true;

		CastMessage:
			while (false == SwinGame.WindowCloseRequested ()) {
				SwinGame.ProcessEvents ();
				SwinGame.DrawText (textBoxMessage, Color.Black, 605, 280);
				if (SwinGame.MouseClicked (MouseButton.LeftButton))
					return;

				SwinGame.RefreshScreen (60);
			}
		}

		public void Invulnerability (Player [] _player)
		{
			string textBoxMessage = "";
			int y = 0;
			if (invulnerabilityUsed) {
				textBoxMessage = "You have already used your Invulnerability!";
				goto CastMessage;
			}
			while (false == SwinGame.WindowCloseRequested ()) {
				SwinGame.ProcessEvents ();
				SwinGame.DrawText ("Select a Piece to be given divine", Color.Black, 605, 280);
				SwinGame.DrawText ("protection!", Color.Black, 605, 295);
				if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
					foreach (Piece c in _player [GameMain.turn].PieceList) {
						if ((SwinGame.MouseX () > c.Cell.X && SwinGame.MouseX () < c.Cell.X + 70) && 
						    (SwinGame.MouseY () > c.Cell.Y && SwinGame.MouseY () < c.Cell.Y + 70)) {
							y = 30;
							c.Immunity = true;
							textBoxMessage = "Soldier become immune for attack!";
							goto CastMessage;
						}
					}
					return;
				}
				SwinGame.RefreshScreen (60);
			}
		CastMessage:
			while (false == SwinGame.WindowCloseRequested ()) {
				SwinGame.ProcessEvents ();
				SwinGame.DrawText (textBoxMessage, Color.Black, 605, 280 + y);
				if (SwinGame.MouseClicked (MouseButton.LeftButton))
					return;

				SwinGame.RefreshScreen (60);
			}
		}
	}
}
