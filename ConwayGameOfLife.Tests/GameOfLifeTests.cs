using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
