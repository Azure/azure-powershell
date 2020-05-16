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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.OperationalInsights.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSClusterPatch
    {
        public PSClusterPatch(PSKeyVaultProperties keyVaultProperties = default(PSKeyVaultProperties), PSClusterSku sku = default(PSClusterSku), Hashtable tags = default(Hashtable))
        {
            KeyVaultProperties = keyVaultProperties;
            Sku = sku;
            Tags = tags;
        }

        public PSClusterPatch(ClusterPatch patch)
        {
            if (patch.KeyVaultProperties != null)
            {
                this.KeyVaultProperties = new PSKeyVaultProperties(patch.KeyVaultProperties);
            }

            if (patch.Sku != null)
            {
                this.Sku = new PSClusterSku(patch.Sku);
            }

            if (patch.Tags != null)
            {
                this.Tags = new Hashtable((IDictionary)patch.Tags);
            }        
        }

        public PSKeyVaultProperties KeyVaultProperties { get; set; }

        public PSClusterSku Sku { get; set; }

        public Hashtable Tags { get; set; }

        private IDictionary<string, string> getTags()
        {
            return this.Tags?.Cast<DictionaryEntry>().ToDictionary(kv => (string)kv.Key, kv => (string)kv.Value);
        }

        public ClusterPatch GetClusterPatch()
        {
            return new ClusterPatch(this.KeyVaultProperties?.GetKeyVaultProperties(), this.Sku?.geteClusterSku(), this.getTags());
        }
    }
}
