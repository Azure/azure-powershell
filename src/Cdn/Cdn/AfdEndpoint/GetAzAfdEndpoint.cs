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

using System.Management.Automation;
using Microsoft.Azure.Commands.Cdn.AfdModels.AfdEndpoint;
using Microsoft.Azure.Commands.Cdn.AfdModels.AfdProfile;
using Microsoft.Azure.Commands.Cdn.AfdHelpers;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Management.Cdn;

namespace Microsoft.Azure.Commands.Cdn.AfdEndpoint
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AfdEndpoint", DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSAfdEndpoint))]
    public class GetAzAfdEndpoint : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName {get; set;}

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AfdProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdEndpointName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AfdEndpointName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = HelpMessageConstants.AfdProfileObjectDescription, ParameterSetName = ObjectParameterSet)]
        [ValidateNotNull]
        public PSAfdProfile AfdProfile { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (ParameterSetName == ObjectParameterSet)
                {
                    this.ResourceGroupName = AfdResourceUtilities.GetResourceGroupFromAfdProfile(AfdProfile);
                    this.AfdProfileName = AfdProfile.Name;

                    // change var to actual data type
                    var endpoints = CdnManagementClient.AFDEndpoints.ListByProfile(this.ResourceGroupName, this.AfdProfileName);
                }

                if (AfdUtilities.IsValuePresent(this.ResourceGroupName) && AfdUtilities.IsValuePresent(this.AfdProfileName) && AfdUtilities.IsValuePresent(this.AfdEndpointName))
                {
                    Microsoft.Azure.Management.Cdn.Models.AFDEndpoint afdEndpoint = CdnManagementClient.AFDEndpoints.Get(this.ResourceGroupName, this.AfdProfileName, this.AfdEndpointName);
                    WriteObject(afdEndpoint.ToPSAfdEndpoint());
                }

                // all endpoints in the profile

            } catch(Microsoft.Azure.Management.Cdn.Models.AfdErrorResponseException errorResponse)
            {
                throw new PSArgumentException(errorResponse.Response.Content);
            }
           
        }
    }
}
