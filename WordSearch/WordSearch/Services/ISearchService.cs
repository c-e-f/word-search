
using WordSearch.Models;

namespace WordSearch.Services
{
    public interface ISearchService
    {
        bool SearchRight(WordModel word, GridModel grid, PositionModel position);
        bool SearchLeft(WordModel word, GridModel grid, PositionModel position);
        bool SearchDown(WordModel word, GridModel grid, PositionModel position);
        bool SearchUp(WordModel word, GridModel grid, PositionModel position);
        bool SearchRightDown(WordModel word, GridModel grid, PositionModel position);
        bool SearchRightUp(WordModel word, GridModel grid, PositionModel position);
        bool SearchLeftDown(WordModel word, GridModel grid, PositionModel position);
        bool SearchLeftUp(WordModel word, GridModel grid, PositionModel position);
    }
}
