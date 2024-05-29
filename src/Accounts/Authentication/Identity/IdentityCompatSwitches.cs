// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------
//
using Microsoft.Azure.PowerShell.Authenticators.Identity.Core;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    internal class IdentityCompatSwitches
    {
        internal const string DisableInteractiveThreadpoolExecutionSwitchName = "Azure.Identity.DisableInteractiveBrowserThreadpoolExecution";
        internal const string DisableInteractiveThreadpoolExecutionEnvVar = "AZURE_IDENTITY_DISABLE_INTERACTIVEBROWSERTHREADPOOLEXECUTION";
        internal const string DisableCP1ExecutionSwitchName = "Azure.Identity.DisableCP1";
        internal const string DisableCP1ExecutionEnvVar = "AZURE_IDENTITY_DISABLE_CP1";
        internal const string DisableMultiTenantAuthSwitchName = "Azure.Identity.DisableMultiTenantAuth";
        internal const string DisableMultiTenantAuthEnvVar = "AZURE_IDENTITY_DISABLE_MULTITENANTAUTH";

        public static bool DisableInteractiveBrowserThreadpoolExecution
            => AppContextSwitchHelper.GetConfigValue(DisableInteractiveThreadpoolExecutionSwitchName, DisableInteractiveThreadpoolExecutionEnvVar);

        public static bool DisableCP1
            => AppContextSwitchHelper.GetConfigValue(DisableCP1ExecutionSwitchName, DisableCP1ExecutionEnvVar);

        public static bool DisableTenantDiscovery
            => AppContextSwitchHelper.GetConfigValue(DisableMultiTenantAuthSwitchName, DisableMultiTenantAuthEnvVar);
    }
}
