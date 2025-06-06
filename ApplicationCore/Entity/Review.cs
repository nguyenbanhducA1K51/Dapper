namespace Dapper.Entity;

public class Review
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int UserId { get; set; }
    public decimal Rating { get; set; }
    public string ReviewText { get; set; }
    public DateTime CreatedDate { get; set; }
}