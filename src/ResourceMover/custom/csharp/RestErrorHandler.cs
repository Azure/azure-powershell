// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Management.Automation;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801;

namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Cmdlets
{
    internal static class CmdletRestExtension
    {
        public static void WriteError(this Cmdlet cmdlet, HttpResponseMessage responseMessage, Task<ICloudError> errorResponseTask, ref Task<bool> returnNow)
        {
            var response = errorResponseTask.ConfigureAwait(false).GetAwaiter().GetResult();
            var errorString = string.Format("ErrorCode: {0}, Message: {1}", response.Code, response.Message);
            errorString+= System.Environment.NewLine;

            if (response?.Detail != null && response?.Detail?.Length != 0)
            {
                var errors = response.Detail;

                foreach(var error in errors)
                {
                    errorString += string.Format("ErrorCode: {0}, Message: {1}", error.Code, error.Message);
                    errorString+= System.Environment.NewLine;
                }
            }
            cmdlet.WriteError(new ErrorRecord(new System.Exception(), null, ErrorCategory.InvalidOperation, null)
            {
                ErrorDetails = new ErrorDetails(errorString) { RecommendedAction = string.Empty }
            });

            returnNow = Task.FromResult(true);
        }
    }
}