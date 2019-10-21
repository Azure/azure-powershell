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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.HealthcareApis.Models
{
    public class PSHealthcareApisServiceConfig
    {

        public PSHealthcareApisServiceConfig(ServicesProperties servicesProperties)
        {
            this.AuthenticationConfiguration = new PSHealthcareApisFhirServiceAuthenticationConfig(servicesProperties.AuthenticationConfiguration);
            this.CosmosDbConfiguration = new PSHealthcareApisFhirServiceCosmosDbConfig(servicesProperties.CosmosDbConfiguration);
            this.CorsConfiguration = new PSHealthcareApisFhirServiceCorsConfig(servicesProperties.CorsConfiguration);
            var accessPolicies = servicesProperties.AccessPolicies;

            var psAccessPolicies = new List<PSHealthcareApisFhirServiceAccessPolicyEntry>();
            foreach(ServiceAccessPolicyEntry accessPolicy in  accessPolicies)
            {
                psAccessPolicies.Add(new PSHealthcareApisFhirServiceAccessPolicyEntry(accessPolicy));
            }

            this.AccessPolicies = psAccessPolicies;
        }

        public IList<PSHealthcareApisFhirServiceAccessPolicyEntry> AccessPolicies { get; private set; }

        public PSHealthcareApisFhirServiceCosmosDbConfig CosmosDbConfiguration { get; private set; }

        public PSHealthcareApisFhirServiceAuthenticationConfig AuthenticationConfiguration { get; private set; }

        public PSHealthcareApisFhirServiceCorsConfig CorsConfiguration { get; private set; }
    }
}
