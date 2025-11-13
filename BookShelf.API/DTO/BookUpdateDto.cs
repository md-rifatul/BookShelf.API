namespace BookShelf.API.DTO
{
    public class BookUpdateDto
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int AuthorId { get; set; }
    }
}
