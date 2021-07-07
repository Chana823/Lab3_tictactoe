namespace Lab3_tictactoe
{
    //EmptyCells use to instantiate the board
   
    public class EmptyCell:IOneCell
    {
        private int value;
        public EmptyCell()
        {
        }

        public void PlaceValue(int value)
        {
            this.value = 0;
        }

        public bool Cross(int cross)
        {
            return false;
        }


        public int ReturnValue()
        {
            value = 0;
            return value;
        }
        

        
    }

}
