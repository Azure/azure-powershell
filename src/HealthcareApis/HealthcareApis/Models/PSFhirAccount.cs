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
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.HealthcareApisFhirService.Models
{
    public class PSFhirAccount
    {
        public PSFhirAccount(ServicesDescription serviceDescription)
        {
            this.ResourceGroupName = ParseResourceGroupFromId(serviceDescription.Id);
            this.Name = serviceDescription.Name;
            this.Id = serviceDescription.Id;
            this.Location = serviceDescription.Location;
            this.ResourceType = serviceDescription.Type;
            this.Tags = serviceDescription.Tags;
            this.Properties = new PSServiceConfig(serviceDescription.Properties);
        }
        public string ResourceGroupName { get; private set; }

        public string Name { get; private set; }

        public string Id { get; private set; }

        public string Location { get; private set; }

        public string ResourceType { get; private set; }

        public IDictionary<string, string> Tags { get; private set; }

        public PSServiceConfig Properties { get; private set; }

        public static PSFhirAccount Create(ServicesDescription healthcareApisAccount)
        {
            var result = new PSFhirAccount(healthcareApisAccount);
            return result;
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
    }
}
