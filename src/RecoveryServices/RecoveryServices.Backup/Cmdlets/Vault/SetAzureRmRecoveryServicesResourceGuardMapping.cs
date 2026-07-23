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

using System;
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Used to enable MUA on the vault
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesResourceGuardMapping", DefaultParameterSetName = SetAzureResourceGuardMapping, SupportsShouldProcess = true), OutputType(typeof(ResourceGuardProxyBaseResource))]
    public class SetAzureRmRecoveryServicesResourceGuardMapping : RSBackupVaultCmdletBase
    {
        internal const string SetAzureResourceGuardMapping = "SetAzureResourceGuardMapping";

        [Parameter(Mandatory = true, ValueFromPipeline = false, ParameterSetName = SetAzureResourceGuardMapping, HelpMessage = ParamHelpMsgs.ResourceGuard.ResourceGuardId)]
        [ValidateNotNullOrEmpty]
        public string ResourceGuardId;

        [Parameter(Mandatory = false, ValueFromPipeline = false, ParameterSetName = SetAzureResourceGuardMapping, HelpMessage = ParamHelpMsgs.ResourceGuard.TokenDepricated)]
        [ValidateNotNullOrEmpty]
        public string Token;

        [Parameter(Mandatory = false, ValueFromPipeline = false, ParameterSetName = SetAzureResourceGuardMapping, HelpMessage = ParamHelpMsgs.ResourceGuard.AuxiliaryAccessToken)]
        [ValidateNotNullOrEmpty]
        public System.Security.SecureString SecureToken;

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                try
                {
                    ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                    string vaultName = resourceIdentifier.ResourceName;
                    string resourceGroupName = resourceIdentifier.ResourceGroupName;

                    string resourceGuardMappingName = "VaultProxy";

                    ResourceGuardProxyBaseResource param = new ResourceGuardProxyBaseResource();
                    param.Properties = new ResourceGuardProxyBase();
                    param.Properties.ResourceGuardResourceId = ResourceGuardId;

                    string plainToken = HelperUtils.GetPlainToken(Token, SecureToken);

                    ResourceGuardProxyBaseResource resourceGuardMapping = ServiceClientAdapter.CreateResourceGuardMapping(vaultName, resourceGroupName, resourceGuardMappingName, param, plainToken);
                    WriteObject(resourceGuardMapping);
                }
                catch (Exception exception)
                {
                    WriteExceptionError(exception);
                }
            }, ShouldProcess(VaultId, VerbsCommon.Set));
        }
    }
}
