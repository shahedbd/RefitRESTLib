using Refit;
using RefitRESTLib.Models;

namespace RefitRESTLib.Services
{
    public interface IJsonPlaceholderApi
    {
        [Get("/posts")]
        Task<List<Post>> GetPostsAsync();

        [Get("/posts/{id}")]
        Task<Post> GetPostByIdAsync(int id);

        [Post("/posts")]
        Task<Post> CreatePostAsync([Body] Post newPost);

        [Put("/posts/{id}")]
        Task<Post> UpdatePostAsync(int id, [Body] Post updatedPost);

        [Delete("/posts/{id}")]
        Task DeletePostAsync(int id);
    }
}
