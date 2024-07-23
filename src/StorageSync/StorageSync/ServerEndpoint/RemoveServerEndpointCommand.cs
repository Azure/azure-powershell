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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.StorageSync.Common;

using Microsoft.Azure.Commands.StorageSync.Common.Extensions;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Commands.StorageSync.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.StorageSync;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System;
using System.Management.Automation;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;
using Microsoft.Azure.Commands.StorageSync.InternalObjects;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.StorageSync.Cmdlets
{
    /// <summary>
    /// Class RemoveServerEndpointCommand.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    [Cmdlet(VerbsCommon.Remove, StorageSyncNouns.NounAzureRmStorageSyncServerEndpoint, DefaultParameterSetName = StorageSyncParameterSets.StringParameterSet, SupportsShouldProcess = true), OutputType(typeof(void))]
    public class RemoveServerEndpointCommand : StorageSyncClientCmdletBase
    {
        /// <summary>
        /// Gets or sets the input object.
        /// </summary>
        /// <value>The input object.</value>
        [Parameter(Mandatory = true,
                   ParameterSetName = StorageSyncParameterSets.InputObjectParameterSet,
                   Position = 0,
                   ValueFromPipeline = true,
                   HelpMessage = HelpMessages.ServerEndpointInputObjectParameter)]
        [ValidateNotNullOrEmpty]
        public PSServerEndpoint InputObject { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier.
        /// </summary>
        /// <value>The resource identifier.</value>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = StorageSyncParameterSets.ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.ServerEndpointResourceIdParameter)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter(StorageSyncConstants.ServerEndpointType)]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group.
        /// </summary>
        /// <value>The name of the resource group.</value>
        [Parameter(
            Position = 0,
            Mandatory = true,
             ParameterSetName = StorageSyncParameterSets.StringParameterSet,
            ValueFromPipelineByPropertyName = false,
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
             ParameterSetName = StorageSyncParameterSets.StringParameterSet,
             Mandatory = true,
             ValueFromPipelineByPropertyName = false,
             HelpMessage = HelpMessages.StorageSyncServiceNameParameter)]
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string StorageSyncServiceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the sync group.
        /// </summary>
        /// <value>The name of the sync group.</value>
        [Parameter(
            Position = 2,
            ParameterSetName = StorageSyncParameterSets.StringParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.SyncGroupNameParameter)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices/syncGroups", "ResourceGroupName", "StorageSyncServiceName")]
        [Alias(StorageSyncAliases.ParentNameAlias)]
        public string SyncGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName = StorageSyncParameterSets.StringParameterSet,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.ServerEndpointNameParameter)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices/syncGroups/serverEndpoints", "ResourceGroupName", "StorageSyncServiceName", "SyncGroupName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the force.
        /// </summary>
        /// <value>The force.</value>
        [Parameter(Mandatory = false,
           ValueFromPipelineByPropertyName = false,
           HelpMessage = HelpMessages.ServerEndpointForceParameter)]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets or sets the pass thru.
        /// </summary>
        /// <value>The pass thru.</value>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets or sets as job.
        /// </summary>
        /// <value>As job.</value>
        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJobParameter)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                var resourceName = default(string);
                var resourceGroupName = default(string);
                var storageSyncServiceName = default(string);
                var parentResourceName = default(string);

                if (this.IsParameterBound(c => c.ResourceId))
                {
                    var resourceIdentifier = new ResourceIdentifier(ResourceId);
                    resourceName = resourceIdentifier.ResourceName;
                    resourceGroupName = resourceIdentifier.ResourceGroupName;
                    parentResourceName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.SyncGroupTypeName, 0);
                    storageSyncServiceName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName, 1);
                }
                else if (this.IsParameterBound(c => c.InputObject))
                {
                    resourceName = InputObject.ServerEndpointName;
                    resourceGroupName = InputObject.ResourceGroupName;
                    parentResourceName = InputObject.SyncGroupName;
                    storageSyncServiceName = InputObject.StorageSyncServiceName;
                }
                else
                {
                    resourceName = Name;
                    resourceGroupName = ResourceGroupName;
                    parentResourceName = SyncGroupName;
                    storageSyncServiceName = StorageSyncServiceName;
                }

                Target = string.Join("/", resourceGroupName, storageSyncServiceName, parentResourceName, resourceName);
                ActionMessage = StorageSyncResources.RemoveServerEndpointActionMessage;
                if (ShouldProcess(Target, ActionMessage))
                {
                    if (Force || ShouldContinue(string.Format(StorageSyncResources.RemoveServerEndpointPromptFormat, Target), string.Empty))
                    {

                        StorageSyncModels.ServerEndpoint serverEndpoint = null;

                        try
                        {
                            serverEndpoint = StorageSyncClientWrapper.StorageSyncManagementClient.ServerEndpoints.Get(resourceGroupName, storageSyncServiceName, parentResourceName, resourceName);
                        }
                        catch(Exception ex)
                        {
                            StorageSyncClientWrapper.VerboseLogger.Invoke($"Skipping RoleAssignments removal. Unable to get ServerEndpoint with error {ex.Message}");
                        }

                        StorageSyncClientWrapper.StorageSyncManagementClient.ServerEndpoints.Delete(resourceGroupName, storageSyncServiceName, parentResourceName, resourceName);

                        if (serverEndpoint != null)
                        {
                            // Get Registered Server
                            var serverResourceIdentifier = new ResourceIdentifier(serverEndpoint.ServerResourceId);
                            StorageSyncModels.RegisteredServer registeredServer = StorageSyncClientWrapper.StorageSyncManagementClient.RegisteredServers.Get(resourceGroupName, storageSyncServiceName, serverResourceIdentifier.ResourceName);

                            if (registeredServer == null)
                            {
                                throw new PSArgumentException(StorageSyncResources.MissingServerResourceIdErrorMessage);
                            }

                            // Handle cluster name server scenario where the rbac needs to be applied on all the nodes.
                            StorageSyncClientWrapper.VerboseLogger.Invoke($"Registered Server Auth Type : {registeredServer.ActiveAuthType} with ServerRole {registeredServer.ServerRole}");
                            IEnumerable<StorageSyncModels.RegisteredServer> impactedRegisteredServers;
                            if (registeredServer.ServerRole == ServerRoleType.ClusterName.ToString())
                            {
                                impactedRegisteredServers = StorageSyncClientWrapper.StorageSyncManagementClient.RegisteredServers
                                .ListByStorageSyncService(resourceGroupName, storageSyncServiceName)
                                .Where(s => !string.IsNullOrEmpty(s.ClusterId) &&
                                    s.ServerRole == ServerRoleType.ClusterNode.ToString() &&
                                    s.ClusterId.Equals(registeredServer.ServerId, StringComparison.InvariantCultureIgnoreCase));
                            }
                            else
                            {
                                impactedRegisteredServers = new List<StorageSyncModels.RegisteredServer> { registeredServer };
                            }
                            foreach (var impactedRegisteredServer in impactedRegisteredServers)
                            {
                                if (!String.IsNullOrEmpty(impactedRegisteredServer.ApplicationId) &&
                                    Guid.TryParse(impactedRegisteredServer.ApplicationId, out Guid serverIdentityGuid) &&
                                    serverIdentityGuid != Guid.Empty)
                                {
                                    StorageSyncModels.CloudEndpoint cloudEndpoint = StorageSyncClientWrapper.StorageSyncManagementClient.CloudEndpoints
                                    .ListBySyncGroup(resourceGroupName, storageSyncServiceName, parentResourceName).FirstOrDefault();

                                    if (cloudEndpoint == null)
                                    {
                                        throw new PSArgumentException(StorageSyncResources.MissingParentResourceIdErrorMessage);
                                    }
                                    var storageAccountResourceIdentifier = new ResourceIdentifier(cloudEndpoint.StorageAccountResourceId);
                                    var scope = $"{cloudEndpoint.StorageAccountResourceId}/fileServices/default/fileshares/{cloudEndpoint.AzureFileShareName}";
                                    bool success = StorageSyncClientWrapper.DeleteRoleAssignmentWithIdentity(storageAccountResourceIdentifier.Subscription,
                                       serverIdentityGuid,
                                       Common.StorageSyncClientWrapper.StorageFileDataPrivilegedContributorRoleDefinitionId,
                                       scope);
                                    if (success)
                                    {
                                        StorageSyncClientWrapper.VerboseLogger($"Role Assignment is successfully deleted with identity guid {serverIdentityGuid}");
                                    }
                                }
                            }
                        }
                    }
                }
            });

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
