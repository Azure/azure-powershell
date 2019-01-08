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
using System.Management.Automation;
using Microsoft.Azure.Management.DataFactory.Models;


namespace Microsoft.Azure.Commands.DataFactoryV2.Models
{
    public class PSManagedIntegrationRuntimeNode
    {
        public PSManagedIntegrationRuntimeNode(
            string resourceGroupName,
            string factoryName,
            string integrationRuntimeName,
            string name,
            ManagedIntegrationRuntimeNode node)
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