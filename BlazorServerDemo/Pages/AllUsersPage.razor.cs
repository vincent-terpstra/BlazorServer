using System.Linq;
using DataAccess.Models;
using DataAccess.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorServerDemo.Pages;

public class AllUsersPageBase : ComponentBase
{
    private readonly ILogger<AllUsersPageBase> _logger;
    private readonly IUserService _userService;
    
    
    public AllUsersPageBase(ILogger<AllUsersPageBase> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    
}