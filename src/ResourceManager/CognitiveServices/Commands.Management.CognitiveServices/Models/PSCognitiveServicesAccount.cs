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

using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using System;
using System.Collections.Generic;
using CognitiveServicesModels = Microsoft.Azure.Management.CognitiveServices.Models;

namespace Microsoft.Azure.Commands.Management.CognitiveServices.Models
{
    public class PSCognitiveServicesAccount
    {
        public PSCognitiveServicesAccount(CognitiveServicesModels.CognitiveServicesAccount cognitiveServicesAccount)
        {
            this.ResourceGroupName = ParseResourceGroupFromId(cognitiveServicesAccount.Id);
            this.AccountName = cognitiveServicesAccount.Name;
            this.Id = cognitiveServicesAccount.Id;
            this.Endpoint = cognitiveServicesAccount.Endpoint;
            this.Location = cognitiveServicesAccount.Location;
            this.Sku = cognitiveServicesAccount.Sku;
            this.AccountType = (CognitiveServicesModels.Kind)Enum.Parse(typeof(CognitiveServicesModels.Kind), cognitiveServicesAccount.Kind);
            this.Etag = cognitiveServicesAccount.Etag;
            this.ResourceType = cognitiveServicesAccount.Type;
            this.ProvisioningState = cognitiveServicesAccount.ProvisioningState;
            this.Tags = cognitiveServicesAccount.Tags;
        }

        public string ResourceGroupName { get; private set; }

        public string AccountName { get; private set; }

        public string Id { get; private set; }

        public string Endpoint { get; private set; }

        public string Location { get; private set; }

        public Sku Sku { get; private set; }
        
        public Kind? AccountType { get; private set; }

        public string ResourceType { get; private set; }

        public string Etag { get; private set; }

        public ProvisioningState? ProvisioningState { get; private set; }

        public IDictionary<string, string> Tags { get; private set; }

        public static PSCognitiveServicesAccount Create(CognitiveServicesModels.CognitiveServicesAccount cognitiveServicesAccount)
        {
            var result = new PSCognitiveServicesAccount(cognitiveServicesAccount);
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

        /// <summary>
        /// Return a string representation of this cognitive services account
        /// </summary>
        /// <returns>null</returns>
        public override string ToString()
        {
            return this.Id;
        }
    }
}
