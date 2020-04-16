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
using Microsoft.Azure.Management.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.IotSecuritySolutionAnalytics
{
    public static class PSIotSecuritySolutionAnalyticsConverters
    {
        public static PSIotSecuritySolutionAnalytics ConvertToPSType(this IoTSecuritySolutionAnalyticsModel value)
        {
            return new PSIotSecuritySolutionAnalytics()
            {
                Metrics = value.Metrics?.ConvertToPSType(),
                UnhealthyDeviceCount = value.UnhealthyDeviceCount,
                DevicesMetrics = value.DevicesMetrics?.ConvertToPSType(),
                TopAlertedDevices = value.TopAlertedDevices?.ConvertToPSType(),
                MostPrevalentDeviceAlerts = value.MostPrevalentDeviceAlerts?.ConvertToPSType(),
                MostPrevalentDeviceRecommendations = value.MostPrevalentDeviceRecommendations?.ConvertToPSType(),
            };
        }

        public static IList<PSIotSecuritySolutionAnalytics> ConvertToPSType(this IoTSecuritySolutionAnalyticsModelList value)
        {
            return value.Value.Select(solution => solution.ConvertToPSType()).ToList();
        }

        public static PSIoTSecurityAggregatedRecommendation ConvertToPSType(this IoTSecurityAggregatedRecommendation value)
        {
            return new PSIoTSecurityAggregatedRecommendation()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Description = value.Description,
                DetectedBy = value.DetectedBy,
                HealthyDevices = value.HealthyDevices,
                LogAnalyticsQuery = value.LogAnalyticsQuery,
                RecommendationDisplayName = value.RecommendationDisplayName,
                RecommendationName = value.RecommendationName,
                RecommendationTypeId = value.RecommendationTypeId,
                RemediationSteps = value.RemediationSteps,
                ReportedSeverity = value.ReportedSeverity,
                Tags = value.Tags,
                UnhealthyDeviceCount = value.UnhealthyDeviceCount
            };
        }

        public static IList<PSIoTSecurityAggregatedRecommendation> ConvertToPSType(this IEnumerable<IoTSecurityAggregatedRecommendation> value)
        {
            return value.Select(solution => solution.ConvertToPSType()).ToList();
        }

        public static PSIoTSecurityAggregatedAlert ConvertToPSType(this IoTSecurityAggregatedAlert value)
        {
            return new PSIoTSecurityAggregatedAlert()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Count = value.Count,
                ActionTaken = value.ActionTaken,
                SystemSource = value.SystemSource,
                EffectedResourceType = value.EffectedResourceType,
                Description = value.Description,
                RemediationSteps = value.RemediationSteps,
                ReportedSeverity = value.ReportedSeverity,
                VendorName = value.VendorName,
                AggregatedDateUtc = value.AggregatedDateUtc,
                AlertDisplayName = value.AlertDisplayName,
                AlertType = value.AlertType,
                LogAnalyticsQuery = value.LogAnalyticsQuery,
                TopDevicesList = value.TopDevicesList?.ConvertToPSType()
            };
        }
        
        public static IList<PSIoTSecurityAggregatedAlert> ConvertToPSType(this IEnumerable<IoTSecurityAggregatedAlert> value)
        {
            return value.Select(solution => solution.ConvertToPSType()).ToList();
        }

        public static PSTopDevice ConvertToPSType(this IoTSecurityAggregatedAlertPropertiesTopDevicesListItem value)
        {
            return new PSTopDevice()
            {
                DeviceId = value.DeviceId,
                AlertsCount = value.AlertsCount,
                LastOccurrence = value.LastOccurrence
            };
        }

        public static IList<PSTopDevice> ConvertToPSType(this IEnumerable<IoTSecurityAggregatedAlertPropertiesTopDevicesListItem> value)
        {
            return value.Select(solution => solution.ConvertToPSType()).ToList();
        }

        public static PSIoTSeverityMetrics ConvertToPSType(this IoTSeverityMetrics value)
        {
            return new PSIoTSeverityMetrics()
            {
                High = value.High,
                Medium = value.Medium,
                Low = value.Low
            };
        }

        public static PSDevicesMetrics ConvertToPSType(this IoTSecuritySolutionAnalyticsModelPropertiesDevicesMetricsItem value)
        {
            return new PSDevicesMetrics()
            {
                Date = value.Date,
                DevicesMetrics = value.DevicesMetrics?.ConvertToPSType()
            };
        }

        public static IList<PSDevicesMetrics> ConvertToPSType(this IEnumerable<IoTSecuritySolutionAnalyticsModelPropertiesDevicesMetricsItem> value)
        {
            return value.Select(solution => solution.ConvertToPSType()).ToList();
        }

        public static PSIoTSecurityAlertedDevice ConvertToPSType(this IoTSecurityAlertedDevice value)
        {
            return new PSIoTSecurityAlertedDevice()
            {
                DeviceId = value.DeviceId,
                AlertsCount = value.AlertsCount
            };
        }

        public static IList<PSIoTSecurityAlertedDevice> ConvertToPSType(this IEnumerable<IoTSecurityAlertedDevice> value)
        {
            return value.Select(solution => solution.ConvertToPSType()).ToList();
        }

        public static PSIoTSecurityDeviceAlert ConvertToPSType(this IoTSecurityDeviceAlert value)
        {
            return new PSIoTSecurityDeviceAlert()
            {
                AlertDisplayName = value.AlertDisplayName,
                ReportedSeverity = value.ReportedSeverity,
                AlertsCount = value.AlertsCount
            };
        }

        public static IList<PSIoTSecurityDeviceAlert> ConvertToPSType(this IEnumerable<IoTSecurityDeviceAlert> value)
        {
            return value.Select(solution => solution.ConvertToPSType()).ToList();
        }

        public static PSIoTSecurityDeviceRecommendation ConvertToPSType(this IoTSecurityDeviceRecommendation value)
        {
            return new PSIoTSecurityDeviceRecommendation()
            {
                RecommendationDisplayName = value.RecommendationDisplayName,
                ReportedSeverity = value.ReportedSeverity,
                DevicesCount = value.DevicesCount
            };
        }

        public static IList<PSIoTSecurityDeviceRecommendation> ConvertToPSType(this IEnumerable<IoTSecurityDeviceRecommendation> value)
        {
            return value.Select(solution => solution.ConvertToPSType()).ToList();
        }

    }
}
