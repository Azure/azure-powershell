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

namespace Microsoft.Azure.Commands.Sql.ManagedInstance.Model
{
    /// <summary>
    /// An ARM Resource SKU.
    /// </summary>
    public partial class ManagedInstanceSku
    {
        /// <summary>
        /// Gets or sets the name of the SKU, typically, a letter + Number
        /// code, e.g. P3.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tier of the particular SKU, e.g. Basic, Premium.
        /// </summary>
        public string Tier { get; set; }

        /// <summary>
        /// Gets or sets size of the particular SKU
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets if the service has different generations of hardware,
        /// for the same SKU, then that can be captured here.
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// Gets or sets capacity of the particular SKU.
        /// </summary>
        public int? Capacity { get; set; }
    }
}

