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

using System.Management.Automation;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Models.Origin;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Cdn.Origin
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnOrigin", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSOrigin))]
    public class NewAzCdnOrigin : AzureCdnCmdletBase
    {

        [Parameter(Mandatory = true, HelpMessage = "Azure CDN endpoint name.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure CDN origin host name.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string HostName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure CDN origin http port.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public int? HttpPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure CDN origin https port.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public int? HttpsPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure CDN origin host header.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OriginHostHeader { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure CDN origin name.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OriginName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure CDN profile name.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure CDN origin priority.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public int? Priority { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure CDN origin private link alias.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkAlias { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "A custom message to be included in the approval request to connect to the Private Link.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkApprovalMessage { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure CDN origin private link location.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkLocation { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure CDN origin private link resource id.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkResourceId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource group of the Azure CDN profile.", ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure CDN origin weight.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public int? Weight { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The CDN origin object.", ParameterSetName = ObjectParameterSet)]
        [ValidateNotNull]
        public PSOrigin CdnOrigin { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = CdnOrigin.ResourceGroupName;
                ProfileName = CdnOrigin.ProfileName;
                EndpointName = CdnOrigin.EndpointName;
                OriginName = CdnOrigin.Name;
                HostName = CdnOrigin.HostName;
                HttpPort = CdnOrigin.HttpPort;
                HttpsPort = CdnOrigin.HttpsPort;
                OriginHostHeader = CdnOrigin.OriginHostHeader;
                Priority = CdnOrigin.Priority;
                PrivateLinkAlias = CdnOrigin.PrivateLinkAlias;
                PrivateLinkApprovalMessage = CdnOrigin.PrivateLinkApprovalMessage;
                PrivateLinkLocation = CdnOrigin.PrivateLinkLocation;
                PrivateLinkResourceId = CdnOrigin.PrivateLinkResourceId;
                Weight = CdnOrigin.Weight;

            }

            ConfirmAction(MyInvocation.InvocationName, OriginName, CreateOrigin);
        }

        private void CreateOrigin()
        {
            Management.Cdn.Models.Origin originProperties = new Management.Cdn.Models.Origin();

            originProperties.HostName = HostName;
            originProperties.HttpPort = HttpPort;
            originProperties.HttpsPort = HttpsPort;
            originProperties.OriginHostHeader = OriginHostHeader;
            originProperties.Priority = Priority;
            originProperties.PrivateLinkAlias = PrivateLinkAlias;
            originProperties.PrivateLinkApprovalMessage = PrivateLinkApprovalMessage;
            originProperties.PrivateLinkLocation = PrivateLinkLocation;
            originProperties.Weight = Weight;

            try
            {
                var origin = CdnManagementClient.Origins.Create(
                    ResourceGroupName,
                    ProfileName,
                    EndpointName,
                    OriginName,
                    originProperties);

                WriteVerbose(Resources.Success);
                WriteObject(origin.ToPsOrigin());
            }
            catch (Microsoft.Azure.Management.Cdn.Models.ErrorResponseException e)
            {
                throw new PSArgumentException(string.Format("Error response received.Error Message: '{0}'",
                                     e.Response.Content));
            }
        }
    }
}
