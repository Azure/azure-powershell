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

using Microsoft.Azure.Management.CognitiveServices.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Management.CognitiveServices.Models
{
    public class PSCognitiveServicesAccount
    {
        public PSCognitiveServicesAccount(Account cognitiveServicesAccount)
        {
            this.ResourceGroupName = ParseResourceGroupFromId(cognitiveServicesAccount.Id);
            this.AccountName = cognitiveServicesAccount.Name;
            this.Id = cognitiveServicesAccount.Id;
            this.Location = cognitiveServicesAccount.Location;
            this.Sku = cognitiveServicesAccount.Sku;
            this.AccountType = cognitiveServicesAccount.Kind;
            this.Etag = cognitiveServicesAccount.Etag;
            this.ResourceType = cognitiveServicesAccount.Type;
            this.Tags = cognitiveServicesAccount.Tags;

            // Properties aliases
            this.CustomSubDomainName = cognitiveServicesAccount.Properties.CustomSubDomainName;
            this.Identity = cognitiveServicesAccount.Identity;
            this.UserOwnedStorage = cognitiveServicesAccount.Properties.UserOwnedStorage;
            this.Encryption = cognitiveServicesAccount.Properties.Encryption;
            this.ApiProperties = CognitiveServicesAccountApiProperties.Parse(cognitiveServicesAccount.Properties.ApiProperties);
            this.PublicNetworkAccess = cognitiveServicesAccount.Properties.PublicNetworkAccess;
            this.DisableLocalAuth = cognitiveServicesAccount.Properties.DisableLocalAuth;
            this.RestrictOutboundNetworkAccess = cognitiveServicesAccount.Properties.RestrictOutboundNetworkAccess;
            this.AllowedFqdnList = cognitiveServicesAccount.Properties.AllowedFqdnList;

            // other properties
            this.Properties = cognitiveServicesAccount.Properties;

            // Read-only properties, should not add more as they can be retrived from properties
            this.PrivateEndpointConnections = cognitiveServicesAccount.Properties.PrivateEndpointConnections;
            this.Capabilities = cognitiveServicesAccount.Properties.Capabilities;
            this.Endpoint = cognitiveServicesAccount.Properties.Endpoint;
            this.ProvisioningState = cognitiveServicesAccount.Properties.ProvisioningState;

            if (cognitiveServicesAccount.Properties.NetworkAcls != null)
            {
                this.NetworkRuleSet = PSNetworkRuleSet.Create(cognitiveServicesAccount.Properties.NetworkAcls);
            }
        }

        public string ResourceGroupName { get; private set; }

        public string AccountName { get; private set; }

        public string Id { get; private set; }

        public string Endpoint { get; private set; }

        public string Location { get; private set; }

        public Sku Sku { get; private set; }

        public string AccountType { get; private set; }

        public string ResourceType { get; private set; }

        public string Etag { get; private set; }

        public string ProvisioningState { get; private set; }

        public string CustomSubDomainName { get; private set; }

        public string PublicNetworkAccess { get; private set; }

        public Identity Identity { get; private set; }

        public Encryption Encryption { get; private set; }

        public IList<UserOwnedStorage> UserOwnedStorage { get; private set; }

        public IList<PrivateEndpointConnection> PrivateEndpointConnections { get; private set; }

        public CognitiveServicesAccountApiProperties ApiProperties { get; private set; }

        public AccountProperties Properties { get; private set; }

        public bool? RestrictOutboundNetworkAccess { get; private set; }

        public IList<string> AllowedFqdnList { get; private set; }

        public bool? DisableLocalAuth { get; private set; }

        public PSNetworkRuleSet NetworkRuleSet { get; private set; }

        public IList<SkuCapability> Capabilities { get; private set; }

        public IDictionary<string, string> Tags { get; private set; }

        public static PSCognitiveServicesAccount Create(Account cognitiveServicesAccount)
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
