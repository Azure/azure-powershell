// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Management.Automation;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701;

namespace Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Cmdlets
{
    internal static class CmdletRestExtension
    {
        public static void WriteError(this Cmdlet cmdlet, HttpResponseMessage responseMessage, Task<ICloudError> errorResponseTask, ref Task<bool> returnNow)
        {
            var errorString = responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            cmdlet.WriteError(new ErrorRecord(new System.Exception(), null, ErrorCategory.InvalidOperation, null)
            {
                ErrorDetails = new ErrorDetails(errorString) { RecommendedAction = string.Empty }
            });

            returnNow = Task.FromResult(true);
        }
    }
}