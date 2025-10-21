// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models;

namespace Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Cmdlets
{
    public partial class GetAzDnsResolverOutboundEndpoint_GetViaIdentityDnsResolver
    {
        partial void overrideOnDefault(HttpResponseMessage responseMessage, Task<ICloudError> errorResponseTask, ref Task<bool> returnNow)
        {
            this.WriteError(responseMessage, errorResponseTask, ref returnNow);
        }
    }
}