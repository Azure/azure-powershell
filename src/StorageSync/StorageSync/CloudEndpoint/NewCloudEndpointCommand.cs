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

using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.StorageSync.Common;

using Microsoft.Azure.Commands.StorageSync.Common.Extensions;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Commands.StorageSync.Properties;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.StorageSync;
using Microsoft.Azure.Management.StorageSync.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using System.Threading;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.CloudEndpoint
{

    /// <summary>
    /// Class NewCloudEndpointCommand.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    [Cmdlet(VerbsCommon.New, StorageSyncNouns.NounAzureRmStorageSyncCloudEndpoint,
        DefaultParameterSetName = StorageSyncParameterSets.StringParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSCloudEndpoint))]
    public class NewCloudEndpointCommand : StorageSyncClientCmdletBase
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
        // TODO : Place ResourceNameCompleter for all non root resources. https://github.com/Azure/azure-powershell/issues/8620
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices/syncGroups", "ResourceGroupName", "StorageSyncServiceName")]
        public string SyncGroupName { get; set; }

        /// <summary>
        /// Gets or sets the parent object.
        /// </summary>
        /// <value>The parent object.</value>
        [Parameter(
           Position = 0,
           ParameterSetName = StorageSyncParameterSets.ObjectParameterSet,
           Mandatory = true,
           ValueFromPipeline = true,
           HelpMessage = HelpMessages.SyncGroupObjectParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.SyncGroupAlias)]
        public PSSyncGroup ParentObject { get; set; }

        /// <summary>
        /// Gets or sets the parent resource identifier.
        /// </summary>
        /// <value>The parent resource identifier.</value>
        [Parameter(
          Position = 0,
          ParameterSetName = StorageSyncParameterSets.ParentStringParameterSet,
          Mandatory = true,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = HelpMessages.SyncGroupParentResourceIdParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.SyncGroupIdAlias)]
        public string ParentResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.CloudEndpointNameParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.CloudEndpointNameAlias)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the storage account resource identifier.
        /// </summary>
        /// <value>The storage account resource identifier.</value>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.StorageAccountResourceIdParameter)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter(StorageSyncConstants.StorageAccountType)]
        public string StorageAccountResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the storage account share.
        /// </summary>
        /// <value>The name of the storage account share.</value>
        [Parameter(
          Mandatory = true,
          ValueFromPipelineByPropertyName = false,
          HelpMessage = HelpMessages.AzureFileShareNameParameter)]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.StorageAccountShareNameAlias)]
        public string AzureFileShareName { get; set; }

        /// <summary>
        /// Gets or sets the storage account tenant identifier.
        /// </summary>
        /// <value>The storage account tenant identifier.</value>
        [Parameter(Mandatory = false,
                   ValueFromPipelineByPropertyName = false,
                   HelpMessage = HelpMessages.StorageAccountTenantIdParameter)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountTenantId { get; set; }

        /// <summary>
        /// Gets or sets as job.
        /// </summary>
        /// <value>As job.</value>
        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJobParameter)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Gets the target.
        /// </summary>
        /// <value>The target.</value>
        protected override string Target => Name;

        /// <summary>
        /// Gets the action message.
        /// </summary>
        /// <value>The action message.</value>
        protected override string ActionMessage => $"{StorageSyncResources.NewCloudEndpointActionMessage} {Name}";

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                // Validate Storage Account Resource Id
                var storageAccountResourceIdentifier = new ResourceIdentifier(StorageAccountResourceId);

                if (string.IsNullOrEmpty(storageAccountResourceIdentifier?.ResourceName))
                {
                    throw new PSArgumentException(nameof(StorageAccountResourceId));
                }

                if(this.IsParameterBound(c=>c.StorageAccountTenantId))
                {
                    if(StorageAccountTenantId != AzureContext.Tenant.Id)
                    {
                        throw new PSArgumentException(string.Format(StorageSyncResources.NewCloudEndpointCrossTenantErrorFormat, StorageAccountTenantId, AzureContext.Tenant.Id));
                    }
                }

                if(storageAccountResourceIdentifier.Subscription != AzureContext.Subscription.Id)
                {
                    WriteWarning(string.Format(StorageSyncResources.NewCloudEndpointCrossSubscriptionWarningFormat, storageAccountResourceIdentifier.Subscription , AzureContext.Subscription.Id));

                    if(!StorageSyncClientWrapper.TryRegisterProvider(AzureContext.Subscription.Id,StorageSyncConstants.ResourceProvider, storageAccountResourceIdentifier.Subscription))
                    {
                        WriteWarning(string.Format(StorageSyncResources.NewCloudEndpointUnableToRegisterErrorFormat, storageAccountResourceIdentifier.Subscription));
                    }
                }

                MicrosoftGraphServicePrincipal servicePrincipal = StorageSyncClientWrapper.GetServicePrincipalOrNull();

                if (servicePrincipal == null)
                {
                    throw new PSArgumentException(StorageSyncResources.MissingServicePrincipalResourceIdErrorMessage);
                }
                RoleAssignment roleAssignment = StorageSyncClientWrapper.EnsureRoleAssignment(servicePrincipal, storageAccountResourceIdentifier.Subscription, StorageAccountResourceId);

                var parentResourceIdentifier = default(ResourceIdentifier);

                if (this.IsParameterBound(c => c.ParentResourceId))
                {
                    parentResourceIdentifier = new ResourceIdentifier(ParentResourceId);

                    if (!string.Equals(StorageSyncConstants.SyncGroupType, parentResourceIdentifier.ResourceType, System.StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException(StorageSyncResources.MissingParentResourceIdErrorMessage);
                    }
                }

                var createParameters = new CloudEndpointCreateParameters()
                {
                    StorageAccountResourceId = StorageAccountResourceId,
                    AzureFileShareName = AzureFileShareName,
                    StorageAccountTenantId = (StorageAccountTenantId ?? AzureContext.Tenant.Id)
                };

                string resourceGroupName = ResourceGroupName ?? ParentObject?.ResourceGroupName ?? parentResourceIdentifier.ResourceGroupName;
                string storageSyncServiceName = StorageSyncServiceName ?? ParentObject?.StorageSyncServiceName ?? parentResourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName, 0);
                string syncGroupName = SyncGroupName ?? ParentObject?.SyncGroupName ?? parentResourceIdentifier.ResourceName;

                // Get Storage sync service
                StorageSyncModels.StorageSyncService storageSyncService = StorageSyncClientWrapper.StorageSyncManagementClient.StorageSyncServices.Get(resourceGroupName, storageSyncServiceName);

                if (storageSyncService == null)
                {
                    throw new PSArgumentException(StorageSyncResources.MissingParentResourceIdErrorMessage);
                }
                bool shouldSleep = false;
                if (storageSyncService.Identity != null && storageSyncService.Identity.PrincipalId.GetValueOrDefault(Guid.Empty) != Guid.Empty
                && storageSyncService.UseIdentity.GetValueOrDefault(false))
                {
                    // Identity , RoleDef, Scope
                    var scope = StorageAccountResourceId;
                    var identityRoleAssignmentForSAScope = StorageSyncClientWrapper.EnsureRoleAssignmentWithIdentity(storageAccountResourceIdentifier.Subscription,
                        storageSyncService.Identity.PrincipalId.Value,
                        Common.StorageSyncClientWrapper.StorageAccountContributorRoleDefinitionId,
                        scope);

                    scope = $"{StorageAccountResourceId}/fileServices/default/fileshares/{AzureFileShareName}";
                    var identityRoleAssignmentForFilsShareScope = StorageSyncClientWrapper.EnsureRoleAssignmentWithIdentity(storageAccountResourceIdentifier.Subscription,
                       storageSyncService.Identity.PrincipalId.Value,
                       Common.StorageSyncClientWrapper.StorageFileDataPrivilegedContributorRoleDefinitionId,
                       scope);
                    shouldSleep = true;
                }

                    Target = string.Join("/", resourceGroupName, storageSyncServiceName, syncGroupName, Name);

                if (ShouldProcess(Target, ActionMessage))
                {
                    if (shouldSleep)
                    {
                        StorageSyncClientWrapper.VerboseLogger.Invoke($"Giving time for role assignments to reflect. Sleeping for 120 seconds...");
                        Thread.Sleep(TimeSpan.FromSeconds(120));
                    }
                    StorageSyncModels.CloudEndpoint resource = StorageSyncClientWrapper.StorageSyncManagementClient.CloudEndpoints.Create(
                        resourceGroupName,
                        storageSyncServiceName,
                       syncGroupName,
                        Name,
                        createParameters);

                    WriteObject(resource);
                }
            });
        }

    }
}