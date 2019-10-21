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

namespace Microsoft.Azure.Commands.Sql.Usages.Models
{
    public class AzureSqlUsageModel
    {
        /// <summary>
        /// Gets or sets the usage id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the usage current value
        /// </summary>
        public int? CurrentValue { get; set; }

        /// <summary>
        /// Gets or sets the usage limit
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Gets or sets the usage requested limit
        /// </summary>
        public int? RequestedLimit { get; set; }

        /// <summary>
        /// Gets or sets the usage unit
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the usage name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the usage type
        /// </summary>
        public string Type { get; set; }
    }
}
