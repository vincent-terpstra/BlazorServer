using Application.Abstractions;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;

namespace Application.Posts.QueryHandlers;

public class GetPostByIdHandler : IRequestHandler<GetPostById, Post?>
{
    private readonly IPostRepository _postRepository;

    public GetPostByIdHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    
    public async Task<Post?> Handle(GetPostById request, CancellationToken cancellationToken)
    {
        return await _postRepository.GetPostById(request.postId);
    }
}