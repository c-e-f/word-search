using System;
using System.Collections.Generic;
using System.Linq;
using WordSearch.Models;
using WordSearch.Services;

namespace WordSearch
{
    public class Display : IDisplay
    {
        private readonly IGridService gridService;
        private readonly ISearchService searchService;
        public Display(IGridService _gridService, ISearchService _searchService)
        {
            gridService = _gridService;
            searchService = _searchService;
        }

        public void Show()
        {
            var grid = gridService.Grid();
            var foundWords = FindWords();

            TextOutput(grid, foundWords);
        }

        private void TextOutput(char [,] grid, List<WordModel> foundWords)
        {
            Console.WriteLine("Word Search");

            for (int y = 0; y < 12; y++)
            {
                for (int x = 0; x < 12; x++)
                {
                    Console.Write(grid[y, x]);
                    Console.Write(' ');
                }
                Console.WriteLine("");

            }

            Console.WriteLine("");
            Console.WriteLine("Found Words");
            Console.WriteLine("------------------------------");

            //PUPPY found at (10,7) to (10, 3)
            foundWords.ForEach(word =>
            {
                Console.WriteLine("{0} found at ({1},{2}) to ({3},{4})",
                    word.Name, word.StartPosition.X, word.StartPosition.Y,
                    word.EndPosition.X, word.EndPosition.Y);
            });

            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }

        private List<WordModel> FindWords()
        {
            string[] Words = new string[]
            {
                "CARPET",
                "CHAIR",
                "DOG",
                "BALL",
                "DRIVEWAY",
                "FISHING",
                "FOODCOURT",
                "FRIDGE",
                "GOLF",
                "MAXIMIZATION",
                "PUPPY",
                "SPACE",
                "TABLE",
                "TELEVISION",
                "WELCOME",
                "WINDOW"
            };

            var words = Words.Select(word => new WordModel { Name = word, FirstLetter = word[0], Length = word.Length });
            var results = new List<WordModel>();

            foreach (WordModel word in words)
            {
                var match = TraverseGrid(word);
                if (match != null)
                {
                    results.Add(match);
                }
            }

            return results;
        }

        private WordModel TraverseGrid(WordModel word)
        {
            // Flatten grid to use search patterns
            var grid = gridService.FormattedGrid();

            foreach (CellModel cell in grid.Cells)
            {
                if (cell.value == word.FirstLetter)
                {
                    // Dont bother searching if word is longer than space left
                    // Each if statement handles a different direction
                    if (cell.Position.X <= grid.Width - word.Name.Length)
                    {
                        // If match is found, map for display purposes
                        if (searchService.SearchRight(word, grid, cell.Position) == true)
                        {
                            word.StartPosition = cell.Position;
                            word.EndPosition = new PositionModel() 
                            { 
                                X = cell.Position.X + word.Name.Length, 
                                Y = cell.Position.Y 
                            };

                            return word;
                        }

                        if (cell.Position.Y >= word.Name.Length)
                        {
                            if (searchService.SearchRightUp(word, grid, cell.Position) == true)
                            {
                                word.StartPosition = cell.Position;
                                word.EndPosition = new PositionModel() 
                                { 
                                    X = cell.Position.X + word.Name.Length, 
                                    Y = cell.Position.Y - word.Name.Length 
                                };

                                return word;
                            }
                        }

                        if (cell.Position.Y <= grid.Height - word.Name.Length)
                        {
                            if (searchService.SearchRightDown(word, grid, cell.Position) == true)
                            {
                                word.StartPosition = cell.Position;
                                word.EndPosition = new PositionModel() 
                                { 
                                    X = cell.Position.X + word.Name.Length, 
                                    Y = cell.Position.Y + word.Name.Length 
                                };

                                return word;
                            }
                        }
                    }

                    if (cell.Position.X >= word.Name.Length - 1)
                    {
                        if (searchService.SearchLeft(word, grid, cell.Position) == true)
                        {
                            word.StartPosition = cell.Position;
                            word.EndPosition = new PositionModel() 
                            { 
                                X = cell.Position.X - word.Name.Length, 
                                Y = cell.Position.Y 
                            };

                            return word;
                        }

                        if (cell.Position.Y <= grid.Height - word.Name.Length)
                        {
                            if (searchService.SearchLeftDown(word, grid, cell.Position) == true)
                            {
                                word.StartPosition = cell.Position;
                                word.EndPosition = new PositionModel() 
                                { 
                                    X = cell.Position.X - word.Name.Length, 
                                    Y = cell.Position.Y + word.Name.Length 
                                };

                                return word;
                            }
                        }

                        if (cell.Position.Y >= word.Name.Length)
                        {
                            if (searchService.SearchLeftUp(word, grid, cell.Position) == true)
                            {
                                word.StartPosition = cell.Position;
                                word.EndPosition = new PositionModel()
                                {
                                    X = cell.Position.X - word.Name.Length,
                                    Y = cell.Position.Y - word.Name.Length
                                };

                                return word;
                            }
                        }
                    }

                    if (cell.Position.Y <= grid.Height - word.Name.Length)
                    {
                        if (searchService.SearchDown(word, grid, cell.Position) == true)
                        {
                            word.StartPosition = cell.Position;
                            word.EndPosition = new PositionModel()
                            {
                                X = cell.Position.X,
                                Y = cell.Position.Y + word.Name.Length
                            };

                            return word;
                        }
                    }

                    if (cell.Position.Y >= word.Name.Length)
                    {
                        if (searchService.SearchUp(word, grid, cell.Position) == true)
                        {
                            word.StartPosition = cell.Position;
                            word.EndPosition = new PositionModel()
                            {
                                X = cell.Position.X,
                                Y = cell.Position.Y - word.Name.Length
                            };

                            return word;
                        }
                    }
                }
            }
            return null;
        }
    }
}
