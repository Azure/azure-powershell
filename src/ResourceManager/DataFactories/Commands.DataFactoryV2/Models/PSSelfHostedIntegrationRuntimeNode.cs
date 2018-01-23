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
using System.Management.Automation;
using Microsoft.Azure.Management.DataFactory.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2.Models
{
    public class PSSelfHostedIntegrationRuntimeNode
    {
        public PSSelfHostedIntegrationRuntimeNode(
            string resourceGroupName,
            string factoryName,
            string integrationRuntimeName,
            string name,
            SelfHostedIntegrationRuntimeNode node,
            string ipAddress)
        {
            if (node == null)
            {
                throw new PSArgumentNullException("node");
            }

            ResourceGroupName = resourceGroupName;
            DataFactoryName = factoryName;
            IntegrationRuntimeName = integrationRuntimeName;
            Name = name;
            _node = node;
            IpAddress = ipAddress;
        }

        private readonly SelfHostedIntegrationRuntimeNode _node;

        public string ResourceGroupName { get; private set; }

        public string DataFactoryName { get; private set; }

        public string IntegrationRuntimeName { get; private set; }

        public string Name { get; private set; }

        public string MachineName => _node.MachineName;

        public string HostServiceUri => _node.HostServiceUri;

        public string Status => _node.Status;

        public IDictionary<string, string> Capabilities => _node.Capabilities;

        public string VersionStatus => _node.VersionStatus;

        public string Version => _node.Version;

        public DateTime? RegisterTime => _node.RegisterTime;

        public DateTime? LastConnectTime => _node.LastConnectTime;

        public DateTime? ExpiryTime => _node.ExpiryTime;

        public DateTime? LastStartTime => _node.LastStartTime;

        public DateTime? LastStopTime => _node.LastStopTime;

        public string LastUpdateResult => _node.LastUpdateResult;

        public DateTime? LastStartUpdateTime => _node.LastStartUpdateTime;

        public DateTime? LastEndUpdateTime => _node.LastEndUpdateTime;

        public bool? IsActiveDispatcher => _node.IsActiveDispatcher;

        public int? ConcurrentJobsLimit => _node.ConcurrentJobsLimit;

        public int? MaxConcurrentJobs => _node.MaxConcurrentJobs;

        public string IpAddress { get; private set; }
    }
}
