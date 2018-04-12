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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// This cmdlet can be used to check if a VM is backed up by any vault in the subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmRecoveryServicesBackupStatus")]
    [OutputType(typeof(List<ARSVault>))]
    public class GetAzureRmRecoveryServicesBackupStatus : RecoveryServicesBackupCmdletBase
    {
        const string NameParamSet = "Name";
        const string IdParamSet = "Id";

        /// <summary>
        /// Name of the Azure Resource whose representative item needs to be checked 
        /// if it is already protected by some Recovery Services Vault in the subscription.
        /// </summary>
        [Parameter(ParameterSetName = NameParamSet,
            HelpMessage = ParamHelpMsgs.ProtectionCheck.Name)]
        public string Name { get; set; }

        /// <summary>
        /// Name of the resource group of the Azure Resource whose representative item 
        /// needs to be checked if it is already protected by some RecoveryServices Vault 
        /// in the subscription.
        /// </summary>
        [Parameter(ParameterSetName = NameParamSet,
            HelpMessage = ParamHelpMsgs.ProtectionCheck.ResourceGroupName)]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Type of the Azure Resource whose representative item needs to be checked 
        /// if it is already protected by some Recovery Services Vault in the subscription.
        /// </summary>
        [Parameter(ParameterSetName = NameParamSet,
            HelpMessage = ParamHelpMsgs.ProtectionCheck.Type)]
        public string Type { get; set; }

        [Parameter(ParameterSetName = IdParamSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = ParamHelpMsgs.ProtectionCheck.ResourceId)]
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
                    name = HelperUtils.GetResourceNameFromId(ResourceId);
                    resourceGroupName = HelperUtils.GetResourceGroupNameFromId(ResourceId);
                    type = HelperUtils.GetResourceTypeFromId(ResourceId);
                }
                
                PsBackupProviderManager providerManager =
                    new PsBackupProviderManager(new Dictionary<Enum, object>()
                    {
                        { ProtectionCheck.Name, name },
                        { ProtectionCheck.ResourceGroupName, resourceGroupName },
                    }, ServiceClientAdapter);

                IPsBackupProvider psBackupProvider =
                    providerManager.GetProviderInstance(type);

                WriteObject(psBackupProvider.CheckBackupStatus());
            });
        }
    }
}
