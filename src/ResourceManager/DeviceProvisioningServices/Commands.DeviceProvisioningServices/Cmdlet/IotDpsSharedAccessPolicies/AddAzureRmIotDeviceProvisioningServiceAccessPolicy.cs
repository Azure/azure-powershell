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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
    using DPSResources = Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Properties.Resources;

    [Cmdlet(VerbsCommon.Add, "AzureRmIoTDeviceProvisioningServiceAccessPolicy", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true)]
    [Alias("Add-AzureRmIoTDpsAccessPolicy")]
    [OutputType(typeof(PSSharedAccessSignatureAuthorizationRuleAccessRightsDescription), typeof(List<PSSharedAccessSignatureAuthorizationRuleAccessRights>))]
    public class AddAzureRmIoTDeviceProvisioningServiceAccessPolicy : IotDpsBaseCmdlet
    {
        private const string ResourceParameterSet = "ResourceSet";
        private const string InputObjectParameterSet = "InputObjectSet";
        private const string ResourceIdParameterSet = "ResourceIdSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "IoT Device Provisioning Service Object")]
        [ValidateNotNullOrEmpty]
        public PSProvisioningServiceDescription DpsObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IoT Device Provisioning Service Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            HelpMessage = "Name of the Resource Group")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            HelpMessage = "Name of the IoT Device Provisioning Service")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            HelpMessage = "IoT Device Provisioning Service access policy key name")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "IoT Device Provisioning Service access policy key name")]
        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            HelpMessage = "IoT Device Provisioning Service access policy key name")]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            HelpMessage = "IoT Device Provisioning Service access policy permissions")]
        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "IoT Device Provisioning Service access policy permissions")]
        [Parameter(
            Position = 3,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            HelpMessage = "IoT Device Provisioning Service access policy permissions")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(new string[] { "ServiceConfig", "EnrollmentRead", "EnrollmentWrite", "DeviceConnect", "RegistrationStatusRead", "RegistrationStatusWrite" }, IgnoreCase = true)]
        public string[] Permissions { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, DPSResources.AddAccessPolicy))
            {
                switch (ParameterSetName)
                {
                    case InputObjectParameterSet:
                        this.ResourceGroupName = this.DpsObject.ResourceGroupName;
                        this.Name = this.DpsObject.Name;
                        this.AddIotDpsAccessPolicy();
                        break;

                    case ResourceIdParameterSet:
                        this.ResourceGroupName = IotDpsUtils.GetResourceGroupName(this.ResourceId);
                        this.Name = IotDpsUtils.GetIotDpsName(this.ResourceId);
                        this.AddIotDpsAccessPolicy();
                        break;

                    case ResourceParameterSet:
                        this.AddIotDpsAccessPolicy();
                        break;

                    default:
                        throw new ArgumentException("BadParameterSetName");
                }
            }
        }

        private void WritePSObject(SharedAccessSignatureAuthorizationRuleAccessRightsDescription iotDpsAccessPolicy)
        {
            this.WriteObject(IotDpsUtils.ToPSSharedAccessSignatureAuthorizationRuleAccessRightsDescription(iotDpsAccessPolicy, this.ResourceGroupName, this.Name), false);
        }

        private void WritePSObjects(IList<SharedAccessSignatureAuthorizationRuleAccessRightsDescription> iotDpsAccessPolicies)
        {
            this.WriteObject(IotDpsUtils.ToPSSharedAccessSignatureAuthorizationRuleAccessRightsCollection(iotDpsAccessPolicies), true);
        }

        private void AddIotDpsAccessPolicy()
        {
            ArrayList accessRights = new ArrayList();
            PSAccessRightsDescription psAccessRightsDescription;

            foreach (string permission in this.Permissions)
            {
                if (!Enum.TryParse<PSAccessRightsDescription>(permission.Trim(), true, out psAccessRightsDescription))
                {
                    throw new ArgumentException("Invalid access policy permission");
                }
                else
                {
                    accessRights.Add(psAccessRightsDescription.ToString());
                }
            }

            SharedAccessSignatureAuthorizationRuleAccessRightsDescription iotDpsAccessPolicy = new SharedAccessSignatureAuthorizationRuleAccessRightsDescription()
            {
                KeyName = this.KeyName,
                Rights = string.Join(", ", accessRights.ToArray())
            };

            ProvisioningServiceDescription provisioningServiceDescription = GetIotDpsResource(this.ResourceGroupName, this.Name);
            IList<SharedAccessSignatureAuthorizationRuleAccessRightsDescription> iotDpsAccessPolicyList = GetIotDpsAccessPolicy(this.ResourceGroupName, this.Name);
            iotDpsAccessPolicyList.Add(iotDpsAccessPolicy);
            provisioningServiceDescription.Properties.AuthorizationPolicies = iotDpsAccessPolicyList;
            IotDpsCreateOrUpdate(this.ResourceGroupName, this.Name, provisioningServiceDescription);

            iotDpsAccessPolicyList = GetIotDpsAccessPolicy(this.ResourceGroupName, this.Name);
            if (iotDpsAccessPolicyList.Count == 1)
            {
                this.WritePSObject(iotDpsAccessPolicyList[0]);
            }
            else
            {
                this.WritePSObjects(iotDpsAccessPolicyList);
            }
        }
    }
}

