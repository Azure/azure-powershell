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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.StorageSync.Common;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Commands.StorageSync.Properties;
using Microsoft.Azure.Management.StorageSync;
using System.Collections;
using System.Management.Automation;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.StorageSync.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using Azure;
using System.Management.Automation.Remoting;
using System.Linq;
using System.Threading;
using Microsoft.Azure.Commands.StorageSync.InternalObjects;

namespace Microsoft.Azure.Commands.StorageSync.StorageSyncService
{

    /// <summary>
    /// Set StorageSyncService
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    [Cmdlet(VerbsCommon.Set, StorageSyncNouns.NounAzureRmStorageSyncServiceIdentity,
        DefaultParameterSetName = StorageSyncParameterSets.StringParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSStorageSyncService))]
    public class SetStorageSyncServiceIdentityCommand : StorageSyncClientCmdletBase
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Parameter(Position = 1,
            ParameterSetName = StorageSyncParameterSets.StringParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.StorageSyncServiceNameParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.StorageSyncServiceNameAlias)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the input object.
        /// </summary>
        /// <value>The input object.</value>
        [Parameter(Mandatory = true,
                   ParameterSetName = StorageSyncParameterSets.InputObjectParameterSet,
                   Position = 0,
                   ValueFromPipeline = true,
                   HelpMessage = HelpMessages.StorageSyncServiceInputObjectParameter)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter(StorageSyncConstants.StorageSyncServiceType)]
        public PSStorageSyncService InputObject { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier.
        /// </summary>
        /// <value>The resource identifier.</value>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = StorageSyncParameterSets.ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.StorageSyncServiceResourceIdParameter)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter(StorageSyncConstants.StorageSyncServiceType)]
        public string ResourceId { get; set; }

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
        protected override string Target => Name;

        /// <summary>
        /// Gets or sets the action message.
        /// </summary>
        /// <value>The action message.</value>
        protected override string ActionMessage => $"{StorageSyncResources.SetStorageSyncServiceActionMessage} {Name}";

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

                // Handle ResourceId Parameter Set
                if (this.IsParameterBound(c => c.ResourceId))
                {
                    var resourceIdentifier = new ResourceIdentifier(ResourceId);
                    resourceName = resourceIdentifier.ResourceName;
                    resourceGroupName = resourceIdentifier.ResourceGroupName;
                }
                else if (this.IsParameterBound(c => c.InputObject))
                {
                    resourceName = InputObject.StorageSyncServiceName;
                    resourceGroupName = InputObject.ResourceGroupName;
                }
                else
                {
                    resourceName = Name;
                    resourceGroupName = ResourceGroupName;
                }


                Target = string.Join("/", resourceGroupName, resourceName);
                if (ShouldProcess(Target, ActionMessage))
                {
                    StorageSyncModels.StorageSyncService storageSyncService = StorageSyncClientWrapper.StorageSyncManagementClient.StorageSyncServices.Get(resourceGroupName, resourceName);
                    bool needPropogationDelay = storageSyncService?.Identity?.Type != ManagedServiceIdentityType.SystemAssigned.ToString();

                    // 1. Check if any server available for migration
                    IEnumerable<StorageSyncModels.RegisteredServer> registeredServers = StorageSyncClientWrapper.StorageSyncManagementClient.RegisteredServers.ListByStorageSyncService(resourceGroupName, resourceName);
                    var candidateServersLookup = new Dictionary<string, StorageSyncModels.RegisteredServer>(StringComparer.InvariantCultureIgnoreCase);
                    var clusterNameServersLookup = new Dictionary<string, List<StorageSyncModels.RegisteredServer>>(StringComparer.InvariantCultureIgnoreCase);
                    foreach (var registeredServer in registeredServers)
                    {
                        // Scenario : Server is running in certificate mode
                        if((registeredServer.ActiveAuthType == StorageSyncModels.ServerAuthType.Certificate && !string.IsNullOrEmpty(registeredServer.ApplicationId) && registeredServer.ApplicationId != Guid.Empty.ToString())
                            || (Guid.TryParse(registeredServer.LatestApplicationId, out Guid latestApplicationId)))
                        {
                            StorageSyncClientWrapper.VerboseLogger.Invoke($"Server :  {registeredServer.ServerName ?? registeredServer.ServerId} ({registeredServer.ServerRole})");

                            if (registeredServer.ServerRole != ServerRoleType.ClusterName.ToString())
                            {
                                candidateServersLookup.Add(registeredServer.Id, registeredServer);
                            }

                            if (registeredServer.ServerRole == ServerRoleType.ClusterNode.ToString())
                            {
                                var clusterNameServer = registeredServers.SingleOrDefault(s => s.ServerId == registeredServer.ClusterId && s.ServerRole == ServerRoleType.ClusterName.ToString());
                                if (clusterNameServer == null)
                                {
                                    throw new PSArgumentException($"Cluster Name Server {clusterNameServer.ServerName} is not found for Cluster Node {registeredServer.ServerName}");
                                }
                                if (!clusterNameServersLookup.ContainsKey(clusterNameServer.Id))
                                {
                                    clusterNameServersLookup.Add(clusterNameServer.Id, new List<RegisteredServer>());
                                }
                                clusterNameServersLookup[clusterNameServer.Id].Add(registeredServer);
                            }
                        }
                    }

                    if(candidateServersLookup.Count == 0)
                    {
                        throw new PSArgumentException("No server found which is available for migration.");
                    }

                    StorageSyncClientWrapper.VerboseLogger.Invoke($"Found {candidateServersLookup.Count} servers out of {registeredServers.Count(s => s.ServerRole != ServerRoleType.ClusterName.ToString())} total servers to migrate");

                    // 2. Set System Assigned managed identity to Storage Sync service
                    var updateParameters = new StorageSyncServiceUpdateParameters()
                    {
                        UseIdentity = storageSyncService.UseIdentity.GetValueOrDefault(false),
                        Identity = new ManagedServiceIdentity()
                        {
                            Type = ManagedServiceIdentityType.SystemAssigned
                        }
                    };
                    storageSyncService = StorageSyncClientWrapper.StorageSyncManagementClient.StorageSyncServices.Update(resourceGroupName, resourceName, updateParameters);
                    if (storageSyncService.Identity == null || storageSyncService.Identity.PrincipalId.GetValueOrDefault(Guid.Empty) == Guid.Empty)
                    {
                        throw new PSArgumentException("Not able to set identity. Please reach out to administrator for further troubleshooting");
                    }
                    else
                    {
                        StorageSyncClientWrapper.VerboseLogger.Invoke($"Storage Sync Service is capable with identity {storageSyncService.Identity.PrincipalId}");
                    }

                    if (needPropogationDelay)
                    {
                        StorageSyncClientWrapper.VerboseLogger.Invoke($"If you are creating this principal and then immediately assigning a role, you will get error PrincipalNotFound which is related to a replication delay. In this case, set the role assignment principalType property to a value, such as ServicePrincipal, User, or Group. See\r\nhttps://aka.ms/docs-principaltype");
                        StorageSyncClientWrapper.VerboseLogger.Invoke($"Sleeping for 120 seconds...");
                        Thread.Sleep(TimeSpan.FromSeconds(120));
                    }

                    // 3. RBAC permission set for Cloud Endpoints and Server Endpoints
                    IEnumerable<StorageSyncModels.SyncGroup> syncGroups = StorageSyncClientWrapper.StorageSyncManagementClient.SyncGroups.ListByStorageSyncService(resourceGroupName, resourceName);
                    Exception syncGroupFirstException = null;
                    foreach (var syncGroup in syncGroups)
                    {
                        try
                        {
                            IEnumerable<StorageSyncModels.CloudEndpoint> cloudEndpoints = StorageSyncClientWrapper.StorageSyncManagementClient.CloudEndpoints.ListBySyncGroup(resourceGroupName, resourceName, syncGroup.Name);
                            StorageSyncModels.CloudEndpoint cloudEndpoint = cloudEndpoints.FirstOrDefault();

                            if (cloudEndpoint == null)
                            {
                                StorageSyncClientWrapper.VerboseLogger.Invoke($"Skipping SyncGroup. No cloud Endpoint found for sync group {syncGroup.Name}");
                                continue;
                            }
                            var storageAccountResourceIdentifier = new ResourceIdentifier(cloudEndpoint.StorageAccountResourceId);

                            // Identity , RoleDef, Scope
                            var scope = cloudEndpoint.StorageAccountResourceId;
                            var identityRoleAssignmentForSAScope = StorageSyncClientWrapper.EnsureRoleAssignmentWithIdentity(storageAccountResourceIdentifier.Subscription,
                                storageSyncService.Identity.PrincipalId.Value,
                                Common.StorageSyncClientWrapper.StorageAccountContributorRoleDefinitionId,
                                scope);

                            scope = $"{cloudEndpoint.StorageAccountResourceId}/fileServices/default/fileshares/{cloudEndpoint.AzureFileShareName}";
                            var identityRoleAssignmentForFilsShareScope = StorageSyncClientWrapper.EnsureRoleAssignmentWithIdentity(storageAccountResourceIdentifier.Subscription,
                               storageSyncService.Identity.PrincipalId.Value,
                               Common.StorageSyncClientWrapper.StorageFileDataPrivilegedContributorRoleDefinitionId,
                               scope);

                            IEnumerable<StorageSyncModels.ServerEndpoint> serverEndpoints = StorageSyncClientWrapper.StorageSyncManagementClient.ServerEndpoints.ListBySyncGroup(resourceGroupName, resourceName, syncGroup.Name);
                            Exception serverEndpointFirstException = null;
                            foreach (var serverEndpoint in serverEndpoints)
                            {
                                try
                                {
                                    var associatedServers = new List<RegisteredServer>();

                                    // It is expected that multiple migration script might have caused to have role assignment already in the system. We are fault tolerant to existing role assignment.
                                    if (candidateServersLookup.ContainsKey(serverEndpoint.ServerResourceId))
                                    {
                                        // Standalone Server scenario
                                        associatedServers.Add(candidateServersLookup[serverEndpoint.ServerResourceId]);
                                    }
                                    else if (clusterNameServersLookup.ContainsKey(serverEndpoint.ServerResourceId))
                                    {
                                        // ClusterNode Server scenario
                                        associatedServers.AddRange(clusterNameServersLookup[serverEndpoint.ServerResourceId]);
                                    }

                                    StorageSyncClientWrapper.VerboseLogger.Invoke($"ServerEndpoint {serverEndpoint.Name} has {associatedServers.Count} associated registered servers.");
                                    foreach (var associatedServer in associatedServers)
                                    {
                                        if (!Guid.TryParse(associatedServer.LatestApplicationId, out Guid applicationGuid))
                                        {
                                            applicationGuid = Guid.Parse(associatedServer.ApplicationId);
                                        }
                                        // Identity , RoleDef, Scope
                                        scope = $"{cloudEndpoint.StorageAccountResourceId}/fileServices/default/fileshares/{cloudEndpoint.AzureFileShareName}";
                                        identityRoleAssignmentForFilsShareScope = StorageSyncClientWrapper.EnsureRoleAssignmentWithIdentity(storageAccountResourceIdentifier.Subscription,
                                           applicationGuid,
                                           Common.StorageSyncClientWrapper.StorageFileDataPrivilegedContributorRoleDefinitionId,
                                           scope);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    StorageSyncClientWrapper.ErrorLogger.Invoke($"ServerEndpoint {serverEndpoint.Name} has failed with an exception {ex.Message}.");
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
                    // 4 Set UseIdentity for given Storage Sync Service
                    updateParameters = new StorageSyncServiceUpdateParameters()
                    {
                        UseIdentity = true
                    };
                    storageSyncService = StorageSyncClientWrapper.StorageSyncManagementClient.StorageSyncServices.Update(resourceGroupName, resourceName, updateParameters);
                    if (!storageSyncService.UseIdentity.GetValueOrDefault(false))
                    {
                        throw new PSArgumentException("Not able to set UseIdentity. Please reach out to administrator for further troubleshooting");
                    }

                    // 5. Patch all servers which were having latest application id.
                    foreach(var serverKvp in candidateServersLookup)
                    {
                        if (serverKvp.Value.ServerRole != ServerRoleType.ClusterName.ToString())
                        {
                            StorageSyncModels.RegisteredServer registeredServer = StorageSyncClientWrapper.StorageSyncManagementClient.RegisteredServers.Update(resourceGroupName, resourceName, serverKvp.Value.ServerId, identity: true);
                            if (!registeredServer.Identity.GetValueOrDefault(false))
                            {
                                throw new PSArgumentException($"Not able to set Identity on to server {serverKvp.Key}. Please reach out to administrator for further troubleshooting");
                            }
                        }
                    }

                    WriteObject(storageSyncService);
                }
            });
        }
    }
}