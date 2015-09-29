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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.Location_Capabilities.Model
{
    /// <summary>
    /// Represents a Service Level Objective and its capabilities
    /// </summary>
    public class ServiceObjectiveCapabilityModel
    {
        /// <summary>
        /// Gets or sets the name of the Service Level Objective
        /// </summary>
        public string ServiceObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the status of the Service Level Objective for the given: Subscription, Server Version, Database Edition combination.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the unique ID of the Service Level Objecive
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the list of supported max sizes and their capabilities
        /// </summary>
        public IList<MaxSizeCapabilityModel> SupportedMaxSizes { get; internal set; }
    }
}
