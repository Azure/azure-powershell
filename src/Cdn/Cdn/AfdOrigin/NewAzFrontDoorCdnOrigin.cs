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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdOrigin
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnOrigin", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSAfdOrigin))]
    public class NewAzFrontDoorCdnOrigin : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdOriginHostName)]
        [ValidateNotNullOrEmpty]
        public string HostName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginHttpPort)]
        [ValidateNotNullOrEmpty]
        public int HttpPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginHttpsPort)]
        [ValidateNotNullOrEmpty]
        public int HttpsPort { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdOriginGroupName)]
        [ValidateNotNullOrEmpty]
        public string OriginGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginHostHeader)]
        [ValidateNotNullOrEmpty]
        public string OriginHostHeader { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdOriginName)]
        [ValidateNotNullOrEmpty]
        public string OriginName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginPriority)]
        [ValidateNotNullOrEmpty]
        public int Priority { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdOriginPrivateLinkId, ParameterSetName = AfdParameterSet.SharedPrivateLinkResource)]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdOriginPrivateLinkLocation, ParameterSetName = AfdParameterSet.SharedPrivateLinkResource)]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkLocation { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdOriginPrivateLinkRequestMessage, ParameterSetName = AfdParameterSet.SharedPrivateLinkResource)]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkRequestMessage { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginWeight)]
        [ValidateNotNullOrEmpty]
        public int Weight { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(AfdResourceProcessMessage.AfdOriginCreateMessage, this.OriginName, this.CreateAfdOrigin);
        }

        private void CreateAfdOrigin()
        {
            try
            {
                AFDOrigin afdOrigin = new AFDOrigin
                {
                    HostName = this.HostName,
                    SharedPrivateLinkResource = this.CreateSharedPrivateLinkResource()
                };

                if (this.MyInvocation.BoundParameters.ContainsKey("HttpPort"))
                {
                    afdOrigin.HttpPort = this.HttpPort;
                }

                if (this.MyInvocation.BoundParameters.ContainsKey("HttpsPort"))
                {
                    afdOrigin.HttpsPort = this.HttpsPort;
                }

                if (this.MyInvocation.BoundParameters.ContainsKey("OriginHostHeader"))
                {
                    afdOrigin.OriginHostHeader = this.OriginHostHeader;
                }

                if (this.MyInvocation.BoundParameters.ContainsKey("Priority"))
                {
                    afdOrigin.Priority = this.Priority;
                }

                if (this.MyInvocation.BoundParameters.ContainsKey("Weight"))
                {
                    afdOrigin.Weight = this.Weight;
                }

                PSAfdOrigin psAfdOrigin = this.CdnManagementClient.AFDOrigins.Create(this.ResourceGroupName, this.ProfileName, this.OriginGroupName, this.OriginName, afdOrigin).ToPSAfdOrigin();
                psAfdOrigin.OriginGroupName = this.OriginGroupName;

                WriteObject(psAfdOrigin);
            }
            catch (AfdErrorResponseException errorResponse)
            {
                throw new PSArgumentException(errorResponse.Response.Content);
            }
        }

        private SharedPrivateLinkResourceProperties CreateSharedPrivateLinkResource()
        {
            bool isPrivateLinkId = this.MyInvocation.BoundParameters.ContainsKey("PrivateLinkId");
            bool isPrivateLinkLocation = this.MyInvocation.BoundParameters.ContainsKey("PrivateLinkLocation");
            bool isPrivateLinkRequestMessage = this.MyInvocation.BoundParameters.ContainsKey("PrivateLinkRequestMessage");

            if (!isPrivateLinkId && !isPrivateLinkLocation && !isPrivateLinkRequestMessage)
            {
                return null;
            }

            SharedPrivateLinkResourceProperties sharedPrivateLinkResource = new SharedPrivateLinkResourceProperties
            {
                PrivateLink = new ResourceReference(this.PrivateLinkId),
                PrivateLinkLocation = this.PrivateLinkLocation,
                RequestMessage = this.PrivateLinkRequestMessage
            };

            return sharedPrivateLinkResource;
        }
    }
}
