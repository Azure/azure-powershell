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

    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IoTDeviceProvisioningServiceEnrollment", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true)]
    [Alias("Set-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IoTDpsEnrollment")]
    [OutputType(typeof(PSIndividualEnrollment))]
    public class SetAzIotDeviceProvisioningServiceEnrollment : IotDpsBaseCmdlet
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

        [Parameter(Mandatory = true, HelpMessage = "Individual enrollment registration id.")]
        [ValidateNotNullOrEmpty]
        public string RegistrationId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "IoT Hub Device ID.")]
        [ValidateNotNullOrEmpty]
        public string DeviceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Device data to be handled on re-provision to different Iot Hub.")]
        [ValidateNotNullOrEmpty]
        public PSReprovisionType ReprovisionPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Flag indicating edge enablement.")]
        public bool EdgeEnabled { get; set; }

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

        [Parameter(Mandatory = false, HelpMessage = "TPM endorsement key for a TPM device.")]
        [ValidateNotNullOrEmpty]
        public string EndorsementKey { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "TPM storage root key for a TPM device.")]
        [ValidateNotNullOrEmpty]
        public string StorageRootKey { get; set; }

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

        [Parameter(Mandatory = false, HelpMessage = "Switch to update X509attestation using root certificates.")]
        public SwitchParameter RootCertificate { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of the primary root CA certificate. If attestation with a root CA certificate is desired then a root ca name must be provided.")]
        [ValidateNotNullOrEmpty]
        public string PrimaryCAName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of the secondary root CA certificate. If attestation with a root CA certificate is desired then a root ca name must be provided.")]
        [ValidateNotNullOrEmpty]
        public string SecondaryCAName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.DpsName, DPSResources.AddEnrollment))
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

                IndividualEnrollment enrollment = client.GetIndividualEnrollmentAsync(this.RegistrationId).GetAwaiter().GetResult();

                if (enrollment != null)
                {
                    // Updating ProvisioningStatus

                    if (this.IsParameterBound(c => c.ProvisioningStatus))
                    {
                        enrollment.ProvisioningStatus = (ProvisioningStatus)Enum.Parse(typeof(ProvisioningStatus), this.ProvisioningStatus.ToString());
                    }

                    // Updating DeviceId

                    if (this.IsParameterBound(c => c.DeviceId))
                    {
                        enrollment.DeviceId = this.DeviceId;
                    }

                    // Updating InitialTwinState

                    if (this.IsParameterBound(c => c.Tag) || this.IsParameterBound(c => c.Desired))
                    {
                        TwinCollection tags = this.IsParameterBound(c => c.Tag) ? new TwinCollection(JsonConvert.SerializeObject(this.Tag)) : (enrollment.InitialTwinState != null ? enrollment.InitialTwinState.Tags : new TwinCollection());
                        TwinCollection desiredProperties = this.IsParameterBound(c => c.Desired) ? new TwinCollection(JsonConvert.SerializeObject(this.Desired)) : (enrollment.InitialTwinState != null ? enrollment.InitialTwinState.DesiredProperties : new TwinCollection());
                        enrollment.InitialTwinState = new TwinState(tags, desiredProperties);
                    }

                    // Updating Capabilities

                    if (this.IsParameterBound(c => c.EdgeEnabled))
                    {
                        enrollment.Capabilities = new DeviceCapabilities() { IotEdge = this.EdgeEnabled };
                    }

                    // Updating ReprovisionPolicy

                    if (this.IsParameterBound(c => c.ReprovisionPolicy))
                    {
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
                    }

                    // Updating AllocationPolicy and Hub

                    if (this.IsParameterBound(c => c.IotHubHostName) && this.IsParameterBound(c => c.AllocationPolicy))
                    {
                        throw new ArgumentException("\"IotHubHostName\" is not required when allocation-policy is defined.");
                    }

                    if (this.IsParameterBound(c => c.IotHubHostName) && this.IsParameterBound(c => c.IotHub))
                    {
                        throw new ArgumentException("\"IotHubHostName\" is not required when IotHub is defined.");
                    }

                    if (this.IsParameterBound(c => c.IotHubHostName))
                    {
                        enrollment.IotHubHostName = this.IotHubHostName;
                        enrollment.CustomAllocationDefinition = null;
                        enrollment.AllocationPolicy = null;
                        enrollment.IotHubs = null;
                    }

                    if (this.IsParameterBound(c => c.AllocationPolicy))
                    {
                        enrollment.AllocationPolicy = (Devices.Provisioning.Service.AllocationPolicy)Enum.Parse(typeof(Devices.Provisioning.Service.AllocationPolicy), this.AllocationPolicy.ToString());
                    }

                    switch (enrollment.AllocationPolicy)
                    {
                        case Devices.Provisioning.Service.AllocationPolicy.Static:
                            if (this.IsParameterBound(c => c.IotHub))
                            {
                                if (this.IotHub.Length > 1)
                                {
                                    throw new ArgumentException("Please provide only one hub when allocation-policy is defined as Static.");
                                }

                                enrollment.IotHubs = this.IotHub;
                            }
                            enrollment.CustomAllocationDefinition = null;
                            enrollment.IotHubHostName = null;
                            break;
                        case Devices.Provisioning.Service.AllocationPolicy.Custom:
                            if (enrollment.CustomAllocationDefinition == null)
                            {
                                if (!this.IsParameterBound(c => c.WebhookUrl))
                                {
                                    throw new ArgumentException("Please provide an Azure function url when allocation-policy is defined as Custom.");
                                }

                                if (!this.IsParameterBound(c => c.ApiVersion))
                                {
                                    throw new ArgumentException("Please provide an Azure function api-version when allocation-policy is defined as Custom.");
                                }
                            }

                            string webhookUrl = string.Empty, apiVersion = string.Empty;
                            webhookUrl = this.IsParameterBound(c => c.WebhookUrl) ? this.WebhookUrl : enrollment.CustomAllocationDefinition.WebhookUrl;
                            apiVersion = this.IsParameterBound(c => c.ApiVersion) ? this.ApiVersion : enrollment.CustomAllocationDefinition.ApiVersion;

                            enrollment.CustomAllocationDefinition = new CustomAllocationDefinition() { WebhookUrl = webhookUrl, ApiVersion = apiVersion };
                            enrollment.IotHubHostName = null;
                            if (this.IsParameterBound(c => c.IotHub))
                            {
                                enrollment.IotHubs = this.IotHub;
                            }
                            break;
                        case Devices.Provisioning.Service.AllocationPolicy.Hashed:
                        case Devices.Provisioning.Service.AllocationPolicy.GeoLatency:
                            if (this.IsParameterBound(c => c.IotHub))
                            {
                                enrollment.IotHubs = this.IotHub;
                            }
                            enrollment.CustomAllocationDefinition = null;
                            enrollment.IotHubHostName = null;
                            break;
                        default:
                            if (this.IsParameterBound(c => c.IotHub))
                            {
                                throw new ArgumentException("Please provide allocation policy.");
                            }
                            break;
                    }

                    switch (enrollment.Attestation)
                    {
                        case SymmetricKeyAttestation attestation:
                            if (this.IsParameterBound(c => c.PrimaryKey) || this.IsParameterBound(c => c.SecondaryKey))
                            {
                                enrollment.Attestation = new SymmetricKeyAttestation(
                                    this.IsParameterBound(c => c.PrimaryKey) ? this.PrimaryKey : attestation.PrimaryKey,
                                    this.IsParameterBound(c => c.SecondaryKey) ? this.SecondaryKey : attestation.SecondaryKey
                                );
                            }
                            break;
                        case TpmAttestation attestation:
                            if (this.IsParameterBound(c => c.EndorsementKey) || this.IsParameterBound(c => c.StorageRootKey))
                            {
                                enrollment.Attestation = new TpmAttestation(this.IsParameterBound(c => c.EndorsementKey) ? this.EndorsementKey : attestation.EndorsementKey, this.IsParameterBound(c => c.StorageRootKey) ? this.StorageRootKey : attestation.StorageRootKey);
                            }
                            break;
                        case X509Attestation attestation:
                            bool updatedPrimaryCAName = this.IsParameterBound(c => c.PrimaryCAName);
                            bool updatedSecondaryCAName = this.IsParameterBound(c => c.SecondaryCAName);

                            bool updatedPrimaryCertificate = this.IsParameterBound(c => c.PrimaryCertificate);
                            bool updatedSecondaryCertificate = this.IsParameterBound(c => c.SecondaryCertificate);

                            if (updatedPrimaryCAName || updatedSecondaryCAName)
                            {
                                enrollment.Attestation = X509Attestation.CreateFromCAReferences(
                                    updatedPrimaryCAName ? this.PrimaryCAName : attestation.CAReferences.Primary,
                                    updatedSecondaryCAName ? this.SecondaryCAName : (attestation.CAReferences.Secondary ?? null)
                                );

                            }
                            else if (updatedPrimaryCertificate || updatedSecondaryCertificate)
                            {
                                string primaryCer = string.Empty, secondaryCer = string.Empty;
                                if (!updatedPrimaryCertificate)
                                {
                                    throw new ArgumentException("Primary certificate cannot be null or empty.");
                                }
                                primaryCer = IotDpsUtils.GetCertificateString(this.PrimaryCertificate);

                                if (this.IsParameterBound(c => c.SecondaryCertificate))
                                {
                                    secondaryCer = IotDpsUtils.GetCertificateString(this.SecondaryCertificate);

                                    if (this.IsParameterBound(c => c.RootCertificate))
                                    {
                                        enrollment.Attestation = X509Attestation.CreateFromRootCertificates(primaryCer, secondaryCer);
                                    }
                                    else
                                    {
                                        enrollment.Attestation = X509Attestation.CreateFromClientCertificates(primaryCer, secondaryCer);
                                    }
                                }
                                else
                                {
                                    if (this.IsParameterBound(c => c.RootCertificate))
                                    {
                                        enrollment.Attestation = X509Attestation.CreateFromRootCertificates(primaryCer);
                                    }
                                    else
                                    {
                                        enrollment.Attestation = X509Attestation.CreateFromClientCertificates(primaryCer);
                                    }
                                }
                            }
                            break;
                        default: break;
                    }
                }
                else
                {
                    throw new ArgumentException("The enrollment doesn't exist.");
                }

                IndividualEnrollment result = client.CreateOrUpdateIndividualEnrollmentAsync(enrollment).GetAwaiter().GetResult();
                this.WriteObject(IotDpsUtils.ToPSIndividualEnrollment(result));
            }
        }
    }
}
