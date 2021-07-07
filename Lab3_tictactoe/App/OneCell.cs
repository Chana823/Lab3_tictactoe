namespace Lab3_tictactoe
{
    public class OneCell : IOneCell
    {
        private int value;

        public OneCell()
        {
        }
        public void PlaceValue(int cross)
        {
            value = cross;
        }
        public int ReturnValue()
        {
            return value;
        }

        public bool Cross(int x)
        {
            PlaceValue(x);
            return true;
        }
    }
}
