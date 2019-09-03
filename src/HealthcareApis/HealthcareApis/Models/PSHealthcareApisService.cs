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
            this.Properties = new PSHealthcareApisServiceConfig(serviceDescription.Properties);
            this.Etag = serviceDescription.Etag;
            this.Kind = serviceDescription.Kind;
        }

        public string ResourceGroupName { get; private set; }

        public string Name { get; private set; }

        public string Id { get; private set; }

        public string Location { get; private set; }

        public string ResourceType { get; private set; }

        public Kind Kind { get; private set; }

        public IDictionary<string, string> Tags { get; private set; }

        public PSHealthcareApisServiceConfig Properties { get; private set; }

        public string Etag { get; private set; }

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


    }
}
