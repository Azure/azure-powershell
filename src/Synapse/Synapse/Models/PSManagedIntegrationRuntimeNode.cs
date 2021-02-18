using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSManagedIntegrationRuntimeNode
    {
        public PSManagedIntegrationRuntimeNode(
               string resourceGroupName,
               string workspaceName,
               string integrationRuntimeName,
               string name,
               ManagedIntegrationRuntimeNode node)
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
        }

        private readonly ManagedIntegrationRuntimeNode _node;

        public string ResourceGroupName { get; private set; }

        public string DataFactoryName { get; private set; }

        public string IntegrationRuntimeName { get; private set; }

        public string Name { get; private set; }

        public string NodeId => _node.NodeId;

        public string Status => _node.Status;

        public IList<ManagedIntegrationRuntimeError> Errors => _node.Errors;
    }
}
