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

using Microsoft.Azure.Batch.Protocol;
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Net.Http;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class ScenarioTestContext : BatchAccountContext
    {
        public ScenarioTestContext(BatchAccountContext context) : base()
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            // Only set the properties needed for interacting with the Batch service.
            this.AccountName = context.AccountName;
            this.PrimaryAccountKey = context.PrimaryAccountKey;
            this.SecondaryAccountKey = context.SecondaryAccountKey;
            this.TaskTenantUrl = context.TaskTenantUrl;
        }

        protected override BatchService CreateBatchRestClient(string url, string accountName, string key)
        {
            // Add HTTP recorder to the BatchRestClient
            HttpMockServer mockServer = HttpMockServer.CreateInstance();
            mockServer.InnerHandler = new HttpClientHandler();

            BatchCredentials credentials = new BatchSharedKeyCredential(accountName, key);
            
            BatchService restClient = new BatchService(credentials, mockServer);
            return restClient;
        }
    }
}
