namespace FoodGramBackend.DAL.Entities;

public class RecipeCommentEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public UserEntity User { get; set; }

    public Guid RecipeId { get; set; }

    public RecipeEntity Recipe { get; set; }

    public string CommentText { get; set; }
}