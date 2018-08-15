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

using System;
using System.Collections;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Models.Profile;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using SdkSku = Microsoft.Azure.Management.Cdn.Models.Sku;
using SdkSkuName = Microsoft.Azure.Management.Cdn.Models.SkuName;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Cdn.Profile
{
    /// <summary>
    /// Defines the New-AzureRmCdnProfile cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnProfile", SupportsShouldProcess = true), OutputType(typeof(PSProfile))]
    public class NewAzureRmCdnProfile : AzureCdnCmdletBase
    {
        /// <summary>
        /// Gets or sets the profile name.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Azure CDN profile name.")]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        /// <summary>
        /// The location in which to create the profile.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The location in which to create the CDN profile.")]
        [LocationCompleter("Microsoft.Cdn/profiles")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// The pricing sku name of the profile.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The pricing sku name of the Azure CDN profile. Valid values are StandardVerizon, StandardAkamai, and PremiumVerizon.")]
        public PSSkuName Sku { get; set; }

        /// <summary>
        /// The resource group name of the profile.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group of the Azure CDN profile will be created in.")]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The tags to associate with the Azure Cdn Profile.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Azure CDN profile.")]
        public Hashtable Tag { get; set; }


        public override void ExecuteCmdlet()
        {

            var existingProfile = CdnManagementClient.Profiles.List()
                .Select(p => p.ToPsProfile())
                .Where(p => p.Name.ToLower() == ProfileName.ToLower())
                .FirstOrDefault(p => p.ResourceGroupName.ToLower() == ResourceGroupName.ToLower());

            if (existingProfile != null)
            {
                throw new PSArgumentException(string.Format(Resources.Error_CreateExistingProfile, ProfileName,
                    ResourceGroupName));
            }

            ConfirmAction(MyInvocation.InvocationName,
                ProfileName,
                NewProfile);
        }

        private void NewProfile()
        {
            var cdnProfile = CdnManagementClient.Profiles.Create(
                ResourceGroupName,
                ProfileName,
                new Management.Cdn.Models.Profile(
                    Location,
                    new SdkSku(Sku.ToString()),
                    id: null,
                    name: null,
                    type: null,
                    tags: Tag.ToDictionaryTags())
                );

            WriteObject(cdnProfile.ToPsProfile());
        }
    }
}
