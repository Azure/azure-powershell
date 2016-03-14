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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Get list of containers
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmRecoveryServicesContainer"), OutputType(typeof(List<AzureRmRecoveryServicesContainerBase>), typeof(AzureRmRecoveryServicesContainerBase))]
    public class GetAzureRmRecoveryServicesContainer : RecoveryServicesBackupCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsg.Common.Vault, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ARSVault Vault { get; set; }

        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsg.Container.ContainerType)]
        [ValidateNotNullOrEmpty]
        public ContainerType ContainerType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsg.Container.Name)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsg.Container.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsg.Container.Status)]
        [ValidateNotNullOrEmpty]
        public ContainerRegistrationStatus Status { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
                {
                    base.ExecuteCmdlet();

                    ProtectionContainerListQueryParams queryParams = new ProtectionContainerListQueryParams();

                    // 1. Filter by Name
                    queryParams.FriendlyName = Name;

                    // 2. Filter by ContainerType
                    queryParams.ProviderType = HydraHelpers.GetHydraProviderType(ContainerType);

                    // 3. Filter by Status
                    queryParams.RegistrationStatus = Status.ToString();

                    var listResponse = HydraAdapter.ListContainers(Vault.Name, Vault.ResouceGroupName, queryParams);

                    List<AzureRmRecoveryServicesContainerBase> containerModels = ConversionHelpers.GetContainerModelList(listResponse);

                    // NOTE: Should move this to provider?
                    // 4. Filter by RG Name
                    if (ContainerType == Models.ContainerType.AzureVM)
                    {
                        containerModels = containerModels.Where(containerModel =>
                            (containerModel as AzureRmRecoveryServicesIaasVmContainer).ResourceGroupName == ResourceGroupName).ToList();
                    }

                    WriteObject(containerModels);
                });
        }
    }
}
