using cat_forum.Models.Enums;
using cat_forum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace cat_forum.Helpers.Attributes
{
    public class Authorization : Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Role> _roles;

        public Authorization (params Role[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization (AuthorizationFilterContext context)
        {
            var unauthorizedStatusObject = new JsonResult (new { Message = "Unauthorzed" })
            { StatusCode = StatusCodes.Status401Unauthorized };


            if (_roles == null)
            {
                context.Result = unauthorizedStatusObject;
            }

            var user = (User)context.HttpContext.Items["User"];
            if (user == null || !_roles.Contains(user.Role))
            {
                context.Result = unauthorizedStatusObject;
            }
        }
    }
}
