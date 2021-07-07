using System.Collections.Generic;

namespace Lab3_tictactoe
{
    public class CellLocations
    {
        public const string NW = "NW";
        public const string NC = "NC";
        public const string NE = "NE";
        public const string CW = "CW";
        public const string CC = "CC";
        public const string CE = "CE";
        public const string SW = "SW";
        public const string SC = "SC";
        public const string SE = "SE";

        //Create a new list to add all the cell codes
        private readonly List<int> cellcodes = new List<int>();

        public int Leveldepth { get; }

        public CellLocations(int leveldepth) => this.Leveldepth = leveldepth;

        //method to return cellcode list created from cell inputs
        public List<int> ReturnCellCodes()
        {
            return cellcodes;
        }

        //converting String cell codes and adding the integer value of them to the cellcodes list
        public void AddCellCodes(string codes)
        {
            cellcodes.Add(CellNumber(codes));
        }
        //adds the cell codes in integer value
        public void AddCellCodes(int codes)
        {
            cellcodes.Add(codes);
        }
        //returns the codes as a string with comma seperator
        public string GetAsCodes(string CommaSeparator)
        {
            List<string> StringList = new List<string>(); 
            foreach (var cell in cellcodes)
            {
                Cells location = (Cells)cell;
                StringList.Add(location.ToString());

            }
            return string.Join(CommaSeparator, StringList.ToArray());
        }

        //Returns int value for the respective string code
        private int CellNumber(string value)
        {
            return value switch
            {
                NW => (int)Cells.NW,
                NC => (int)Cells.NC,
                NE => (int)Cells.NE,
                CW => (int)Cells.CW,
                CC => (int)Cells.CC,
                CE => (int)Cells.CE,
                SW => (int)Cells.SW,
                SC => (int)Cells.SC,
                SE => (int)Cells.SE,
                _ => 0,
            };
        }

    }

}



