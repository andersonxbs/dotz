using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dotz.Api.Controllers.Abstractions
{
    [Authorize]
    public abstract class DotzControllerBase : ControllerBase
    {
        protected string CurrentUserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }
    }
}