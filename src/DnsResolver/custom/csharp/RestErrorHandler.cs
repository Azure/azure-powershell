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
            var errorResponse = errorResponseTask?.ConfigureAwait(false).GetAwaiter().GetResult();

            if (errorResponse?.Detail != null)
            {
                var errorDetails = errorResponse.Detail;
                var errorDetailsString = "";
               
                foreach(var errorDetail in errorDetails)
                {
                    errorDetailsString += errorDetail.Message + " ";
                }
                
                cmdlet.WriteError(new ErrorRecord(new System.Exception(), null, ErrorCategory.InvalidOperation, null)
                {
                    ErrorDetails = new ErrorDetails(errorDetailsString) { RecommendedAction = string.Empty }
                });
                
                returnNow = Task.FromResult(true);
            }
            else
            {
                returnNow = Task.FromResult(false);
            }
        }
    }
}