using Domain.Models;
using MediatR;

namespace Application.Posts.Queries;

public class GetAllPosts :IRequest<ICollection<Post>>, IRequest<Unit>
{
    
}