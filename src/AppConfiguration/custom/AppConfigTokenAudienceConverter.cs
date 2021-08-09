using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration
{
    class AppConfigTokenAudienceConverter : ITokenAudienceConverter
    {
        public string Convert(IAzureEnvironment environment, IAzureEnvironment baseEnvironment, Uri requestUri)
        {
            throw new NotImplementedException();
        }
    }
}
