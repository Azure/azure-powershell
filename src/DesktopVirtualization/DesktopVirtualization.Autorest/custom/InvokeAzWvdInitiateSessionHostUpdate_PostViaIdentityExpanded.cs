// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models;

namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Cmdlets
{
    public partial class InvokeAzWvdInitiateSessionHostUpdate_PostViaIdentityExpanded
    {
        partial void overrideOnDefault(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IErrorResponse> response, ref global::System.Threading.Tasks.Task<bool> returnNow)
        {
            if(responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                 returnNow = Task.FromResult(true);
                return;
            }
        }
    }
}