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

using Commands.StorageSync.Interop;
using Commands.StorageSync.Interop.Clients;
using Commands.StorageSync.Interop.DataObjects;
using Commands.StorageSync.Interop.Interfaces;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.StorageSync.Common;

using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Commands.StorageSync.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.StorageSync;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.StorageSync.Cmdlets
{

    /// <summary>
    /// Class ResetServerCertificateCommand.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    [Cmdlet(VerbsCommon.Reset, StorageSyncNouns.NounAzureRmStorageSyncServerCertificate, DefaultParameterSetName = StorageSyncParameterSets.StringParameterSet, SupportsShouldProcess = true), OutputType(typeof(void))]
    public class ResetServerCertificateCommand : StorageSyncClientCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the resource group.
        /// </summary>
        /// <value>The name of the resource group.</value>
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.ResourceGroupNameParameter)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the storage sync service.
        /// </summary>
        /// <value>The name of the storage sync service.</value>
        [Parameter(
           Position = 1,
           ParameterSetName =StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.StorageSyncServiceNameParameter)]
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.ParentNameAlias)]
        public string StorageSyncServiceName { get; set; }

        /// <summary>
        /// Gets or sets the parent object.
        /// </summary>
        /// <value>The parent object.</value>
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.ObjectParameterSet,
           Mandatory = true,
           ValueFromPipeline = true,
           HelpMessage = HelpMessages.StorageSyncServiceObjectParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.StorageSyncServiceAlias)]
        public PSStorageSyncService ParentObject { get; set; }

        /// <summary>
        /// Gets or sets the parent resource identifier.
        /// </summary>
        /// <value>The parent resource identifier.</value>
        [Parameter(
          Position = 0,
          ParameterSetName = StorageSyncParameterSets.ParentStringParameterSet,
          Mandatory = true,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = HelpMessages.StorageSyncServiceParentResourceIdParameter)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter(StorageSyncConstants.StorageSyncServiceType)]
        [Alias(StorageSyncAliases.StorageSyncServiceIdAlias)]
        public string ParentResourceId { get; set; }

        /// <summary>
        /// Gets or sets the pass thru.
        /// </summary>
        /// <value>The pass thru.</value>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>The target.</value>
        protected override string Target => StorageSyncServiceName ?? ParentObject?.StorageSyncServiceName ?? ParentResourceId;

        /// <summary>
        /// Gets or sets the action message.
        /// </summary>
        /// <value>The action message.</value>
        protected override string ActionMessage => $"{StorageSyncResources.ResetServerCertificateActionMessage} {StorageSyncServiceName ?? ParentObject?.StorageSyncServiceName ?? ParentResourceId}";

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                var parentResourceIdentifier = default(ResourceIdentifier);

                if (this.IsParameterBound(c => c.ParentResourceId))
                {
                    parentResourceIdentifier = new ResourceIdentifier(ParentResourceId);

                    if (!string.Equals(StorageSyncConstants.StorageSyncServiceType, parentResourceIdentifier.ResourceType, System.StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException(StorageSyncResources.MissingParentResourceIdErrorMessage);
                    }
                }

                var resourceGroupName = ResourceGroupName ?? ParentObject?.ResourceGroupName ?? parentResourceIdentifier?.ResourceGroupName;
                var parentResourceName = StorageSyncServiceName ?? ParentObject?.StorageSyncServiceName ?? parentResourceIdentifier?.ResourceName;
                if (ShouldProcess(Target, ActionMessage))
                {
                    TriggerCertificateRollover(resourceGroupName, SubscriptionId, parentResourceName);
                }
            });

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
        /// <summary>
        /// Triggers the certificate rollover.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="subscriptionId">The subscription identifier.</param>
        /// <param name="storageSyncServiceName">Name of the storage sync service.</param>
        private void TriggerCertificateRollover(string resourceGroupName, Guid subscriptionId, string storageSyncServiceName)
        {
            using (ISyncServerCertificateRollover certificateRolloverClient = new SyncServerCertificateRolloverClient(StorageSyncClientWrapper.StorageSyncResourceManager.CreateEcsManagement()))
            {
                certificateRolloverClient.RolloverServerCertificate(
                    ManagementInteropConstants.CertificateProviderName,
                    ManagementInteropConstants.CertificateHashAlgorithm,
                    ManagementInteropConstants.CertificateKeyLength,
                    (certificate, serverId) => PerformTriggerRolloverInCloud(certificate, serverId, resourceGroupName,storageSyncServiceName),
                    (inputLogData) => StorageSyncClientWrapper.VerboseLogger(inputLogData));
            }
        }

        /// <summary>
        /// Triggers certificate rollover workflow on service
        /// </summary>
        /// <param name="certificateData">certificate to add</param>
        /// <param name="serverId">serverId</param>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="storageSyncServiceName">Name of the storage sync service.</param>
        private void PerformTriggerRolloverInCloud(string certificateData, Guid serverId, string resourceGroupName, string storageSyncServiceName)
        {
            WriteVerbose(StorageSyncResources.ResetCertificateMessage17);

            StorageSyncClientWrapper.StorageSyncManagementClient.RegisteredServers.TriggerRollover(resourceGroupName, storageSyncServiceName, serverId.ToString(), certificateData);

            WriteVerbose(StorageSyncResources.ResetCertificateMessage18);
        }
    }
}
