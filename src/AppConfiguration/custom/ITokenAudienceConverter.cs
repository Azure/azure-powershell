using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration
{
    interface ITokenAudienceConverter
    {
        string Convert(string curEnvEndpointResourceId, string curEnvEndpointSuffix, string baseEnvEndpointResourceId, string baseEnvEndpointSuffix, System.Uri requestUri);
    }
}
