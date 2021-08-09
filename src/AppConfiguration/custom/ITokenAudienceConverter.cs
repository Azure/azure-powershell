using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration
{
    interface ITokenAudienceConverter
    {
        string Convert(IAzureEnvironment environment, IAzureEnvironment baseEnvironment, System.Uri requestUri);
    }
}
