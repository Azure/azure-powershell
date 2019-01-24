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
using System.IO;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.WindowsAzure.Commands.Common.Properties;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    public partial class DataFactoryClient
    {
        private readonly Guid _subscriptionId;

        public DataFactoryManagementClient DataFactoryManagementClient { get; private set; }

        public DataFactoryClient(IAzureContext context)
        {
            if (context == null)
            {
                throw new ApplicationException(Resources.InvalidDefaultSubscription);
            }

            _subscriptionId = Guid.Parse(context.Subscription.Id);
            this.DataFactoryManagementClient = DataFactoryClient.CreateAdfClient(context);
        }

        /// <summary>
        /// Parameterless constructor for Mocking.
        /// </summary>
        public DataFactoryClient()
        {
        }

        public virtual string ReadJsonFileContent(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            using (TextReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }

        internal static DataFactoryManagementClient CreateAdfClient(IAzureContext context)
        {
            if (context == null)
            {
                throw new ApplicationException(Resources.NoCurrentContextForDataCmdlet);
            }

            return AzureSession.Instance.ClientFactory.CreateArmClient<DataFactoryManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }
    }
}
