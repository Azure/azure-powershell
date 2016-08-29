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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Resources;
using System;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
        public IBatchManagementClient BatchManagementClient { get; private set; }

        public IResourceManagementClient ResourceManagementClient { get; private set; }

        internal Action<string> VerboseLogger { get; set; }

        private static string batchProvider = "Microsoft.Batch";
        private static string accountObject = "batchAccounts";
        private static string accountSearch = batchProvider + "/" + accountObject;

        public BatchClient()
        { }

        /// <summary>
        /// Creates new BatchClient instance
        /// </summary>
        /// <param name="batchManagementClient">The IBatchManagementClient instance</param>
        /// <param name="resourceManagementClient">The IResourceManagementClient instance</param>
        public BatchClient(IBatchManagementClient batchManagementClient, IResourceManagementClient resourceManagementClient)
        {
            BatchManagementClient = batchManagementClient;
            ResourceManagementClient = resourceManagementClient;
        }

        /// <summary>
        /// Creates new BatchClient
        /// </summary>
        /// <param name="context">Context with subscription containing a batch account to manipulate</param>
        public BatchClient(AzureContext context)
            : this(AzureSession.ClientFactory.CreateArmClient<BatchManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager),
            AzureSession.ClientFactory.CreateClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        private void WriteVerbose(string message)
        {
            if (VerboseLogger != null)
            {
                VerboseLogger(message);
            }
        }
    }
}
