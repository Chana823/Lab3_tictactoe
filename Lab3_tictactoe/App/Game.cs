using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3_tictactoe
{
    public class Game
    {
        private int leveldepth;
        private IDBoard dBoard;
        private IBoard board;
        private readonly Dictionary<int, List<CellLocations>> AddMoves = new Dictionary<int, List<CellLocations>>();

        private readonly List<string> WinMoves = new List<string>();


        public void Playnow(string cellinputs)
        {
            //split by commas of the cell input arguments and pass to an array
            string[] stringarr = cellinputs.Split(Constants.Comma).Distinct().ToArray();

            //Split by dots to get the depth level
            leveldepth = stringarr[0].Split(Constants.Dot).Length;

            //Creates a new Cell Locations List
            List<CellLocations> item = new List<CellLocations>();

            foreach (var cell in stringarr)
            {

                //split the cell data line by line by the dot
                string[] cellData = cell.Split(Constants.Dot);

                //Check for each celldata equalant to same level depth
                if (cellData.Length != leveldepth)
                {
                    Console.WriteLine(Constants.ErrorDepth);
                    break;

                }
                else
                {
                    //CellLocations objects to store locations
                    CellLocations cellLocation = new CellLocations(leveldepth); 

                    foreach (string code in cellData)
                    {
                        cellLocation.AddCellCodes(code);

                    }
                    //add cell Location object to item object list
                    item.Add(cellLocation); 
                }
            }


            //creates a new instance of DBoard
            dBoard = new DBoard(leveldepth);

            //Implementing tree structure board
            board = new Board(dBoard);

            if (leveldepth > 1)
            {
                IBoard vB = new VBoard(dBoard);
                //Hardcode the level as 1
                vB.LevelSetter(1);

                //Making the level depth 2 board. Prototype method used here.
                board = vB.CloneAdd(vB, board);

                for (int level = 1; level < leveldepth - 1; level++)
                {
                    IBoard vB1 = new VBoard(dBoard);
                    vB1.LevelSetter(level + 1);
                    board = vB1.CloneAdd(vB1, board);
                }
            }

            AddMoves.Add(1, new List<CellLocations>());
            AddMoves.Add(2, new List<CellLocations>());
            
            int player = 1;
            foreach (CellLocations cellparm in item)
            {

                List<int> cell = cellparm.ReturnCellCodes();
                //Cross mark a cell and find a winner after every move
                bool True = board.CrossCell(player, cellparm.ReturnCellCodes());
                board.FindTreeWin(cell);

                if (True)
                {
                    AddMoves[player].Add(cellparm);

                    //Player change
                    player = player == 1 ? 2 : 1; 

                }

            }

            //Valid winning checker
            if (AddMoves.ContainsKey(board.ReturnWinner()))
            {
                //Return the winning moves orderly
                foreach (CellLocations cellparm in AddMoves[board.ReturnWinner()])
                {
                    List<int> cell = cellparm.ReturnCellCodes();
                    bool move = board.FindWin(board.ReturnWinner(), cellparm.ReturnCellCodes());
                    if (move)
                    {
                        WinMoves.Add(cellparm.GetAsCodes(Constants.Dot));
                    }
                }
            }
        }
        //Validation of a winner
        public bool ValidWinner()
        {
            return !AddMoves.ContainsKey(board.ReturnWinner());
        }
        public string LargeWin()
        {
            if (leveldepth > 1)
            {
                return string.Join(Constants.Comma, dBoard.GetLargeWins(board.ReturnWinner()));
            }
            else
            {
                return string.Join(Constants.Comma, WinMoves.ToArray());
            }

        }
        public string SmallWin()
        {
            return string.Join(Constants.Comma, WinMoves.ToArray());
        }
        public string WinCount()
        {
            return string.Join(Constants.Dot, dBoard.GetA().ToArray().Reverse()) + Constants.Space + string.Join(Constants.Dot, dBoard.GetB().ToArray().Reverse());
        }

    
    } 
}
