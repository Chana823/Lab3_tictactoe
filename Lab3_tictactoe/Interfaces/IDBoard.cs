namespace Lab3_tictactoe
{
    public interface IDBoard
    {
        int[] GetA();
        int[] GetB();

        void LargeCellWin(int level, int player, int board);
        void WinCount(int level, int player);
        string GetLargeWins(int player);
        
    }
}
