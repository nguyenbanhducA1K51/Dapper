using Dapper.Entity;

namespace Dapper.Contracts.Repositories;


    public interface IReviewRepository
    {
        Task<Review> GetByIdAsync(int id);
        Task<IEnumerable<Review>> GetByMovieIdAsync(int movieId);
        Task CreateAsync(Review review);
        Task UpdateAsync(Review review);
        Task DeleteAsync(int id);
    }
