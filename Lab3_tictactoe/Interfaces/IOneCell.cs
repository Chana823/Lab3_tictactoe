namespace Lab3_tictactoe
{
    public interface IOneCell
    {
        //Places the value for cell
        public void PlaceValue(int value);

        //returns the value
        public int ReturnValue();

        //Crossmark a cell 
        public bool Cross(int cross);
    }
}
