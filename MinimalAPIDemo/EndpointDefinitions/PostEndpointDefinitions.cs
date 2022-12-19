using Application.Posts.Commands;
using Application.Posts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalAPIDemo.Abstractions;

namespace MinimalAPIDemo;

public class PostEndpointDefinitions : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
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

        app.MapGet("/api/posts", GetAllPosts)
            .Produces<List<Post>>();

        app.MapPut("/api/posts/{id}", UpdatePost);
    }

    private async Task<IResult> UpdatePost(int id, UpdatePost updatePost, IMediator mediator)
    {
        updatePost.PostId = id; 
        return Results.Ok(await mediator.Send(updatePost));
        
    }

    private async Task<IResult> GetAllPosts(IMediator mediator)
    {
        return Results.Ok(await mediator.Send(new GetAllPosts()));
    }

    private async Task<IResult> DeletePostById(int id, IMediator mediator)
    {
        var deletePost = new DeletePost() {Id = id};
        await mediator.Send(deletePost);
        return Results.NoContent();
    }

    private async Task<IResult> CreatePost([FromBody]CreatePost createPost, IMediator mediator)
    {
        var post = await mediator.Send(createPost);
        return Results.CreatedAtRoute(nameof(GetPostById), new { post.Id},  post);
       
    }

    private async Task<IResult> GetPostById(int id, IMediator mediator)
    {
        var getPost = new GetPostById() {postId = id};
        var post = await mediator.Send(getPost);
        
        return post is null ? Results.NotFound() : Results.Ok(post);
    }
}