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

using System.Collections.Generic;
using Microsoft.Azure.Management.DataFactory.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.DataFactoryV2.Models
{
    public class PSLinkedIntegrationRuntimeStatus : PSSelfHostedIntegrationRuntimeStatus
    {
        public PSLinkedIntegrationRuntimeStatus(
            IntegrationRuntimeResource integrationRuntime,
            SelfHostedIntegrationRuntimeStatus status,
            string resourceGroupName,
            string factoryName,
            JsonSerializerSettings deserializerSettings,
            string authType,
            string origIntegrationRuntimeName,
            string origDataFactoryName)
            : base(integrationRuntime, status, resourceGroupName, factoryName, deserializerSettings)
        {
            DataFactoryName = factoryName;
            ResourceGroupName = resourceGroupName;
            OriginalIntegrationRuntimeName = origIntegrationRuntimeName;
            OriginalDataFactoryName = origDataFactoryName;
            AuthorizationType = authType;
        }

        public new string Name => IntegrationRuntime.Name;

        public new string Type => Constants.IntegrationRuntimeSelfhostedLinked;

        public new string DataFactoryName { get; private set; }

        public new string ResourceGroupName { get; private set; }

        public string OriginalIntegrationRuntimeName { get; private set; }

        public string OriginalDataFactoryName { get; private set; }

        public string AuthorizationType { get; private set; }

        private new IList<LinkedIntegrationRuntime> Links { get; set; }
    }
}
