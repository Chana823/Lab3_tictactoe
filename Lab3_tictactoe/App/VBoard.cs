using System.Collections.Generic;

namespace Lab3_tictactoe
{
    //VBoard is a collection of 9 cell Boards
    public class VBoard : IBoard
    {
        private IDBoard DBoard;
        private int level;
        private int win;
        private List<IBoard> boards = new List<IBoard>();
        private static readonly List<int> lists = new List<int>();
        private readonly List<int> winning = lists;


        public VBoard(IDBoard board)
        {
            DBoard = board;
        }

        public bool BuildBoard(IBoard board)
        {
            boards.Add(board);
            return true;
        }

        public IBoard CloneBoard()
        {
            VBoard clone = (VBoard)MemberwiseClone();
            clone.boards = boards.ConvertAll(bd => bd.CloneBoard());
            return clone;
        }
        public void SetWinner(int win)
        {
            this.win = win;
            DBoard.WinCount(this.level, win);

        }
        public int ReturnWinner()
        {
            return win;
        }
        public void LevelSetter(int level)
        {
            this.level = level;
        }

        public int FindTreeWin(List<int> cellNumber)
        {
            int find = cellNumber[0];
            List<int> win = new List<int>(cellNumber);
            win.RemoveAt(0);


            int selected = ReturnSelectedBoard(find).FindTreeWin(win);
            if (selected == 0)
            {
                return 0;
            }
            DBoard.LargeCellWin(level, selected, find);

            return FindTreeWin();
        }
        private int FindTreeWin()
        {
            if (boards[0].ReturnWinner() != 0 && 
                boards[0].ReturnWinner() == boards[1].ReturnWinner() && 
                boards[0].ReturnWinner() == boards[2].ReturnWinner())
            {
                winning.Add(0);
                winning.Add(1);
                winning.Add(2);
                SetWinner(boards[0].ReturnWinner());
                return ReturnWinner();
            }
            else if (boards[3].ReturnWinner() != 0 && 
                boards[3].ReturnWinner() == boards[4].ReturnWinner() && 
                boards[3].ReturnWinner() == boards[5].ReturnWinner())
            {
                winning.Add(3);
                winning.Add(4);
                winning.Add(5);
                SetWinner(boards[3].ReturnWinner());
                return ReturnWinner();
            }
            else if (boards[6].ReturnWinner() != 0 && 
                boards[6].ReturnWinner() == boards[7].ReturnWinner() && 
                boards[6].ReturnWinner() == boards[8].ReturnWinner())
            {
                winning.Add(6);
                winning.Add(7);
                winning.Add(8);
                SetWinner(boards[6].ReturnWinner());
                return ReturnWinner();
            }
            else if (boards[0].ReturnWinner() != 0 && 
                boards[0].ReturnWinner() == boards[3].ReturnWinner() && 
                boards[0].ReturnWinner() == boards[6].ReturnWinner())
            {
                winning.Add(0);
                winning.Add(3);
                winning.Add(6);
                SetWinner(boards[0].ReturnWinner());
                return ReturnWinner();
            }
            else if (boards[1].ReturnWinner() != 0 && 
                boards[1].ReturnWinner() == boards[4].ReturnWinner() && 
                boards[1].ReturnWinner() == boards[7].ReturnWinner())
            {
                winning.Add(1);
                winning.Add(4);
                winning.Add(7);
                SetWinner(boards[1].ReturnWinner());
                return ReturnWinner();
            }
            else if (boards[2].ReturnWinner() != 0 && 
                boards[2].ReturnWinner() == boards[5].ReturnWinner() && 
                boards[2].ReturnWinner() == boards[8].ReturnWinner())
            {
                winning.Add(2);
                winning.Add(5);
                winning.Add(8);
                SetWinner(boards[2].ReturnWinner());
                return ReturnWinner();
            }
            else if (boards[0].ReturnWinner() != 0 && 
                boards[0].ReturnWinner() == boards[4].ReturnWinner() && 
                boards[0].ReturnWinner() == boards[8].ReturnWinner())
            {
                winning.Add(0);
                winning.Add(4);
                winning.Add(8);
                SetWinner(boards[0].ReturnWinner());
                return ReturnWinner();
            }
            else if (boards[2].ReturnWinner() != 0 && 
                boards[2].ReturnWinner() == boards[4].ReturnWinner() && 
                boards[2].ReturnWinner() == boards[6].ReturnWinner())
            {
                winning.Add(2);
                winning.Add(4);
                winning.Add(6);
                SetWinner(boards[2].ReturnWinner());
                return ReturnWinner();
            }

            return 0;
        }

        public bool CrossCell(int player, List<int> cellNumber)

        //Recursion method used here to mark the cell
        {
            int find = cellNumber[0];
            List<int> win = new List<int>(cellNumber);
            win.RemoveAt(0);
            return ReturnSelectedBoard(find).CrossCell(player, win); 

        }

        public bool FindWin(int player, List<int> cellNumber)
        {
            int find = cellNumber[0];
            List<int> win = new List<int>(cellNumber);
            win.RemoveAt(0);
            return ReturnSelectedBoard(find).FindWin(player, win);

        }

        private IBoard ReturnSelectedBoard(int number)
        {

            return number switch
            {
                0 => boards[0],
                1 => boards[1],
                2 => boards[2],
                3 => boards[3],
                4 => boards[4],
                5 => boards[5],
                6 => boards[6],
                7 => boards[7],
                8 => boards[8],
                _ => boards[0],
            };
        }
        public IBoard CloneAdd(IBoard vB, IBoard board)
        {
            vB.BuildBoard(board.CloneBoard());
            vB.BuildBoard(board.CloneBoard());
            vB.BuildBoard(board.CloneBoard());
            vB.BuildBoard(board.CloneBoard());
            vB.BuildBoard(board.CloneBoard());
            vB.BuildBoard(board.CloneBoard());
            vB.BuildBoard(board.CloneBoard());
            vB.BuildBoard(board.CloneBoard());
            vB.BuildBoard(board.CloneBoard());

            return vB;
        }
    }
}
