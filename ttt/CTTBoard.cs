using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ttt
{
    public class CTTBoard
    {
        public enum Player : byte
        {
            PlayerX = (byte)'X',
            PlayerY = (byte)'Y'
        }
        private byte[,] _board = new byte[3,3];
        public CTTBoard()
        {
            Reset();
        }
        public void Reset()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    _board[i,j] = 0;
        }
        public void Dump2Con()
        {

        }

        public void ApplyStep(Player pl,int x, int y)
        {
            _applyStep(_board,(byte)pl, x, y);
        }
        
        private static void _applyStep(byte[,] board, byte Val, int x, int y)
        {
            if (board[x,y] != 0)
                throw new Exception("Cell is busy");
            board[x,y] = Val;
        }
        private static bool _checkWin(byte[,] board, int x, int  y)
        {
            byte prev = board[0, y];
            bool found = true;
            for (int xx = 1; xx < 3 && found; xx++)
            {
                found = (prev == board[xx, y]);
            }
            if (found)
                return true;
            found = true;
            prev = board[x, 0];
            for (int yy = 1; yy < 3 && found; yy++)
            {
                found = (prev == board[x, yy]);
            }
            if (found)
                return true;
            if ( x == y || y + x == 2)
            {
                found = true;
                prev = board[0, 0];
                for (int xx = 0; xx < 3 && found; xx++)
                    found = (board[xx, xx] == prev && board[xx, 2 - xx] == prev);
            }
            return found;    
        }
        public static Player InvPlayer(Player pl)
        {
            switch(pl)
            {
                case Player.PlayerX: return Player.PlayerY;
                case Player.PlayerY: return Player.PlayerX;
                default:
                    throw new Exception("Invalid plsayer code");
            }
        } 
        private  static Tuple<int,Player> _getStepAssesment(byte[,] board, Player pl ,int x, int y, int level)
        {
            _applyStep(board, (byte)pl, x, y);
            if (_checkWin(board, x, y))
                return Tuple.Create(level, pl);
            level++;
            var retAss = Tuple.Create(10, pl);

            pl = InvPlayer(pl);

            
            for (int xx = 0;xx < 3; xx++)
                for(int yy =0; yy <3; yy++)
                {
                    if (board[xx, yy] == 0)
                    {
                        var ass = _getStepAssesment(board, pl, xx, yy, level);
                        if (retAss.Item1 > ass.Item1)
                            retAss = ass; 
                    }
                }
            board[x, y] = 0;
            return retAss;
        }
        public int[,]  GetNextStepAssesment(Player pl)
        {
            var assArr = new int[3, 3];
            Task[] tskList = new Task[9];
            for (int x= 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                {
                    int xc = x;
                    int yc = y;
                    tskList[x+y*3] = Task.Factory.StartNew(() => {
                        Console.WriteLine("{0},{1}",xc, yc);

                        if (_board[xc, yc] != 0)
                            assArr[xc, yc] = -100;
                        else
                        {
                            byte[,] copyBoard = (byte[,])_board.Clone();
                            var ass = _getStepAssesment(copyBoard, pl, xc, yc, 0);
                            //if (ass != null)
                                assArr[xc, yc] = (10 - ass.Item1) * ((ass.Item2 == pl) ? 1 : -1);
                        }
                    });

                }
            Task.WaitAll(tskList);
            return assArr;
        }
        public Tuple<byte, byte> GetNextStep(Player pl)
        {
            var assArr = GetNextStepAssesment(pl);
            return Tuple.Create((byte)0, (byte)0);
        }
        
    }
}
