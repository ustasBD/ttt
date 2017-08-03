using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ttt
{
    public class CTTBoard : ICloneable
    {
        public enum Player : byte
        {
            PlayerX = (byte)'X',
            PlayerO = (byte)'O'
        }
        public CTTBoard()
        {
            Reset();
        }
        private byte[,] _board = new byte[3, 3];
        public void Reset()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    _board[i, j] = 0;
        }
        public byte GetCell(int x, int y)
        {
            return _board[x, y];
        }
        public void Dump2Con()
        {
            for (var y = 0; y < 3; y++)
            {
                for (var x = 0; x < 3; x++)
                    Console.Write((char)_board[x, y]);
                Console.WriteLine();
            }
        }
        public void CleanCell(int x, int y)
        {
            _board[x, y] = 0;
        }
        public void ApplyStep(Player pl, int x, int y)
        {
            _applyStep(_board, (byte)pl, x, y);
        }
        private static void _applyStep(byte[,] board, byte Val, int x, int y)
        {
            if (board[x, y] != 0)
                throw new Exception("Cell is busy");
            board[x, y] = Val;
        }
        public bool CheckComplete()
        {
            bool _isEmpty = false;
            for (int x = 0; x < 3 && !_isEmpty; x++)
                for (int y = 0; y < 3 && !_isEmpty; y++)
                    _isEmpty = _board[x, y] == 0;
            return !_isEmpty;

        }
        public bool CheckWin()
        {
            if (_board[0, 0] == _board[0, 1] && _board[0, 1] == _board[0, 2])
                return true;
            if (_board[1, 0] == _board[1, 1] && _board[1, 1] == _board[1, 2])
                return true;
            if (_board[2, 0] == _board[2, 1] && _board[2, 1] == _board[2, 2])
                return true;

            if (_board[0, 0] == _board[1, 0] && _board[1, 0] == _board[2, 0])
                return true;
            if (_board[0, 1] == _board[1, 1] && _board[1, 1] == _board[2, 1])
                return true;
            if (_board[0, 2] == _board[1, 2] && _board[1, 2] == _board[2, 2])
                return true;
            

            if (_board[0, 0] == _board[1, 1] && _board[1, 1] == _board[2, 2])
                return true;
            if (_board[0, 2] == _board[1, 1] && _board[1, 1] == _board[2, 0])
                return true;


            return false;
        }

        public object Clone()
        {
            return new CTTBoard() { _board = (byte[,])this._board.Clone()};
        }
    }
    public class CTTHeuristic
    {
        private static int _stepAssesmetInfinity = 10;
        public CTTHeuristic()
        {
        }
        
      
        public static CTTBoard.Player InvPlayer(CTTBoard.Player pl)
        {
            switch(pl)
            {
                case CTTBoard.Player.PlayerX: return CTTBoard.Player.PlayerO;
                case CTTBoard.Player.PlayerO: return CTTBoard.Player.PlayerX;
                default:
                    throw new Exception("Invalid plsayer code");
            }
        } 
        private  static int _getStepAssesment(CTTBoard board, CTTBoard.Player me, CTTBoard.Player pl ,int x, int y, int level)
        {
            board.ApplyStep( pl, x, y);
            int stepScore = _stepAssesmetInfinity-level;
            int nopScore = _stepAssesmetInfinity;

            if (me != pl)
                stepScore = -stepScore;
            else
                nopScore = -nopScore;

            var retAss = -nopScore;

            if (board.CheckWin( ))
            {
                //Dump2Con(board);
                //Console.WriteLine(string.Format("{0},{1}",x,y));
                board.CleanCell(x, y);
                return stepScore;
            }
            if (board.CheckComplete())
            {
                board.CleanCell(x, y);
                return 0;
            }
            
            for (int xx = 0;xx < 3; xx++)
                for(int yy =0; yy <3; yy++)
                {
                    if (board.GetCell(xx, yy) == 0)
                    {
                        var ass = _getStepAssesment(board, me, InvPlayer(pl), xx, yy, level+1);
                        if (me != pl)
                        {
                            if (retAss < ass)
                                retAss = ass;
                        }
                        else
                            if (retAss > ass)
                                retAss = ass;
                    }
                }
            board.CleanCell(x, y);
            return retAss;
        }
        public int[,]  GetNextStepAssesment(CTTBoard board, CTTBoard.Player pl)
        {
            var assArr = new int[3, 3];
            Task[] tskList = new Task[9];
            for (int x= 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                {
                    int xc = x;
                    int yc = y;
                  
                    {
                        Console.WriteLine("{0},{1}", xc, yc);

                        if (board.GetCell(xc, yc) != 0)
                        {
                            assArr[xc, yc] = -100;
                        }
                        else
                        {
                            var copyBoard = (CTTBoard)board.Clone();
                            var ass = _getStepAssesment(copyBoard, pl, pl, xc, yc, 0);
                            //if (ass != null)
                            assArr[xc, yc] = ass;
                        }
                    };
                    //tskList[x+y*3] = Task.Factory.StartNew(assFunk);

                }
            //Task.WaitAll(tskList);
            return assArr;
        }
        public Tuple<byte, byte> GetNextStep(CTTBoard board, CTTBoard.Player pl)
        {
            var assArr = GetNextStepAssesment(board, pl);
            return Tuple.Create((byte)0, (byte)0);
        }
        
    }
}
