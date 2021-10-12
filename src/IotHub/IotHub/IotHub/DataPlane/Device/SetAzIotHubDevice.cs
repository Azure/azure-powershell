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

    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubDevice", DefaultParameterSetName = ResourceParameterSetForStatus, SupportsShouldProcess = true)]
    [OutputType(typeof(PSDevice))]
    public class SetAzIotHubDevice : IotHubBaseCmdlet, IDynamicParameters
    {
        private const string ResourceIdParameterSetForAuth = "ResourceIdSetForAuth";
        private const string ResourceParameterSetForAuth = "ResourceSetForAuth";
        private const string InputObjectParameterSetForAuth = "InputObjectSetForAuth";

        private const string ResourceIdParameterSetForStatus = "ResourceIdSetForStatus";
        private const string ResourceParameterSetForStatus = "ResourceSetForStatus";
        private const string InputObjectParameterSetForStatus = "InputObjectSetForStatus";

        private const string ResourceIdParameterSetForEdgeEnabled = "ResourceIdSetForEdgeEnabled";
        private const string ResourceParameterSetForEdgeEnabled = "ResourceSetForEdgeEnabled";
        private const string InputObjectParameterSetForEdgeEnabled = "InputObjectSetForEdgeEnabled";

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = InputObjectParameterSetForAuth, ValueFromPipeline = true, HelpMessage = "IotHub object")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = InputObjectParameterSetForStatus, ValueFromPipeline = true, HelpMessage = "IotHub object")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = InputObjectParameterSetForEdgeEnabled, ValueFromPipeline = true, HelpMessage = "IotHub object")]
        [ValidateNotNullOrEmpty]
        public PSIotHub InputObject { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceParameterSetForAuth, HelpMessage = "Name of the Resource Group")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceParameterSetForStatus, HelpMessage = "Name of the Resource Group")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceParameterSetForEdgeEnabled, HelpMessage = "Name of the Resource Group")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceIdParameterSetForAuth, ValueFromPipelineByPropertyName = true, HelpMessage = "IotHub Resource Id")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceIdParameterSetForStatus, ValueFromPipelineByPropertyName = true, HelpMessage = "IotHub Resource Id")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceIdParameterSetForEdgeEnabled, ValueFromPipelineByPropertyName = true, HelpMessage = "IotHub Resource Id")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Devices/IotHubs")]
        public string ResourceId { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceParameterSetForAuth, HelpMessage = "Name of the Iot Hub")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceParameterSetForStatus, HelpMessage = "Name of the Iot Hub")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceParameterSetForEdgeEnabled, HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string IotHubName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = InputObjectParameterSetForAuth, HelpMessage = "Target Device Id.")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceIdParameterSetForAuth, HelpMessage = "Target Device Id.")]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = ResourceParameterSetForAuth, HelpMessage = "Target Device Id.")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = InputObjectParameterSetForStatus, HelpMessage = "Target Device Id.")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceIdParameterSetForStatus, HelpMessage = "Target Device Id.")]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = ResourceParameterSetForStatus, HelpMessage = "Target Device Id.")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = InputObjectParameterSetForEdgeEnabled, HelpMessage = "Target Device Id.")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceIdParameterSetForEdgeEnabled, HelpMessage = "Target Device Id.")]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = ResourceParameterSetForEdgeEnabled, HelpMessage = "Target Device Id.")]
        [ValidateNotNullOrEmpty]
        public string DeviceId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = InputObjectParameterSetForAuth, HelpMessage = "The authorization type an entity is to be created with.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSetForAuth, HelpMessage = "The authorization type an entity is to be created with.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceParameterSetForAuth, HelpMessage = "The authorization type an entity is to be created with.")]
        [ValidateNotNullOrEmpty]
        public PSDeviceAuthType AuthMethod { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = InputObjectParameterSetForStatus, HelpMessage = "Set device status upon creation.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSetForStatus, HelpMessage = "Set device status upon creation.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceParameterSetForStatus, HelpMessage = "Set device status upon creation.")]
        [ValidateNotNullOrEmpty]
        public PSDeviceStatus Status { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = InputObjectParameterSetForStatus, HelpMessage = "Description for device status.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSetForStatus, HelpMessage = "Description for device status.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceParameterSetForStatus, HelpMessage = "Description for device status.")]
        public string StatusReason { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = InputObjectParameterSetForEdgeEnabled, HelpMessage = "Flag indicating edge enablement.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSetForEdgeEnabled, HelpMessage = "Flag indicating edge enablement.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceParameterSetForEdgeEnabled, HelpMessage = "Flag indicating edge enablement.")]
        [ValidateNotNullOrEmpty]
        public bool EdgeEnabled { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.DeviceId, Properties.Resources.UpdateIotHubDevice))
            {
                IotHubDescription iotHubDescription = null;
                switch (ParameterSetName)
                {
                    case InputObjectParameterSetForAuth:
                    case InputObjectParameterSetForStatus:
                    case InputObjectParameterSetForEdgeEnabled:
                        this.ResourceGroupName = this.InputObject.Resourcegroup;
                        this.IotHubName = this.InputObject.Name;
                        iotHubDescription = IotHubUtils.ConvertObject<PSIotHub, IotHubDescription>(this.InputObject);
                        break;
                    case ResourceIdParameterSetForAuth:
                    case ResourceIdParameterSetForStatus:
                    case ResourceIdParameterSetForEdgeEnabled:
                        this.ResourceGroupName = IotHubUtils.GetResourceGroupName(this.ResourceId);
                        this.IotHubName = IotHubUtils.GetIotHubName(this.ResourceId);
                        break;
                }

                if (iotHubDescription == null)
                {
                    iotHubDescription = this.IotHubClient.IotHubResource.Get(this.ResourceGroupName, this.IotHubName);
                }

                IEnumerable<SharedAccessSignatureAuthorizationRule> authPolicies = this.IotHubClient.IotHubResource.ListKeys(this.ResourceGroupName, this.IotHubName);
                SharedAccessSignatureAuthorizationRule policy = IotHubUtils.GetPolicy(authPolicies, PSAccessRights.RegistryWrite);

                PSIotHubConnectionString psIotHubConnectionString = IotHubUtils.ToPSIotHubConnectionString(policy, iotHubDescription.Properties.HostName);
                RegistryManager registryManager = RegistryManager.CreateFromConnectionString(psIotHubConnectionString.PrimaryConnectionString);

                PSDevice device = IotHubDataPlaneUtils.ToPSDevice(registryManager.GetDeviceAsync(this.DeviceId).GetAwaiter().GetResult());

                switch (ParameterSetName)
                {
                    case InputObjectParameterSetForAuth:
                    case ResourceIdParameterSetForAuth:
                    case ResourceParameterSetForAuth:
                        PSAuthenticationMechanism auth = new PSAuthenticationMechanism();
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
                        break;
                    case InputObjectParameterSetForStatus:
                    case ResourceIdParameterSetForStatus:
                    case ResourceParameterSetForStatus:
                        device.Status = this.Status;
                        device.StatusReason = this.StatusReason;
                        break;
                    case InputObjectParameterSetForEdgeEnabled:
                    case ResourceIdParameterSetForEdgeEnabled:
                    case ResourceParameterSetForEdgeEnabled:
                        device.Capabilities.IotEdge = this.EdgeEnabled;
                        break;
                }

                this.WriteObject(IotHubDataPlaneUtils.ToPSDevice(registryManager.UpdateDeviceAsync(IotHubDataPlaneUtils.ToDevice(device)).GetAwaiter().GetResult()));
            }
        }

        public new object GetDynamicParameters()
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
            [Parameter(Mandatory = true, ParameterSetName = InputObjectParameterSetForAuth, HelpMessage = "Explicit self-signed certificate thumbprint to use for primary key.")]
            [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSetForAuth, HelpMessage = "Explicit self-signed certificate thumbprint to use for primary key.")]
            [Parameter(Mandatory = true, ParameterSetName = ResourceParameterSetForAuth, HelpMessage = "Explicit self-signed certificate thumbprint to use for primary key.")]
            [ValidateNotNullOrEmpty]
            public string PrimaryThumbprint { get; set; }

            [Parameter(Mandatory = false, ParameterSetName = InputObjectParameterSetForAuth, HelpMessage = "Explicit self-signed certificate thumbprint to use for secondary key.")]
            [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSetForAuth, HelpMessage = "Explicit self-signed certificate thumbprint to use for secondary key.")]
            [Parameter(Mandatory = false, ParameterSetName = ResourceParameterSetForAuth, HelpMessage = "Explicit self-signed certificate thumbprint to use for secondary key.")]
            [ValidateNotNullOrEmpty]
            public string SecondaryThumbprint { get; set; }
        }
    }
}
