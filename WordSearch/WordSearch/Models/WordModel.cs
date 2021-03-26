
namespace WordSearch.Models
{
    public class WordModel
    {
        public string Name { get; set; }
        public char FirstLetter { get; set; }
        public int Length { get; set; }
        public PositionModel StartPosition { get; set; }
        public PositionModel EndPosition { get; set; }
    }
}
