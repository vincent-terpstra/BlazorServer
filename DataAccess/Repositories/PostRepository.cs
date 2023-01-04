using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class PostRepository : IPostRepository
{
    private readonly AppDbContext.AppDbContext _dbContext;

    public PostRepository(AppDbContext.AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<Post>> GetAllPosts()
        => await _dbContext.Posts.ToListAsync();
    
    public async Task<Post?> GetPostById(int id)
        => await _dbContext.Posts.FirstOrDefaultAsync(post => post.Id == id);
    

    public async Task<Post> CreatePost(Post create)
    {
        create.DateCreated = DateTime.Now;
        create.DateModified = DateTime.Now;

        _dbContext.Posts.Add(create);
        await _dbContext.SaveChangesAsync();
        return create;
    }

    public async Task<Post> UpdatePost(string updatedContent, int postId)
    {
        var post = await GetPostById(postId);
        if (post is null)
            throw new KeyNotFoundException();

        post.Content = updatedContent;
        post.DateModified = DateTime.Now;
        
        _dbContext.Posts.Update(post);
        await _dbContext.SaveChangesAsync();

        return post;
    }

    public async Task DeletePost(int postId)
    {
        var post = await GetPostById(postId);
        if (post is null)
            throw new KeyNotFoundException();
        
        _dbContext.Posts.Remove(post);
        await _dbContext.SaveChangesAsync();
    }
}