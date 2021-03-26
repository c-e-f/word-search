using System;
using System.Collections.Generic;
using System.Linq;
using WordSearch.Models;

namespace WordSearch.Services
{
    public class SearchService : ISearchService
    {
        public SearchService() { }

        public bool SearchRight(WordModel word, GridModel grid, PositionModel position)
        {
            var gridSlice = grid.Cells
                .Where(cell => cell.Position.Y == position.Y && cell.Position.X >= position.X && cell.Position.X < position.X + word.Name.Length)
                .Select(cell => cell.value);
            var stringToCompare = string.Join("", gridSlice);

            return word.Name == stringToCompare ? true : false;
        }

        public bool SearchLeft(WordModel word, GridModel grid, PositionModel position)
        {
            var gridSlice = grid.Cells
                .Where(cell => cell.Position.Y == position.Y && cell.Position.X > position.X - word.Name.Length && cell.Position.X < position.X + 1)
                .Select(cell => cell.value)
                .Reverse();
            var stringToCompare = string.Join("", gridSlice);

            return word.Name == stringToCompare ? true : false;
        }

        public bool SearchDown(WordModel word, GridModel grid, PositionModel position)
        {
            var gridSlice = grid.Cells
                .Where(cell => cell.Position.X == position.X && cell.Position.Y >= position.Y && cell.Position.Y < position.Y + word.Name.Length)
                .Select(cell => cell.value);
            var stringToCompare = string.Join("", gridSlice);

            return word.Name == stringToCompare ? true : false;
        }

        public bool SearchUp(WordModel word, GridModel grid, PositionModel position)
        {
            var gridSlice = grid.Cells
                .Where(cell => cell.Position.X == position.X && cell.Position.Y > position.Y - word.Name.Length && cell.Position.Y < position.Y + 1)
                .Select(cell => cell.value)
                .Reverse();
            var stringToCompare = string.Join("", gridSlice);

            return word.Name == stringToCompare ? true : false;
        }

        public bool SearchRightDown(WordModel word, GridModel grid, PositionModel position)
        {
            var gridSlice = new List<char>();
            var max = word.Name.Length;
            var i = 0;

            while (i < max)
            {
                var nextCellValue = grid.Cells
                    .Where(cell => cell.Position.X == position.X + i && cell.Position.Y == position.Y + i)
                    .Select(cell => cell.value)
                    .FirstOrDefault();
                gridSlice.Add(nextCellValue);
                i++;
            }
            var stringToCompare = string.Join("", gridSlice);

            return word.Name == stringToCompare ? true : false;
        }

        public bool SearchRightUp(WordModel word, GridModel grid, PositionModel position)
        {
            var gridSlice = new List<char>();
            var max = word.Name.Length;
            var i = 0;

            while (i < max)
            {
                var nextCellValue = grid.Cells
                    .Where(cell => cell.Position.X == position.X + i && cell.Position.Y == position.Y - i)
                    .Select(cell => cell.value)
                    .FirstOrDefault();
                gridSlice.Add(nextCellValue);
                i++;
            }
            var stringToCompare = string.Join("", gridSlice);

            return word.Name == stringToCompare ? true : false;
        }

        public bool SearchLeftDown(WordModel word, GridModel grid, PositionModel position)
        {
            var gridSlice = new List<char>();
            var max = word.Name.Length;
            var i = 0;

            while (i < max)
            {
                var nextCellValue = grid.Cells
                    .Where(cell => cell.Position.X == position.X - i && cell.Position.Y == position.Y + i)
                    .Select(cell => cell.value)
                    .Reverse()
                    .FirstOrDefault();
                gridSlice.Add(nextCellValue);
                i++;
            }

            var stringToCompare = string.Join("", gridSlice);

            return word.Name == stringToCompare ? true : false;
        }

        public bool SearchLeftUp(WordModel word, GridModel grid, PositionModel position)
        {
            var gridSlice = new List<char>();
            var max = word.Name.Length;
            var i = 0;

            while (i < max)
            {
                var nextCellValue = grid.Cells
                    .Where(cell => cell.Position.X == position.X - i && cell.Position.Y == position.Y - i)
                    .Select(cell => cell.value)
                    .Reverse()
                    .FirstOrDefault();
                gridSlice.Add(nextCellValue);
                i++;
            }

            var stringToCompare = string.Join("", gridSlice);

            return word.Name == stringToCompare ? true : false;
        }
    }
}
