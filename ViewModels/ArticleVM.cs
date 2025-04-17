namespace razorweb.ViewModels
{
    public class ArticleVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
