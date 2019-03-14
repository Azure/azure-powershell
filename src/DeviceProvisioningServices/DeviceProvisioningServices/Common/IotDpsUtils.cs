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
    using System.Linq;
    using System.Text.RegularExpressions;
    using Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models;
    using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
    using Newtonsoft.Json;

    public static class IotDpsUtils
    {
        const string TotalDeviceCountMetricName = "TotalDeviceCount";
        const string UnlimitedString = "Unlimited";
        const string IotHubConnectionStringTemplate = "HostName={0};SharedAccessKeyName={1};SharedAccessKey={2}";

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

        public static TagsResource ToTagsResource(IDictionary<string,string> tags)
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
            Regex r = new Regex(@"(.*?)/provisioningServices/(?<provisioningServicename>\S[^/]+)(/certificates/(.*?))*", RegexOptions.IgnoreCase);
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
