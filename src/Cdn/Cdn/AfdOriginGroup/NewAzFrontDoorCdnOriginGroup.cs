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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnOriginGroup", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSAfdOriginGroup))]
    public class NewAzFrontDoorCdnOriginGroup : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginGroupAdditionalLatencyInMilliseconds, ParameterSetName = FieldsParameterSet)]
        public int AdditionalLatencyInMillisecond { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdOriginGroupName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OriginGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginGroupProbeIntervalInSeconds, ParameterSetName = FieldsParameterSet)]
        public int ProbeIntervalInSeconds { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginGroupProbePath, ParameterSetName = FieldsParameterSet)]
        public string ProbePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginGroupProbeProtocol, ParameterSetName = FieldsParameterSet)]
        [PSArgumentCompleter("Http", "Https")]
        public string ProbeProtocol { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginGroupProbeRequestType, ParameterSetName = FieldsParameterSet)]
        [PSArgumentCompleter("GET", "HEAD")]
        public string ProbeRequestType { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginGroupSampleSize, ParameterSetName = FieldsParameterSet)]
        public int SampleSize { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginGroupSuccessfulSamplesRequired, ParameterSetName = FieldsParameterSet)]
        public int SuccessfulSamplesRequired { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginGroupTrafficRestorationTimeToHealedOrNewEndpointsInMinutes, ParameterSetName = FieldsParameterSet)]
        public int TrafficRestorationTimeToHealedOrNewEndpointsInMinutes { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(AfdResourceProcessMessage.AfdOriginGroupCreateMessage, this.OriginGroupName, this.CreateAfdOriginGroup);
        }

        public void CreateAfdOriginGroup()
        {
            try
            {
                // availability of load balancing settings parameters
                bool isSampleSize = this.MyInvocation.BoundParameters.ContainsKey("SampleSize");
                bool isSuccessfulSampleRequired = this.MyInvocation.BoundParameters.ContainsKey("SuccessfulSamplesRequired");
                bool isAdditionalLatencyInMilliseconds = this.MyInvocation.BoundParameters.ContainsKey("AdditionalLatencyInMillisecond");

                // availability of health probe settings parameters
                bool isProbePath = this.MyInvocation.BoundParameters.ContainsKey("ProbePath");
                bool isProbeRequestType = this.MyInvocation.BoundParameters.ContainsKey("ProbeRequestType");
                bool isProbeProtocol = this.MyInvocation.BoundParameters.ContainsKey("ProbeProtocol");
                bool isProbeIntervalInSeconds = this.MyInvocation.BoundParameters.ContainsKey("ProbeIntervalInSeconds");

                // availability of parameters on the origin group
                bool isTrafficRestorationTimeToHealedOrNewEndpointsInMinutes = this.MyInvocation.BoundParameters.ContainsKey("TrafficRestorationTimeToHealedOrNewEndpointsInMinutes");

                AFDOriginGroup afdOriginGroup = new AFDOriginGroup()
                {
                    LoadBalancingSettings = this.CreateLoadBalancingSettings(isSampleSize, isSuccessfulSampleRequired, isAdditionalLatencyInMilliseconds),
                    HealthProbeSettings = this.CreateHealthProbeSettings(isProbePath, isProbeRequestType, isProbeProtocol, isProbeIntervalInSeconds),
                    TrafficRestorationTimeToHealedOrNewEndpointsInMinutes = isTrafficRestorationTimeToHealedOrNewEndpointsInMinutes ? this.TrafficRestorationTimeToHealedOrNewEndpointsInMinutes : 10 
                };
                
                PSAfdOriginGroup psAfdOriginGroup = this.CdnManagementClient.AFDOriginGroups.Create(this.ResourceGroupName, this.ProfileName, this.OriginGroupName, afdOriginGroup).ToPSAfdOriginGroup();

                WriteObject(psAfdOriginGroup);
            }
            catch (AfdErrorResponseException errorResponse)
            {
                throw new PSArgumentException(errorResponse.Response.Content);
            }
        }

        private LoadBalancingSettingsParameters CreateLoadBalancingSettings(bool isSampleSize, bool isSuccessfulSampleRequired, bool isAdditionalLatencyInMilliseconds)
        {
            if (!isSampleSize && !isSuccessfulSampleRequired && !isAdditionalLatencyInMilliseconds)
            {
                return null;
            }

            LoadBalancingSettingsParameters loadBalancingSettings = new LoadBalancingSettingsParameters
            {
                SampleSize = isSampleSize ? this.SampleSize : 4,
                SuccessfulSamplesRequired = isSuccessfulSampleRequired ? this.SuccessfulSamplesRequired : 2,
                AdditionalLatencyInMilliseconds = isAdditionalLatencyInMilliseconds ? this.AdditionalLatencyInMillisecond : 0
            };
          
            return loadBalancingSettings;
        }

        private HealthProbeParameters CreateHealthProbeSettings(bool isProbePath, bool isProbeRequestType, bool isProbeProtocol, bool isProbeIntervalInSeconds)
        {
            if (!isProbePath && !isProbeRequestType && !isProbeProtocol && !isProbeIntervalInSeconds)
            {
                return null;
            }

            HealthProbeParameters healthProbeSettings = new HealthProbeParameters
            {
                ProbePath = isProbePath ? this.ProbePath : "/",
                ProbeRequestType = isProbeRequestType ? AfdUtilities.CreateProbeRequestType(this.ProbeRequestType) : HealthProbeRequestType.HEAD,
                ProbeProtocol = isProbeProtocol ? AfdUtilities.CreateProbeProtocol(this.ProbeProtocol) : Management.Cdn.Models.ProbeProtocol.Http,
                ProbeIntervalInSeconds = isProbeIntervalInSeconds ? this.ProbeIntervalInSeconds : 240
            };

            return healthProbeSettings;
        }
    }
}
