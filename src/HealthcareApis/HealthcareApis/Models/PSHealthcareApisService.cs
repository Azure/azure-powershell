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

using Microsoft.Azure.Management.HealthcareApis.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.HealthcareApis.Models
{
    public class PSHealthcareApisService
    {
        public PSHealthcareApisService(ServicesDescription serviceDescription)
        {
            this.ResourceGroupName = ParseResourceGroupFromId(serviceDescription.Id);
            this.Name = serviceDescription.Name;
            this.Id = serviceDescription.Id;
            this.Location = serviceDescription.Location;
            this.ResourceType = serviceDescription.Type;
            this.Tags = serviceDescription.Tags;
            this.CosmosDbOfferThroughput = serviceDescription.Properties.CosmosDbConfiguration?.OfferThroughput;
            this.CorsOrigins = serviceDescription.Properties.CorsConfiguration?.Origins;
            this.CorsHeaders = serviceDescription.Properties.CorsConfiguration?.Headers;
            this.CorsMethods = serviceDescription.Properties.CorsConfiguration?.Methods;
            this.CorsMaxAge = serviceDescription.Properties.CorsConfiguration?.MaxAge;
            this.CorsAllowCredentials = serviceDescription.Properties.CorsConfiguration?.AllowCredentials;
            this.Authority = serviceDescription.Properties.AuthenticationConfiguration?.Authority;
            this.Audience = serviceDescription.Properties.AuthenticationConfiguration?.Audience;
            this.SmartProxyEnabled = serviceDescription.Properties.AuthenticationConfiguration?.SmartProxyEnabled;
            this.Etag = serviceDescription.Etag;
            this.Kind = GetKindValue(serviceDescription.Kind);

            var psAccessPolicies = new List<PSHealthcareApisFhirServiceAccessPolicyEntry>();
            foreach (ServiceAccessPolicyEntry accessPolicy in serviceDescription.Properties.AccessPolicies)
            {
                psAccessPolicies.Add(new PSHealthcareApisFhirServiceAccessPolicyEntry(accessPolicy));
            }

            this.AccessPolicies = psAccessPolicies;
        }

        public IList<PSHealthcareApisFhirServiceAccessPolicyEntry> AccessPolicies { get; private set; }

        public string Audience { get; private set; }

        public string Authority { get; private set; }

        public bool? CorsAllowCredentials { get; private set; }
        public IList<string> CorsHeaders { get; private set; }

        public int? CorsMaxAge { get; private set; }

        public IList<string> CorsMethods { get; private set; }

        public IList<string> CorsOrigins { get; private set; }

        public int? CosmosDbOfferThroughput { get; private set; }

        public string Etag { get; private set; }

        public string Id { get; private set; }

        public string Kind { get; private set; }

        public string Location { get; private set; }

        public string Name { get; private set; }

        public string ResourceGroupName { get; private set; }

        public IDictionary<string, string> Tags { get; private set; }

        public string ResourceType { get; private set; }

        public bool? SmartProxyEnabled { get; private set; }

        public static PSHealthcareApisService Create(ServicesDescription healthcareApisAccount)
        {
            return new PSHealthcareApisService(healthcareApisAccount);
        }

        private static string ParseResourceGroupFromId(string idFromServer)
        {
            if (!string.IsNullOrEmpty(idFromServer))
            {
                string[] tokens = idFromServer.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return tokens[3];
            }

            return null;
        }

        private static string GetKindValue(Kind kind)
        {
            switch (kind)
            {
                case Management.HealthcareApis.Models.Kind.Fhir:
                    return "fhir-R4";
                case Management.HealthcareApis.Models.Kind.FhirStu3:
                    return "fhir-Stu3";
                case Management.HealthcareApis.Models.Kind.FhirR4:
                    return "fhir-R4";
            }
            return null;
        }
    }
}
