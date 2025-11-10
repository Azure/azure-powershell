// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801;

namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Cmdlets
{
    [global::Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.PreviewMessage(@"**********************************************************************************************
    * This cmdlet will undergo a breaking change in Az v15.0.0, to be released on November 19th 2025. *
    * At least one change applies to this cmdlet.                                                     *
    * See all possible breaking changes at https://go.microsoft.com/fwlink/?linkid=2333486            *
    ***************************************************************************************************")] 
    public partial class InvokeAzResourceMoverPrepare_PrepareExpanded
    {
        partial void overrideOnDefault(HttpResponseMessage responseMessage, Task<ICloudError> errorResponseTask, ref Task<bool> returnNow)
        {
            this.WriteError(responseMessage, errorResponseTask, ref returnNow);
        }
    }
}
