using Dapper.Entity;

namespace Dapper.Contracts.Services;

public interface IReviewService
{
    Task<Review> GetReviewByIdAsync(int id);
    Task<IEnumerable<Review>> GetReviewsByMovieIdAsync(int movieId);
    Task CreateReviewAsync(Review review);
    Task UpdateReviewAsync(Review review);
    Task DeleteReviewAsync(int id);
}