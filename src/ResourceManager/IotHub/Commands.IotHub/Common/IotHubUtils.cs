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

namespace Microsoft.Azure.Commands.Management.IotHub.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub.Models;
    using Newtonsoft.Json;

    public static class IotHubUtils
    {
        const string TotalDeviceCountMetricName = "TotalDeviceCount";
        const string UnlimitedString = "Unlimited";
        const string IotHubConnectionStringTemplate = "HostName={0};SharedAccessKeyName={1};SharedAccessKey={2}";

        public static T2 ConvertObject<T1, T2>(T1 iotHubObject)
        {
            return JsonConvert.DeserializeObject<T2>(JsonConvert.SerializeObject(iotHubObject));
        }

        public static IEnumerable<PSIotHub> ToPSIotHubs(IEnumerable<IotHubDescription> iotHubDescriptions)
        {
            return ConvertObject<IEnumerable<IotHubDescription>, IEnumerable<PSIotHub>>(iotHubDescriptions.ToList());
        }

        public static PSIotHub ToPSIotHub(IotHubDescription iotHubDescription)
        {
            return ConvertObject<IotHubDescription, PSIotHub>(iotHubDescription);
        }

        public static IotHubProperties ToIotHubProperties(PSIotHubInputProperties psIotHubInputProperties)
        {
            return ConvertObject<PSIotHubInputProperties, IotHubProperties>(psIotHubInputProperties);
        }

        public static IEnumerable<PSSharedAccessSignatureAuthorizationRule> ToPSSharedAccessSignatureAuthorizationRules(IEnumerable<SharedAccessSignatureAuthorizationRule> authorizationPolicies)
        {
            return ConvertObject<IEnumerable<SharedAccessSignatureAuthorizationRule>, IEnumerable<PSSharedAccessSignatureAuthorizationRule>>(authorizationPolicies.ToList());
        }

        public static PSSharedAccessSignatureAuthorizationRule ToPSSharedAccessSignatureAuthorizationRule(SharedAccessSignatureAuthorizationRule authorizationPolicy)
        {
            return ConvertObject<SharedAccessSignatureAuthorizationRule, PSSharedAccessSignatureAuthorizationRule>(authorizationPolicy);
        }

        public static IEnumerable<SharedAccessSignatureAuthorizationRule> ToSharedAccessSignatureAuthorizationRules(IEnumerable<PSSharedAccessSignatureAuthorizationRule> authorizationPolicies)
        {
            return ConvertObject<IEnumerable<PSSharedAccessSignatureAuthorizationRule>, IEnumerable<SharedAccessSignatureAuthorizationRule>>(authorizationPolicies.ToList());
        }

        public static SharedAccessSignatureAuthorizationRule ToSharedAccessSignatureAuthorizationRule(PSSharedAccessSignatureAuthorizationRule authorizationPolicy)
        {
            return ConvertObject<PSSharedAccessSignatureAuthorizationRule, SharedAccessSignatureAuthorizationRule>(authorizationPolicy);
        }

        public static IEnumerable<PSIotHubJobResponse> ToPSIotHubJobResponseList(IEnumerable<JobResponse> jobResponseList)
        {
            return ConvertObject<IEnumerable<JobResponse>, IEnumerable<PSIotHubJobResponse>>(jobResponseList.ToList());
        }

        public static PSIotHubJobResponse ToPSIotHubJobResponse(JobResponse jobResponse)
        {
            return ConvertObject<JobResponse, PSIotHubJobResponse>(jobResponse);
        }

        public static ExportDevicesRequest ToExportDevicesRequest(PSExportDevicesRequest psExportDevicesRequest)
        {
            return ConvertObject<PSExportDevicesRequest, ExportDevicesRequest>(psExportDevicesRequest);
        }

        public static ImportDevicesRequest ToImportDevicesRequest(PSImportDevicesRequest psImportDevicesRequest)
        {
            return ConvertObject<PSImportDevicesRequest, ImportDevicesRequest>(psImportDevicesRequest);
        }

        public static PSIotHubRegistryStatistics ToPSIotHubRegistryStatistics(RegistryStatistics registryStats)
        {
            return ConvertObject<RegistryStatistics, PSIotHubRegistryStatistics>(registryStats);
        }

        public static IEnumerable<PSIotHubSkuDescription> ToPSIotHubSkuDescriptions(IEnumerable<IotHubSkuDescription> iotHubSkuDescriptions)
        {
            return ConvertObject<IEnumerable<IotHubSkuDescription>, IEnumerable<PSIotHubSkuDescription>>(iotHubSkuDescriptions.ToList());
        }

        public static IDictionary<string, EventHubProperties> ToEventHubEndpointProperties(IDictionary<string, PSEventHubInputProperties> psEventHubEndpointProperties)
        {
            return ConvertObject<IDictionary<string, PSEventHubInputProperties>, IDictionary<string, EventHubProperties>>(psEventHubEndpointProperties);
        }

        public static IDictionary<string, MessagingEndpointProperties> ToMessagingEndpoints(IDictionary<string, PSMessagingEndpointProperties> psMessagingEndpointProperties)
        {
            return ConvertObject<IDictionary<string, PSMessagingEndpointProperties>, IDictionary<string, MessagingEndpointProperties>>(psMessagingEndpointProperties);
        }

        public static IDictionary<string, StorageEndpointProperties> ToStorageEndpoints(IDictionary<string, PSStorageEndpointProperties> psStorageEndpointProperties)
        {
            return ConvertObject<IDictionary<string, PSStorageEndpointProperties>, IDictionary<string, StorageEndpointProperties>>(psStorageEndpointProperties);
        }

        public static CloudToDeviceProperties ToCloudToDeviceProperties(PSCloudToDeviceProperties psCloudToDeviceProperties)
        {
            return ConvertObject<PSCloudToDeviceProperties, CloudToDeviceProperties>(psCloudToDeviceProperties);
        }

        public static OperationsMonitoringProperties ToOperationsMonitoringProperties(PSOperationsMonitoringProperties psOperationsMonitoringProperties)
        {
            return ConvertObject<PSOperationsMonitoringProperties, OperationsMonitoringProperties>(psOperationsMonitoringProperties);
        }

        public static IotHubSkuInfo ToIotHubSku(PSIotHubSkuInfo psIotHubSkuInfo)
        {
            return ConvertObject<PSIotHubSkuInfo, IotHubSkuInfo>(psIotHubSkuInfo);
        }

        public static RoutingProperties ToRoutingProperties(PSRoutingProperties psRoutingProperties)
        {
            return ConvertObject<PSRoutingProperties, RoutingProperties>(psRoutingProperties);
        }

        public static List<RouteProperties> ToRouteProperties(List<PSRouteMetadata> psRouteProperties)
        {
            return ConvertObject<List<PSRouteMetadata>, List<RouteProperties>>(psRouteProperties);
        }

        public static RouteProperties ToRouteProperty(PSRouteMetadata psRouteProperty)
        {
            return ConvertObject<PSRouteMetadata, RouteProperties>(psRouteProperty);
        }

        public static FallbackRouteProperties ToFallbackRouteProperty(PSFallbackRouteMetadata psRouteProperty)
        {
            return ConvertObject<PSFallbackRouteMetadata, FallbackRouteProperties>(psRouteProperty);
        }

        public static IList<PSIotHubConnectionString> ToPSIotHubConnectionStrings(IEnumerable<SharedAccessSignatureAuthorizationRule> authorizationPolicies, string hostName)
        {
            var psConnectionStrings = new List<PSIotHubConnectionString>();

            if (psConnectionStrings != null)
            {
                foreach (var authorizationPolicy in authorizationPolicies)
                {
                    psConnectionStrings.Add(authorizationPolicy.ToPSIotHubConnectionString(hostName));
                }
            }

            return psConnectionStrings;
        }

        public static PSIotHubConnectionString ToPSIotHubConnectionString(this SharedAccessSignatureAuthorizationRule authorizationPolicy, string hostName)
        {
            return new PSIotHubConnectionString()
            {
                KeyName = authorizationPolicy.KeyName,
                PrimaryConnectionString = String.Format(IotHubConnectionStringTemplate, hostName, authorizationPolicy.KeyName, authorizationPolicy.PrimaryKey),
                SecondaryConnectionString = String.Format(IotHubConnectionStringTemplate, hostName, authorizationPolicy.KeyName, authorizationPolicy.SecondaryKey)
            };
        }

        public static IList<PSIotHubQuotaMetric> ToPSIotHubQuotaMetrics(IEnumerable<IotHubQuotaMetricInfo> iotHubQuotaMetrics)
        {
            var psIotHubQuotaMetrics = new List<PSIotHubQuotaMetric>();

            foreach (var iotHubQuotaMetric in iotHubQuotaMetrics)
            {
                psIotHubQuotaMetrics.Add(iotHubQuotaMetric.ToPSIotHubQuotaMetric());
            }

            return psIotHubQuotaMetrics;
        }

        public static PSIotHubQuotaMetric ToPSIotHubQuotaMetric(this IotHubQuotaMetricInfo iotHubQuotaMetric)
        {
            return new PSIotHubQuotaMetric()
            {
                Name = iotHubQuotaMetric.Name,
                CurrentValue = ((long)iotHubQuotaMetric.CurrentValue).ToString(),
                MaxValue = iotHubQuotaMetric.Name.Equals(TotalDeviceCountMetricName, StringComparison.OrdinalIgnoreCase) ? UnlimitedString : ((long)iotHubQuotaMetric.MaxValue).ToString()
            };
        }

        public static PSCertificateDescription ToPSCertificateDescription(CertificateDescription certificateDescription)
        {
            return ConvertObject<CertificateDescription, PSCertificateDescription>(certificateDescription);
        }

        public static IEnumerable<PSCertificate> ToPSCertificates(CertificateListDescription certificateListDescription)
        {
            return ConvertObject<IEnumerable<CertificateDescription>, IEnumerable<PSCertificate>>(certificateListDescription.Value);
        }

        public static PSCertificateWithNonceDescription ToPSCertificateWithNonceDescription(CertificateWithNonceDescription certificateWithNonceDescription)
        {
            return ConvertObject<CertificateWithNonceDescription, PSCertificateWithNonceDescription>(certificateWithNonceDescription);
        }

        public static string GetResourceGroupName(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return null;
            Regex r = new Regex(@"(.*?)/resourcegroups/(?<rgname>\S+)/providers/(.*?)", RegexOptions.IgnoreCase);
            Match m = r.Match(Id);
            return m.Success ? m.Groups["rgname"].Value : null;
        }

        public static string GetIotHubName(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return null;
            Regex r = new Regex(@"(.*?)/IotHubs/(?<iothubname>\S+)/certificates/(.*?)", RegexOptions.IgnoreCase);
            Match m = r.Match(Id);
            return m.Success ? m.Groups["iothubname"].Value : null;
        }

        public static string GetIotHubCertificateName(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return null;
            Regex r = new Regex(@"(.*?)/certificates/(?<iothubcertificatename>\S+)", RegexOptions.IgnoreCase);
            Match m = r.Match(Id);
            return m.Success ? m.Groups["iothubcertificatename"].Value : null;
        }
    }
}
