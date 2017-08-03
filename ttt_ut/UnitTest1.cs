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
            board.ApplyStep(CTTBoard.Player.PlayerO, 0, 0);
            board.ApplyStep(CTTBoard.Player.PlayerO, 0, 1);
            board.ApplyStep(CTTBoard.Player.PlayerO, 0, 2);
            Assert.IsTrue(board.CheckWin(),"should win");
           
        }
        [TestMethod]
        public void TestLeftColumnWin1()
        {
            var board = new CTTBoard();
            board.ApplyStep(CTTBoard.Player.PlayerO, 1, 0);
            board.ApplyStep(CTTBoard.Player.PlayerO, 1, 1);
            board.ApplyStep(CTTBoard.Player.PlayerO, 1, 2);
            Assert.IsTrue(board.CheckWin(), "should win");

        }
        [TestMethod]
        public void TestLeftColumnWin2()
        {
            var board = new CTTBoard();
            board.ApplyStep(CTTBoard.Player.PlayerO, 2, 0);
            board.ApplyStep(CTTBoard.Player.PlayerO, 2, 1);
            board.ApplyStep(CTTBoard.Player.PlayerO, 2, 2);
            Assert.IsTrue(board.CheckWin(), "should win");

        }
        [TestMethod]
        public void TestLeftColumnWin3()
        {
            var board = new CTTBoard();
            board.ApplyStep(CTTBoard.Player.PlayerO, 0, 0);
            board.ApplyStep(CTTBoard.Player.PlayerO, 1, 0);
            board.ApplyStep(CTTBoard.Player.PlayerO, 2, 0);
            Assert.IsTrue(board.CheckWin(), "should win");

        }
        [TestMethod]
        public void TestLeftColumnWin4()
        {
            var board = new CTTBoard();
            board.ApplyStep(CTTBoard.Player.PlayerO, 0, 1);
            board.ApplyStep(CTTBoard.Player.PlayerO, 1, 1);
            board.ApplyStep(CTTBoard.Player.PlayerO, 2, 1);
            Assert.IsTrue(board.CheckWin(), "should win");

        }
        [TestMethod]
        public void TestLeftColumnWin5()
        {
            var board = new CTTBoard();
            board.ApplyStep(CTTBoard.Player.PlayerO, 0, 2);
            board.ApplyStep(CTTBoard.Player.PlayerO, 1, 2);
            board.ApplyStep(CTTBoard.Player.PlayerO, 2, 2);
            Assert.IsTrue(board.CheckWin(), "should win");

        }

        [TestMethod]
        public void TestLeftDiagWin()
        {
            var board = new CTTBoard();
            board.ApplyStep(CTTBoard.Player.PlayerO, 0, 0);
            board.ApplyStep(CTTBoard.Player.PlayerO, 1, 1);
            board.ApplyStep(CTTBoard.Player.PlayerO, 2, 2);
            Assert.IsTrue(board.CheckWin(), "should win");
        }

        [TestMethod]
        public void TestRightDiagWin()
        {
            var board = new CTTBoard();
            board.ApplyStep(CTTBoard.Player.PlayerO, 0, 2);
            board.ApplyStep(CTTBoard.Player.PlayerO, 1, 1);
            board.ApplyStep(CTTBoard.Player.PlayerO, 2, 0);
            Assert.IsTrue(board.CheckWin(), "should win");
        
        }
    }
}
