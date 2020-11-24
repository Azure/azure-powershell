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

using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Management.SecurityInsights.Models;
using System.Security.Cryptography;

namespace Microsoft.Azure.Commands.SecurityInsights.Models.DataConnectors
{
    public static class PSSentinelDataConnectorConvertors
    {

        public static PSSentinelDataConnector ConvertToPSType(this DataConnector value)
        {
            var convertedAADValue = value as AADDataConnector;

            if (convertedAADValue != null)
            {
                return convertedAADValue.ConvertToPSType();
            }

            var convertedAATPValue = value as AATPDataConnector;

            if (convertedAATPValue != null)
            {
                return convertedAATPValue.ConvertToPSType();
            }

            var convertedASCValue = value as ASCDataConnector;

            if (convertedASCValue != null)
            {
                return convertedASCValue.ConvertToPSType();
            }

            var convertedAWSValue = value as AwsCloudTrailDataConnector;

            if (convertedAWSValue != null)
            {
                return convertedAWSValue.ConvertToPSType();
            }

            var convertedMCASValue = value as MCASDataConnector;

            if (convertedMCASValue != null)
            {
                return convertedMCASValue.ConvertToPSType();
            }

            var convertedMDATPValue = value as MDATPDataConnector;

            if (convertedMDATPValue != null)
            {
                return convertedMDATPValue.ConvertToPSType();
            }

            var convertedOfficeValue = value as OfficeDataConnector;

            if (convertedOfficeValue != null)
            {
                return convertedOfficeValue.ConvertToPSType();
            }

            var convertedTIValue = value as TIDataConnector;

            if (convertedTIValue != null)
            {
                return convertedTIValue.ConvertToPSType();
            }

            return new PSSentinelDataConnector()
            {
                Kind = "Error",
                Name = value.Name
            };
        }

        public static List<PSSentinelDataConnector> ConvertToPSType(this IEnumerable<DataConnector> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }
        
        public static PSSentinelDataConnectorAAD ConvertToPSType(this AADDataConnector value)
        {
            return new PSSentinelDataConnectorAAD()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Etag = value.Etag,
                Kind = "AzureActiveDirectory",
                DataTypes = value.DataTypes.ConvertToPSType(),
                TenantId = value.TenantId
            };
        }

