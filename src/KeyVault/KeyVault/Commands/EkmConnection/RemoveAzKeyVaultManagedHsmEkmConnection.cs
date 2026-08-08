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
    /// Deletes the External Key Manager (EKM) connection from a Managed HSM. (Preview)
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultManagedHsmEkmConnection",
        SupportsShouldProcess = true, DefaultParameterSetName = ByHsmNameParameterSet)]
    [OutputType(typeof(PSKeyVaultEkmConnection))]
    public class RemoveAzKeyVaultManagedHsmEkmConnection : KeyVaultEkmConnectionCmdletBase
    {
        [Parameter(Mandatory = false,
            HelpMessage = "Cmdlet does not return an object by default. If this switch is specified, the deleted EKM connection is returned.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            NormalizeHsmIdentifier();
            if (ShouldProcess(HsmName, "Delete External Key Manager (EKM) connection"))
            {
                var deleted = Track2DataClient.RemoveManagedHsmEkmConnection(HsmName);
                if (PassThru.IsPresent)
                {
                    WriteObject(deleted);
                }
            }
        }
    }
}
