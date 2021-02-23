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

namespace Microsoft.Azure.Commands.Cdn.AfdOriginGroup
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AfdOriginGroup", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSAfdOriginGroup))]
    public class NewAzAfdOriginGroup : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginGroupAdditionalLatencyInMilliseconds, ParameterSetName = FieldsParameterSet)]
        public int AdditionalLatencyInMilliseconds { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdOriginGroupName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OriginGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginGroupSampleSize, ParameterSetName = FieldsParameterSet)]
        public int SampleSize { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginGroupSuccessfulSamplesRequired, ParameterSetName = FieldsParameterSet)]
        public int SuccessfulSamplesRequired { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(AfdResourceProcessMessage.AfdOriginGroupCreateMessage, this.OriginGroupName, this.CreateAfdOriginGroup);
        }

        public void CreateAfdOriginGroup()
        {
            try
            {
                bool isSampleSize = this.MyInvocation.BoundParameters.ContainsKey("SampleSize");
                bool isSuccessfulSampleRequired = this.MyInvocation.BoundParameters.ContainsKey("SuccessfulSamplesRequired");
                bool isAdditionalLatencyInMilliseconds = this.MyInvocation.BoundParameters.ContainsKey("AdditionalLatencyInMilliseconds");

                AFDOriginGroup afdOriginGroup = new AFDOriginGroup()
                {
                    LoadBalancingSettings = this.CreateLoadBalancingSettings(isSampleSize, isSuccessfulSampleRequired, isAdditionalLatencyInMilliseconds),
                    HealthProbeSettings = null, //implement using same pattern as above
                    ResponseBasedAfdOriginErrorDetectionSettings = null, //implement using same pattern as above
                    
                };
                
                PSAfdOriginGroup psAfdOriginGroup = this.CdnManagementClient.AFDOriginGroups.Create(this.ResourceGroupName, this.ProfileName, this.OriginGroupName, afdOriginGroup).ToPSAfdOriginGroup();

                WriteObject(psAfdOriginGroup);
            }
            catch (AfdErrorResponseException errorResponse)
            {
                throw new PSArgumentException(errorResponse.Response.Content);
            }
        }

        private LoadBalancingSettingsParameters CreateLoadBalancingSettings(bool IsSampleSize, bool IsSuccessfulSampleRequired, bool IsAdditionalLatencyInMilliseconds)
        {
            if (!IsSampleSize && !IsSuccessfulSampleRequired && !IsAdditionalLatencyInMilliseconds)
            {
                return null;
            }

            LoadBalancingSettingsParameters loadBalancingSettings = new LoadBalancingSettingsParameters();

            loadBalancingSettings.SampleSize = IsSampleSize ? this.SampleSize : 4;
            loadBalancingSettings.SuccessfulSamplesRequired = IsSuccessfulSampleRequired ? this.SuccessfulSamplesRequired : 2;
            loadBalancingSettings.AdditionalLatencyInMilliseconds = IsAdditionalLatencyInMilliseconds ? this.AdditionalLatencyInMilliseconds : 0;

            return loadBalancingSettings;
        }
    }
}
