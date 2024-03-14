// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Cmdlets
{
    using System.Threading.Tasks;
    using System;

    public partial class GetAzAppComplianceAutomationSnapshot_List : global::System.Management.Automation.PSCmdlet,
        Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Runtime.IEventListener
    {
        partial void overrideOnOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.ISnapshotResourceList> response, ref global::System.Threading.Tasks.Task<bool> returnNow)
        {
            var result = response.ConfigureAwait(false).GetAwaiter().GetResult();
            WriteObject(result.Value, true);
            returnNow = global::System.Threading.Tasks.Task.FromResult(true);
        }
    }
}
