
using System.Collections.Generic;

namespace WordSearch.Models
{
    public class GridModel
    {
        public IEnumerable<CellModel> Cells { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
