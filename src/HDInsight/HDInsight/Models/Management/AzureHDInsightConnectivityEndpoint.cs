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

using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightConnectivityEndpoint
    {
        public AzureHDInsightConnectivityEndpoint() { }

        public AzureHDInsightConnectivityEndpoint(string name = null, string protocol = null, string location = null, int? port = null, string privateIPAddress = null)
        {
            Name = name;
            Protocol = protocol;
            Location = location;
            Port = port;
            PrivateIPAddress = privateIPAddress;
        }

        public AzureHDInsightConnectivityEndpoint(ConnectivityEndpoint connectivityEndpoint = null)
        {
            Name = connectivityEndpoint?.Name;
            Protocol = connectivityEndpoint?.Protocol;
            Location = connectivityEndpoint?.Location;
            Port = connectivityEndpoint?.Port;
            PrivateIPAddress = connectivityEndpoint?.PrivateIPAddress;
        }

        /// <summary>
        /// Gets or sets the name of connectivity endpoint.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the protocol of connectivity endpoint.
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// Gets or sets the location of connectivity endpoint.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the port of connectivity endpoint.
        /// </summary>
        public int? Port { get; set; }

        /// <summary>
        /// Gets or sets the private ip address of connectivity endpoint.
        /// </summary>
        public string PrivateIPAddress { get; set; }
    }
}
