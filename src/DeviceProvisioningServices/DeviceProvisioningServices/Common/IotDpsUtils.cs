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
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models;
    using Microsoft.Azure.Devices.Provisioning.Service;
    using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
    using Newtonsoft.Json;

    public static class IotDpsUtils
    {
        const string TotalDeviceCountMetricName = "TotalDeviceCount";
        const string UnlimitedString = "Unlimited";
        const string IotDpsConnectionStringTemplate = "HostName={0};SharedAccessKeyName={1};SharedAccessKey={2}";

        public static T2 ConvertObject<T1, T2>(T1 iotDpsObject)
        {
            return JsonConvert.DeserializeObject<T2>(JsonConvert.SerializeObject(iotDpsObject));
        }

        public static IEnumerable<PSProvisioningServicesDescription> ToPSProvisioningServicesDescription(IEnumerable<ProvisioningServiceDescription> provisioningServiceDescriptions)
        {
            return ConvertObject<IEnumerable<ProvisioningServiceDescription>, IEnumerable<PSProvisioningServicesDescription>>(provisioningServiceDescriptions.ToList());
        }

        public static PSProvisioningServiceDescription ToPSProvisioningServiceDescription(ProvisioningServiceDescription provisioningServiceDescription)
        {
            return ConvertObject<ProvisioningServiceDescription, PSProvisioningServiceDescription>(provisioningServiceDescription);
        }

        public static IotDpsPropertiesDescription ToIotDpsPropertiesDescription(PSIotDpsPropertiesDescription psIotDpsPropertiesDescription)
        {
            return ConvertObject<PSIotDpsPropertiesDescription, IotDpsPropertiesDescription>(psIotDpsPropertiesDescription);
        }

        public static TagsResource ToTagsResource(IDictionary<string, string> tags)
        {
            return new TagsResource(tags);
        }

        public static PSSharedAccessSignatureAuthorizationRuleAccessRightsDescription ToPSSharedAccessSignatureAuthorizationRuleAccessRightsDescription(SharedAccessSignatureAuthorizationRuleAccessRightsDescription accessPolicy, string resourceGroupName, string name)
        {
            PSSharedAccessSignatureAuthorizationRuleAccessRightsDescription psSharedAccessSignatureAuthorizationRuleAccessRightsDescription = ConvertObject<SharedAccessSignatureAuthorizationRuleAccessRightsDescription, PSSharedAccessSignatureAuthorizationRuleAccessRightsDescription>(accessPolicy);
            psSharedAccessSignatureAuthorizationRuleAccessRightsDescription.ResourceGroupName = resourceGroupName;
            psSharedAccessSignatureAuthorizationRuleAccessRightsDescription.Name = name;
            return psSharedAccessSignatureAuthorizationRuleAccessRightsDescription;
        }

        public static IList<PSSharedAccessSignatureAuthorizationRuleAccessRights> ToPSSharedAccessSignatureAuthorizationRuleAccessRightsCollection(IList<SharedAccessSignatureAuthorizationRuleAccessRightsDescription> accessPolicies)
        {
            return ConvertObject<IList<SharedAccessSignatureAuthorizationRuleAccessRightsDescription>, IList<PSSharedAccessSignatureAuthorizationRuleAccessRights>>(accessPolicies);
        }

        public static PSIotHubDefinitionDescription ToPSIotHubDefinitionDescription(IotHubDefinitionDescription linkedHub, string resourceGroupName, string name)
        {
            PSIotHubDefinitionDescription psIotHubDefinitionDescription = ConvertObject<IotHubDefinitionDescription, PSIotHubDefinitionDescription>(linkedHub);
            psIotHubDefinitionDescription.ResourceGroupName = resourceGroupName;
            psIotHubDefinitionDescription.Name = name;
            return psIotHubDefinitionDescription;
        }

        public static IList<PSIotHubDefinitions> ToPSIotHubDefinitionDescription(IList<IotHubDefinitionDescription> linkedHubs)
        {
            return ConvertObject<IList<IotHubDefinitionDescription>, IList<PSIotHubDefinitions>>(linkedHubs);
        }

        public static PSCertificateResponse ToPSCertificateResponse(CertificateResponse certificateResponse)
        {
            return ConvertObject<CertificateResponse, PSCertificateResponse>(certificateResponse);
        }

        public static IList<PSCertificate> ToPSCertificates(IList<CertificateResponse> certificateResponses)
        {
            return ConvertObject<IList<CertificateResponse>, IList<PSCertificate>>(certificateResponses);
        }

        public static PSVerificationCodeResponse ToPSVerificationCodeResponse(VerificationCodeResponse verificationCodeResponse)
        {
            return ConvertObject<VerificationCodeResponse, PSVerificationCodeResponse>(verificationCodeResponse);
        }

        public static IList<PSIndividualEnrollments> ToPSIndividualEnrollments(IEnumerable<object> enrollments)
        {
            IList<PSIndividualEnrollments> psIndividualEnrollments = new List<PSIndividualEnrollments>();
            foreach (IndividualEnrollment enrollment in enrollments)
            {
                PSIndividualEnrollments psIndividualEnrollment = ConvertObject<IndividualEnrollment, PSIndividualEnrollments>(enrollment);
                psIndividualEnrollment.Attestation = GetAttestationMechanism(enrollment.Attestation);
                psIndividualEnrollments.Add(psIndividualEnrollment);
            }

            return psIndividualEnrollments;
        }

        public static IList<PSEnrollmentGroups> ToPSEnrollmentGroups(IEnumerable<object> enrollments)
        {
            IList<PSEnrollmentGroups> psEnrollmentGroups = new List<PSEnrollmentGroups>();
            foreach (EnrollmentGroup enrollment in enrollments)
            {
                PSEnrollmentGroups psEnrollmentGroup = ConvertObject<EnrollmentGroup, PSEnrollmentGroups>(enrollment);
                psEnrollmentGroup.Attestation = GetAttestationMechanism(enrollment.Attestation);
                psEnrollmentGroups.Add(psEnrollmentGroup);
            }

            return psEnrollmentGroups;
        }

        public static PSIndividualEnrollment ToPSIndividualEnrollment(IndividualEnrollment enrollment)
        {
            PSIndividualEnrollment psIndividualEnrollment = ConvertObject<IndividualEnrollment, PSIndividualEnrollment>(enrollment);
            psIndividualEnrollment.Attestation = GetAttestationMechanism(enrollment.Attestation);
            return psIndividualEnrollment;
        }

        public static PSEnrollmentGroup ToPSEnrollmentGroup(EnrollmentGroup enrollment)
        {
            PSEnrollmentGroup psEnrollmentGroup = ConvertObject<EnrollmentGroup, PSEnrollmentGroup>(enrollment);
            psEnrollmentGroup.Attestation = GetAttestationMechanism(enrollment.Attestation);
            return psEnrollmentGroup;
        }

        public static PSDeviceRegistrationState ToPSDeviceRegistrationState(DeviceRegistrationState registration)
        {
            return ConvertObject<DeviceRegistrationState, PSDeviceRegistrationState>(registration);
        }

        public static IEnumerable<PSDeviceRegistrationStates> ToPSDeviceRegistrationStates(IEnumerable<object> registrations)
        {
            return ConvertObject<IEnumerable<object>, IEnumerable<PSDeviceRegistrationStates>>(registrations);
        }

        public static PSAttestation GetAttestationMechanism(Attestation enrollmentAttestation)
        {
            if (enrollmentAttestation.GetType().Name.Equals("SymmetricKeyAttestation", StringComparison.OrdinalIgnoreCase))
            {
                return new PSAttestation()
                {
                    Type = PSAttestationMechanismType.SymmetricKey,
                    SymmetricKey = (SymmetricKeyAttestation)enrollmentAttestation
                };
            }
            else if (enrollmentAttestation.GetType().Name.Equals("X509Attestation", StringComparison.OrdinalIgnoreCase))
            {
                return new PSAttestation()
                {
                    Type = PSAttestationMechanismType.X509,
                    X509 = (X509Attestation)enrollmentAttestation
                };
            }
            else if (enrollmentAttestation.GetType().Name.Equals("TpmAttestation", StringComparison.OrdinalIgnoreCase))
            {
                return new PSAttestation()
                {
                    Type = PSAttestationMechanismType.Tpm,
                    Tpm = (TpmAttestation)enrollmentAttestation
                };
            }
            else
            {
                throw new ProvisioningServiceClientException("Unknown Attestation type");
            }
        }

        public static IList<PSIotDpsConnectionString> ToPSIotDpsConnectionStrings(IEnumerable<SharedAccessSignatureAuthorizationRuleAccessRightsDescription> authorizationPolicies, string serviceOperationsHostName)
        {
            var psConnectionStrings = new List<PSIotDpsConnectionString>();

            if (psConnectionStrings != null)
            {
                foreach (var authorizationPolicy in authorizationPolicies)
                {
                    psConnectionStrings.Add(authorizationPolicy.ToPSIotDpsConnectionString(serviceOperationsHostName));
                }
            }

            return psConnectionStrings;
        }

        public static PSIotDpsConnectionString ToPSIotDpsConnectionString(this SharedAccessSignatureAuthorizationRuleAccessRightsDescription authorizationPolicy, string serviceOperationsHostName)
        {
            return new PSIotDpsConnectionString()
            {
                KeyName = authorizationPolicy.KeyName,
                PrimaryConnectionString = String.Format(IotDpsConnectionStringTemplate, serviceOperationsHostName, authorizationPolicy.KeyName, authorizationPolicy.PrimaryKey),
                SecondaryConnectionString = String.Format(IotDpsConnectionStringTemplate, serviceOperationsHostName, authorizationPolicy.KeyName, authorizationPolicy.SecondaryKey)
            };
        }

        public static SharedAccessSignatureAuthorizationRuleAccessRightsDescription GetPolicy(IEnumerable<SharedAccessSignatureAuthorizationRuleAccessRightsDescription> authorizationPolicies, PSAccessRightsDescription accessRight)
        {
            SharedAccessSignatureAuthorizationRuleAccessRightsDescription policy;
            policy = authorizationPolicies.Where(p => p.Rights.Contains(accessRight.ToString())).FirstOrDefault();
            if (policy == null)
                throw new UnauthorizedAccessException(string.Format("Missing shared access policy for {0} permission.", accessRight.ToString()));
            return policy;
        }

        public static string GetCertificateString(string path)
        {
            string certificate = string.Empty;
            FileInfo fileInfo = new FileInfo(path);
            switch (fileInfo.Extension.ToLower(CultureInfo.InvariantCulture))
            {
                case ".cer":
                    certificate = AzureSession.Instance.DataStore.ReadFileAsText(path);
                    if (!certificate.StartsWith("-----BEGIN CERTIFICATE-----"))
                    {
                        var certificateByteContent = AzureSession.Instance.DataStore.ReadFileAsBytes(path);
                        certificate = Convert.ToBase64String(certificateByteContent);
                    }
                    break;
                case ".pem":
                    certificate = AzureSession.Instance.DataStore.ReadFileAsText(path);
                    break;
                default:
                    certificate = path;
                    break;
            }

            return Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(certificate));
        }

        public static string GetResourceGroupName(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return null;
            Regex r = new Regex(@"(.*?)/resourcegroups/(?<rgname>\S+)/providers/(.*?)", RegexOptions.IgnoreCase);
            Match m = r.Match(Id);
            return m.Success ? m.Groups["rgname"].Value : null;
        }

        public static string GetIotDpsName(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return null;
            Regex r = new Regex(@"(.*?)/provisioningServices/(?<provisioningServicename>[^\s/]+)", RegexOptions.IgnoreCase);
            Match m = r.Match(Id);
            return m.Success ? m.Groups["provisioningServicename"].Value : null;
        }

        public static string GetIotDpsCertificateName(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return null;
            Regex r = new Regex(@"(.*?)/certificates/(?<iotdpscertificatename>\S+)", RegexOptions.IgnoreCase);
            Match m = r.Match(Id);
            return m.Success ? m.Groups["iotdpscertificatename"].Value : null;
        }
    }
}
