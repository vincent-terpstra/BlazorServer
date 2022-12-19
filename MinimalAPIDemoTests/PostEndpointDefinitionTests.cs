using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Application.Posts.Commands;
using Application.Posts.Queries;
using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using MinimalAPIDemo;
using Xunit;

namespace MinimalAPIDemoTests;

public class PostEndpointDefinitionTests
{
    private HttpClient _api;

    public PostEndpointDefinitionTests()
    {
        var factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(
                builder => { builder.UseEnvironment("test"); }
            );

        _api = factory.CreateClient();
    }

    [Fact]
    public async void CreatePostReturnStatusOk()
    {
        //Arrange
        var post = new
        {
            postContent = "valid string"
        };
        
        //Act
        var result = await _api.PostAsJsonAsync("/api/posts", post);
        var content = await result.Content.ReadFromJsonAsync<Post>();

        //Assert
        Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        Assert.Equal(content?.Content, post.postContent);
        Assert.EndsWith($@"/api/posts/{content?.Id}", result.Headers.Location?.ToString() ?? "");
    }

    [Fact]
    public async void GetPostByIdReturnsNotFound()
    {
        //Arrange
        
        //Act
        var result = await _api.GetAsync("/api/posts/1");
        
        //Assert
        Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
    }

    [Fact]
    public async void GetPostByIdReturnsPost()
    {
        //Arrange
        int postId = await CreateValidPost();

        //Act
        var result = await _api.GetAsync($"/api/posts/{postId}");
        Post? content = await result.Content.ReadFromJsonAsync<Post>();
        
        //Assert
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.Equal(postId, content?.Id);
    }

    [Fact]
    public async void UpdatePostByIdUpdatesPost()
    {
        //Arrange
        int postId = await CreateValidPost();
        UpdatePost updatePost = new()
        {
            PostContent = "Updated Content"
        };

        //Act
        var result = await _api.PutAsJsonAsync($"/api/posts/{postId}", updatePost);
        Post? content = await result.Content.ReadFromJsonAsync<Post>();
        Post? updated = await GetPostById(postId);
        
        //Assert
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.Equal(updatePost.PostContent, content?.Content);
        Assert.Equal(updatePost.PostContent, updated?.Content);
        
    }

    [Fact]
    public async void DeletePostReturnsNotFound()
    {
        //Note this is testing the middleware functionality in MinimalAPIDemo/Abstractions/MinimalAPIExtensions
        
        //Arrange
        
        //Act
        var result = await _api.DeleteAsync($"/api/posts/1");

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
    }

    [Fact]
    public async void DeletePostReturnsNoContent()
    {
        //Arrange
        int postId = await CreateValidPost();
        
        //Act
        var result = await _api.DeleteAsync($"/api/posts/{postId}");
        var checkDelete = await _api.GetAsync($"/api/posts/{postId}");
        
        //Assert
        Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        Assert.Equal(HttpStatusCode.NotFound, checkDelete.StatusCode);
    }

    private async Task<Post?> GetPostById(int id)
    {
        var response = await _api.GetAsync($"/api/posts/{id}");
        return await response.Content.ReadFromJsonAsync<Post>();
    }
    
    private async Task<int> CreateValidPost()
    {
        var validPost = new CreatePost()
        {
            PostContent = "Valid string"
        };
        
        var result = await _api.PostAsJsonAsync("/api/posts", validPost);

        Post content = await result.Content.ReadFromJsonAsync<Post>() ?? throw new InvalidOperationException();
        return content.Id;
    }
}