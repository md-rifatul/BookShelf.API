namespace BookShelf.API.DTO
{
    public class BookCreateDto
    {
        public string? Title { get; set; }
        public int Year { get; set; }
        public int AuthorId { get; set; }
    }
}
