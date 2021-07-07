# Lab3_tictactoe

How Program Works - 

This is a brief discussion about the process of the tictactoe program and how the related methods and variables connected together to out put the results.


The program consist of total 10 classes including main class, Game, Board, VBoard, DBoard, CellLocations, OneCell, EmptyCell, Constants, Enums and 3 interfaces namely IBoard, 
IDBoard, IOneCell. A Separate Test project has been added to the program to write tests. Once the input arguments are given to the command terminal, the entry point to the 
program, main method runs which contains a string array of arguments (args). At first the program check whether the argument length is 1 and if not, it returns an error about 
the invalid cell input. When length equals to 1, the arguments will be passed to an input string called ‘cellinputs’ (Game.Playnow(cellinputs)) and passes to the ‘Playnow’ 
method in ‘Game’ class.

The ‘Playnow’ method in Game class firstly removes all the duplicates from the cell input arguments and split them by comma and pass them to an array. It also take the level 
depth of the boards by taking the first index of the created array and split them by dot. Then a new list called ‘item’ from ‘CellLocations’ class is created to store the cell 
locations with respective enums. One important factor here is that the method, ‘CellNumber’ in ‘CellLocations’ class returns the integer value for a particular cell code with 
the use of ‘CellLocations’ enums. Now the created array goes through a foreach loop to check whether that each cell data equivalent to the same level depth. Each cell is split 
with a dot and create a new string called ‘cellData’ which contains the splitted codes. If all elements does not have the same level depth it outputs an error, if it contains 
the same level, a new object called ‘cellLocation’ is created to store the locations. The respective integer values of ‘code’ paramenter in ‘AddCellCodes’ method is added to the newly created object. Then the ‘item’ list is added to the ‘cellLocation’ object which contains all the integer values.
In the next step, a new instance of DBoard is created called ‘dBoard’. DBoard class contains all the meta data of the tic-tac-toe game, the winnings of small and large boards. 
Next it use tree data structure to setup boards by passing ‘dBoard’. Now it checks whether the leveldepth is greater than 1 and creates a new instance of the VBoard called ‘vB’.
The Program has an interface called IBoard which uses composite design pattern and it inherits in to Board and VBoard. ‘vB’ calls for ‘LevelSetter’ method in ‘VBoard’ which 
contains the ‘level’ variable and hard code it as 1 to set the leveldepth 1. Next steps is about creating boards with tree data structures. ‘vB’ calls for ‘CloneAdd’ method 
in ‘VBoard’ to make the leveldepth 2 boards. Board is a simple unit which consist of One 9 cell small board. VBoard is a collection of 9 cell boards. Board class has implemented with 9 empty cells which uses null design pattern to handle null instances.
Game class have a dictionary called ‘AddMoves’ to store key-value pairs. It stores all the moves for player 1 and player 2. Now the program has created both dictionary and the 
board. We start with Player 1 and then goes through a foreach loop to iterate through every cell parameter in item list which contains all the moves with respected integer value and call for ‘FindTreeWin’ method from the whole board to find the winner after every move in each layer. Then we change to player 2 and iterate through the same process. Next, if the ‘ReturnWinner’ methods returns a 0 means a valid winner is not found. The if loop here check whether a winner is found in related to the key
in ‘AddMoves’ dictionary and when a winner is found we check their respective winning moves. Values in dictionary contains the related moves of the player. Here we only outputs the winning moves by ignoring the random moves.
Lastly, the main program have a method called ‘Validwinner’ to find whether a valid winner is present for the Game. It outputs an error if no winner is found for the moves. If it is valid, it prints 3 key outputs, LargeWin, SmallWin and WinCount to the terminal.

Design Patterns used in the program - 

