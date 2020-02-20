﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.Management.IotHub
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Devices;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubDevice", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSDevice))]
    public class AddAzIotHubDevice : IotHubBaseCmdlet, IDynamicParameters
    {
        private const string ResourceIdParameterSet = "ResourceIdSet";
        private const string ResourceParameterSet = "ResourceSet";
        private const string InputObjectParameterSet = "InputObjectSet";

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = InputObjectParameterSet, ValueFromPipeline = true, HelpMessage = "IotHub object")]
        [ValidateNotNullOrEmpty]
        public PSIotHub InputObject { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Name of the Resource Group")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "IotHub Resource Id")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Devices/IotHubs")]
        public string ResourceId { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string IotHubName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = InputObjectParameterSet, HelpMessage = "Target Device Id.")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Target Device Id.")]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Target Device Id.")]
        [ValidateNotNullOrEmpty]
        public string DeviceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The authorization type an entity is to be created with.")]
        public PSDeviceAuthType AuthMethod { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Set device status upon creation.")]
        public PSDeviceStatus Status { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Description for device status.")]
        public string StatusReason { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Flag indicating edge enablement.")]
        public SwitchParameter EdgeEnabled { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.DeviceId, Properties.Resources.AddIotHubDevice))
            {
                IotHubDescription iotHubDescription;
                if (ParameterSetName.Equals(InputObjectParameterSet))
                {
                    this.ResourceGroupName = this.InputObject.Resourcegroup;
                    this.IotHubName = this.InputObject.Name;
                    iotHubDescription = IotHubUtils.ConvertObject<PSIotHub, IotHubDescription>(this.InputObject);
                }
                else
                {
                    if (ParameterSetName.Equals(ResourceIdParameterSet))
                    {
                        this.ResourceGroupName = IotHubUtils.GetResourceGroupName(this.ResourceId);
                        this.IotHubName = IotHubUtils.GetIotHubName(this.ResourceId);
                    }

                    iotHubDescription = this.IotHubClient.IotHubResource.Get(this.ResourceGroupName, this.IotHubName);
                }

                IEnumerable<SharedAccessSignatureAuthorizationRule> authPolicies = this.IotHubClient.IotHubResource.ListKeys(this.ResourceGroupName, this.IotHubName);
                SharedAccessSignatureAuthorizationRule policy = IotHubUtils.GetPolicy(authPolicies, PSAccessRights.RegistryWrite);

                PSIotHubConnectionString psIotHubConnectionString = IotHubUtils.ToPSIotHubConnectionString(policy, iotHubDescription.Properties.HostName);

                PSDeviceCapabilities psDeviceCapabilities = new PSDeviceCapabilities();
                psDeviceCapabilities.IotEdge = this.EdgeEnabled.IsPresent;

                PSAuthenticationMechanism auth = new PSAuthenticationMechanism();

                PSDevice device = new PSDevice();
                device.Id = this.DeviceId;
                switch (this.AuthMethod)
                {
                    case PSDeviceAuthType.x509_thumbprint:
                        auth.Type = PSAuthenticationType.SelfSigned;
                        auth.X509Thumbprint = new PSX509Thumbprint();
                        auth.X509Thumbprint.PrimaryThumbprint = this.authTypeDynamicParameter.PrimaryThumbprint;
                        auth.X509Thumbprint.SecondaryThumbprint = this.authTypeDynamicParameter.SecondaryThumbprint;
                        break;
                    case PSDeviceAuthType.x509_ca:
                        auth.Type = PSAuthenticationType.CertificateAuthority;
                        break;
                    default:
                        auth.SymmetricKey = new PSSymmetricKey();
                        auth.Type = PSAuthenticationType.Sas;
                        break;
                }
                device.Authentication = auth;
                device.Capabilities = psDeviceCapabilities;
                device.Status = this.Status;
                device.StatusReason = this.StatusReason;

                RegistryManager registryManager = RegistryManager.CreateFromConnectionString(psIotHubConnectionString.PrimaryConnectionString);
                this.WriteObject(IotHubDataPlaneUtils.ToPSDevice(registryManager.AddDeviceAsync(IotHubDataPlaneUtils.ToDevice(device)).GetAwaiter().GetResult()));
            }
        }

        public object GetDynamicParameters()
        {
            if (this.AuthMethod.Equals(PSDeviceAuthType.x509_thumbprint))
            {
                authTypeDynamicParameter = new AuthTypeDynamicParameter();
                return authTypeDynamicParameter;
            }

            return null;
        }

        private AuthTypeDynamicParameter authTypeDynamicParameter;

        public class AuthTypeDynamicParameter
        {
            [Parameter(Mandatory = true, ParameterSetName = InputObjectParameterSet, HelpMessage = "Explicit self-signed certificate thumbprint to use for primary key.")]
            [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Explicit self-signed certificate thumbprint to use for primary key.")]
            [Parameter(Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Explicit self-signed certificate thumbprint to use for primary key.")]
            [ValidateNotNullOrEmpty]
            public string PrimaryThumbprint { get; set; }

            [Parameter(Mandatory = false, ParameterSetName = InputObjectParameterSet, HelpMessage = "Explicit self-signed certificate thumbprint to use for secondary key.")]
            [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Explicit self-signed certificate thumbprint to use for secondary key.")]
            [Parameter(Mandatory = false, ParameterSetName = ResourceParameterSet, HelpMessage = "Explicit self-signed certificate thumbprint to use for secondary key.")]
            [ValidateNotNullOrEmpty]
            public string SecondaryThumbprint { get; set; }
        }
    }
}
