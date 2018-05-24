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

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Maps.Models
{
    public class PSMapsAccount
    {
        public PSMapsAccount(Management.Maps.Models.MapsAccount mapsAccount)
        {
            this.ResourceGroupName = ParseResourceGroupFromId(mapsAccount.Id);
            this.AccountName = mapsAccount.Name;
            this.Id = mapsAccount.Id;
            this.Location = mapsAccount.Location;
            this.Sku = new PSMapsAccountSku(mapsAccount.Sku);
            this.ResourceType = mapsAccount.Type;
            this.Tags = mapsAccount.Tags;
        }

        public string ResourceGroupName { get; private set; }

        public string AccountName { get; private set; }

        public string Id { get; private set; }

        public string Location { get; private set; }

        public PSMapsAccountSku Sku { get; private set; }

        public string ResourceType { get; private set; }

        public IDictionary<string, string> Tags { get; private set; }

        public static PSMapsAccount Create(Management.Maps.Models.MapsAccount mapsAccount)
        {
            var result = new PSMapsAccount(mapsAccount);
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
        /// Return a string representation of this Maps account
        /// </summary>
        /// <returns>null</returns>
        public override string ToString()
        {
            return this.Id;
        }
    }
}
