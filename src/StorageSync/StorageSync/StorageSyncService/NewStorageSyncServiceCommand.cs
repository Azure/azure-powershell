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
using System.Collections.Generic;
using System;

namespace Microsoft.Azure.Commands.StorageSync.StorageSyncService
{

    /// <summary>
    /// Creates a new StorageSyncService in a specific location.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    [Cmdlet(VerbsCommon.New, StorageSyncNouns.NounAzureRmStorageSyncService,
        DefaultParameterSetName = StorageSyncParameterSets.StringParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSStorageSyncService))]
    public class NewStorageSyncServiceCommand : StorageSyncClientCmdletBase
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
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        [Parameter(
           Position = 2,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.StorageSyncServiceLocationParameter)]
        [LocationCompleter(StorageSyncConstants.StorageSyncServiceType)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the IncomingTrafficPolicy.
        /// </summary>
        /// <value>The IncomingTrafficPolicy.</value>
        [Parameter(
           Position = 3,
           ParameterSetName = StorageSyncParameterSets.StringParameterSet,
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = HelpMessages.StorageSyncServiceIncomingTrafficPolicyParameter)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(StorageSyncModels.IncomingTrafficPolicy.AllowVirtualNetworksOnly,
            StorageSyncModels.IncomingTrafficPolicy.AllowAllTraffic,
            IgnoreCase = true)]
        public string IncomingTrafficPolicy { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = HelpMessages.StorageSyncServiceAssignIdentityParameter)]
        public SwitchParameter AssignIdentity { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.StorageSyncServiceUserAssignedIdentityIdParameter)]
        [ValidateNotNullOrEmpty]
        public string UserAssignedIdentityId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.StorageSyncServiceIdentityTypeParameter)]
        [ValidateSet(StorageSyncServiceIdentityType.systemAssigned,
            StorageSyncServiceIdentityType.userAssigned,
            StorageSyncServiceIdentityType.systemAssignedUserAssigned,
            StorageSyncServiceIdentityType.none,
            IgnoreCase = true)]
        public string IdentityType { get; set; }

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
        protected override string ActionMessage => $"{StorageSyncResources.NewStorageSyncServiceActionMessage} {Name}";

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {

            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {

                CheckNameAvailabilityResult checkNameAvailabilityResult = StorageSyncClientWrapper.StorageSyncManagementClient.StorageSyncServices.CheckNameAvailability(Location.Replace(" ", string.Empty), Name);

                if (!checkNameAvailabilityResult.NameAvailable.Value)
                {
                    throw new PSArgumentException(checkNameAvailabilityResult.Message, nameof(Name));
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

                var createParameters = new StorageSyncServiceCreateParameters()
                {
                    Location = Location,
                    Tags = TagsConversionHelper.CreateTagDictionary(Tag ?? new Hashtable(), validate: true),
                    IncomingTrafficPolicy = incomingTrafficPolicy
                };

                if (AssignIdentity.IsPresent || this.UserAssignedIdentityId != null || this.IdentityType != null)
                {
                    createParameters.Identity = new ManagedServiceIdentity() { Type = StorageSyncModels.ManagedServiceIdentityType.SystemAssigned };
                    if (this.IdentityType != null)
                    {
                        createParameters.Identity.Type = GetIdentityTypeString(this.IdentityType);
                    }
                    if (this.UserAssignedIdentityId != null)
                    {
                        if (createParameters.Identity.Type != StorageSyncModels.ManagedServiceIdentityType.UserAssigned &&
                        createParameters.Identity.Type != StorageSyncModels.ManagedServiceIdentityType.SystemAssignedUserAssigned)
                        {
                            throw new ArgumentException("UserAssignIdentityId should only be specified when AssignIdentityType is UserAssigned or SystemAssignedUserAssigned.", "UserAssignIdentityId");
                        }
                        createParameters.Identity.UserAssignedIdentities = new Dictionary<string, UserAssignedIdentity>
                        {
                            { this.UserAssignedIdentityId, new UserAssignedIdentity() }
                        };
                    }
                }

                Target = string.Join("/", ResourceGroupName, Name);
                if (ShouldProcess(Target, ActionMessage))
                {
                    StorageSyncModels.StorageSyncService storageSyncService = StorageSyncClientWrapper.StorageSyncManagementClient.StorageSyncServices.Create(ResourceGroupName, Name, createParameters);

                    WriteObject(storageSyncService);
                }
            });
        }

        public static string GetIdentityTypeString(string inputIdentityType)
        {
            if (inputIdentityType == null)
            {
                return null;
            }

            // The parameter validate set make sure the value must be systemAssigned or userAssigned or systemAssignedUserAssigned or None
            if (inputIdentityType.ToLower() == StorageSyncServiceIdentityType.systemAssigned.ToLower())
            {
                return StorageSyncModels.ManagedServiceIdentityType.SystemAssigned;
            }
            if (inputIdentityType.ToLower() == StorageSyncServiceIdentityType.userAssigned.ToLower())
            {
                return StorageSyncModels.ManagedServiceIdentityType.UserAssigned;
            }
            if (inputIdentityType.ToLower() == StorageSyncServiceIdentityType.systemAssignedUserAssigned.ToLower())
            {
                return StorageSyncModels.ManagedServiceIdentityType.SystemAssignedUserAssigned;
            }
            if (inputIdentityType.ToLower() == StorageSyncServiceIdentityType.none.ToLower())
            {
                return StorageSyncModels.ManagedServiceIdentityType.None;
            }
            throw new ArgumentException("The value for AssignIdentityType is not valid, the valid value are: \"None\", \"SystemAssigned\", \"UserAssigned\", or \"SystemAssignedUserAssigned\"", "AssignIdentityType");
        }
        protected struct StorageSyncServiceIdentityType
        {
            internal const string systemAssigned = "SystemAssigned";
            internal const string userAssigned = "UserAssigned";
            internal const string systemAssignedUserAssigned = "SystemAssignedUserAssigned";
            internal const string none = "None";
        }
    }
}