namespace StackOverflowApp.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Question>? Questions { get; set; }
        public List<Answer>? Answers { get; set; }
    }
}
