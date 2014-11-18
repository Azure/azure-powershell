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

namespace Microsoft.Azure.Commands.ManagedCache.Models
{
    using System.Net;
    using Microsoft.Azure.Management.ManagedCache.Models;

    class CacheAccessKeys
    {
        public CacheAccessKeys(string cacheServiceName, CachingKeysResponse response)
        {
            Name = cacheServiceName;
            Primary = response.Primary;
            Secondary = response.Secondary;
            StatusCode = response.StatusCode;
            RequestId = response.RequestId;
        }

        public string Name { get; private set; }

        public string Primary { get; private set; }

        public string Secondary { get; private set; }

        public HttpStatusCode StatusCode { get; private set; }

        public string RequestId { get; private set; }
    }
}