using Dapper.Contracts.Repositories;
using Dapper.Contracts.Services;
using Dapper.Entity;

namespace Infrastructure.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _repository;

    public ReviewService(IReviewRepository repository)
    {
        _repository = repository;
    }

    public Task<Review> GetReviewByIdAsync(int id) => _repository.GetByIdAsync(id);

    public Task<IEnumerable<Review>> GetReviewsByMovieIdAsync(int movieId) => _repository.GetByMovieIdAsync(movieId);

    public Task CreateReviewAsync(Review review) => _repository.CreateAsync(review);

    public Task UpdateReviewAsync(Review review) => _repository.UpdateAsync(review);

    public Task DeleteReviewAsync(int id) => _repository.DeleteAsync(id);
}
