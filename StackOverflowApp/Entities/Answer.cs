namespace StackOverflowApp.Entities
{
    public class Answer
    {

        public Guid Id { get; set; }
        public string ContentOfAnswer { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Rating { get; set; }
        public Question Question { get; set; }
        public Guid QuestionId { get; set; }
        public List<Comment>? Comments { get; set; }
        public User Author { get; set; }
        public Guid AuthorId { get; set; }


    }
}
