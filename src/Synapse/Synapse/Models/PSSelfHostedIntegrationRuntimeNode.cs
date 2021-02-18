using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSelfHostedIntegrationRuntimeNode
    {
        public PSSelfHostedIntegrationRuntimeNode(
            string resourceGroupName,
            string workspaceName,
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
            DataFactoryName = workspaceName;
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
