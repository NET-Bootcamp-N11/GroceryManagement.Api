using GroceryManagement.Domain.Entities.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace GroceryManagement.Api.Atribitues
{
    [AttributeUsage(AttributeTargets.Method)]   // Permissionlarni nmani ustida ishlatatyotganimizni yozish kerak (bizda controllerni ichida bir method ustida ishlatmoqdamiz)
    public class IdentityFilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly int _permissionId;
        public IdentityFilterAttribute(Permissions permissions)
        {
            _permissionId = (int)permissions;
        }
        public void OnAuthorization(AuthorizationFilterContext context)  
        {
           
            ClaimsIdentity identity = context.HttpContext.User.Identity as ClaimsIdentity;
            string permmissionsJson = identity.FindFirst("permissions")!.Value;
            bool result = JsonSerializer.Deserialize<IEnumerable<int>>(permmissionsJson)!.Any(x => x == _permissionId);
            if (!result)
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }

}
