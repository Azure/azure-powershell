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

using Microsoft.Azure.Management.CosmosDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSDataCenterResourceProperties
    {
        PSDataCenterResourceProperties()
        {
        }

        public PSDataCenterResourceProperties(DataCenterResourceProperties dataCenterProperties)
        {
            if (dataCenterProperties == null)
            {
                return;
            }

            DataCenterLocation = dataCenterProperties.DataCenterLocation;
            NodeCount = dataCenterProperties.NodeCount;
            Base64EncodedCassandraYamlFragment = dataCenterProperties.Base64EncodedCassandraYamlFragment;
            DelegatedSubnetId = dataCenterProperties.DelegatedSubnetId;
            ProvisioningState = dataCenterProperties.ProvisioningState;
            SeedNodes = new List<PSSeedNode>();
            foreach (SeedNode seedNode in dataCenterProperties.SeedNodes)
            {
                SeedNodes.Add(new PSSeedNode(seedNode?.IpAddress));
            }
        }

        //
        // Summary:
        //     Gets or sets Node count of Cassandra Datacenter.
        public int? NodeCount { get; set; }
        //
        // Summary:
        //      Gets or sets DataCenter Location of Cassandra Datacenter.
        public string DataCenterLocation { get; set; }
        //
        // Summary:
        //      Gets or sets DelegatedSubnetId of Cassandra Datacenter.
        public string DelegatedSubnetId { get; }
        //
        // Summary:
        //      Gets or sets ProvisioningState of Cassandra Datacenter.
        public string ProvisioningState { get; }
        //
        // Summary:
        //      Gets or sets Base64EncodedCassandraYamlFragment of Cassandra Datacenter.
        public string Base64EncodedCassandraYamlFragment { get; }
        //
        // Summary:
        //      Gets or sets SeedNodes of Cassandra Datacenter.
        public IList<PSSeedNode> SeedNodes { get; }
    }
}