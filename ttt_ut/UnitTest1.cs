using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ttt;

namespace ttt_ut
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLeftColumnWin()
        {
            var board = new CTTBoard();
            board.ApplyStep(CTTBoard.Player.PlayerY, 0, 0);
            board.ApplyStep(CTTBoard.Player.PlayerY, 0, 1);
            board.ApplyStep(CTTBoard.Player.PlayerY, 0, 2);
            Assert.IsTrue(CTTBoard._checkWin(board.GetBoard(), 0, 0),"should win");
            Assert.IsTrue(CTTBoard._checkWin(board.GetBoard(), 0, 1), "should win");
            Assert.IsTrue(CTTBoard._checkWin(board.GetBoard(), 0, 2), "should win");
        }

        [TestMethod]
        public void TestLeftDiagWin()
        {
            var board = new CTTBoard();
            board.ApplyStep(CTTBoard.Player.PlayerY, 0, 0);
            board.ApplyStep(CTTBoard.Player.PlayerY, 1, 1);
            board.ApplyStep(CTTBoard.Player.PlayerY, 2, 2);
            Assert.IsTrue(CTTBoard._checkWin(board.GetBoard(), 0, 0), "should win");
            Assert.IsTrue(CTTBoard._checkWin(board.GetBoard(), 1, 1), "should win");
            Assert.IsTrue(CTTBoard._checkWin(board.GetBoard(), 2, 2), "should win");
        }

        [TestMethod]
        public void TestRightDiagWin()
        {
            var board = new CTTBoard();
            board.ApplyStep(CTTBoard.Player.PlayerY, 0, 2);
            board.ApplyStep(CTTBoard.Player.PlayerY, 1, 1);
            board.ApplyStep(CTTBoard.Player.PlayerY, 2, 0);
            Assert.IsTrue(CTTBoard._checkWin(board.GetBoard(), 0, 2), "should win");
            Assert.IsTrue(CTTBoard._checkWin(board.GetBoard(), 1, 1), "should win");
            Assert.IsTrue(CTTBoard._checkWin(board.GetBoard(), 2, 0), "should win");
        }
    }
}
