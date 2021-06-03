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
    public class PSClusterNodeStatusNodesItem
    {
        PSClusterNodeStatusNodesItem()
        {
        }

        public PSClusterNodeStatusNodesItem(ClusterNodeStatusNodesItem clusterNodeStatusItem)
        {
            if(clusterNodeStatusItem == null)
            {
                return;
            }

            Owns = clusterNodeStatusItem.Owns;
            Datacenter = clusterNodeStatusItem.Datacenter;
            Status = clusterNodeStatusItem.Status;
            State = clusterNodeStatusItem.State;
            Address = clusterNodeStatusItem.Address;
            Load = clusterNodeStatusItem.Load;
            HostId = clusterNodeStatusItem.HostId;
            Rack = clusterNodeStatusItem.Rack;
            Tokens = clusterNodeStatusItem.Tokens;
        }

        //
        // Summary:
        //      Gets or sets Datacenter of Node.
        public string Datacenter { get; }
        //
        // Summary:
        //       Gets or sets Status of Node.
        public string Status { get; }
        //
        // Summary:
        //       Gets or sets State of Node.
        public string State { get; }
        //
        // Summary:
        //      Gets or sets Address of Node.
        public string Address { get; }
        //
        // Summary:
        //      Gets or sets Load of Node.
        public string Load { get; }
        //
        // Summary:
        //      Gets or sets HostId of Node.
        public string HostId { get; }
        //
        // Summary:
        //      Gets or sets Rack of Node.
        public string Rack { get; }
        //
        // Summary:
        //     Gets or sets Owns of Node.
        public double? Owns { get; set; }
        //
        // Summary:
        //     Gets or sets Tokens of Node.
        public IList<string> Tokens { get; set; }
    }
}