There are 3 main design patterns used in this program namely composite pattern, null pattern and the prototype pattern. The core of this program presented in a tree structure and when it comes to tree structure objects, Composite design pattern is the most appropriate and it breaks the complexity in to parents and child’s to work as individual objects. I have also used the recursion method to find out the cumulative result and get the final output of the tree. In this program the VBoard implemented as the parent while Board act as the child component. When it comes to creating the board, a list has been implemented in VBoard which is declared with IBoard to store the objects of Board and VBoard (private List<IBoard> boards = new List<IBoard>();). The interface method (FindTreeWin()) of IBoard has implemented in both Board and VBoard to find out the winner for the tree. Also the CrossCell() interface method is implemented in both classes to cross mark the cells by traversing through the tree with respective player’s value. Value means the symbol that player marked (X/O).

The null pattern is used in the program to handle all the null instances. The empty cells and cross marked cells are differentiated with the use of null pattern in the program. The interface class ‘IOneCell’ inherits in to OneCell and EmptyCell where OneCell represents a cross marked cell and EmptyCell which mark as 0 represents a cell that is not marked by a player. The program use EmptyCell to create the Board at the first place. Then an instance of Board class is implemented to create a list of 9 EmptyCell and 0 is marked as the default value for all the cells. When the input arguments are given to the terminal, the program converts them to integers. The CrossCell() method in Board represent the mark symbol of OneCell.

Prototype design pattern is also used in the program which helped to clone the objects. Both Composite and Prototype design patterns work together in this program in Board class, Interface IBoard and the VBoard. Board class clone itself while the deep copy, which copies the entire object graph happens with the VBoard. The clone method used in creating boards depends on the level depth. The interface method CloneAdd() in IBoard interface, clone boards for 9 times and adds to the IBoard list. The board is setting up as a tree structure and after finishing of creating boards the IBoard list contains a list of cloned IBoards based on level depth.


Software Maintainability with OOP concepts - 

The program supports number of OOP concepts for software maintainability. Maintainable code is easy to fix and very organized to find errors and fix them immediately.

Encapsulation - 
Introducing three interfaces to hide the values and state of the objects in relevant classes reveals how encapsulation works in the program. Private methods are used in Board and VBoard classes and hid their information using the interface to put restrictions on accessing variables and methods directly by other classes. This shows how separating interfaces from implementation works to manage data access. Interfaces also allowed to achieve loose coupling in the modules which reveals “Low in coupling, High in cohesion”.

Reusability - 
The project files are stored in a particular folder structure as Interfaces, App and Utility for easy maintenance and organization of the code. Constants and Enumerations are moved in to separate files. So, if we need to do a change or introduce new constants and enums we can directly add them to those places and can use in the application codebase. This will avoid duplicate codes and improve reusability.

Single Responsibility - 
Single responsibility principle in SOLID has implemented throughout the code by giving small piece of responsibility in each class. One good example is Dashboard class which responsible for handling only all the meta data of the application.

Open closed principle - 
Open closed principle has been followed in the code to being open for easy extensions. The application has introduced IBoard interface which inherits in to Board and VBoard to provide interface abstraction while avoiding the dependency on implementing the module. Adding new components can be easily achieved by adding them to the tree structure without changing the code.

Replacing conditionals with polymorphism - 
The code also follows replacing conditionals with polymorphism refactoring technique by not using conditionals to check the type of the objects to refer to a particular method. As an example FindTreeWin(), CrossCell() and FindWin() methods in VBoard calls to the private method IBoard ReturnSelectedBoard() which returns a VBoard or a Board at runtime. The type of the IBoard is verified at the runtime and respective method declared in both are called at runtime. This could be illustrated as a good example that polymorphism has been used.

Testability - 
TicTacToeTest Unit testing module has implemented to test individual units of the programs to validate each code performs as expected. When we have test and when we do the code changes tests should be passes. Test make sure that our implementation will not break any existing functionality.

Richard Fledman’s “Making the impossible states impossible.” - 
The enums were declared in the program to hold only the allowed code combinations to run the application. If a user tries to enter invalid input to the terminal which is not declared in the program, it throws an error. If a user needs to make any modifications to add a new input code combination in future, it can easily get through specifying the constant and corresponding enumeration to it. Also, I put enum as a separate file to make future changes easier. This proves Richard Fledman’s popular phrase “making the impossible states impossible” where if a user inputs the correct input, it will output the correct result and on the other hand it treats the impossible inputs as impossible
