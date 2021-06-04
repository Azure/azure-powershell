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

namespace Microsoft.Azure.Commands.Cdn.AfdOrigin
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnOrigin", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSAfdOrigin))]
    public class SetAzFrontDoorCdnOrigin : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginHostName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string HostName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginHttpPort, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public int HttpPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginHttpsPort, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public int HttpsPort { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdOriginObject, ParameterSetName = ObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAfdOrigin Origin { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdOriginGroupName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OriginGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginHostHeader, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OriginHostHeader { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdOriginName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OriginName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginPriority, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public int Priority { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginPrivateLinkId, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginPrivateLinkLocation, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkLocation { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginPrivateLinkRequestMessage, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkRequestMessage { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginWeight, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public int Weight { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ObjectParameterSet:
                    this.ObjectParameterSetCmdlet();
                    break;
            }

            ConfirmAction(AfdResourceProcessMessage.AfdOriginUpdateMessage, this.OriginName, this.UpdateAfdOrigin);
        }

        private void UpdateAfdOrigin()
        {
            try
            {
                PSAfdOrigin currentPsAfdOrigin = this.CdnManagementClient.AFDOrigins.Get(this.ResourceGroupName, this.ProfileName, this.OriginGroupName, this.OriginName).ToPSAfdOrigin();

                AFDOriginUpdateParameters afdOrigin = new AFDOriginUpdateParameters();

                if (ParameterSetName == ObjectParameterSet)
                {
                    afdOrigin = this.CreateAfdOriginUpdateByObject(currentPsAfdOrigin);
                }
                if (ParameterSetName == FieldsParameterSet)
                {
                    afdOrigin = this.CreateAfdOriginUpdateByFields(currentPsAfdOrigin);
                }

                PSAfdOrigin updatedPsAfdOrigin = this.CdnManagementClient.AFDOrigins.Update(this.ResourceGroupName, this.ProfileName, this.OriginGroupName, this.OriginName, afdOrigin).ToPSAfdOrigin();
                updatedPsAfdOrigin.OriginGroupName = this.OriginGroupName;

                WriteObject(updatedPsAfdOrigin);
            }
            catch (AfdErrorResponseException errorResponse)
            {
                throw new PSArgumentException(errorResponse.Response.Content);
            }
        }

        private void ObjectParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdOriginResourceId = new ResourceIdentifier(this.Origin.Id);

            this.OriginName = parsedAfdOriginResourceId.ResourceName;
            this.OriginGroupName = parsedAfdOriginResourceId.GetResourceName("origingroups");
            this.ProfileName = parsedAfdOriginResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdOriginResourceId.ResourceGroupName;
        }

        private AFDOriginUpdateParameters CreateAfdOriginUpdateByObject(PSAfdOrigin currentPsAfdOrigin)
        {
            SharedPrivateLinkResourceProperties sharedPrivateLinkResource = new SharedPrivateLinkResourceProperties
            {
                PrivateLink = new ResourceReference(currentPsAfdOrigin.PrivateLinkId),
                PrivateLinkLocation = currentPsAfdOrigin.PrivateLinkLocation,
                RequestMessage = currentPsAfdOrigin.PrivateLinkRequestMessage
            };

            AFDOriginUpdateParameters afdOrigin = new AFDOriginUpdateParameters
            {
                HostName = currentPsAfdOrigin.HostName,
                HttpPort = currentPsAfdOrigin.HttpPort,
                HttpsPort = currentPsAfdOrigin.HttpsPort,
                OriginHostHeader = currentPsAfdOrigin.OriginHostHeader,
                Priority = currentPsAfdOrigin.Priority,
                Weight = currentPsAfdOrigin.Weight,
                SharedPrivateLinkResource = sharedPrivateLinkResource
            };

            if (this.Origin.HostName != currentPsAfdOrigin.HostName)
            {
                afdOrigin.HostName = this.Origin.HostName;
            }
            if (this.Origin.HttpPort != currentPsAfdOrigin.HttpPort)
            {
                afdOrigin.HttpPort = this.Origin.HttpPort;
            }
            if (this.Origin.HttpsPort != currentPsAfdOrigin.HttpsPort)
            {
                afdOrigin.HttpsPort = this.Origin.HttpsPort;
            }
            if (this.Origin.OriginHostHeader != currentPsAfdOrigin.OriginHostHeader)
            {
                afdOrigin.OriginHostHeader = this.Origin.OriginHostHeader;
            }
            if (this.Origin.Priority != currentPsAfdOrigin.Priority)
            {
                afdOrigin.Priority = this.Origin.Priority;
            }
            if (this.Origin.Weight != currentPsAfdOrigin.Weight)
            {
                afdOrigin.Weight = this.Origin.Weight;
            }
            if (this.Origin.PrivateLinkId != currentPsAfdOrigin.PrivateLinkId)
            {
                sharedPrivateLinkResource.PrivateLink.Id = this.Origin.PrivateLinkId;
                afdOrigin.SharedPrivateLinkResource = sharedPrivateLinkResource;
            }
            if (this.Origin.PrivateLinkLocation != currentPsAfdOrigin.PrivateLinkLocation)
            {
                sharedPrivateLinkResource.PrivateLinkLocation = this.Origin.PrivateLinkLocation;
                afdOrigin.SharedPrivateLinkResource = sharedPrivateLinkResource;
            }
            if (this.Origin.PrivateLinkRequestMessage != currentPsAfdOrigin.PrivateLinkRequestMessage)
            {
                sharedPrivateLinkResource.RequestMessage = this.Origin.PrivateLinkRequestMessage;
                afdOrigin.SharedPrivateLinkResource = sharedPrivateLinkResource;
            }

            return afdOrigin;
        }

        private AFDOriginUpdateParameters CreateAfdOriginUpdateByFields(PSAfdOrigin currentPsAfdOrigin)
        {
            bool isHostName = this.MyInvocation.BoundParameters.ContainsKey("HostName");
            bool isHttpPort = this.MyInvocation.BoundParameters.ContainsKey("HttpPort");
            bool isHttpsPort = this.MyInvocation.BoundParameters.ContainsKey("HttpsPort");
            bool isPriority = this.MyInvocation.BoundParameters.ContainsKey("Priority");
            bool isWeight = this.MyInvocation.BoundParameters.ContainsKey("Weight");
            bool isOriginHostHeader = this.MyInvocation.BoundParameters.ContainsKey("OriginHostHeader");
            bool isPrivateLinkId = this.MyInvocation.BoundParameters.ContainsKey("PrivateLinkId");
            bool isPrivateLinkLocation = this.MyInvocation.BoundParameters.ContainsKey("PrivateLinkLocation");
            bool isPrivateLinkRequestMessage = this.MyInvocation.BoundParameters.ContainsKey("PrivateLinkRequestMessage");

            AFDOriginUpdateParameters afdOrigin = new AFDOriginUpdateParameters
            {
                HostName = currentPsAfdOrigin.HostName,
                HttpPort = currentPsAfdOrigin.HttpPort,
                HttpsPort = currentPsAfdOrigin.HttpsPort,
                OriginHostHeader = currentPsAfdOrigin.OriginHostHeader,
                Priority = currentPsAfdOrigin.Priority,
                Weight = currentPsAfdOrigin.Weight,
            };

            if (isHostName)
            {
                afdOrigin.HostName = this.HostName;
            }
            if (isHttpPort)
            {
                afdOrigin.HttpPort = this.HttpPort;
            }
            if (isHttpsPort)
            {
                afdOrigin.HttpsPort = this.HttpsPort;
            }
            if (isPriority)
            {
                afdOrigin.Priority = this.Priority;
            }
            if (isWeight)
            {
                afdOrigin.Weight = this.Weight;
            }
            if (isOriginHostHeader)
            {
                afdOrigin.OriginHostHeader = this.OriginHostHeader;
            }

            if (isPrivateLinkId || isPrivateLinkLocation || isPrivateLinkRequestMessage)
            {
                SharedPrivateLinkResourceProperties sharedPrivateLinkResource = new SharedPrivateLinkResourceProperties
                {
                    PrivateLink = new ResourceReference(currentPsAfdOrigin.PrivateLinkId),
                    PrivateLinkLocation = currentPsAfdOrigin.PrivateLinkLocation,
                    RequestMessage = currentPsAfdOrigin.PrivateLinkRequestMessage
                };

                if (isPrivateLinkId)
                {
                    sharedPrivateLinkResource.PrivateLink.Id = this.PrivateLinkId;
                    afdOrigin.SharedPrivateLinkResource = sharedPrivateLinkResource;
                }
                if (isPrivateLinkLocation)
                {
                    sharedPrivateLinkResource.PrivateLinkLocation = this.PrivateLinkLocation;
                    afdOrigin.SharedPrivateLinkResource = sharedPrivateLinkResource;
                }
                if (isPrivateLinkRequestMessage)
                {
                    sharedPrivateLinkResource.RequestMessage = this.PrivateLinkRequestMessage;
                    afdOrigin.SharedPrivateLinkResource = sharedPrivateLinkResource;
                }
            }

            return afdOrigin;
        }
    }
}
