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
using Microsoft.Azure.Commands.SecurityCenter.Models.Alerts;
using Microsoft.Azure.Management.Security.Models;

namespace Microsoft.Azure.Commands.Security.Models.Alerts
{
    public static class PSSecurityAlertConverters
    {
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
        {
            return value.Select(aps => aps.ConvertToPSType()).ToList();
        }

        public static PSSecurityAlertEntity ConvertToPSType(this AlertEntity value)
        {
            return new PSSecurityAlertEntity
            {
                Type = value.Type
            };
        }

        public static List<PSSecurityAlertEntity> ConvertToPSType(this IEnumerable<AlertEntity> value)
        {
            return value.Select(aps => aps.ConvertToPSType()).ToList();
        }
    }
}
