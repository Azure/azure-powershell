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

using Microsoft.Azure.Commands.Management.IotHub.Common;

namespace Microsoft.Azure.Commands.Management.IotHub.Models
{
    public class PSRoutingCustomEndpoint
    {
        /// <summary>
        /// The name of the custom endpoint.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The connection string of the custom endpoint.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Container name of the custom storage container endpoint.
        /// </summary>
        public string ContainerName { get; set; }

        /// <summary>
        /// The endpoint type of the custom endpoint
        /// </summary>
        public PSEndpointType EndpointType { get; set; }

        /// <summary>
        /// Azure resource of the custom endpoint.
        /// </summary>
        public string AzureResource
        {
            get
            {
                return IotHubUtils.GetAzureResource(this.EndpointType, this.ConnectionString, this.ContainerName);
            }
        }
    }
}
