using System;
using SwinGameSDK;
using NUnit.Framework;

namespace MyGame
{
	[TestFixture()]
	public class UnitTesting
	{
		[Test ()]
		public void TestCreateAllPieces ()
		{
			Cell someCell = new Cell (Color.Black, 0, 0);
			Pawn somePawn = new Pawn (Color.Black, someCell);
			King someKing = new King (Color.Black, someCell);
			Queen someQueen = new Queen (Color.Black, someCell);
			Rook someRook = new Rook (Color.Black, someCell);
			Knight someKnight = new Knight (Color.Black, someCell);
			Bishop someBishop = new Bishop (Color.Black, someCell);

			Assert.IsInstanceOf<Pawn> (somePawn);
			Assert.IsInstanceOf<King> (someKing);
			Assert.IsInstanceOf<Queen> (someQueen);
			Assert.IsInstanceOf<Rook> (someRook);
			Assert.IsInstanceOf<Knight> (someKnight);
			Assert.IsInstanceOf<Bishop> (someBishop);
		}

		[Test ()]
		public void TestMove ()
		{
			Cell firstCell = new Cell (Color.Black, 0, 0);
			Cell nextCell = new Cell (Color.White, 50, 50);
			Pawn somePawn = new Pawn (Color.Black, firstCell);

			Assert.AreEqual (somePawn.Cell, firstCell);

			somePawn.Move (nextCell);
			Assert.AreEqual (somePawn.Cell, nextCell);
		}

		[Test ()]
		public void TestPawnMoveWithRestriction ()
		{
			Player [] _player = new Player [2];
			_player [0] = new Player ("Player");
			_player [1] = new Player ("AI");

			Cell firstCell = new Cell (Color.Black, 0, 0);
			Cell invalidCell = new Cell (Color.White, 50, 50);
			Cell validCell = new Cell (Color.White, 0, 70);
			Pawn somePawn = new Pawn (Color.Black, firstCell);

			Assert.IsFalse (somePawn.MoveRestriction (invalidCell, _player));
			Assert.IsTrue (somePawn.MoveRestriction (validCell, _player));
		}

		[Test ()]
		public void TestKingMoveWithRestriction ()
		{
			Player [] _player = new Player [2];
			_player [0] = new Player ("Player");
			_player [1] = new Player ("AI");

			Cell firstCell = new Cell (Color.Black, 140, 140);
			Cell invalidCell = new Cell (Color.White, 50, 50);
			Cell validCell = new Cell (Color.White, 70, 70);
			Cell anotherValidCell = new Cell (Color.White, 210, 210);
			King someKing = new King (Color.Black, firstCell);

			Assert.IsFalse (someKing.MoveRestriction (invalidCell, _player));
			Assert.IsTrue(someKing.MoveRestriction (validCell, _player));
			Assert.IsTrue(someKing.MoveRestriction (anotherValidCell, _player));
		}

		[Test ()]
		public void TestQueenMoveWithRestriction ()
		{
			Player [] _player = new Player [2];
			_player [0] = new Player ("Player");
			_player [1] = new Player ("AI");

			Cell firstCell = new Cell (Color.Black, 140, 140);
			Cell invalidCell = new Cell (Color.White, 50, 50);
			Cell validCell = new Cell (Color.White, 140, 280);
			Cell anotherValidCell = new Cell (Color.White, 350, 350);
			Queen someQueen = new Queen (Color.Black, firstCell);

			Assert.IsFalse (someQueen.MoveRestriction (invalidCell, _player));
			Assert.IsTrue (someQueen.MoveRestriction (validCell, _player));
			Assert.IsTrue (someQueen.MoveRestriction (anotherValidCell, _player));
		}

		[Test ()]
		public void TestRookMoveWithRestriction ()
		{
			Player [] _player = new Player [2];
			_player [0] = new Player ("Player");
			_player [1] = new Player ("AI");

			Cell firstCell = new Cell (Color.Black, 140, 140);
			Cell invalidCell = new Cell (Color.White, 50, 50);
			Cell validCell = new Cell (Color.White, 140, 280);
			Cell anotherValidCell = new Cell (Color.White, 280, 140);
			Rook someRook = new Rook (Color.Black, firstCell);

			Assert.IsFalse (someRook.MoveRestriction (invalidCell, _player));
			Assert.IsTrue (someRook.MoveRestriction (validCell, _player));
			Assert.IsTrue (someRook.MoveRestriction (anotherValidCell, _player));
		}

		[Test ()]
		public void TestKnightMoveWithRestriction ()
		{
			Player [] _player = new Player [2];
			_player [0] = new Player ("Player");
			_player [1] = new Player ("AI");

			Cell firstCell = new Cell (Color.Black, 140, 140);
			Cell invalidCell = new Cell (Color.White, 50, 50);
			Cell validCell = new Cell (Color.White, 210, 280);
			Cell anotherValidCell = new Cell (Color.White, 280, 70);
			Knight someKnight = new Knight (Color.Black, firstCell);

			Assert.IsFalse (someKnight.MoveRestriction (invalidCell, _player));
			Assert.IsTrue (someKnight.MoveRestriction (validCell, _player));
			Assert.IsTrue (someKnight.MoveRestriction (anotherValidCell, _player));
		}

		[Test ()]
		public void TestBishopMoveWithRestriction ()
		{
			Player [] _player = new Player [2];
			_player [0] = new Player ("Player");
			_player [1] = new Player ("AI");

			Cell firstCell = new Cell (Color.Black, 140, 140);
			Cell invalidCell = new Cell (Color.White, 50, 50);
			Cell validCell = new Cell (Color.White, 0, 0);
			Cell anotherValidCell = new Cell (Color.White, 350, 350);
			Bishop someBishop = new Bishop (Color.Black, firstCell);

			Assert.IsFalse (someBishop.MoveRestriction (invalidCell, _player));
			Assert.IsTrue (someBishop.MoveRestriction (validCell, _player));
			Assert.IsTrue (someBishop.MoveRestriction (anotherValidCell, _player));
		}
	}
}
