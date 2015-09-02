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

namespace Microsoft.Azure.Commands.Sql.Location_Capabilities.Model
{
    /// <summary>
    /// Represents the capabilities of a server version
    /// </summary>
    public class ServerVersionCapabilityModel
    {
        /// <summary>
        /// Gets or sets the name of the Server Version
        /// </summary>
        public string ServerVersionName { get; set; }

        /// <summary>
        /// Gets or sets the status of the Azure SQL Server Version with respect to the current subscription
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the list of supported datababase Editions and their capabilities
        /// </summary>
        public IList<EditionCapabilityModel> SupportedEditions { get; set; }
    }
}
