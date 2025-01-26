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

using Commands.StorageSync.Interop.DataObjects;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.StorageSync.Common;
using Microsoft.Azure.Commands.StorageSync.Interop.Enums;
using Microsoft.Azure.Commands.StorageSync.Interop.ManagedIdentity;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Commands.StorageSync.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.StorageSync;
using Microsoft.Azure.Management.StorageSync.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.Cmdlets
{
    /// <summary>
    /// Class SetRegisteredServerCommand.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    [Cmdlet(VerbsCommon.Set, StorageSyncNouns.NounAzureRmStorageSyncServer,
        DefaultParameterSetName = StorageSyncParameterSets.StringParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSRegisteredServer))]
    public class SetRegisteredServerCommand : StorageSyncClientCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the resource group.
        /// </summary>
        /// <value>The name of the resource group.</value>
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
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
        [Alias(StorageSyncAliases.ParentNameAlias)]
        public string StorageSyncServiceName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Parameter(Position = 2,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.RegisteredServerNameParameter)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices/registeredServers", "ResourceGroupName", "StorageSyncServiceName")]
        [Alias(StorageSyncAliases.RegisteredServerNameAlias)]
        public string ServerId{ get; set; }

        /// <summary>
        /// Gets or sets the input object.
        /// </summary>
        /// <value>The input object.</value>
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.ObjectParameterSet,
           Mandatory = true,
           ValueFromPipeline = true,
           HelpMessage = HelpMessages.RegisteredServerObjectParameter)]
        [Alias(StorageSyncAliases.RegisteredServerAlias)]
        public PSRegisteredServer InputObject { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the policy to use for regular download sync sessions.
        /// </summary>
        /// <value>The local cache mode.</value>
        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = false,
          HelpMessage = HelpMessages.ServerIdentityParameter)]
        public SwitchParameter Identity { get; set; }

        /// <summary>
        /// Gets or sets as job.
        /// </summary>
        /// <value>As job.</value>
        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJobParameter)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>The target.</value>
        protected override string Target => ServerId ?? InputObject?.ServerId;

        /// <summary>
        /// Gets or sets the action message.
        /// </summary>
        /// <value>The action message.</value>
        protected override string ActionMessage => $"{StorageSyncResources.SetRegisteredServerActionMessage} {ServerId ?? InputObject?.ServerId}";

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

                bool? identity = default;

                if (this.IsParameterBound(c => c.InputObject))
                {
                    resourceName = InputObject.ServerId;
                    resourceGroupName = InputObject.ResourceGroupName;
                    storageSyncServiceName = InputObject.StorageSyncServiceName;
                }
                else
                {
                    resourceName = ServerId;
                    resourceGroupName = ResourceGroupName;
                    storageSyncServiceName = StorageSyncServiceName;
                }

                if (this.IsParameterBound(c => c.Identity))
                {
                    identity = Identity;
                }

                RegisteredServer registeredServer = StorageSyncClientWrapper.StorageSyncManagementClient.RegisteredServers.Get(resourceGroupName, storageSyncServiceName, ServerId);
                if (registeredServer == null)
                {
                    throw new PSArgumentException($"Server {ServerId} not found.");
                }
                if (registeredServer.ServerRole == InternalObjects.ServerRoleType.ClusterName.ToString())
                {
                    throw new PSArgumentException($"Please provide the current server resource id with ServerType as ClusterNode");
                }
                if(!identity.GetValueOrDefault())
                {
                    throw new NotSupportedException(ActionMessage + " requires Identity parameter to be set to true.");

                }

                // 1. Get the server's latest applicationId
                var serverManagedIdentityProvider = new ServerManagedIdentityProvider
                {
                    EnableMIChecking = true
                };

                LocalServerType serverTypeFromRegistry = StorageSyncClientWrapper.StorageSyncResourceManager.GetServerTypeFromRegistry();
                Guid applicationId = serverManagedIdentityProvider.GetServerApplicationId(serverTypeFromRegistry, throwIfNotFound: false);

                if (applicationId == Guid.Empty)
                {
                    StorageSyncClientWrapper.VerboseLogger.Invoke($"Unable to retrieve a managed identity to patch this server.");
                    throw new PSArgumentException("Not able to set the server's identity. Please ensure this server has Azure Arc installed and connected or Azure VM has a system assigned managed identity enabled.");
                }
                else
                {
                    WriteVerbose($"Server ApplicationId to apply: {applicationId}");
                }

                // 2. RBAC permission set for Server Endpoints
                string serverResourceId;

                if (registeredServer.ServerRole == InternalObjects.ServerRoleType.ClusterNode.ToString())
                {
                    // this is unexpected scenario but can happen if the server is not registered properly
                    if (string.IsNullOrEmpty(registeredServer.ClusterId) || Guid.Parse(registeredServer.ClusterId) == Guid.Empty)
                    {
                        throw new PSArgumentException($"Cluster Id is not available for cluster node server {registeredServer.Id}. Please contact administrator for further troubleshooting.");
                    }

                    RegisteredServer clusterNameServer = StorageSyncClientWrapper.StorageSyncManagementClient.RegisteredServers.Get(resourceGroupName, storageSyncServiceName, registeredServer.ClusterId.ToString());
                    if (clusterNameServer == null)
                    {
                        throw new PSArgumentException($"Cluster  {registeredServer.ClusterName} not found.");
                    }
                    serverResourceId = clusterNameServer?.Id;
                }
                else
                {
                    serverResourceId = registeredServer.Id;
                }

                IEnumerable <StorageSyncModels.SyncGroup> syncGroups = StorageSyncClientWrapper.StorageSyncManagementClient.SyncGroups.ListByStorageSyncService(resourceGroupName, storageSyncServiceName);
                Exception syncGroupFirstException = null;
                if (syncGroups != null)
                {
                    foreach (StorageSyncModels.SyncGroup syncGroup in syncGroups)
                    {
                        try
                        {
                            IEnumerable<StorageSyncModels.CloudEndpoint> cloudEndpoints = StorageSyncClientWrapper.StorageSyncManagementClient.CloudEndpoints.ListBySyncGroup(resourceGroupName, storageSyncServiceName, syncGroup.Name);
                            StorageSyncModels.CloudEndpoint cloudEndpoint = cloudEndpoints.FirstOrDefault();

                            if (cloudEndpoint == null)
                            {
                                StorageSyncClientWrapper.VerboseLogger.Invoke($"Skipping SyncGroup. No cloud Endpoint found for sync group {syncGroup.Name}");
                                continue;
                            }
                            var storageAccountResourceIdentifier = new ResourceIdentifier(cloudEndpoint.StorageAccountResourceId);

                            IEnumerable<StorageSyncModels.ServerEndpoint> serverEndpoints = StorageSyncClientWrapper.StorageSyncManagementClient.ServerEndpoints.ListBySyncGroup(resourceGroupName, storageSyncServiceName, syncGroup.Name);
                            Exception serverEndpointFirstException = null;
                            foreach (StorageSyncModels.ServerEndpoint serverEndpoint in serverEndpoints)
                            {
                                try
                                {
                                    // if we found a matching ServerEndpoint for this server, create a role assignment for this file share/cep
                                    if (serverEndpoint.ServerResourceId.Equals(serverResourceId, StringComparison.OrdinalIgnoreCase))
                                    {
                                        // Identity, RoleDef, Scope
                                        var scope = $"{cloudEndpoint.StorageAccountResourceId}/fileServices/default/fileshares/{cloudEndpoint.AzureFileShareName}";
                                        var identityRoleAssignmentForFileShareScope = StorageSyncClientWrapper.EnsureRoleAssignmentWithIdentity(storageAccountResourceIdentifier.Subscription,
                                            applicationId,
                                            Common.StorageSyncClientWrapper.StorageFileDataPrivilegedContributorRoleDefinitionId,
                                            scope);

                                        // break because a given server (as an sep) can only participate once in each sync group/cep
                                        break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    StorageSyncClientWrapper.ErrorLogger.Invoke($"RBAC creation for ServerEndpoint {serverEndpoint.Name} has failed with an exception {ex.Message}.");
                                    serverEndpointFirstException = serverEndpointFirstException ?? ex;
                                }
                            } // Iterating server endpoints
                            if (serverEndpointFirstException != null)
                            {
                                throw serverEndpointFirstException;
                            }
                        }
                        catch (Exception ex)
                        {
                            StorageSyncClientWrapper.ErrorLogger.Invoke($"SyncGroup {syncGroup.Name} has failed with an exception {ex.Message}.");
                            syncGroupFirstException = syncGroupFirstException ?? ex;
                        }
                    } // Iterating sync groups
                    if (syncGroupFirstException != null)
                    {
                        throw syncGroupFirstException;
                    }
                }
                else
                {
                    StorageSyncClientWrapper.VerboseLogger.Invoke($"No SyncGroups found for StorageSyncService {storageSyncServiceName}");
                }

                Target = string.Join("/", resourceGroupName, storageSyncServiceName, resourceName);
                if (ShouldProcess(Target, ActionMessage))
                {
                    RegisteredServer resource = StorageSyncClientWrapper.StorageSyncManagementClient.RegisteredServers.Update(
                        resourceGroupName,
                        storageSyncServiceName,
                        resourceName,
                        new RegisteredServerUpdateParameters()
                        {
                            Identity = identity,
                            ApplicationId = applicationId.ToString()
                        }
                        );

                    WriteObject(resource);
                }
            });
        }
    }
}