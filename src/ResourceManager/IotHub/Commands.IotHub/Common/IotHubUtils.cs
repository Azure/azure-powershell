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
    using Newtonsoft.Json;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub.Models;
    using Microsoft.Rest.Azure;

    public static class IotHubUtils
    {
        const string TotalDeviceCountMetricName = "TotalDeviceCount";
        const string UnlimitedString = "Unlimited";
        const string IotHubConnectionStringTemplate = "HostName={0};ShareAccessKeyName={1};SharedAccessKey={2}";

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
    }
}