using System.Linq;
using WordSearch.Models;
using WordSearch.Repositories;

namespace WordSearch.Services
{
    public class GridService : IGridService
    {
        private readonly IGridDataAccess gridDataAccess;
        public GridService(IGridDataAccess _gridDataAccess)
        {
            gridDataAccess = _gridDataAccess;
        }

        public char[,] Grid()
        {
            return gridDataAccess.GetGrid();
        }

        public GridModel FormattedGrid()
        {
            var grid = gridDataAccess.GetGrid();
            // Flatten 12x12 2d array
            var flatGrid = grid.Cast<char>().ToArray();

            // Map to Model
            var cells = flatGrid.Select((value, index) => new CellModel { value = value, Position = new PositionModel { X = calculateX(index), Y = calculateY(index) } });

            return new GridModel
            {
                Cells = cells,
                Width = grid.GetLength(1),
                Height = grid.GetLength(0)
            };
        }

        private int calculateX(int index)
        {
            return index < 12 ? index : index % 12;
        }

        private int calculateY(int index)
        {
            return index < 12 ? 0 : index / 12;
        }
    }
}
