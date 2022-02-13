// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Cdn.AfdHelpers;
using Microsoft.Azure.Commands.Cdn.AfdModels;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdProfile
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnProfile", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSAfdProfile))]
    public class NewAzFrontDoorCdnProfile : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileSku, ParameterSetName = FieldsParameterSet)]
        [PSArgumentCompleter(AfdSkuConstants.PremiumAzureFrontDoor, AfdSkuConstants.StandardAzureFrontDoor)]
        public string Sku { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.TagsDescription, ParameterSetName = FieldsParameterSet)]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(AfdResourceProcessMessage.AfdProfileCreateMessage, this.ProfileName, this.CreateAfdProfile);     
        }

        private void CreateAfdProfile()
        {  
            try
            {
                Sku afdSku = AfdUtilities.GenerateAfdProfileSku(this.Sku);

                if (afdSku == null)
                {
                    throw new PSArgumentException($"{this.Sku} is not a valid SKU. Please use {AfdSkuConstants.PremiumAzureFrontDoor} or {AfdSkuConstants.StandardAzureFrontDoor}.");
                }

                Management.Cdn.Models.Profile afdProfile = new Management.Cdn.Models.Profile
                {
                    Location = AfdResourceConstants.AfdResourceLocation,
                    Sku = afdSku,
                    Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, true)
                };

                PSAfdProfile psAfdProfile = this.CdnManagementClient.Profiles.Create(this.ResourceGroupName, this.ProfileName, afdProfile).ToPSAfdProfile();

                WriteObject(psAfdProfile);
            }
            catch (AfdErrorResponseException errorResponseException)
            {
                throw new PSArgumentException(errorResponseException.Response.Content);
            }
        }
    }
}
