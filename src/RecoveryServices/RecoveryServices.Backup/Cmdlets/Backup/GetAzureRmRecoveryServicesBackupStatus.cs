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
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// This cmdlet can be used to check if a VM is backed up by any vault in the subscription.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupStatus", DefaultParameterSetName = NameParamSet)]
    [OutputType(typeof(ResourceBackupStatus))]
    public class GetAzureRmRecoveryServicesBackupStatus : RecoveryServicesBackupCmdletBase
    {
        const string NameParamSet = "Name";
        const string IdParamSet = "Id";
        const string IdWorkloadParamSet = "IdWorkload";

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
        [Parameter(ParameterSetName = IdWorkloadParamSet, Mandatory = true,
            HelpMessage = ParamHelpMsgs.ProtectionCheck.Type),]
        [ValidateSet("AzureVM", "AzureFiles")]
        public string Type { get; set; }

        [Parameter(ParameterSetName = IdParamSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = ParamHelpMsgs.ProtectionCheck.ResourceId, Mandatory = true)]
        [Parameter(ParameterSetName = IdWorkloadParamSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = ParamHelpMsgs.ProtectionCheck.ResourceId, Mandatory = true)]
        public string ResourceId { get; set; }


        [Parameter(ParameterSetName = IdWorkloadParamSet, ValueFromPipelineByPropertyName = true,
          HelpMessage = ParamHelpMsgs.ProtectionCheck.ProtectableObjName, Mandatory = true)]
        public string ProtectableObjectName { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                string resourceId = ResourceId;
                if (ParameterSetName == NameParamSet)
                {
                    // Form ID from name

                    ResourceIdentifier resourceIdentifier = new ResourceIdentifier();
                    resourceIdentifier.Subscription = ServiceClientAdapter.SubscriptionId;
                    resourceIdentifier.ResourceGroupName = ResourceGroupName;

                    resourceIdentifier.ResourceType = ConversionUtils.GetARMResourceType(Type);
                    resourceIdentifier.ResourceName = Name;

                    resourceId = resourceIdentifier.ToString();
                }
                else if (ParameterSetName == IdParamSet)
                {
                    ResourceIdentifier resourceIdentifier = new ResourceIdentifier(resourceId);
                    Type = ConversionUtils.GetWorkloadTypeFromArmType(resourceIdentifier.ResourceType);
                }
                else
                {
                    // Pass on the ID
                }

                GenericResource resource = ServiceClientAdapter.GetAzureResource(resourceId);

                BackupStatusResponse backupStatus = ServiceClientAdapter.CheckBackupStatus(Type, resourceId, resource.Location, ProtectableObjectName).Body;

                Boolean isProtected = String.Equals(backupStatus.ProtectionStatus, "Protected", StringComparison.OrdinalIgnoreCase);

                WriteObject(new ResourceBackupStatus(
                                isProtected == true ? backupStatus.VaultId : null,
                                isProtected));
            });
        }
    }
}
