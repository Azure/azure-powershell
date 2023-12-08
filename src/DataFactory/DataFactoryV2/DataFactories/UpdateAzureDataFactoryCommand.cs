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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactoryV2", DefaultParameterSetName = ParameterSetNames.ByFactoryName, SupportsShouldProcess = true), OutputType(typeof(PSDataFactory))]
    public class UpdateAzureDataFactoryCommand : DataFactoryBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 0, Mandatory = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 1, Mandatory = true,
            HelpMessage = Constants.HelpFactoryName)]
        [Alias(Constants.DataFactoryName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        #region Attributes
        [Parameter(Mandatory = false, HelpMessage = Constants.HelpIdentityType)]
        #endregion
        public string IdentityType { get; set; }

        #region Attributes
        [Parameter(Mandatory = false, HelpMessage = Constants.HelpPublicNetworkAccess)]
        #endregion
        public string PublicNetworkAccess { get; set; }

        #region Attributes
        [Parameter(Mandatory = false, HelpMessage = Constants.HelpUserAssignedIdenty)]
        #endregion
        public IDictionary<string, object> UserAssignedIdentity { get; set; }

        #region Attributes
        [Parameter(Mandatory = false, HelpMessage = Constants.HelpEncryptionVaultBaseUrl)]
        #endregion
        public string EncryptionVaultBaseUrl { get; set; }

        #region Attributes
        [Parameter(Mandatory = false, HelpMessage = Constants.HelpEncryptionKeyName)]
        #endregion
        public string EncryptionKeyName { get; set; }

        #region Attributes
        [Parameter(Mandatory = false, HelpMessage = Constants.HelpEncryptionKeyVersion)]
        #endregion
        public string EncryptionKeyVersion { get; set; }

        #region Attributes
        [Parameter(Mandatory = false, HelpMessage = Constants.HelpEncryptionUserAssignedIdentity)]
        #endregion
        public string EncryptionUserAssignedIdentity { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 0, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = Constants.HelpFactoryObject)]
        [ValidateNotNullOrEmpty]
        public PSDataFactory InputObject { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByResourceId, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = Constants.HelpTagsForFactory)]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParameterSetNames.ByFactoryObject, StringComparison.OrdinalIgnoreCase))
            {
                Name = InputObject.DataFactoryName;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(ParameterSetNames.ByResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                Name = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            string factoryIdentityType = FactoryIdentityType.SystemAssigned;
            if (!string.IsNullOrWhiteSpace(this.IdentityType))
            {
                factoryIdentityType = this.IdentityType;
            }

            if (this.UserAssignedIdentity != null && this.UserAssignedIdentity.Count > 0)
            {
                if (!factoryIdentityType.ToLower().Contains(FactoryIdentityType.UserAssigned.ToLower()))
                {
                    factoryIdentityType = FactoryIdentityType.SystemAssignedUserAssigned;
                }
            }
            FactoryIdentity factoryIdentity = new FactoryIdentity(factoryIdentityType, userAssignedIdentities: this.UserAssignedIdentity);

            EncryptionConfiguration encryption = null;
            if (!string.IsNullOrWhiteSpace(this.EncryptionVaultBaseUrl) && !string.IsNullOrWhiteSpace(this.EncryptionKeyName))
            {
                CMKIdentityDefinition cmkIdentity = null;
                if (!string.IsNullOrWhiteSpace(this.EncryptionUserAssignedIdentity))
                {
                    cmkIdentity = new CMKIdentityDefinition(this.EncryptionUserAssignedIdentity);
                }
                encryption = new EncryptionConfiguration(this.EncryptionKeyName, this.EncryptionVaultBaseUrl, this.EncryptionKeyVersion, cmkIdentity);
            }

            string publicNetworkAccess = Management.DataFactory.Models.PublicNetworkAccess.Enabled;
            if (!string.IsNullOrWhiteSpace(this.PublicNetworkAccess))
            {
                publicNetworkAccess = this.PublicNetworkAccess;
            }

            var parameters = new UpdatePSDataFactoryParameters()
            {
                ResourceGroupName = ResourceGroupName,
                PublicNetworkAccess = publicNetworkAccess,
                DataFactoryName = Name,
                EncryptionConfiguration = encryption,
                FactoryIdentity = factoryIdentity,
                Tags = Tag
            };

            if (ShouldProcess(Name))
            {
                WriteObject(DataFactoryClient.UpdatePSDataFactory(parameters));
            }
        }
    }
}
