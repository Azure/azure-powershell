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

using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands.EkmConnection
{
    /// <summary>
    /// Base class for the External Key Manager (EKM) connection cmdlets. Provides the
    /// three ways to identify a Managed HSM (name, resource id, or piped HSM object)
    /// and resolves them into <see cref="HsmName"/>.
    /// </summary>
    public abstract class KeyVaultEkmConnectionCmdletBase : KeyVaultCmdletBase
    {
        protected const string ByHsmNameParameterSet = "ByHsmName";
        protected const string ByHsmIdParameterSet = "ByHsmId";
        protected const string ByInputObjectParameterSet = "ByInputObject";

        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByHsmNameParameterSet,
            HelpMessage = "Name of the HSM.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string HsmName { get; set; }

        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByHsmIdParameterSet,
            HelpMessage = "Resource Id of the HSM.")]
        [ValidateNotNullOrEmpty]
        public string HsmId { get; set; }

        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "HSM object.")]
        [ValidateNotNullOrEmpty]
        public PSManagedHsm HsmObject { get; set; }

        /// <summary>
        /// Normalizes the various input parameter sets into <see cref="HsmName"/>.
        /// </summary>
        protected void NormalizeHsmIdentifier()
        {
            switch (ParameterSetName)
            {
                case ByHsmIdParameterSet:
                    HsmName = new ResourceIdentifier(HsmId).ResourceName;
                    break;
                case ByInputObjectParameterSet:
                    HsmName = HsmObject.VaultName;
                    break;
            }
        }
    }
}
