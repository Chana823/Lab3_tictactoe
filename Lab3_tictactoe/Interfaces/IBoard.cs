using System.Collections.Generic;

namespace Lab3_tictactoe
{
    //Composite pattern use here
    public interface IBoard
    {
        //setting the winner of the board
        public void SetWinner(int win);

        //Returns the winner
        public int ReturnWinner();

        //Tree structure winner finder
        public int FindTreeWin(List<int> cellNumber);

        //Cross Marks the cells
        public bool CrossCell(int player, List<int> cellNumber);

        //Finding the winning move
        public bool FindWin(int player, List<int> cellNumber);

        //Setting up the board level
        public void LevelSetter(int level);

        //Adding board to the IBoard list
        public bool BuildBoard(IBoard board);

        //Cloning of Boards
        public IBoard CloneBoard();

        //Cloning nine times and adding boards to the IBoard List
        public IBoard CloneAdd(IBoard vB, IBoard board);

    }
}
