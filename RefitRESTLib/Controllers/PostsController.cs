using Microsoft.AspNetCore.Mvc;
using Refit;
using RefitRESTLib.Models;
using RefitRESTLib.Services;

namespace RefitRESTLib.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IJsonPlaceholderApi _jsonPlaceholderApi;

        public PostsController(IJsonPlaceholderApi jsonPlaceholderApi)
        {
            _jsonPlaceholderApi = jsonPlaceholderApi;
        }

        // GET: /posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            try
            {
                var posts = await _jsonPlaceholderApi.GetPostsAsync();
                return Ok(posts);
            }
            catch (ApiException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Content);
            }
        }

        // GET: /posts/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            try
            {
                var post = await _jsonPlaceholderApi.GetPostByIdAsync(id);
                return Ok(post);
            }
            catch (ApiException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Content);
            }
        }

        // POST: /posts
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost([FromBody] Post newPost)
        {
            try
            {
                var createdPost = await _jsonPlaceholderApi.CreatePostAsync(newPost);
                return CreatedAtAction(nameof(GetPost), new { id = createdPost.Id }, createdPost);
            }
            catch (ApiException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Content);
            }
        }

        // PUT: /posts/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> UpdatePost(int id, [FromBody] Post updatedPost)
        {
            try
            {
                var post = await _jsonPlaceholderApi.UpdatePostAsync(id, updatedPost);
                return Ok(post);
            }
            catch (ApiException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Content);
            }
        }

        // DELETE: /posts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _jsonPlaceholderApi.DeletePostAsync(id);
                return NoContent();
            }
            catch (ApiException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Content);
            }
        }
    }
}
