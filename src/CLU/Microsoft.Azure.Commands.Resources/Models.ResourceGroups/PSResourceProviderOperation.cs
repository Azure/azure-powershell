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

namespace Microsoft.Azure.Commands.Resources.Models
{
    /// <summary>
    /// Definition of a resource provider and its registration state
    /// </summary>
    public class PSResourceProviderOperation
    {
        /// <summary>
        /// Gets or sets the operation id
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// Gets or sets the name of the provider operation.
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// Gets or sets the name of the operation provider.
        /// </summary>
        public string ProviderNamespace { get; set; }

        /// <summary>
        /// Gets or sets the name of the operation resource.
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the operation description.
        /// </summary>
        public string Description { get; set; }
    }
}
