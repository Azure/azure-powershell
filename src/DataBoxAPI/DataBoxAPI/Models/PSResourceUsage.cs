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

namespace Microsoft.Azure.Commands.Cdn.Models
{
    /// <summary>
    /// Resource usage class of powershell
    /// </summary>
    public class PSResourceUsage
    {
        /// <summary>
        /// Gets or sets the resource type of the usage.
        /// </summary>
        public string ResourceType { get; set; }

        /// <summary>
        /// The unit of the quota
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// The current value of already used quota
        /// </summary>
        public int CurrentValue { get; set; }

        /// <summary>
        /// The maximum quota of the entity
        /// </summary>
        public int Limit { get; set; }
    }
}
