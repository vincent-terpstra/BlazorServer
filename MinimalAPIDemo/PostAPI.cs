using Application.Posts.Commands;
using Application.Posts.Queries;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace MinimalAPIDemo;

public static class PostAPI
{
    public static void MapPostEndpoints(this WebApplication app)
    {
        app.MapGet("/api/posts/{id}", GetPostById)
            .WithName(nameof(GetPostById))
            .WithDisplayName("Get by Id")
            .Produces<Post>();

        app.MapPost("/api/posts", CreatePost)
            .WithName(nameof(CreatePost))
            .WithDisplayName("Create Post")
            .Produces<Post>();

        app.MapDelete("/api/posts/{id}", DeletePostById);

        app.MapGet("/api/posts", GetAllPosts);

        app.MapPut("/api/posts/{id}", UpdatePost);
    }

    private static async Task<IResult> UpdatePost(int id, UpdatePost updatePost, IMediator mediator)
    {
        try
        {
            updatePost.PostId = id;
            return Results.Ok(await mediator.Send(updatePost));
        }
        catch (Exception ex)
        {
            return Results.NotFound();
        }
        
    }

    private static async Task<IResult> GetAllPosts(IMediator mediator)
    {
        return Results.Ok(await mediator.Send(new GetAllPosts()));
    }

    private static async Task<IResult> DeletePostById(int id, IMediator mediator)
    {
        try
        {
            var deletePost = new DeletePost() {Id = id};
            await mediator.Send(deletePost);
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return Results.NotFound();
        }
    }

    private static async Task<IResult> CreatePost([FromBody]CreatePost createPost, IMediator mediator)
    {
        try
        {
            var post = await mediator.Send(createPost);
            return Results.CreatedAtRoute(nameof(GetPostById), new { post.Id},  post);
        }
        catch (Exception ex)
        {
            return Results.NotFound();
        }
    }

    private static async Task<IResult> GetPostById(int id, IMediator mediator)
    {
        var getPost = new GetPostById() {postId = id};
        var post = await mediator.Send(getPost);
        
        return post is null ? Results.NotFound() : Results.Ok(post);
    }
}