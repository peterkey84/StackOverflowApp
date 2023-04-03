using Microsoft.EntityFrameworkCore;
using StackOverflowApp.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<StackOverflowContext>(
    option => option
    .UseSqlServer(builder.Configuration.GetConnectionString("StackOverflowConnectionString"))
    );

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();



app.MapGet("GetAllQuestion", (StackOverflowContext db) =>
{

    var allQ = db.Questions.ToList();

    return allQ;

});

app.MapPost("AddQuestion", (Guid userId, string title, string content,  StackOverflowContext db) =>
{

    Question question = new Question()
    {
        Id = Guid.NewGuid(),
        Title = title,
        ContentOfQuestion = content,
        CreatedDate = DateTime.Now,
        AuthorId = userId

    };

    db.Questions.Add(question);
    db.SaveChanges();

    return question;

});


app.MapPost("UpdateQuestion", (Guid questionId, string questionConent, StackOverflowContext db) =>
{
    Question question = db.Questions.FirstOrDefault(q => q.Id == questionId);
    question.ContentOfQuestion = questionConent;
    question.UpdatedDate = DateTime.Now;
    db.SaveChanges();
    return question;


});




app.MapPost("AddAnswerToQuestion", (Guid quetionId, Guid userId, string content, StackOverflowContext db) =>
{

    Answer answer = new Answer()
    {
        Id = Guid.NewGuid(),
        ContentOfAnswer = content,
        CreatedDate = DateTime.Now,
        QuestionId = quetionId,
        AuthorId = userId
    };

    
    db.Answers.Add(answer);
    db.SaveChanges();

    return answer;

});

app.MapPost("UpdateAnswer", (Guid answerId, string answerConent, StackOverflowContext db) =>
{
    Answer answer = db.Answers.FirstOrDefault(q => q.Id == answerId);
    answer.ContentOfAnswer = answerConent;
    answer.UpdatedDate = DateTime.Now;
    db.SaveChanges();
    return answer;


});


app.MapPost("AddCommentToQuestion", (Guid questionId, string content, Guid userId, StackOverflowContext db) =>
{

    Comment comment = new Comment()
    {
        Id = Guid.NewGuid(),
        ContentOfComment = content,
        CreatedDate = DateTime.Now,
        QuestionId = questionId,
        AuthorId = userId

    };

    db.Comments.Add(comment);
    db.SaveChanges();
    return comment;


});

app.MapPost("AddCommentToAnswer", (Guid answerId, Guid questionId, string content, Guid userId, StackOverflowContext db) =>
{

    Comment comment = new Comment()
    {
        Id = Guid.NewGuid(),
        ContentOfComment = content,
        CreatedDate = DateTime.Now,
        QuestionId = questionId,
        AnswerId = answerId,
        AuthorId = userId

    };

    db.Comments.Add(comment);
    db.SaveChanges();
    return comment;


});



app.MapPost("AddRatingToQuestion", (Guid questionId, int rating, StackOverflowContext db) =>
{

    Question question = db.Questions.FirstOrDefault(q => q.Id == questionId);

    if (rating > 0)
    {
        question.Rating = question.Rating + 1;

    }
    else
    {
        if (question.Rating <= 0)
        {
            question.Rating = 0;
        }
        else
        {
            question.Rating = question.Rating - 1;
        }
    }

    db.SaveChanges();
    return question;

});


app.MapPost("AddRatingToAnswer", (Guid answerId, int rating, StackOverflowContext db) =>
{

Answer answer = db.Answers.FirstOrDefault(q => q.Id == answerId);

    if (rating > 0)
    {
        answer.Rating = answer.Rating + 1;

    }
    else
    {
        if (answer.Rating <= 0)
        {
            answer.Rating = 0;
        }
        else
        {
            answer.Rating = answer.Rating - 1;
        }
    }

    db.SaveChanges();
    return answer;

});



app.Run();

