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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnOriginGroup", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSAfdOriginGroup))]
    public class SetAzFrontDoorCdnOriginGroup : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdOriginGroupAdditionalLatencyInMilliseconds, ParameterSetName = FieldsParameterSet)]
        public int AdditionalLatencyInMillisecond { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = HelpMessageConstants.AfdOriginGroupObject, ParameterSetName = ObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAfdOriginGroup OriginGroup { get; set; }

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
            switch (ParameterSetName)
            {
                case ObjectParameterSet:
                    this.ObjectParameterSetCmdlet();
                    break;
            }

            ConfirmAction(AfdResourceProcessMessage.AfdOriginGroupUpdateMessage, this.OriginGroupName, this.UpdateAfdOriginGroup);
        }

        private void UpdateAfdOriginGroup()
        {
            try
            {
                PSAfdOriginGroup currentPsAfdOriginGroup = this.CdnManagementClient.AFDOriginGroups.Get(this.ResourceGroupName, this.ProfileName, this.OriginGroupName).ToPSAfdOriginGroup();

                AFDOriginGroupUpdateParameters afdOriginGroupParameters = new AFDOriginGroupUpdateParameters();

                if (ParameterSetName == ObjectParameterSet)
                {
                    afdOriginGroupParameters.LoadBalancingSettings = this.CreateLoadBalancingSettingsByObject(currentPsAfdOriginGroup, this.OriginGroup);
                    afdOriginGroupParameters.HealthProbeSettings = this.CreateHealthProbeSettingsByObject(currentPsAfdOriginGroup, this.OriginGroup);
                } 
                else
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

                    afdOriginGroupParameters.LoadBalancingSettings = this.CreateLoadBalancingSettingsByFields(currentPsAfdOriginGroup, isSampleSize, isSuccessfulSampleRequired, isAdditionalLatencyInMilliseconds);
                    afdOriginGroupParameters.HealthProbeSettings = this.CreateHealthProbeSettingsByFields(currentPsAfdOriginGroup, isProbePath, isProbeRequestType, isProbeProtocol, isProbeIntervalInSeconds);

                    if (isTrafficRestorationTimeToHealedOrNewEndpointsInMinutes)
                    {
                        afdOriginGroupParameters.TrafficRestorationTimeToHealedOrNewEndpointsInMinutes = this.TrafficRestorationTimeToHealedOrNewEndpointsInMinutes;
                    }
                }

                PSAfdOriginGroup updatedPsAfdOriginGroup = this.CdnManagementClient.AFDOriginGroups.Update(this.ResourceGroupName, this.ProfileName, this.OriginGroupName, afdOriginGroupParameters).ToPSAfdOriginGroup();

                WriteObject(updatedPsAfdOriginGroup);
            }
            catch (AfdErrorResponseException errorResponse)
            {
                throw new PSArgumentException(errorResponse.Response.Content);
            }
        }

        private void ObjectParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdOriginGroupResourceId = new ResourceIdentifier(this.OriginGroup.Id);

            this.OriginGroupName = parsedAfdOriginGroupResourceId.ResourceName;
            this.ProfileName = parsedAfdOriginGroupResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdOriginGroupResourceId.ResourceGroupName;
        }

        private LoadBalancingSettingsParameters CreateLoadBalancingSettingsByObject(PSAfdOriginGroup currentPsAfdOriginGroup, PSAfdOriginGroup proposedPsAfdOriginGroup)
        {
            // keep current values and only change them if they differ from the input object aka this.OriginGroup
            LoadBalancingSettingsParameters loadBalancingSettings = new LoadBalancingSettingsParameters
            { 
                SampleSize = currentPsAfdOriginGroup.SampleSize,
                SuccessfulSamplesRequired = currentPsAfdOriginGroup.SuccessfulSamplesRequired,
                AdditionalLatencyInMilliseconds = currentPsAfdOriginGroup.AdditionalLatencyInMilliseconds
            };

            if (proposedPsAfdOriginGroup.SampleSize != currentPsAfdOriginGroup.SampleSize)
            {
                loadBalancingSettings.SampleSize = proposedPsAfdOriginGroup.SampleSize;
            }
            
            if (proposedPsAfdOriginGroup.SuccessfulSamplesRequired != currentPsAfdOriginGroup.SuccessfulSamplesRequired)
            {
                loadBalancingSettings.SuccessfulSamplesRequired = proposedPsAfdOriginGroup.SuccessfulSamplesRequired;
            }

            if (proposedPsAfdOriginGroup.AdditionalLatencyInMilliseconds != currentPsAfdOriginGroup.AdditionalLatencyInMilliseconds)
            {
                loadBalancingSettings.AdditionalLatencyInMilliseconds = proposedPsAfdOriginGroup.AdditionalLatencyInMilliseconds;
            }

            return loadBalancingSettings;
        }

        private LoadBalancingSettingsParameters CreateLoadBalancingSettingsByFields(PSAfdOriginGroup currentPsAfdOriginGroup, bool isSampleSize, bool isSuccessfulSampleRequired, bool isAdditionalLatencyInMilliseconds)
        {
            if (!isSampleSize && !isSuccessfulSampleRequired && !isAdditionalLatencyInMilliseconds)
            {
                return null;
            }

            // keep the current values and only change them if they differ from the paramters aka this.SampleSize, this.SuccessfulSamplesRequired, this.AdditionalLatencyInMilliseconds
            LoadBalancingSettingsParameters loadBalancingSettings = new LoadBalancingSettingsParameters
            {
                SampleSize = currentPsAfdOriginGroup.SampleSize,
                SuccessfulSamplesRequired = currentPsAfdOriginGroup.SuccessfulSamplesRequired,
                AdditionalLatencyInMilliseconds = currentPsAfdOriginGroup.AdditionalLatencyInMilliseconds
            };

            if (isSampleSize)
            {
                loadBalancingSettings.SampleSize = this.SampleSize;
            }

            if (isSuccessfulSampleRequired)
            {
                loadBalancingSettings.SuccessfulSamplesRequired = this.SuccessfulSamplesRequired;
            }

            if (isAdditionalLatencyInMilliseconds)
            {
                loadBalancingSettings.AdditionalLatencyInMilliseconds = this.AdditionalLatencyInMillisecond;
            }

            return loadBalancingSettings;
        }

        private HealthProbeParameters CreateHealthProbeSettingsByObject(PSAfdOriginGroup currentPsAfdOriginGroup, PSAfdOriginGroup proposedPsAfdOriginGroup)
        {
            HealthProbeParameters healthProbeSettings = new HealthProbeParameters
            {
                ProbeIntervalInSeconds = currentPsAfdOriginGroup.ProbeIntervalInSeconds,
                ProbePath = currentPsAfdOriginGroup.ProbePath,
                ProbeProtocol = AfdUtilities.CreateProbeProtocol(currentPsAfdOriginGroup.ProbeProtocol),
                ProbeRequestType = AfdUtilities.CreateProbeRequestType(currentPsAfdOriginGroup.ProbeRequestType)
            };

            if (proposedPsAfdOriginGroup.ProbeIntervalInSeconds != currentPsAfdOriginGroup.ProbeIntervalInSeconds)
            {
                healthProbeSettings.ProbeIntervalInSeconds = proposedPsAfdOriginGroup.ProbeIntervalInSeconds;
            }

            if (proposedPsAfdOriginGroup.ProbePath != currentPsAfdOriginGroup.ProbePath)
            {
                healthProbeSettings.ProbePath = proposedPsAfdOriginGroup.ProbePath;
            }

            if (proposedPsAfdOriginGroup.ProbeProtocol != currentPsAfdOriginGroup.ProbeProtocol)
            {
                healthProbeSettings.ProbeProtocol = AfdUtilities.CreateProbeProtocol(proposedPsAfdOriginGroup.ProbeProtocol);
            }

            if (proposedPsAfdOriginGroup.ProbeRequestType != currentPsAfdOriginGroup.ProbeRequestType)
            {
                healthProbeSettings.ProbeRequestType = AfdUtilities.CreateProbeRequestType(proposedPsAfdOriginGroup.ProbeRequestType);
            }

            return healthProbeSettings;
        }

        private HealthProbeParameters CreateHealthProbeSettingsByFields(PSAfdOriginGroup currentPsAfdOriginGroup, bool isProbePath, bool isProbeRequestType, bool isProbeProtocol, bool isProbeIntervalInSeconds)
        {
            if (!isProbePath && !isProbeRequestType && !isProbeProtocol && !isProbeIntervalInSeconds)
            {
                return null;
            }

            HealthProbeParameters healthProbeSettings = new HealthProbeParameters
            {
                ProbeIntervalInSeconds = currentPsAfdOriginGroup.ProbeIntervalInSeconds,
                ProbePath = currentPsAfdOriginGroup.ProbePath,
                ProbeProtocol = AfdUtilities.CreateProbeProtocol(currentPsAfdOriginGroup.ProbeProtocol),
                ProbeRequestType = AfdUtilities.CreateProbeRequestType(currentPsAfdOriginGroup.ProbeRequestType)
            };

            if (isProbePath)
            {
                healthProbeSettings.ProbePath = this.ProbePath;
            }

            if (isProbeRequestType)
            {
                healthProbeSettings.ProbeRequestType = AfdUtilities.CreateProbeRequestType(this.ProbeRequestType);
            }

            if (isProbeProtocol)
            {
                healthProbeSettings.ProbeProtocol = AfdUtilities.CreateProbeProtocol(this.ProbeProtocol);
            }

            if (isProbeIntervalInSeconds)
            {
                healthProbeSettings.ProbeIntervalInSeconds = this.ProbeIntervalInSeconds;
            }

            return healthProbeSettings;
        }
    }
}
