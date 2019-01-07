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

using Microsoft.Rest;
using System;
using System.Net.Http;

namespace Microsoft.Azure.Commands.Profile.Test
{

    public class MockServiceClient : ServiceClient<MockServiceClient>
    {
        public MockServiceClient(Uri uri, ServiceClientCredentials credentials)
        {
            BaseUri = uri;
            Credentials = credentials;
        }

        public MockServiceClient(Uri uri, ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
        {
            BaseUri = uri;
            Credentials = credentials;
        }

        public string SubscriptionId { get; set; }

        public ServiceClientCredentials Credentials { get; set; }

        public Uri BaseUri { get; set; }
    }
}
