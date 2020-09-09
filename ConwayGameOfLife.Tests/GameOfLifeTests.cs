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

        [Fact]
        public void Step_DeadCellWithThreeLiveNeighbours_ComesAlive()
        {
            var gameBoard = new GameBoard(@"
DADD
AAAD
DDDD
DDDD".Trim());

            gameBoard.Step();

            var expected = @"
AAAD
AAAD
DADD
DDDD".Trim();


            Assert.Equal(gameBoard.ToString(), expected);
        }

        [Fact]
        public void Step_LiveCellWithLessThanTwoLiveNeigbours_Dies()
        {
            var gameBoard = new GameBoard(@"
AADD
DDAD
DDDD
DDDD".Trim());
            gameBoard.Step();

            var expected = @"
DADD
DADD
DDDD
DDDD".Trim();


            Assert.Equal(gameBoard.ToString(), expected);

        }

        [Fact]
        public void Step_LiveCellWithMoreThanThreeLiveNeighbours_Dies()
        {
            var gameBoard = new GameBoard(@"
DADD
AAAD
DADD
DDDD".Trim());

            gameBoard.Step();

            var expected = @"
AAAD
ADAD
AAAD
DDDD".Trim();


            Assert.Equal(gameBoard.ToString(), expected);


        }

    }


    public class GameBoard
    {
        private char _alive;
        private char _dead;
        private List<string> _state;
        public int Width { get { return _state.Max(x => x.Length); } }
        public int Height { get { return _state.Count; } }

        public GameBoard(string state, char alive = 'A', char dead = 'D')
        {
            _state = state.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            _alive = alive;
            _dead = dead;

        }

        public void Step()
        {
            var newState = new List<string>();
            for (var y = 0; y < Height; y++)
            {
                var thisLine = "";
                for (var x = 0; x < Width; x++)
                {
                    var transformed = CalculateNewState(x, y);
                    thisLine += transformed;
                }

                newState.Add(thisLine);
            }

            _state = newState;
        }

        private object CalculateNewState(int x, int y)
        {
            var cell = _state[y][x];
            var neighbours = GetNeighbours(x, y);
            int liveNeighbours = neighbours.Count(n => n == _alive);
            if (cell == _dead && liveNeighbours == 3)
            {
                return _alive;
            }

            if (cell != _alive) return cell;

            if (liveNeighbours < 2 || liveNeighbours > 3)
            {
                return _dead;
            }

            return cell;
        }

        private IEnumerable<char> GetNeighbours(int x, int y)
        {
            var coords = new List<Coord> {
                new Coord(x - 1, y - 1),
                new Coord(x - 1, y),
                new Coord(x - 1, y + 1),
                new Coord(x, y - 1),
                new Coord(x, y+1),
                new Coord(x + 1, y - 1),
                new Coord(x + 1, y),
                new Coord(x + 1, y + 1)
            };

            var neighbours = new List<char>();
            foreach (var coord in coords)
            {
                try
                {
                    var neighbouringCell = _state[coord.Y][coord.X];
                    neighbours.Add(neighbouringCell);
                }
                catch
                {
                }
            }

            return neighbours;
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

    public class Coord
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }

    }

}
