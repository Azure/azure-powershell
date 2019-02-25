using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Services
{
    internal class InformationProtectionPolicy
    {
        public IDictionary<string, Guid> SensitivityLabels { get; private set; }
        public IDictionary<string, Guid> InformationTypes { get; private set; }

        public static InformationProtectionPolicy ToInformationProtectionPolicy(JToken policyToken) => new InformationProtectionPolicy
        {
            SensitivityLabels = ToDictionary(policyToken, "labels"),
            InformationTypes = ToDictionary(policyToken, "informationTypes"),
        };

        private static IDictionary<string, Guid> ToDictionary(JToken policyToken, string policyEntry)
        {
            JToken propertiesToken = policyToken["properties"];
            IDictionary<string, JToken> dictionary = (JObject)propertiesToken[policyEntry];
            return dictionary.ToDictionary(pair => pair.Value["displayName"].ToString(), pair => Guid.Parse(pair.Key));
        }
    }
}
