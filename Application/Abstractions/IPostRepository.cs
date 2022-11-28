using Domain.Models;

namespace Application.Abstractions;

public interface IPostRepository
{
    Task<ICollection<Post>> GetAllPosts();
    Task<Post?> GetPostById(int id);
    Task<Post> CreatePost(Post create);
    Task<Post> UpdatePost(string updatedContent, int postId);
    Task DeletePost(int postId);
}