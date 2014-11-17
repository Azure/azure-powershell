//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Azure.Management.ManagedCache;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;

namespace Microsoft.Azure
{
    public static class ManagedCacheDiscoveryExtensions
    {
        public static ManagedCacheClient CreateManagedCacheManagementClient(this CloudClients clients, SubscriptionCloudCredentials credentials)
        {
            return new ManagedCacheClient(credentials);
        }

        public static ManagedCacheClient CreateManagedCacheManagementClient(this CloudClients clients, SubscriptionCloudCredentials credentials, Uri baseUri)
        {
            return new ManagedCacheClient(credentials, baseUri);
        }

        public static ManagedCacheClient CreateManagedCacheClient(this CloudClients clients)
        {
            return ConfigurationHelper.CreateFromSettings<ManagedCacheClient>(ManagedCacheClient.Create);
        }
    }
}

namespace Microsoft.Azure.Management.ManagedCache
{
    public partial class ManagedCacheClient
    {
        public static ManagedCacheClient Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            SubscriptionCloudCredentials credentials = ConfigurationHelper.GetCredentials<SubscriptionCloudCredentials>(settings);

            Uri baseUri = ConfigurationHelper.GetUri(settings, "BaseUri", false);

            return baseUri != null ?
                new ManagedCacheClient(credentials, baseUri) :
                new ManagedCacheClient(credentials);
        }

        public override ManagedCacheClient WithHandler(DelegatingHandler handler)
        {
            return (ManagedCacheClient)WithHandler(new ManagedCacheClient(), handler);
        }
    }
}
