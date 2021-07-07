using System.Collections.Generic;

namespace Lab3_tictactoe
{
    #region Public Methods
    //All the meta data of the game handles in this class (Winnings of small and large boards)
    public class DBoard : IDBoard 
    {
        int[] a;
        int[] b;
        int leveldepth;

        IList<int> aLarge = new List<int>();
        IList<int> bLarge = new List<int>();

        public DBoard(int x)
        {
            leveldepth = x;
            a = new int[x];
            b = new int[x];
        }

        public int[] GetA()
        {
            return a;
        }
        public int[] GetB()
        {
            return b;
        }


        //stores large cell winnings
        public void LargeCellWin(int level, int player, int board)
        {
            if (leveldepth - 1 == level)
            {
                if (player == 1)
                {

                    aLarge.Add(board);
                }
                else
                {
                    bLarge.Add(board);
                }
            }
        }

        //stores level wise win count 
        public void WinCount(int level, int player)
        {
            if (player == 1)
            {
                a[level] = a[level] + 1;
            }
            else
            {
                b[level] = b[level] + 1; 
            }

        }

        // returns large cell winnings
        public string GetLargeWins(int player) 
        {
            if (player == 1)
            {
                CellLocations cell = new CellLocations(3);
                foreach (var c in aLarge)
                {
                    cell.AddCellCodes(c);
                }
                return cell.GetAsCodes(Constants.Comma);
            }
            else if (player == 2)
            {
                CellLocations cell = new CellLocations(3);
                foreach (var c in bLarge)
                {
                    cell.AddCellCodes(c);
                }
                return cell.GetAsCodes(Constants.Comma);
            }
            return string.Empty;
        }

    }
    #endregion
}
