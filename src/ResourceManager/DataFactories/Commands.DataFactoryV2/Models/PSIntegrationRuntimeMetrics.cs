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
using System.Collections.Generic;
using Microsoft.Azure.Management.DataFactory.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2.Models
{
    public class PSIntegrationRuntimeMetrics
    {
        private readonly IntegrationRuntimeMonitoringData _monitoringData;

        public PSIntegrationRuntimeMetrics()
        {
            _monitoringData = new IntegrationRuntimeMonitoringData();
        }

        public PSIntegrationRuntimeMetrics(IntegrationRuntimeMonitoringData data, string resourceGroupName, string factoryName)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            this._monitoringData = data;
            this.ResourceGroupName = resourceGroupName;
            this.DataFactoryName = factoryName;
        }

        public string IntegrationRuntimeName => _monitoringData.Name;

        public string ResourceGroupName { get; private set; }

        public string DataFactoryName { get; private set; }

        public IList<IntegrationRuntimeNodeMonitoringData> Nodes => _monitoringData.Nodes;
    }
}
