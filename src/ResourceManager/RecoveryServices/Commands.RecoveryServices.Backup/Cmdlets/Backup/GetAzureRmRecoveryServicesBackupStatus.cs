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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// This cmdlet can be used to check if a VM is backed up by any vault in the subscription.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupStatus",DefaultParameterSetName = NameParamSet)]
    [OutputType(typeof(ResourceBackupStatus))]
    public class GetAzureRmRecoveryServicesBackupStatus : RecoveryServicesBackupCmdletBase
    {
        const string NameParamSet = "Name";
        const string IdParamSet = "Id";

        /// <summary>
        /// Name of the Azure Resource whose representative item needs to be checked 
        /// if it is already protected by some Recovery Services Vault in the subscription.
        /// </summary>
        [Parameter(ParameterSetName = NameParamSet, Mandatory = true,
            HelpMessage = ParamHelpMsgs.ProtectionCheck.Name)]
        public string Name { get; set; }

        /// <summary>
        /// Name of the resource group of the Azure Resource whose representative item 
        /// needs to be checked if it is already protected by some RecoveryServices Vault 
        /// in the subscription.
        /// </summary>
        [Parameter(ParameterSetName = NameParamSet, Mandatory = true,
            HelpMessage = ParamHelpMsgs.ProtectionCheck.ResourceGroupName)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Type of the Azure Resource whose representative item needs to be checked 
        /// if it is already protected by some Recovery Services Vault in the subscription.
        /// </summary>
        [Parameter(ParameterSetName = NameParamSet, Mandatory = true,
            HelpMessage = ParamHelpMsgs.ProtectionCheck.Type)]
        [ValidateSet("AzureVM")]
        public string Type { get; set; }

        [Parameter(ParameterSetName = IdParamSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = ParamHelpMsgs.ProtectionCheck.ResourceId, Mandatory = true)]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                string name = Name;
                string resourceGroupName = ResourceGroupName;
                string type = Type;

                if (ParameterSetName == IdParamSet)
                {
                    ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ResourceId);
                    name = resourceIdentifier.ResourceName;
                    resourceGroupName = resourceIdentifier.ResourceGroupName;
                    type = resourceIdentifier.ResourceType;
                }

                PsBackupProviderManager providerManager =
                    new PsBackupProviderManager(new Dictionary<Enum, object>()
                    {
                        { ProtectionCheckParams.Name, name },
                        { ProtectionCheckParams.ResourceGroupName, resourceGroupName },
                    }, ServiceClientAdapter);

                IPsBackupProvider psBackupProvider =
                    providerManager.GetProviderInstance(type);

                WriteObject(psBackupProvider.CheckBackupStatus());
            });
        }
    }
}
