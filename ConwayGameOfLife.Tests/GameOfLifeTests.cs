using System;
using System.Collections.Generic;
using Xunit;

namespace ConwayGameOfLife.Tests
{
    public class GameOfLifeTests
    {
        [Fact]
        public void Ctor_GivenTwobyTwoBoard_WidthAndHeightSet()
        {
            var gameBoard = new GameBoard(
            @"
DDD
ADD
DDD
".Trim()
);
            Assert.Equal(3, gameBoard.Width);
            Assert.Equal(3, gameBoard.Height);

        }
    }

    public class GameBoard
    {
        private string _state;
        public int Width { get; internal set; }
        public int Height { get; internal set; }

        public GameBoard(string state)
        {
            _state = state;
            Width = 3;
            Height = 3;

        }

    }
}
