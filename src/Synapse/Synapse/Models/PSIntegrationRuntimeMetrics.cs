using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
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
