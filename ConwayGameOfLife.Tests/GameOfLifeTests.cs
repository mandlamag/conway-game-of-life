using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ConwayGameOfLife.Tests
{
    public class GameOfLifeTests
    {
        [Fact]
        public void Ctor_GivenThreeByThreeBoard_WidthAndHeightSet()
        {
            var gameBoard = new GameBoard(
        @"
ADD
ADD
DDD".Trim()
);
            Assert.Equal(3, gameBoard.Width);
            Assert.Equal(3, gameBoard.Height);

        }


        [Fact]
        public void Ctor_GivenFivebyFixBoard_WidthAndHeightSet()
        {
            var gameBoard = new GameBoard(
        @"
ADDDD
ADDDD
ADDDD
AAADD
DDDDD".Trim()
);
            Assert.Equal(5, gameBoard.Width);
            Assert.Equal(5, gameBoard.Height);

        }


        [Fact]
        public void Step_CellsAreAllDead_NothingLives()
        {
            var gameBoard = new GameBoard(@"
DDDD
DDDD
DDDD
DDDD".Trim());
            gameBoard.Step();

            var expected = @"
DDDD
DDDD
DDDD
DDDD".Trim();
            Assert.Equal(gameBoard.ToString(), expected);


        }


    }




    public class GameBoard
    {
        private List<string> _state;
        public int Width { get { return _state.Max(x => x.Length); } }
        public int Height { get { return _state.Count; } }


        public GameBoard(string state)
        {
            _state = state.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();

        }

        public void Step()
        {
            var newState = new List<string>();
            for (var y = 0; y < Height; y++)
            {
                var thisLine = "";
                for (var x = 0; x < Width; x++)
                {
                    var cell = _state[y][x];

                    thisLine += cell;

                }
                newState.Add(thisLine);
            }

            _state = newState;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var line in _state)
            {
                sb.AppendLine(line);

            }
            return sb.ToString().Trim();
        }





    }
}
