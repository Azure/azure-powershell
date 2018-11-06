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
using Commands.StorageSync.Interop.DataObjects;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.StorageSync.Common;
using Microsoft.Azure.Commands.StorageSync.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.StorageSync;
using StorageSync.Management.PowerShell.Cmdlets.CertificateRollover;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.StorageSync.Cmdlets
{

    [Cmdlet(VerbsCommon.Reset, StorageSyncNouns.NounAzureRmStorageSyncServerCertificate, DefaultParameterSetName = StorageSyncParameterSets.ObjectParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class ResetServerCertificateCommand : StorageSyncClientCmdletBase
    {
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.ResourceGroupNameParameter)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
           Position = 1,
           ParameterSetName =StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.StorageSyncServiceNameParameter)]
        [StorageSyncServiceCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.ParentNameAlias)]
        public string StorageSyncServiceName { get; set; }

        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.ObjectParameterSet,
           Mandatory = true,
           ValueFromPipeline = true,
           HelpMessage = HelpMessages.StorageSyncServiceObjectParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.StorageSyncServiceAlias)]
        public PSStorageSyncService ParentObject { get; set; }

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

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                var parentResourceIdentifier = default(ResourceIdentifier);

                if (!string.IsNullOrEmpty(ParentResourceId))
                {
                    parentResourceIdentifier = new ResourceIdentifier(ParentResourceId);

                    if (!string.Equals(StorageSyncConstants.StorageSyncServiceType, parentResourceIdentifier.ResourceType, System.StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException($"Invalid Argument {nameof(ParentResourceId)}", nameof(ParentResourceId));
                    }
                }

                var resourceGroupName = ResourceGroupName ?? ParentObject?.ResourceGroupName ?? parentResourceIdentifier?.ResourceGroupName;

                if(string.IsNullOrEmpty(resourceGroupName))
                {
                    throw new PSArgumentException($"Invalid Argument {nameof(ResourceGroupName)}", nameof(ResourceGroupName));
                }

                var parentResourceName = StorageSyncServiceName ?? ParentObject?.StorageSyncServiceName ?? parentResourceIdentifier?.ResourceName;

                if (string.IsNullOrEmpty(parentResourceName))
                {
                    throw new PSArgumentException($"Invalid Argument {nameof(StorageSyncServiceName)}", nameof(StorageSyncServiceName));
                }

                if (!SubscriptionId.HasValue)
                {
                    throw new PSArgumentException("No subscription found", nameof(SubscriptionId));
                }

                PerformTriggerRolloverInCloud(resourceGroupName, SubscriptionId.Value, parentResourceName);
            });

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
        private void PerformTriggerRolloverInCloud(string resourceGroupName, Guid subscriptionId, string storageSyncServiceName)
        {
            if (subscriptionId == null)
            {
                throw new PSArgumentException("No subscription found");
            }

            using (ISyncServerCertificateRollover certificateRolloverClient = new SyncServerCertificateRolloverClient(InteropClientFactory.CreateEcsManagement(IsRunningInTest)))
            {
                certificateRolloverClient.RolloverServerCertificate(
                    ManagementInteropConstants.CertificateProviderName,
                    ManagementInteropConstants.CertificateHashAlgorithm,
                    ManagementInteropConstants.CertificateKeyLength,
                    (certificate, serverId) => TriggerCertificateRollover(certificate, serverId, resourceGroupName,storageSyncServiceName),
                    (inputLogData) => StorageSyncClientWrapper.VerboseLogger(inputLogData));
            }
        }

        /// <summary>
        /// Triggers certificate rollover workflow on service
        /// </summary>
        /// <param name="certificateData"> certificate to add </param>
        /// <param name="serverId"> serverId</param>
        private void TriggerCertificateRollover(string certificateData, Guid serverId, string resourceGroupName, string storageSyncServiceName)
        {
            WriteVerbose("Triggering certificate rollover on service");

            StorageSyncClientWrapper.StorageSyncManagementClient.RegisteredServers.TriggerRollover(resourceGroupName, storageSyncServiceName, serverId.ToString(), certificateData);

            WriteVerbose("Certificate Rollover request completed on the service");
        }
    }
}
