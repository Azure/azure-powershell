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
using System.Runtime.InteropServices;
using Microsoft.Azure.Management.DataFactory.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2.Models
{
    public class PSIntegrationRuntime
    {
        internal readonly IntegrationRuntimeResource IntegrationRuntime;

        public PSIntegrationRuntime(IntegrationRuntimeResource integrationRuntime, string resourceGroupName, string factoryName)
        {
            if (integrationRuntime == null)
            {
                throw new ArgumentNullException(nameof(integrationRuntime));
            }

            IntegrationRuntime = integrationRuntime;
            ResourceGroupName = resourceGroupName;
            DataFactoryName = factoryName;
        }

        public string Name => IntegrationRuntime.Name;

        public string Type
        {
            get
            {
                if (IntegrationRuntime.Properties is ManagedIntegrationRuntime)
                {
                    return  Constants.IntegrationRuntimeTypeManaged;
                }
                else if (IntegrationRuntime.Properties is SelfHostedIntegrationRuntime)
                {
                    return Constants.IntegrationRuntimeSelfhosted;
                }

                return string.Empty;
            }
        }

        public string ResourceGroupName { get; private set; }

        public string DataFactoryName { get; private set; }

        public string Description
        {
            get { return IntegrationRuntime.Properties.Description; }
            set { IntegrationRuntime.Properties.Description = value; }
        }

        public string Id => IntegrationRuntime.Id;
    }
}
