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

namespace Microsoft.Azure.Commands.Management.DeviceProvisioningServices
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Devices.Provisioning.Service;
    using Microsoft.Azure.Management.DeviceProvisioningServices;
    using Microsoft.Azure.Management.DeviceProvisioningServices.Models;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IoTDeviceProvisioningServiceEnrollmentGroup", DefaultParameterSetName = ResourceParameterSet)]
    [Alias("Get-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IoTDpsEnrollmentGroup")]
    [OutputType(typeof(PSEnrollmentGroup), typeof(PSEnrollmentGroups[]))]
    public class GetAzIotDeviceProvisioningServiceEnrollmentGroup : IotDpsBaseCmdlet
    {
        private const string ResourceIdParameterSet = "ResourceIdSet";
        private const string ResourceParameterSet = "ResourceSet";
        private const string InputObjectParameterSet = "InputObjectSet";

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = InputObjectParameterSet, ValueFromPipeline = true, HelpMessage = "IoT Device Provisioning Service Object")]
        [ValidateNotNullOrEmpty]
        public PSProvisioningServiceDescription DpsObject { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "IoT Device Provisioning Service Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Name of the Resource Group")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Name of the IoT Device Provisioning Service")]
        [ValidateNotNullOrEmpty]
        public string DpsName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of the enrollment group.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            ProvisioningServiceDescription provisioningServiceDescription;
            if (ParameterSetName.Equals(InputObjectParameterSet))
            {
                this.ResourceGroupName = this.DpsObject.ResourceGroupName;
                this.DpsName = this.DpsObject.Name;
                provisioningServiceDescription = IotDpsUtils.ConvertObject<PSProvisioningServiceDescription, ProvisioningServiceDescription>(this.DpsObject);
            }
            else
            {
                if (ParameterSetName.Equals(ResourceIdParameterSet))
                {
                    this.ResourceGroupName = IotDpsUtils.GetResourceGroupName(this.ResourceId);
                    this.DpsName = IotDpsUtils.GetIotDpsName(this.ResourceId);
                }

                provisioningServiceDescription = GetIotDpsResource(this.ResourceGroupName, this.DpsName);
            }

            IEnumerable<SharedAccessSignatureAuthorizationRuleAccessRightsDescription> authPolicies = this.IotDpsClient.IotDpsResource.ListKeys(this.DpsName, this.ResourceGroupName);
            SharedAccessSignatureAuthorizationRuleAccessRightsDescription policy = IotDpsUtils.GetPolicy(authPolicies, PSAccessRightsDescription.EnrollmentWrite);
            PSIotDpsConnectionString psIotDpsConnectionString = IotDpsUtils.ToPSIotDpsConnectionString(policy, provisioningServiceDescription.Properties.ServiceOperationsHostName);
            ProvisioningServiceClient client = ProvisioningServiceClient.CreateFromConnectionString(psIotDpsConnectionString.PrimaryConnectionString);

            if (this.Name != null)
            {
                EnrollmentGroup result = client.GetEnrollmentGroupAsync(this.Name).GetAwaiter().GetResult();
                this.WriteObject(IotDpsUtils.ToPSEnrollmentGroup(result));
            }
            else
            {
                QueryResult enrollments = client.CreateEnrollmentGroupQuery(new QuerySpecification("select * from enrollments")).NextAsync().GetAwaiter().GetResult();
                this.WriteObject(IotDpsUtils.ToPSEnrollmentGroups(enrollments.Items), true);
            }
        }
    }
}
