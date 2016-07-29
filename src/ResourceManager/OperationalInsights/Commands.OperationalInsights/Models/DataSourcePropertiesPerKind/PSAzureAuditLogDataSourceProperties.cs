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

using Microsoft.Azure.Commands.OperationalInsights.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{

    public class PSAzureAuditLogDataSourceProperties: PSDataSourcePropertiesBase
    {
        [JsonIgnore]
        public override string Kind { get { return PSDataSourceKinds.AzureAuditLog; } }

        /// <summary>
        /// Id of the azure subscription, which you want audit log to be collect from.
        /// </summary>
        [JsonProperty(PropertyName="linkedResourceId")]
        [JsonConverter(typeof(AuditLogConverter))]
        public string SubscriptionId { get; set; }
    }

    /// <summary>
    /// Convert between AuditLog resourceId to SubscriptionId.
    /// 
    /// Our ARM API takes ResourceId, while in that resourceId, only SubscriptionId matters.
    /// To better serve the information via powershell, only SubscriptionId exposed.
    /// </summary>
    public class AuditLogConverter : JsonConverter {
        const string SubscriptionsString = "subscriptions";
        const string ProviderString = "providers";
        const string InsightsProviderString = "microsoft.insights";
        const string EventTypesString = "eventtypes";

        static readonly char[] UriDelimeter = { '/' };
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(String.Format(Resources.AzureAuditLogResourceFormat, value));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
            {
                return null;
            }

            var auditLogResourceId = (string)reader.Value;

            // AuditLogResource always have this schema "/subscriptions/{0}/providers/microsoft.insights/eventtypes"
            var segments = auditLogResourceId.Split(UriDelimeter, StringSplitOptions.RemoveEmptyEntries);
            if (segments.Length > 4
                && segments[0].Equals(SubscriptionsString, StringComparison.InvariantCultureIgnoreCase)
                && segments[2].Equals(ProviderString, StringComparison.InvariantCultureIgnoreCase)
                && segments[3].Equals(InsightsProviderString, StringComparison.InvariantCultureIgnoreCase)
                && segments[4].Equals(EventTypesString, StringComparison.InvariantCultureIgnoreCase))
            {
                return segments[1];
            }

            return null;
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
