using WordSearch.Models;

namespace WordSearch.Services
{
    public interface IGridService
    {
        char[,] Grid();
        GridModel FormattedGrid();
    }
}
