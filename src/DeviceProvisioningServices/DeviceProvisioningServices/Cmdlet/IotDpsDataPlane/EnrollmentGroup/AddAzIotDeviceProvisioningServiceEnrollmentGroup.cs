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
    using Microsoft.Azure.Devices.Provisioning.Service;
    using Microsoft.Azure.Devices.Shared;
    using Microsoft.Azure.Management.DeviceProvisioningServices;
    using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json;
    using DPSResources = Properties.Resources;

    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IoTDeviceProvisioningServiceEnrollmentGroup", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true)]
    [Alias("Add-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IoTDpsEnrollmentGroup")]
    [OutputType(typeof(PSEnrollmentGroup))]
    public class AddAzIotDeviceProvisioningServiceEnrollmentGroup : IotDpsBaseCmdlet
    {
        private const string ResourceParameterSet = "ResourceSet";
        private const string InputObjectParameterSet = "InputObjectSet";
        private const string ResourceIdParameterSet = "ResourceIdSet";

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

        [Parameter(Mandatory = true, HelpMessage = "Name of the enrollment group.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Attestation Mechanism.")]
        [ValidateNotNullOrEmpty]
        public PSAttestationMechanismType AttestationType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The primary symmetric shared access key stored in base64 format.")]
        [ValidateNotNullOrEmpty]
        public string PrimaryKey { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The secondary symmetric shared access key stored in base64 format.")]
        [ValidateNotNullOrEmpty]
        public string SecondaryKey { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The path to the file containing the primary certificate. Base-64 representation of X509 certificate .cer file or .pem file path.")]
        [ValidateNotNullOrEmpty]
        public string PrimaryCertificate { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The path to the file containing the secondary certificate. Base-64 representation of X509 certificate .cer file or .pem file path.")]
        [ValidateNotNullOrEmpty]
        public string SecondaryCertificate { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Allows to create X509attestation using root certificates.")]
        public SwitchParameter RootCertificate { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of the primary root CA certificate. If attestation with a root CA certificate is desired then a root ca name must be provided.")]
        [ValidateNotNullOrEmpty]
        public string PrimaryCAName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of the secondary root CA certificate. If attestation with a root CA certificate is desired then a root ca name must be provided.")]
        [ValidateNotNullOrEmpty]
        public string SecondaryCAName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Device data to be handled on re-provision to different Iot Hub.")]
        [ValidateNotNullOrEmpty]
        public PSReprovisionType ReprovisionPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Flag indicating edge enablement.")]
        public SwitchParameter EdgeEnabled { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Initial twin tags.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Initial twin desired properties.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Desired { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Type of allocation for device assigned to the Hub.")]
        [ValidateNotNullOrEmpty]
        public PSAllocationPolicy AllocationPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enable or disable enrollment entry.")]
        [ValidateNotNullOrEmpty]
        public PSProvisioningStatus ProvisioningStatus { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Host name of the target IoT Hub.")]
        [ValidateNotNullOrEmpty]
        public string IotHubHostName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Host name of target IoT Hub. Use space-separated list for multiple IoT Hubs.")]
        [ValidateNotNullOrEmpty]
        public string[] IotHub { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The webhook URL used for custom allocation requests.")]
        [ValidateNotNullOrEmpty]
        public string WebhookUrl { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The API version of the provisioning service in the custom allocation request.")]
        [ValidateNotNullOrEmpty]
        public string ApiVersion { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.DpsName, DPSResources.AddEnrollmentGroup))
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

                Attestation attestation = null;
                TwinCollection tags = new TwinCollection(), desiredProperties = new TwinCollection();

                if (this.IsParameterBound(c => c.Tag))
                {
                    tags = new TwinCollection(JsonConvert.SerializeObject(this.Tag));
                }

                if (this.IsParameterBound(c => c.Desired))
                {
                    desiredProperties = new TwinCollection(JsonConvert.SerializeObject(this.Desired));
                }

                switch (this.AttestationType)
                {
                    case PSAttestationMechanismType.SymmetricKey:
                        if ((this.IsParameterBound(c => c.PrimaryKey) && !this.IsParameterBound(c => c.SecondaryKey)) ||
                            (!this.IsParameterBound(c => c.PrimaryKey) && this.IsParameterBound(c => c.SecondaryKey)))
                        {
                            throw new ArgumentException("Please provide both primary and secondary key.");
                        }
                        else
                        {
                            attestation = new SymmetricKeyAttestation(this.PrimaryKey, this.SecondaryKey);
                        }
                        break;
                    case PSAttestationMechanismType.Tpm:
                        throw new ArgumentException("\"TPM\" is not a valid attestation mechanism for an enrollment group.");
                    case PSAttestationMechanismType.X509:
                        if (!this.IsParameterBound(c => c.PrimaryCertificate) &&
                            !this.IsParameterBound(c => c.SecondaryCertificate) &&
                            (this.IsParameterBound(c => c.PrimaryCAName) || this.IsParameterBound(c => c.SecondaryCAName)))
                        {
                            if (!this.IsParameterBound(c => c.PrimaryCAName))
                            {
                                throw new ArgumentException("Primary CA reference cannot be null or empty.");
                            }

                            if (this.IsParameterBound(c => c.SecondaryCAName))
                            {
                                attestation = X509Attestation.CreateFromCAReferences(this.PrimaryCAName, this.SecondaryCAName);
                            }
                            else
                            {
                                attestation = X509Attestation.CreateFromCAReferences(this.PrimaryCAName);
                            }
                        }
                        else if (!this.IsParameterBound(c => c.PrimaryCAName) &&
                                 !this.IsParameterBound(c => c.SecondaryCAName) &&
                                 (this.IsParameterBound(c => c.PrimaryCertificate) || this.IsParameterBound(c => c.SecondaryCertificate)))
                        {
                            string primaryCer = string.Empty, secondaryCer = string.Empty;

                            if (!this.IsParameterBound(c => c.PrimaryCertificate))
                            {
                                throw new ArgumentException("Primary certificate cannot be null or empty.");
                            }

                            primaryCer = IotDpsUtils.GetCertificateString(this.PrimaryCertificate);

                            if (this.IsParameterBound(c => c.SecondaryCertificate))
                            {
                                secondaryCer = IotDpsUtils.GetCertificateString(this.SecondaryCertificate);

                                if (this.IsParameterBound(c => c.RootCertificate))
                                {
                                    attestation = X509Attestation.CreateFromRootCertificates(primaryCer, secondaryCer);
                                }
                                else
                                {
                                    attestation = X509Attestation.CreateFromClientCertificates(primaryCer, secondaryCer);
                                }
                            }
                            else
                            {
                                if (this.IsParameterBound(c => c.RootCertificate))
                                {
                                    attestation = X509Attestation.CreateFromRootCertificates(primaryCer);
                                }
                                else
                                {
                                    attestation = X509Attestation.CreateFromClientCertificates(primaryCer);
                                }
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Please provide either CA reference or X509 certificate.");
                        }
                        break;
                    default:
                        throw new ArgumentException("Please provide valid attestation mechanism.");
                }

                EnrollmentGroup enrollment = new EnrollmentGroup(this.Name, attestation);

                enrollment.InitialTwinState = new TwinState(tags, desiredProperties);
                enrollment.Capabilities = new DeviceCapabilities() { IotEdge = this.EdgeEnabled.IsPresent };

                switch (this.ReprovisionPolicy)
                {
                    case PSReprovisionType.reprovisionandmigratedata:
                        enrollment.ReprovisionPolicy = new ReprovisionPolicy() { UpdateHubAssignment = true, MigrateDeviceData = true };
                        break;
                    case PSReprovisionType.reprovisionandresetdata:
                        enrollment.ReprovisionPolicy = new ReprovisionPolicy() { UpdateHubAssignment = true, MigrateDeviceData = false };
                        break;
                    case PSReprovisionType.never:
                        enrollment.ReprovisionPolicy = new ReprovisionPolicy() { UpdateHubAssignment = false, MigrateDeviceData = false };
                        break;
                }

                if (this.IsParameterBound(c => c.AllocationPolicy))
                {
                    if (this.IsParameterBound(c => c.IotHubHostName))
                    {
                        throw new ArgumentException("\"IotHubHostName\" is not required when allocation-policy is defined.");
                    }

                    if (this.AllocationPolicy.Equals(PSAllocationPolicy.Static))
                    {
                        if (this.IsParameterBound(c => c.IotHub))
                        {
                            if (this.IotHub.Length > 1)
                            {
                                throw new ArgumentException("Please provide only one hub when allocation-policy is defined as Static.");
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Please provide a hub to be assigned with device.");
                        }
                    }

                    if (this.AllocationPolicy.Equals(PSAllocationPolicy.Custom))
                    {
                        if (!this.IsParameterBound(c => c.WebhookUrl))
                        {
                            throw new ArgumentException("Please provide an Azure function url when allocation-policy is defined as Custom.");
                        }

                        if (!this.IsParameterBound(c => c.ApiVersion))
                        {
                            throw new ArgumentException("Please provide an Azure function api-version when allocation-policy is defined as Custom.");
                        }

                        enrollment.CustomAllocationDefinition = new CustomAllocationDefinition() { WebhookUrl = this.WebhookUrl, ApiVersion = this.ApiVersion };
                    }

                    enrollment.AllocationPolicy = (Devices.Provisioning.Service.AllocationPolicy)Enum.Parse(typeof(Devices.Provisioning.Service.AllocationPolicy), this.AllocationPolicy.ToString());
                    enrollment.IotHubs = this.IotHub;
                }
                else
                {
                    if (this.IsParameterBound(c => c.IotHub))
                    {
                        throw new ArgumentException("Please provide allocation policy.");
                    }

                    if (this.IsParameterBound(c => c.IotHubHostName))
                    {
                        enrollment.IotHubHostName = this.IotHubHostName;
                    }
                }

                if (this.IsParameterBound(c => c.ProvisioningStatus))
                {
                    enrollment.ProvisioningStatus = (ProvisioningStatus)Enum.Parse(typeof(ProvisioningStatus), this.ProvisioningStatus.ToString());
                }

                EnrollmentGroup result = client.CreateOrUpdateEnrollmentGroupAsync(enrollment).GetAwaiter().GetResult();
                this.WriteObject(IotDpsUtils.ToPSEnrollmentGroup(result));
            }
        }
    }
}
