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
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdOriginGroup
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnOriginGroup", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzFrontDoorCdnOriginGroup : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = HelpMessageConstants.AfdOriginGroupObject, ParameterSetName = ObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAfdOriginGroup OriginGroup { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdOriginGroupName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OriginGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceId, ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            // no case for FieldsParameterSet since required parameters will be present
            switch (ParameterSetName)
            {
                case ObjectParameterSet:
                    this.ObjectParameterSetCmdlet();
                    break;
                case ResourceIdParameterSet:
                    this.ResourceIdParameterSetCmdlet();
                    break;
            }

            ConfirmAction(AfdResourceProcessMessage.AfdOriginGroupDeleteMessage, this.OriginGroupName, this.DeleteAfdOriginGroup);
        }

        private void DeleteAfdOriginGroup()
        {
            try
            {
                this.CdnManagementClient.AFDOriginGroups.Delete(this.ResourceGroupName, this.ProfileName, this.OriginGroupName);
            }
            catch (AfdErrorResponseException errorResponseException)
            {
                throw new PSArgumentException(errorResponseException.Response.Content);
            }

            if (this.PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }

        private void ObjectParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdOriginGroupResourceId = new ResourceIdentifier(this.OriginGroup.Id);

            this.OriginGroupName = parsedAfdOriginGroupResourceId.ResourceName;
            this.ProfileName = parsedAfdOriginGroupResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdOriginGroupResourceId.ResourceGroupName;
        }

        private void ResourceIdParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdOriginGroupResouceId = new ResourceIdentifier(this.ResourceId);

            this.OriginGroupName = parsedAfdOriginGroupResouceId.ResourceName;
            this.ProfileName = parsedAfdOriginGroupResouceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdOriginGroupResouceId.ResourceGroupName;
        }
    }
}
