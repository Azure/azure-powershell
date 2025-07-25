// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801;

namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Cmdlets
{
    public partial class RemoveAzResourceMoverMoveResource_Delete
    {
        partial void overrideOnDefault(HttpResponseMessage responseMessage, Task<ICloudError> errorResponseTask, ref Task<bool> returnNow)
        {
            this.WriteError(responseMessage, errorResponseTask, ref returnNow);
        }
    }
}
