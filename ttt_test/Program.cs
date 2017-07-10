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
            var board = new CTTBoard();
          board.ApplyStep(CTTBoard.Player.PlayerY, 0, 1);
            board.ApplyStep(CTTBoard.Player.PlayerY, 1, 2);
            board.ApplyStep(CTTBoard.Player.PlayerX, 0, 2);
            board.ApplyStep(CTTBoard.Player.PlayerX, 2, 2);

            var ass = board.GetNextStepAssesment(CTTBoard.Player.PlayerX);

        }
    }
}
