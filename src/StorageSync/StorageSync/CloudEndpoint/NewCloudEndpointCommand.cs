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
using Microsoft.Azure.Commands.StorageSync.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.StorageSync.Common.Extensions;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.Azure.Management.Authorization.Version2015_07_01.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.StorageSync;
using Microsoft.Azure.Management.StorageSync.Models;
using System;
using System.Management.Automation;
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
        /// Gets or sets the name of the storage synchronize service.
        /// </summary>
        /// <value>The name of the storage synchronize service.</value>
        [Parameter(
           Position = 1,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = false,
           HelpMessage = HelpMessages.StorageSyncServiceNameParameter)]
        [StorageSyncServiceCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(StorageSyncAliases.ParentNameAlias)]
        public string StorageSyncServiceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the synchronize group.
        /// </summary>
        /// <value>The name of the synchronize group.</value>
        [Parameter(
           Position = 2,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = false,
           HelpMessage = HelpMessages.SyncGroupNameParameter)]
        [ValidateNotNullOrEmpty]
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
          HelpMessage = HelpMessages.StorageAccountShareNameParameter)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountShareName { get; set; }

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
        /// Kailani Service application ID, for both PROD and PPE (first-party app)
        /// </summary>
        private Guid KailaniAppId = new Guid("9469b9f5-6722-4481-a2b2-14ed560b706f");

        /// <summary>
        /// Gets the target.
        /// </summary>
        /// <value>The target.</value>
        protected override string Target => Name;

        /// <summary>
        /// Gets the action message.
        /// </summary>
        /// <value>The action message.</value>
        protected override string ActionMessage => $"Create a new Cloud Endpoint {Name}";

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Target, ActionMessage))
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

                    if (!IsPlaybackMode)
                    {
                        PSADServicePrincipal servicePrincipal = StorageSyncClientWrapper.EnsureServicePrincipal();

                        if (servicePrincipal == null)
                        {
                            throw new PSArgumentException(nameof(servicePrincipal));
                        }

                        RoleAssignment roleAssignment = StorageSyncClientWrapper.EnsureRoleAssignment(servicePrincipal, StorageAccountResourceId);

                        if (roleAssignment == null)
                        {
                            throw new PSArgumentException(nameof(roleAssignment));
                        }
                    }

                    var parentResourceIdentifier = default(ResourceIdentifier);

                    if (!string.IsNullOrEmpty(ParentResourceId))
                    {
                        parentResourceIdentifier = new ResourceIdentifier(ParentResourceId);

                        if (!string.Equals(StorageSyncConstants.SyncGroupType, parentResourceIdentifier.ResourceType, System.StringComparison.OrdinalIgnoreCase))
                        {
                            throw new PSArgumentException(nameof(ParentResourceId));
                        }
                    }

                    var createParameters = new CloudEndpointCreateParameters()
                    {
                        StorageAccountResourceId = StorageAccountResourceId,
                        StorageAccountShareName = StorageAccountShareName,
                        StorageAccountTenantId = (StorageAccountTenantId ?? DefaultContext.Tenant?.Id)
                    };

                    if (string.IsNullOrEmpty(createParameters.StorageAccountTenantId))
                    {
                        throw new PSArgumentException(nameof(createParameters.StorageAccountTenantId));
                    }

                // TODO : Remove when we record next.
                createParameters.StorageAccountTenantId = "\"" + createParameters.StorageAccountTenantId + "\"";

                    StorageSyncModels.CloudEndpoint resource = StorageSyncClientWrapper.StorageSyncManagementClient.CloudEndpoints.Create(
                        ResourceGroupName ?? ParentObject?.ResourceGroupName ?? parentResourceIdentifier.ResourceGroupName,
                        StorageSyncServiceName ?? ParentObject?.StorageSyncServiceName ?? parentResourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName, 0),
                        SyncGroupName ?? ParentObject?.SyncGroupName ?? parentResourceIdentifier.ResourceName,
                        Name,
                        createParameters);

                    WriteObject(resource);
                });
            }
        }
    }
}