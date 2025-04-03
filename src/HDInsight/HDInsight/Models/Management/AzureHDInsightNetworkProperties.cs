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
    public class AzureHDInsightNetworkProperties
    {
        public AzureHDInsightNetworkProperties() { }

        public AzureHDInsightNetworkProperties(string resourceProviderConnection = null, string privateLink = null, IpTag publicIPTag = null, string outboundDependenciesManagedType = null)
        {
            ResourceProviderConnection = resourceProviderConnection;
            PrivateLink = privateLink;
            PublicIPTag = publicIPTag;
            OutboundDependenciesManagedType = outboundDependenciesManagedType;
        }

        public AzureHDInsightNetworkProperties(NetworkProperties networkProperties = null)
        {
            ResourceProviderConnection = networkProperties?.ResourceProviderConnection;
            PrivateLink = networkProperties?.PrivateLink;
            PublicIPTag = networkProperties?.PublicIPTag != null ? networkProperties?.PublicIPTag : null;
            OutboundDependenciesManagedType = networkProperties?.OutboundDependenciesManagedType;
        }

        /// <summary>
        /// Gets or sets the direction for the resource provider connection. Possible values include: 'Inbound', 'Outbound'
        /// </summary>
        public string ResourceProviderConnection { get; set; }

        /// <summary>
        /// Gets or sets indicates whether or not private link is enabled. Possible values include: 'Disabled', 'Enabled'
        /// </summary>
        public string PrivateLink { get; set; }

        /// <summary>
        /// A value to describe how the outbound dependencies of a HDInsight cluster are managed. 'Managed' means that the 
        /// outbound dependencies are managed by the HDInsight service. 'External' means that the outbound dependencies are 
        /// managed by a customer specific solution.
        /// </summary>
        public string OutboundDependenciesManagedType {get; set; }

        /// <summary>
        /// Gets or sets gets or sets the IP tag for the public IPs created along with
        /// the HDInsight Clusters.
        /// </summary>
        public IpTag PublicIPTag {get; set; }
    }
}
