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

                    // 1. Check if any server available for migration
                    IEnumerable<StorageSyncModels.RegisteredServer> registeredServers = StorageSyncClientWrapper.StorageSyncManagementClient.RegisteredServers.ListByStorageSyncService(resourceGroupName, resourceName);
                    var candidateServersLookup = new Dictionary<string, StorageSyncModels.RegisteredServer>(StringComparer.InvariantCultureIgnoreCase);
                    foreach (var registeredServer in registeredServers)
                    {
                        if (Guid.TryParse(registeredServer.LatestApplicationId, out Guid latestApplicationId))
                        {
                            candidateServersLookup.Add(registeredServer.Id, registeredServer);
                        }
                    }

                    // TODO : Check if we need SkipServerValidation Property in case only CloudEndpoint was added
                    if(candidateServersLookup.Count == 0)
                    {
                        throw new PSArgumentException("No server found which is available for migration.");
                    }

                    // 2. Set System Assigned managed identity to Storage Sync service
                    var updateParameters = new StorageSyncServiceUpdateParameters()
                    {
                        Identity = new ManagedServiceIdentity()
                        {
                            Type = ManagedServiceIdentityType.SystemAssigned 
                        }
                    };
                    storageSyncService = StorageSyncClientWrapper.StorageSyncManagementClient.StorageSyncServices.Update(resourceGroupName, resourceName, updateParameters);
                    if (storageSyncService.Identity != null && storageSyncService.Identity.PrincipalId.GetValueOrDefault(Guid.Empty) != Guid.Empty)
                    {
                        throw new PSArgumentException("Not able to set identity. Please reach out to administrator for further troubleshooting");
                    }

                    // 3. RBAC permission set for Cloud Endpoints and Server Endpoints
                    IEnumerable<StorageSyncModels.SyncGroup> syncGroups = StorageSyncClientWrapper.StorageSyncManagementClient.SyncGroups.ListByStorageSyncService(resourceGroupName, resourceName);
                    foreach (var syncGroup in syncGroups)
                    {
                        IEnumerable<StorageSyncModels.CloudEndpoint> cloudEndpoints = StorageSyncClientWrapper.StorageSyncManagementClient.CloudEndpoints.ListBySyncGroup(resourceGroupName, resourceName, syncGroup.Name);
                        StorageSyncModels.CloudEndpoint cloudEndpoint = cloudEndpoints.FirstOrDefault();

                        if (cloudEndpoint == null)
                        {
                            // TODO : Verbose logging for skipping Syncgroup
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
                        foreach (var serverEndpoint in serverEndpoints)
                        {
                            if (candidateServersLookup.ContainsKey(serverEndpoint.ServerResourceId))
                            {

                                // Identity , RoleDef, Scope
                                scope = $"{cloudEndpoint.StorageAccountResourceId}/fileServices/default/fileshares/{cloudEndpoint.AzureFileShareName}";
                                identityRoleAssignmentForFilsShareScope = StorageSyncClientWrapper.EnsureRoleAssignmentWithIdentity(storageAccountResourceIdentifier.Subscription,
                                   Guid.Parse(candidateServersLookup[serverEndpoint.ServerResourceId].LatestApplicationId),
                                   Common.StorageSyncClientWrapper.StorageFileDataPrivilegedContributorRoleDefinitionId,
                                   scope);
                            }
                        }
                    }

                    // 4 Set UseIdentity for given Storage Sync Service
                    updateParameters = new StorageSyncServiceUpdateParameters()
                    {
                        UseIdentity = true
                    };
                    storageSyncService = StorageSyncClientWrapper.StorageSyncManagementClient.StorageSyncServices.Update(resourceGroupName, resourceName, updateParameters);
                    if (storageSyncService.UseIdentity.GetValueOrDefault(false))
                    {
                        throw new PSArgumentException("Not able to set UseIdentity. Please reach out to administrator for further troubleshooting");
                    }

                    // 5. Patch all servers which were having latest application id.
                    foreach(var serverKvp in candidateServersLookup)
                    {
                        StorageSyncModels.RegisteredServer registeredServer = StorageSyncClientWrapper.StorageSyncManagementClient.RegisteredServers.Update(resourceGroupName, resourceName, serverKvp.Value.ServerId, identity: true);
                        if(!registeredServer.Identity.GetValueOrDefault(false))
                        {
                            throw new PSArgumentException($"Not able to set Identity on to server {serverKvp.Key}. Please reach out to administrator for further troubleshooting");
                        }
                    }

                    WriteObject(storageSyncService);
                }
            });
        }
    }
}