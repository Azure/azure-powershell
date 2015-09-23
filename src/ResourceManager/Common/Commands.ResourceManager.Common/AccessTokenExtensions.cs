using Microsoft.Azure.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public static class AccessTokenExtensions
    {
        public static string GetDomain(this IAccessToken token)
        {
            if( token != null && token.UserId !=null && token.UserId.Contains('@'))
            {
                return token.UserId.Split(
                    new[] { '@' }, 
                    StringSplitOptions.RemoveEmptyEntries).Last();
            }

            return null;
        }
    }
}
