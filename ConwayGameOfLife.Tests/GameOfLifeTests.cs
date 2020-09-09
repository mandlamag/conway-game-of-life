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

}
