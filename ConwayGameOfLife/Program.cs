using System;
using System.Threading;

namespace ConwayGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialState = @"
o.........
.o.o......
...o.o....
....o.....
..o...o...
.o.o..o...
..........".Trim();

            var gameBoard = new GameBoard(initialState, 'o', '.');

            for (int i = 0; i < 100; i++)
            {
                var output = gameBoard.ToString();
                Console.Clear();
                Console.WriteLine(output);

                Thread.Sleep(250);
                gameBoard.Step();

            }
        }
    }
}
