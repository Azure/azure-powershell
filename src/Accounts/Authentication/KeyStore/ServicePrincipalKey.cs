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
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public class ServicePrincipalKey : IKeyStoreKey
    {
        [JsonProperty]
        readonly private string appId = null;
        [JsonProperty]
        readonly private string tenantId = null;
        [JsonProperty]
        readonly private string name = null;

        public ServicePrincipalKey(string name, string appId, string tenantId)
        {
            this.name = name?? string.Empty;
            this.appId = appId?? string.Empty;
            this.tenantId = tenantId?? string.Empty;
        }

        protected override string CreateKey()
        {
            return $"{name}_{appId}_{tenantId}";
        }

        public override string ToString()
        {
            return CreateKey();
        }

        public override int GetHashCode()
        {
            return CreateKey().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is ServicePrincipalKey other)
            {
                return this.name == other.name && this.appId == other.appId && this.tenantId == other.tenantId;
            }
            return false;
        }
    }
}
