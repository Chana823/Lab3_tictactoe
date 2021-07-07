using System;
using Xunit;
using Lab3_tictactoe;
public class UnitTest
{
    private string cellinputs = string.Empty;
    string OutputOne = string.Empty;
    string OutputTwo = string.Empty;
    string OutputThree = string.Empty;

    [Fact]
    public void FirstTest()
    {
        cellinputs = "NW.CC,NC.CC,NW.NW,NE.CC,NW.SE,CE.CC,CW.CC,SE.CC,CW.NW,CC.CC,CW.SE,CC.NW,CC.SE,CE.NW,SW.CC,CE.SE,SW.NW,SE.SE,SW.SE";
        OutputOne = "NW,CW,SW";
        OutputTwo = "NW.CC,NW.NW,NW.SE,CW.CC,CW.NW,CW.SE,SW.CC,SW.NW,SW.SE"; 
        OutputThree = "1.3 0.1";

        Game Game = new Game();
        Game.Playnow(cellinputs);

        Assert.Equal(OutputOne, Game.LargeWin());
        Assert.Equal(OutputTwo, Game.SmallWin());
        Assert.Equal(OutputThree, Game.WinCount());
    }
    [Fact]
    public void SecondTest() 
    {
        cellinputs = "NW,CC,SE,NE,SE,SC,SW";
        OutputOne = "CC,NE,SW";
        OutputTwo = "CC,NE,SW";
        OutputThree = "0 1";

        Game Game = new Game();
        Game.Playnow(cellinputs);

        Assert.Equal(OutputOne, Game.LargeWin());
        Assert.Equal(OutputTwo, Game.SmallWin());
        Assert.Equal(OutputThree, Game.WinCount());
    }
    [Fact]
    public void ThirdTest()
    {
        cellinputs = "NW.NW.NW,NC.NW.NW,NC.NW.NW,NW.NW.CC,NW.SW.SW,NW.NW.SE,CW.SW.SW,NW.CC.NW,SW.SW.SW,NW.CC.CC,NC.SW.SW,NW.CC.SE,CC.SW.SW,NW.SE.NW,SC.SW.SW,NW.SE.CC,NE.SW.SW,NW.SE.SE,CE.SW.SW,CW.NW.NW,SE.SW.SW,CW.NW.CC,NW.SW.CC,CW.NW.SE,CW.SW.CC,CW.CC.NW,SW.SW.CC,CW.CC.CC,NC.SW.CC,CW.CC.SE,CC.SW.CC,CW.SE.NW,SC.SW.CC,CW.SE.CC,NE.SW.CC,CW.SE.SE,CE.SW.CC,SW.NW.NW,SE.SW.CC,SW.NW.CC,NW.SW.SE,SW.NW.SE,CW.SW.SE,SW.CC.NW,SW.SW.SE,SW.CC.CC,NC.SW.SE,SW.CC.SE,CC.SW.SE,SW.SE.NW,SC.SW.SE,SW.SE.CC,NE.SW.SE,SW.SE.SE";
        OutputOne = "NW,CW,SW";
        OutputTwo = "NW.NW.NW,NW.NW.CC,NW.NW.SE,NW.CC.NW,NW.CC.CC,NW.CC.SE,NW.SE.NW,NW.SE.CC,NW.SE.SE,CW.NW.NW,CW.NW.CC,CW.NW.SE,CW.CC.NW,CW.CC.CC,CW.CC.SE,CW.SE.NW,CW.SE.CC,CW.SE.SE,SW.NW.NW,SW.NW.CC,SW.NW.SE,SW.CC.NW,SW.CC.CC,SW.CC.SE,SW.SE.NW,SW.SE.CC,SW.SE.SE";
        OutputThree = "1.3.9 0.0.0";

        Game Game = new Game();
        Game.Playnow(cellinputs);

        Assert.Equal(OutputOne, Game.LargeWin());
        Assert.Equal(OutputTwo, Game.SmallWin());
        Assert.Equal(OutputThree, Game.WinCount());
    }
    [Fact]
    public void FourthTest()
    {
        cellinputs = "CW.CC,SE.CC,CW.NW,CC.CC,CW.SE,CC.NW,CC.SE,CE.NW,NW.CC,NC.CC,NW.NW,NE.CC,NW.SE,CE.CC,SW.CC,CE.SE,SW.NW,SE.SE,SW.SE";
        OutputOne = "CW,NW,SW";
        OutputTwo = "CW.CC,CW.NW,CW.SE,NW.CC,NW.NW,NW.SE,SW.CC,SW.NW,SW.SE";
        OutputThree = "1.3 0.1";

        Game Game = new Game();
        Game.Playnow(cellinputs);

        Assert.Equal(OutputOne, Game.LargeWin());
        Assert.Equal(OutputTwo, Game.SmallWin());
        Assert.Equal(OutputThree, Game.WinCount());
    }
}