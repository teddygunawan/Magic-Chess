﻿using System;
using SwinGameSDK;
using System.Collections.Generic;
using System.Linq;
namespace MyGame
{
	public class Bishop: Piece
	{
		public Bishop (Color clr, Cell cl): base(clr, cl)
		{

		}

		public override void Draw ()
		{
			if(Color == Color.White)
				SwinGame.DrawBitmap (GameResources.PieceImage ("BW"), Cell.X, Cell.Y);
			else
				SwinGame.DrawBitmap (GameResources.PieceImage ("BB"), Cell.X, Cell.Y);
		}

		public override bool MoveRestriction (Cell destCell, Player [] _player)
		{
			int x = destCell.X;
			int y = destCell.Y;

			if (Cell.X > destCell.X) {
				if (Cell.Y > destCell.Y) {
					do {
						for (int i = 0; i < 2; i++) {
							foreach (Piece c in _player [i].PieceList) { 
								if (destCell.X == x && destCell.Y == y)
									break;
								else if (c.Cell.X == x && c.Cell.Y == y)
									return false;
							}
						}
						x += 70;
						y += 70;
						if ((x == Cell.X && Cell.Y == y))
							return true;
					} while (Cell.X != x && Cell.Y != y);
					return false;
				} else if (Cell.Y < destCell.Y) {
					do {
						for (int i = 0; i < 2; i++) {
							foreach (Piece c in _player [i].PieceList) {
								if (destCell.X == x && destCell.Y == y)
									break;
								else if (c.Cell.X == x && c.Cell.Y == y)
									return false;
							}
						}
						x += 70;
						y -= 70;
						if (x == Cell.X && Cell.Y == y)
							return true;
					} while (Cell.X != x && Cell.Y != y);
					return false;
				}
			} 
			else if (Cell.X < destCell.X) { 
				if (Cell.Y > destCell.Y) {
					do {
						for (int i = 0; i < 2; i++) {
							foreach (Piece c in _player [i].PieceList) {
								if (destCell.X == x && destCell.Y == y)
									break;
								else if (c.Cell.X == x && c.Cell.Y == y)
									return false;
							}
						}
						x -= 70;
						y += 70;
						if (x == Cell.X && Cell.Y == y)
							return true;
					} while (Cell.X != x && Cell.Y != y);
					return false;
				} else if (Cell.Y < destCell.Y) {
					do {
						for (int i = 0; i < 2; i++) {
							foreach (Piece c in _player [i].PieceList) {
								if (destCell.X == x && destCell.Y == y)
									break;
								else if (c.Cell.X == x && c.Cell.Y == y)
									return false;
							}
						}
						x -= 70;
						y -= 70;
						if (x == Cell.X && Cell.Y == y)
							return true;
					} while (Cell.X != x && Cell.Y != y);
					return false;
				}
				
			}

			return false;
		}
	}
}
