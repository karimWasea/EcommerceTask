﻿


using System.Security.Claims;
namespace Vmodels
{

    public static class ClaimsPrincipalExtension

    {
        public static string GetName(this ClaimsPrincipal principal)
        {

            var Name = principal.Claims.FirstOrDefault(c => c.Type == "Name");
            return Name?.Value;
        }
    }


}