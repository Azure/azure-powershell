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

using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
=======
using Microsoft.Azure.Commands.SecurityCenter.Models.Alerts;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
using Microsoft.Azure.Management.Security.Models;

namespace Microsoft.Azure.Commands.Security.Models.Alerts
{
    public static class PSSecurityAlertConverters
    {
<<<<<<< HEAD
        public static PSSecurityAlert ConvertToPSType(this Alert value)
        {
            return new PSSecurityAlert()
            {
                Id = value.Id,
                ActionTaken = value.ActionTaken,
                AlertDisplayName = value.AlertDisplayName,
                AlertName = value.AlertName,
                AssociatedResource = value.AssociatedResource,
                CanBeInvestigated = value.CanBeInvestigated,
                CompromisedEntity = value.CompromisedEntity,
                ConfidenceReasons = value.ConfidenceReasons.ConvertToPSType(),
                ConfidenceScore = value.ConfidenceScore,
                Description = value.Description,
                DetectedTimeUtc = value.DetectedTimeUtc,
                Entities = value.Entities.ConvertToPSType(),
                ExtendedProperties = value.ExtendedProperties,
                InstanceId = value.InstanceId,
                Name = value.Name,
                RemediationSteps = value.RemediationSteps,
                ReportedSeverity = value.ReportedSeverity,
                ReportedTimeUtc = value.ReportedTimeUtc,
                State = value.State,
                SubscriptionId = value.SubscriptionId,
                SystemSource = value.SystemSource,
                VendorName = value.VendorName,
                WorkspaceArmId = value.WorkspaceArmId
            };
        }

        public static List<PSSecurityAlert> ConvertToPSType(this IEnumerable<Alert> value)
=======
        public static PSSecurityAlertV3 ConvertToPSType(this Alert value)
        {
            return new PSSecurityAlertV3
            {                
                Id = value.Id,
                AlertDisplayName = value.AlertDisplayName,
                AlertType = value.AlertType,
                AlertUri = value.AlertUri,
                CompromisedEntity = value.CompromisedEntity,
                CorrelationKey = value.CorrelationKey,
                Description = value.Description,
                EndTimeUtc = value.EndTimeUtc,
                Entities = value.Entities?.ConvertToPSType() ?? new List<PSSecurityAlertEntity>(),
                ExtendedLinks = value.ExtendedLinks?.ToList() ?? new List<IDictionary<string, string>>(),
                ExtendedProperties = value.ExtendedProperties,
                Intent = value.Intent,
                IsIncident = value.IsIncident,
                Name = value.Name,
                ProcessingEndTimeUtc = value.ProcessingEndTimeUtc,
                ProductComponentName = value.ProductComponentName,
                ProductName = value.ProductName,
                RemediationSteps = value.RemediationSteps?.ToList() ?? new List<string>(),
                ResourceIdentifiers = value.ResourceIdentifiers?.ToList() ?? new List<ResourceIdentifier>(),
                Severity = value.Severity,
                StartTimeUtc = value.StartTimeUtc,
                Status = value.Status,
                SystemAlertId = value.SystemAlertId,
                TimeGeneratedUtc = value.TimeGeneratedUtc,
                VendorName = value.VendorName
            };
        }

        public static List<PSSecurityAlertV3> ConvertToPSType(this IEnumerable<Alert> value)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        {
            return value.Select(aps => aps.ConvertToPSType()).ToList();
        }

        public static PSSecurityAlertEntity ConvertToPSType(this AlertEntity value)
        {
<<<<<<< HEAD
            return new PSSecurityAlertEntity()
=======
            return new PSSecurityAlertEntity
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            {
                Type = value.Type
            };
        }

        public static List<PSSecurityAlertEntity> ConvertToPSType(this IEnumerable<AlertEntity> value)
        {
            return value.Select(aps => aps.ConvertToPSType()).ToList();
        }
<<<<<<< HEAD

        public static PSSecurityAlertConfidenceReason ConvertToPSType(this AlertConfidenceReason value)
        {
            return new PSSecurityAlertConfidenceReason()
            {
                Reason = value.Reason,
                Type = value.Type
            };
        }

        public static List<PSSecurityAlertConfidenceReason> ConvertToPSType(this IEnumerable<AlertConfidenceReason> value)
        {
            return value.Select(aps => aps.ConvertToPSType()).ToList();
        }
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}
