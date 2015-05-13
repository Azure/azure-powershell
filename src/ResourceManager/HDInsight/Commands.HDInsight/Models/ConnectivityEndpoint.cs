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

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class ConnectivityEndpoint
    {
        /// <summary>
        /// The location of the endpoint.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The name of the endpoint.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The port to connect to.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// The protocol of the endpoint.
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// Initializes a new instance of the ConnectivityEndpoint class.
        /// </summary>
        public ConnectivityEndpoint()
        {
        }
    }
}
