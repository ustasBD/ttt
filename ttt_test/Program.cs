using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ttt;

namespace ttt_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new CTTHeuristic();

            var board = new CTTBoard();
            board.ApplyStep(CTTBoard.Player.PlayerO, 0, 0);
            board.ApplyStep(CTTBoard.Player.PlayerO, 2, 2);
            //board.ApplyStep(CTTBoard.Player.PlayerY, 1, 2);
            board.ApplyStep(CTTBoard.Player.PlayerX, 1, 1);
           // board.ApplyStep(CTTBoard.Player.PlayerX, 0, 2);
            //board.ApplyStep(CTTBoard.Player.PlayerX, 2, 2);
            board.Dump2Con();
                

            var ass = game.GetNextStepAssesment(board, CTTBoard.Player.PlayerX);

        }
    }
}
