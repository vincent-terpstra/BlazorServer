using MediatR;

namespace Application.Posts.Commands;

public class DeletePost : IRequest
{
    public int Id { get; set; }    
}