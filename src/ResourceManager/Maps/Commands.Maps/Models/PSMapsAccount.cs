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

using Microsoft.Azure.Management.LocationBasedServices;
using Microsoft.Azure.Management.LocationBasedServices.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.LocationBasedServices.Models
{
    public class PSLocationBasedServicesAccount
    {
        public PSLocationBasedServicesAccount(LocationBasedServicesAccount locationBasedServicesAccount)
        {
            this.ResourceGroupName = ParseResourceGroupFromId(locationBasedServicesAccount.Id);
            this.AccountName = locationBasedServicesAccount.Name;
            this.Id = locationBasedServicesAccount.Id;
            this.Location = locationBasedServicesAccount.Location;
            this.Sku = new PSLocationBasedServicesAccountSku(locationBasedServicesAccount.Sku);
            this.ResourceType = locationBasedServicesAccount.Type;
            this.Tags = locationBasedServicesAccount.Tags;
        }

        public string ResourceGroupName { get; private set; }

        public string AccountName { get; private set; }

        public string Id { get; private set; }

        public string Location { get; private set; }

        public PSLocationBasedServicesAccountSku Sku { get; private set; }

        public string ResourceType { get; private set; }

        public IDictionary<string, string> Tags { get; private set; }

        public static PSLocationBasedServicesAccount Create(LocationBasedServicesAccount locationBasedServicesAccount)
        {
            var result = new PSLocationBasedServicesAccount(locationBasedServicesAccount);
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
        /// Return a string representation of this location based services account
        /// </summary>
        /// <returns>null</returns>
        public override string ToString()
        {
            return this.Id;
        }
    }
}
