using System.Collections.Generic;

namespace Lab3_tictactoe
{
    //Board is a one simple unit which has one small 9 cells
    public class Board : IBoard
    {
        #region Public Methods

        public Board(IDBoard board)
        {
            dBoard = board;
            cellunit[0, 0] = new EmptyCell();
            cellunit[0, 1] = new EmptyCell();
            cellunit[0, 2] = new EmptyCell();
            cellunit[1, 0] = new EmptyCell();
            cellunit[1, 1] = new EmptyCell();
            cellunit[1, 2] = new EmptyCell();
            cellunit[2, 0] = new EmptyCell();
            cellunit[2, 1] = new EmptyCell();
            cellunit[2, 2] = new EmptyCell();
        }
        public IBoard CloneBoard()
        {
            Board clone = new Board(dBoard);
            return clone;
        }
        public void LevelSetter(int level)
        {
            this.level = level;
        }

        public void SetWinner(int win)
        {
            this.win = win;
            dBoard.WinCount(this.level, win);
        }
        public int ReturnWinner()
        {
            return win;
        }

        public int FindTreeWin(List<int> cellNumber)
        {
            if (cellunit[0, 0].ReturnValue() != 0 && 
                cellunit[0, 0].ReturnValue() == cellunit[0, 1].ReturnValue() && 
                cellunit[0, 0].ReturnValue() == cellunit[0, 2].ReturnValue())
            {
                winning.Add(0);
                winning.Add(1);
                winning.Add(2);
                SetWinner(cellunit[0, 0].ReturnValue());
                return ReturnWinner();
            }
            else if (cellunit[1, 0].ReturnValue() != 0 && 
                cellunit[1, 0].ReturnValue() == cellunit[1, 1].ReturnValue() && 
                cellunit[1, 0].ReturnValue() == cellunit[1, 2].ReturnValue())
            {
                winning.Add(3);
                winning.Add(4);
                winning.Add(5);
                SetWinner(cellunit[1, 0].ReturnValue());
                return ReturnWinner();
            }
            else if (cellunit[2, 0].ReturnValue() != 0 && 
                cellunit[2, 0].ReturnValue() == cellunit[2, 1].ReturnValue() && 
                cellunit[2, 0].ReturnValue() == cellunit[2, 2].ReturnValue())
            {
                winning.Add(6);
                winning.Add(7);
                winning.Add(8);
                SetWinner(cellunit[2, 0].ReturnValue());
                return ReturnWinner();
            }
            else if (cellunit[0, 0].ReturnValue() != 0 && 
                cellunit[0, 0].ReturnValue() == cellunit[1, 0].ReturnValue() && 
                cellunit[0, 0].ReturnValue() == cellunit[2, 0].ReturnValue())
            {
                winning.Add(0);
                winning.Add(3);
                winning.Add(6);
                SetWinner(cellunit[0, 0].ReturnValue());
                return ReturnWinner();
            }
            else if (cellunit[0, 1].ReturnValue() != 0 && 
                cellunit[0, 1].ReturnValue() == cellunit[1, 1].ReturnValue() && 
                cellunit[0, 1].ReturnValue() == cellunit[2, 1].ReturnValue())
            {
                winning.Add(1);
                winning.Add(4);
                winning.Add(7);
                SetWinner(cellunit[0, 1].ReturnValue());
                return ReturnWinner();
            }
            else if (cellunit[0, 2].ReturnValue() != 0 && 
                cellunit[0, 2].ReturnValue() == cellunit[1, 2].ReturnValue() && 
                cellunit[0, 2].ReturnValue() == cellunit[2, 2].ReturnValue())
            {
                winning.Add(2);
                winning.Add(5);
                winning.Add(8);
                SetWinner(cellunit[0, 2].ReturnValue());
                return ReturnWinner();
            }
            else if (cellunit[0, 0].ReturnValue() != 0 && 
                cellunit[0, 0].ReturnValue() == cellunit[1, 1].ReturnValue() && 
                cellunit[0, 0].ReturnValue() == cellunit[2, 2].ReturnValue())
            {
                winning.Add(0);
                winning.Add(4);
                winning.Add(8);
                SetWinner(cellunit[0, 0].ReturnValue());
                return ReturnWinner();
            }
            else if (cellunit[0, 2].ReturnValue() != 0 && 
                cellunit[0, 2].ReturnValue() == cellunit[1, 1].ReturnValue() && 
                cellunit[0, 2].ReturnValue() == cellunit[2, 0].ReturnValue())
            {
                winning.Add(2);
                winning.Add(4);
                winning.Add(6);
                SetWinner(cellunit[0, 2].ReturnValue());
                return ReturnWinner();
            }
            return 0;
        }

        public bool CrossCell(int player, List<int> cellNumber)
        {
            int find = cellNumber[0];
            return ReturnSelectedCell(find).Cross(player);
        }

        public bool FindWin(int player, List<int> cellNumber)
        {
            if (player == win)
            {
                return winning.Contains(cellNumber[0]);
            }
            return false;
        }

        public bool BuildBoard(IBoard board)
        {
            return true;
        }

        public IBoard CloneAdd(IBoard vBoard, IBoard board)
        {
            return vBoard;
        }

        #endregion

        #region Private Methods

        private IDBoard dBoard;
        private int level;
        private int win;
        private readonly IList<int> winning = new List<int>();

        private IOneCell[,] cellunit = new IOneCell[3, 3];


        private IOneCell ReturnSelectedCell(int number)
        {

            switch (number)
            {

                case 0:
                    cellunit[0, 0] = new OneCell();
                    return cellunit[0, 0];
                case 1:
                    cellunit[0, 1] = new OneCell();
                    return cellunit[0, 1];
                case 2:
                    cellunit[0, 2] = new OneCell();
                    return cellunit[0, 2];
                case 3:
                    cellunit[1, 0] = new OneCell();
                    return cellunit[1, 0];
                case 4:
                    cellunit[1, 1] = new OneCell();
                    return cellunit[1, 1];
                case 5:
                    cellunit[1, 2] = new OneCell();
                    return cellunit[1, 2];
                case 6:
                    cellunit[2, 0] = new OneCell();
                    return cellunit[2, 0];
                case 7:
                    cellunit[2, 1] = new OneCell();
                    return cellunit[2, 1];
                case 8:
                    cellunit[2, 2] = new OneCell();
                    return cellunit[2, 2];
                default:
                    return cellunit[0, 0];
            }

        }

        #endregion


    }

}
