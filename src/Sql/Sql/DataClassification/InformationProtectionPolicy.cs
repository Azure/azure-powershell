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

        public static InformationProtectionPolicy DefaultInformationProtectionPolicy => new InformationProtectionPolicy
        {
            SensitivityLabels = new Dictionary<string, Guid>()
                    {
                        { "Public", Guid.Parse("1866CA45-1973-4C28-9D12-04D407F147AD") },
                        { "General", Guid.Parse("684A0DB2-D514-49D8-8C0C-DF84A7B083EB") },
                        { "Confidential", Guid.Parse("331F0B13-76B5-2F1B-A77B-DEF5A73C73C2") },
                        { "Confidential - GDPR", Guid.Parse("989ADC05-3F3F-0588-A635-F475B994915B") },
                        { "Highly Confidential", Guid.Parse("B82CE05B-60A9-4CF3-8A8A-D6A0BB76E903") },
                        { "Highly Confidential - GDPR", Guid.Parse("3302AE7F-B8AC-46BC-97F8-378828781EFD") }
                    },
            InformationTypes = new Dictionary<string, Guid>()
                    {
                        { "Networking", Guid.Parse("B40AD280-0F6A-6CA8-11BA-2F1A08651FCF") },
                        { "Contact Info", Guid.Parse("5C503E21-22C6-81FA-620B-F369B8EC38D1") },
                        { "Credentials", Guid.Parse("C64ABA7B-3A3E-95B6-535D-3BC535DA5A59") },
                        { "Credit Card", Guid.Parse("D22FA6E9-5EE4-3BDE-4C2B-A409604C4646") },
                        { "Banking", Guid.Parse("8A462631-4130-0A31-9A52-C6A9CA125F92") },
                        { "Financial", Guid.Parse("C44193E1-0E58-4B2A-9001-F7D6E7BC1373") },
                        { "Other", Guid.Parse("9C5B4809-0CCC-0637-6547-91A6F8BB609D") },
                        { "Name", Guid.Parse("57845286-7598-22F5-9659-15B24AEB125E") },
                        { "National ID", Guid.Parse("6F5A11A7-08B1-19C3-59E5-8C89CF4F8444") },
                        { "SSN", Guid.Parse("D936EC2C-04A4-9CF7-44C2-378A96456C61") },
                        { "Health", Guid.Parse("6E2C5B18-97CF-3073-27AB-F12F87493DA7") },
                        { "Date Of Birth", Guid.Parse("3DE7CC52-710D-4E96-7E20-4D5188D2590C") }
                    }
        };

        private static IDictionary<string, Guid> ToDictionary(JToken policyToken, string policyEntry)
        {
            JToken propertiesToken = policyToken["properties"];
            IDictionary<string, JToken> dictionary = (JObject)propertiesToken[policyEntry];
            return dictionary.ToDictionary(pair => pair.Value["displayName"].ToString(), pair => Guid.Parse(pair.Key));
        }
    }
}