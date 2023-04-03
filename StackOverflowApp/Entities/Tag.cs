namespace StackOverflowApp.Entities
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Question Question { get; set; }
        public Guid QuestionId { get; set; }
    }
}
