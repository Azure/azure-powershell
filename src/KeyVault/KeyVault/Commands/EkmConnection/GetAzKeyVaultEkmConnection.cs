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

using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands.EkmConnection
{
    /// <summary>
    /// Gets the External Key Manager (EKM) connection configured on a Managed HSM. (Preview)
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultEkmConnection",
        DefaultParameterSetName = ByHsmNameParameterSet)]
    [OutputType(typeof(PSKeyVaultEkmConnection))]
    public class GetAzKeyVaultEkmConnection : KeyVaultEkmConnectionCmdletBase
    {
        public override void ExecuteCmdlet()
        {
            NormalizeHsmIdentifier();
            WriteObject(Track2DataClient.GetManagedHsmEkmConnection(HsmName));
        }
    }
}
