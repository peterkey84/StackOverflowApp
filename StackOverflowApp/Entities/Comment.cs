namespace StackOverflowApp.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string ContentOfComment { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Question? Question { get; set; }
        public Guid? QuestionId { get; set; }
        public Answer? Answer { get; set; }
        public Guid? AnswerId { get; set; }
        public User? Author { get; set; }
        public Guid AuthorId { get; set; }



    }
}
