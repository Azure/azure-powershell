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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Used to disable MUA on the vault
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesResourceGuardMapping", DefaultParameterSetName = DeleteAzureResourceGuardMapping, SupportsShouldProcess = true), OutputType(typeof(Object))]
    public class RemoveAzureRmRecoveryServicesResourceGuardMapping : RSBackupVaultCmdletBase
    {
        internal const string DeleteAzureResourceGuardMapping = "DeleteAzureResourceGuardMapping";

        [Parameter(Mandatory = false, ValueFromPipeline = false, ParameterSetName = DeleteAzureResourceGuardMapping, HelpMessage = ParamHelpMsgs.ResourceGuard.TokenDepricated)]
        [ValidateNotNullOrEmpty]
        public string Token;

        [Parameter(Mandatory = false, ValueFromPipeline = false, ParameterSetName = DeleteAzureResourceGuardMapping, HelpMessage = ParamHelpMsgs.ResourceGuard.AuxiliaryAccessToken)]
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

                    string plainToken = HelperUtils.GetPlainToken(Token, SecureToken);

                    Rest.Azure.AzureOperationResponse result = ServiceClientAdapter.DeleteResourceGuardMapping(vaultName, resourceGroupName, resourceGuardMappingName, plainToken);
                    WriteObject(result);
                }
                catch (Exception exception)
                {
                    WriteExceptionError(exception);
                }
            }, ShouldProcess("ResourceGuardMapping", VerbsCommon.Remove));
        }
    }
}
