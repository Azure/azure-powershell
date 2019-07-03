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
using Microsoft.Azure.Management.Kusto;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Kusto.Utilities;
using Microsoft.Azure.Management.Kusto.Models;

namespace Microsoft.Azure.Commands.Kusto.Models
{
    public class PSKustoCluster
    {
        private readonly Cluster _cluster;

        public PSKustoCluster(Cluster cluster)
        {
            _cluster = cluster;
        }

        public string Type
        {
            get
            {
                return _cluster.Type;
            }
        }

        public string Id
        {
            get
            {
                return _cluster.Id;
            }
        }

        public string ResourceGroup
        {
            get
            {
                string resourceGroupName = string.Empty;
                KustoUtils.GetResourceGroupNameFromClusterId(Id, out resourceGroupName);
                return resourceGroupName;
            }
        }

        public string Name
        {
            get
            {
                return _cluster.Name;
            }
        }

        public string Location
        {
            get
            {
                return _cluster.Location;
            }
        }

        public string Sku
        {
            get
            {
                return (_cluster.Sku != null) ? _cluster.Sku.Name : null;
            }
        }

        public int? Capacity
        {
            get
            {
                return (_cluster.Sku != null) ? _cluster.Sku.Capacity : null;
            }
        }

        public string ProvisioningState
        {
            get
            {
                return _cluster.ProvisioningState;

            }
        }

        public string State
        {
            get
            {
                return _cluster.State;

            }
        }

        public System.Collections.Generic.IDictionary<string, string> Tag
        {
            get
            {
                return _cluster.Tags != null ? new Dictionary<string, string>(_cluster.Tags) : new Dictionary<string, string>();
            }
        }

        public string Uri
        {
            get
            {
                return _cluster.Uri;

            }
        }

        public string DataIngestionUri
        {
            get
            {
                return _cluster.DataIngestionUri;
            }
        }
    }
}
