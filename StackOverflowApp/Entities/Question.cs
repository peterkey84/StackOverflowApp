namespace StackOverflowApp.Entities
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ContentOfQuestion { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Rating { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Tag>? Tags { get; set; }
        public List<Answer>? Answers { get; set; }
        public User Author { get; set; } 
        public Guid AuthorId { get; set; }

    }
}
