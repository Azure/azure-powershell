// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.Chaos.Cmdlets
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models;

    public partial class RemoveAzChaosScenarioConfiguration_DeleteViaIdentity
    {
        partial void overrideOnDefault(HttpResponseMessage responseMessage, Task<IErrorResponse> response, ref Task<bool> returnNow) => this.writeError(responseMessage, response, ref returnNow);

        partial void overrideOnNotFound(HttpResponseMessage responseMessage, ref Task<bool> returnNow)
        {
            if (this.treatScenarioConfigurationNotFoundAsSuccessfulDelete(responseMessage, PassThru.IsPresent))
            {
                returnNow = Task.FromResult(true);
            }
        }
    }
}