        public static PSSentinelDataConnectorAATP ConvertToPSType(this AATPDataConnector value)
        {
            return new PSSentinelDataConnectorAATP()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Etag = value.Etag,
                Kind = "AzureAdvancedThreatProtection",
                DataTypes = value.DataTypes.ConvertToPSType(),
                TenantId = value.TenantId
            };
        }

        public static PSSentinelDataConnectorASC ConvertToPSType(this ASCDataConnector value)
        {
            return new PSSentinelDataConnectorASC()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Etag = value.Etag,
                Kind = "AzureSecurityCenter",
                DataTypes = value.DataTypes.ConvertToPSType(),
                SubscriptionId = value.SubscriptionId
            };
        }

        public static PSSentinelDataConnectorAWS ConvertToPSType(this AwsCloudTrailDataConnector value)
        {
            return new PSSentinelDataConnectorAWS()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Etag = value.Etag,
                Kind = "AmazonWebServicesCloudTrail",
                DataTypes = value.DataTypes.ConvertToPSType(),
                AwsRoleArn = value.AwsRoleArn
            };
        }

        public static PSSentinelDataConnectorMCAS ConvertToPSType(this MCASDataConnector value)
        {
            return new PSSentinelDataConnectorMCAS()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Etag = value.Etag,
                Kind = "MicrosoftCloudAppSecurity",
                DataTypes = value.DataTypes.ConvertToPSType(),
                TenantId = value.TenantId
            };
        }

        public static PSSentinelDataConnectorMDATP ConvertToPSType(this MDATPDataConnector value)
        {
            return new PSSentinelDataConnectorMDATP()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Etag = value.Etag,
                Kind = "MicrosoftDefenderAdvancedThreatProtection",
                DataTypes = value.DataTypes.ConvertToPSType(),
                TenantId = value.TenantId
            };
        }

        public static PSSentinelDataConnectorOffice ConvertToPSType(this OfficeDataConnector value)
        {
            return new PSSentinelDataConnectorOffice()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Etag = value.Etag,
                Kind = "Office365",
                DataTypes = value.DataTypes.ConvertToPSType(),
                TenantId = value.TenantId
            };
        }

        public static PSSentinelDataConnectorTI ConvertToPSType(this TIDataConnector value)
        {
            return new PSSentinelDataConnectorTI()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Etag = value.Etag,
                Kind = "ThreatIntelligence",
                DataTypes = value.DataTypes.ConvertToPSType(),
                TenantId = value.TenantId
            };
        }

        public static PSSentinelDataConnectorDataTypeAlert ConvertToPSType(this AlertsDataTypeOfDataConnector value)
        {
            return new PSSentinelDataConnectorDataTypeAlert()
            {
                Alerts = value.Alerts.ConvertToPSType()
            };
        }

        public static PSSentinelDataConnectorDataTypeCloudTrail ConvertToPSType(this AwsCloudTrailDataConnectorDataTypes value)
        {
            return new PSSentinelDataConnectorDataTypeCloudTrail()
            {
                Logs = value.Logs.ConvertToPSType()
            };
        }

        public static PSSentinelDataConnectorDataTypeMCAS ConvertToPSType(this MCASDataConnectorDataTypes value)
        {
            return new PSSentinelDataConnectorDataTypeMCAS()
            {
                Alerts = value.Alerts.ConvertToPSType(),
                DiscoveryLogs = value.DiscoveryLogs.ConvertToPSType()

            };
        }

        public static PSSentinelDataConnectorDataTypeOffice ConvertToPSType(this OfficeDataConnectorDataTypes value)
        {
            return new PSSentinelDataConnectorDataTypeOffice()
            {
                Exchange = value.Exchange.ConvertToPSType(),
                SharePoint = value.SharePoint.ConvertToPSType()

            };
        }

        public static PSSentinelDataConnectorDataTypeTI ConvertToPSType(this TIDataConnectorDataTypes value)
        {
            return new PSSentinelDataConnectorDataTypeTI()
            {
                Indicators = value.Indicators.ConvertToPSType()
            };
        }

        public static PSSentinelDataConnectorDataTypeCommon ConvertToPSType(this DataConnectorDataTypeCommon value)
        {
            return new PSSentinelDataConnectorDataTypeCommon()
            {
                State = value.State
            };
        }

        public static PSSentinelDataConnectorDataTypeCloudTrailLog ConvertToPSType(this AwsCloudTrailDataConnectorDataTypesLogs value)
        {
            return new PSSentinelDataConnectorDataTypeCloudTrailLog()
            {
                State = value.State
            };
        }
        public static PSSentinelDataConnectorDataTypeOfficeExchange ConvertToPSType(this OfficeDataConnectorDataTypesExchange value)
        {
            return new PSSentinelDataConnectorDataTypeOfficeExchange()
            {
                State = value.State
            };
        }
        public static PSSentinelDataConnectorDataTypeOfficeSharePoint ConvertToPSType(this OfficeDataConnectorDataTypesSharePoint value)
        {
            return new PSSentinelDataConnectorDataTypeOfficeSharePoint()
            {
                State = value.State
            };
        }

        public static PSSentinelDataConnectorDataTypeTIIndicator ConvertToPSType(this TIDataConnectorDataTypesIndicators value)
        {
            return new PSSentinelDataConnectorDataTypeTIIndicator()
            {
                State = value.State
            };
        }


        public static DataConnector CreatePSType(this PSSentinelDataConnector value)
        {
            var convertedAADValue = value as PSSentinelDataConnectorAAD;

            if (convertedAADValue != null)
            {
                return convertedAADValue.CreatePSType();
            }

            var convertedAATPValue = value as PSSentinelDataConnectorAATP;

            if (convertedAATPValue != null)
            {
                return convertedAATPValue.CreatePSType();
            }

            var convertedASCValue = value as PSSentinelDataConnectorASC;

            if (convertedASCValue != null)
            {
                return convertedASCValue.CreatePSType();
            }

            var convertedAWSValue = value as PSSentinelDataConnectorAWS;

            if (convertedAWSValue != null)
            {
                return convertedAWSValue.CreatePSType();
            }

            var convertedMCASValue = value as PSSentinelDataConnectorMCAS;

            if (convertedMCASValue != null)
            {
                return convertedMCASValue.CreatePSType();
            }

            var convertedMDATPValue = value as PSSentinelDataConnectorMDATP;

            if (convertedMDATPValue != null)
            {
                return convertedMDATPValue.CreatePSType();
            }

            var convertedOfficeValue = value as PSSentinelDataConnectorOffice;

            if (convertedOfficeValue != null)
            {
                return convertedOfficeValue.CreatePSType();
            }

            var convertedTIValue = value as PSSentinelDataConnectorTI;

            if (convertedTIValue != null)
            {
                return convertedTIValue.CreatePSType();
            }

            return new DataConnector()
            {
            };
        }

        public static List<DataConnector> CreatePSType(this IEnumerable<PSSentinelDataConnector> value)
        {
            return value.Select(dss => dss.CreatePSType()).ToList();
        }

        public static AADDataConnector CreatePSType(this PSSentinelDataConnectorAAD value)
        {
            return new AADDataConnector()
            {
                DataTypes = value.DataTypes.CreatePSType(),
                TenantId = value.TenantId
            };
        }

        public static AATPDataConnector CreatePSType(this PSSentinelDataConnectorAATP value)
        {
            return new AATPDataConnector()
            {
                DataTypes = value.DataTypes.CreatePSType(),
                TenantId = value.TenantId
            };
        }

        public static ASCDataConnector CreatePSType(this PSSentinelDataConnectorASC value)
        {
            return new ASCDataConnector()
            {
                DataTypes = value.DataTypes.CreatePSType(),
                SubscriptionId = value.SubscriptionId
            };
        }

        public static AwsCloudTrailDataConnector CreatePSType(this PSSentinelDataConnectorAWS value)
        {
            return new AwsCloudTrailDataConnector()
            {
                DataTypes = value.DataTypes.CreatePSType(),
                AwsRoleArn = value.AwsRoleArn
            };
        }

        public static MCASDataConnector CreatePSType(this PSSentinelDataConnectorMCAS value)
        {
            return new MCASDataConnector()
            {
                DataTypes = value.DataTypes.CreatePSType(),
                TenantId = value.TenantId
            };
        }

        public static MDATPDataConnector CreatePSType(this PSSentinelDataConnectorMDATP value)
        {
            return new MDATPDataConnector()
            {
                DataTypes = value.DataTypes.CreatePSType(),
                TenantId = value.TenantId
            };
        }

        public static OfficeDataConnector CreatePSType(this PSSentinelDataConnectorOffice value)
        {
            return new OfficeDataConnector()
            {
                DataTypes = value.DataTypes.CreatePSType(),
                TenantId = value.TenantId
            };
        }

        public static TIDataConnector CreatePSType(this PSSentinelDataConnectorTI value)
        {
            return new TIDataConnector()
            {
                DataTypes = value.DataTypes.CreatePSType(),
                TenantId = value.TenantId
            };
        }

        public static AlertsDataTypeOfDataConnector CreatePSType(this PSSentinelDataConnectorDataTypeAlert value)
        {
            return new AlertsDataTypeOfDataConnector()
            {
                Alerts = value.Alerts.CreatePSType()
            };
        }

        public static AwsCloudTrailDataConnectorDataTypes CreatePSType(this PSSentinelDataConnectorDataTypeCloudTrail value)
        {
            return new AwsCloudTrailDataConnectorDataTypes()
            {
                Logs = value.Logs.CreatePSType()
            };
        }

        public static MCASDataConnectorDataTypes CreatePSType(this PSSentinelDataConnectorDataTypeMCAS value)
        {
            return new MCASDataConnectorDataTypes()
            {
                Alerts = value.Alerts.CreatePSType(),
                DiscoveryLogs = value.DiscoveryLogs.CreatePSType()

            };
        }

        public static OfficeDataConnectorDataTypes CreatePSType(this PSSentinelDataConnectorDataTypeOffice value)
        {
            return new OfficeDataConnectorDataTypes()
            {
                Exchange = value.Exchange.CreatePSType(),
                SharePoint = value.SharePoint.CreatePSType()

            };
        }

        public static TIDataConnectorDataTypes CreatePSType(this PSSentinelDataConnectorDataTypeTI value)
        {
            return new TIDataConnectorDataTypes()
            {
                Indicators = value.Indicators.CreatePSType()
            };
        }

        public static DataConnectorDataTypeCommon CreatePSType(this PSSentinelDataConnectorDataTypeCommon value)
        {
            return new DataConnectorDataTypeCommon()
            {
                State = value.State
            };
        }

        public static AwsCloudTrailDataConnectorDataTypesLogs CreatePSType(this PSSentinelDataConnectorDataTypeCloudTrailLog value)
        {
            return new AwsCloudTrailDataConnectorDataTypesLogs()
            {
                State = value.State
            };
        }
        public static OfficeDataConnectorDataTypesExchange CreatePSType(this PSSentinelDataConnectorDataTypeOfficeExchange value)
        {
            return new OfficeDataConnectorDataTypesExchange()
            {
                State = value.State
            };
        }
        public static OfficeDataConnectorDataTypesSharePoint CreatePSType(this PSSentinelDataConnectorDataTypeOfficeSharePoint value)
        {
            return new OfficeDataConnectorDataTypesSharePoint()
            {
                State = value.State
            };
        }
        public static TIDataConnectorDataTypesIndicators CreatePSType(this PSSentinelDataConnectorDataTypeTIIndicator value)
        {
            return new TIDataConnectorDataTypesIndicators()
            {
                State = value.State
            };
        }
    }
}
