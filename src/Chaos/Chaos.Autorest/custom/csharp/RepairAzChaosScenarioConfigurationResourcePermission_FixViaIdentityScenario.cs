// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.Chaos.Cmdlets
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models;

    public partial class RepairAzChaosScenarioConfigurationResourcePermission_FixViaIdentityScenario
    {
        partial void overrideOnDefault(HttpResponseMessage responseMessage, Task<IErrorResponse> response, ref Task<bool> returnNow) { this.writeError(responseMessage, response, ref returnNow); }
    }
}
