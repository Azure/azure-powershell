﻿// ----------------------------------------------------------------------------------
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Common.Authentication;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Common
{
    public class MockSubsciptionFactory : IClientFactory
    {
        public void AddAction(Azure.Common.Authentication.Models.IClientAction action)
        {
            throw new NotImplementedException();
        }

        public TClient CreateClient<TClient>(Azure.Common.Authentication.Models.AzureProfile profile, Azure.Common.Authentication.Models.AzureSubscription subscription, Azure.Common.Authentication.Models.AzureEnvironment.Endpoint endpoint) where TClient : Hyak.Common.ServiceClient<TClient>
        {
            throw new NotImplementedException();
        }

        public TClient CreateClient<TClient>(Azure.Common.Authentication.Models.AzureProfile profile, Azure.Common.Authentication.Models.AzureEnvironment.Endpoint endpoint) where TClient : Hyak.Common.ServiceClient<TClient>
        {
            throw new NotImplementedException();
        }

        public TClient CreateClient<TClient>(Azure.Common.Authentication.Models.AzureContext context, Azure.Common.Authentication.Models.AzureEnvironment.Endpoint endpoint) where TClient : Hyak.Common.ServiceClient<TClient>
        {
            throw new NotImplementedException();
        }

        public TClient CreateCustomClient<TClient>(params object[] parameters) where TClient : Hyak.Common.ServiceClient<TClient>
        {
            throw new NotImplementedException();
        }

        public HttpClient CreateHttpClient(string endpoint, HttpMessageHandler effectiveHandler)
        {
            throw new NotImplementedException();
        }

        public HttpClient CreateHttpClient(string endpoint, System.Net.ICredentials credentials)
        {
            throw new NotImplementedException();
        }

        public void RemoveAction(Type actionType)
        {
            throw new NotImplementedException();
        }

        public void AddUserAgent(string productName, string productVersion)
        {
            throw new NotImplementedException();
        }

        public void AddUserAgent(string productName)
        {
            throw new NotImplementedException();
        }

        public HashSet<ProductInfoHeaderValue> UserAgents
        {
            get { throw new NotImplementedException(); }
        }


        public TClient CreateArmClient<TClient>(Azure.Common.Authentication.Models.AzureContext context, Azure.Common.Authentication.Models.AzureEnvironment.Endpoint endpoint) where TClient : Microsoft.Rest.ServiceClient<TClient>
        {
            throw new NotImplementedException();
        }

        public TClient CreateCustomArmClient<TClient>(params object[] parameters) where TClient : Microsoft.Rest.ServiceClient<TClient>
        {
            throw new NotImplementedException();
        }

        List<ProductInfoHeaderValue> IClientFactory.UserAgents
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
