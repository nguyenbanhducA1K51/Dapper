using Dapper.Contracts.Repositories;
using Dapper.Entity;

namespace Infrastructure.Repositories;

using Dapper;
using Microsoft.Data.SqlClient;

public class ReviewRepository : IReviewRepository
{
    private readonly string _connectionString;

    public ReviewRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    private SqlConnection GetConnection() => new SqlConnection(_connectionString);

    public async Task<Review> GetByIdAsync(int id)
    {
        using var connection = GetConnection();
        string sql = "SELECT * FROM Reviews WHERE Id = @Id";
        return await connection.QuerySingleOrDefaultAsync<Review>(sql, new { Id = id });
    }

    public async Task<IEnumerable<Review>> GetByMovieIdAsync(int movieId)
    {
        using var connection = GetConnection();
        string sql = "SELECT * FROM Reviews WHERE MovieId = @MovieId";
        return await connection.QueryAsync<Review>(sql, new { MovieId = movieId });
    }

    public async Task CreateAsync(Review review)
    {
        using var connection = GetConnection();
        string sql = @"INSERT INTO Reviews (MovieId, UserId, Rating, ReviewText, CreatedDate)
                       VALUES (@MovieId, @UserId, @Rating, @ReviewText, @CreatedDate)";
        await connection.ExecuteAsync(sql, review);
    }

    public async Task UpdateAsync(Review review)
    {
        using var connection = GetConnection();
        string sql = @"UPDATE Reviews 
                       SET MovieId = @MovieId, UserId = @UserId, Rating = @Rating, ReviewText = @ReviewText 
                       WHERE Id = @Id";
        await connection.ExecuteAsync(sql, review);
    }

    public async Task DeleteAsync(int id)
    {
        using var connection = GetConnection();
        string sql = "DELETE FROM Reviews WHERE Id = @Id";
        await connection.ExecuteAsync(sql, new { Id = id });
    }
}
