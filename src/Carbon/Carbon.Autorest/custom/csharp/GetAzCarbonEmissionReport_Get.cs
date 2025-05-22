// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.PowerShell.Cmdlets.Carbon.Models;

namespace Microsoft.Azure.PowerShell.Cmdlets.Carbon.Cmdlets
{
    public partial class GetAzCarbonEmissionReport_Get
    {
        partial void overrideOnDefault(HttpResponseMessage responseMessage, Task<IErrorResponse> errorResponseTask, ref Task<bool> returnNow)
        {
            this.writeError(responseMessage, errorResponseTask, ref returnNow);
        }
    }
}