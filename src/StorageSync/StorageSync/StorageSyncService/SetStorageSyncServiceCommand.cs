﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.StorageSync.StorageSyncService
{

    /// <summary>
    /// Set StorageSyncService
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    [Cmdlet(VerbsCommon.Set, StorageSyncNouns.NounAzureRmStorageSyncService,
        DefaultParameterSetName = StorageSyncParameterSets.StringParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSStorageSyncService))]
    public class SetStorageSyncServiceCommand : StorageSyncClientCmdletBase
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
        /// Gets or sets the IncomingTrafficPolicy.
        /// </summary>
        /// <value>The IncomingTrafficPolicy.</value>
        [Parameter(
           Position = 2,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.StorageSyncServiceIncomingTrafficPolicyParameter)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(StorageSyncModels.IncomingTrafficPolicy.AllowVirtualNetworksOnly,
            StorageSyncModels.IncomingTrafficPolicy.AllowAllTraffic,
            IgnoreCase = true)]
        public string IncomingTrafficPolicy { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>The tag.</value>
        [Parameter(
             ParameterSetName = StorageSyncParameterSets.StringParameterSet,
             Mandatory = false,
             HelpMessage = HelpMessages.StorageSyncServiceTagsParameter)]
        [ValidateNotNull]
        [Alias(StorageSyncAliases.TagsAlias)]
        public Hashtable Tag { get; set; }

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

                string incomingTrafficPolicy;
                if (this.IsParameterBound(c => c.IncomingTrafficPolicy))
                {
                    if(string.IsNullOrEmpty(this.IncomingTrafficPolicy))
                    {
                        throw new PSArgumentException(nameof(IncomingTrafficPolicy));
                    }
                    incomingTrafficPolicy = this.IncomingTrafficPolicy;
                }
                else
                {
                    incomingTrafficPolicy = StorageSyncModels.IncomingTrafficPolicy.AllowAllTraffic;
                }

                var updateParameters = new StorageSyncServiceUpdateParameters()
                {
                    Tags = TagsConversionHelper.CreateTagDictionary(Tag ?? new Hashtable(), validate: true),
                    IncomingTrafficPolicy = incomingTrafficPolicy
                };

                Target = string.Join("/", resourceGroupName, resourceName);
                if (ShouldProcess(Target, ActionMessage))
                {
                    StorageSyncModels.StorageSyncService storageSyncService = StorageSyncClientWrapper.StorageSyncManagementClient.StorageSyncServices.Update(ResourceGroupName, Name, updateParameters);

                    WriteObject(storageSyncService);
                }
            });
        }
    }
}