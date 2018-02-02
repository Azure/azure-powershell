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

namespace Microsoft.Azure.Commands.ServiceBus.Models
{

    /// <summary>
    /// Description of a Check Name availability request properties.
    /// </summary>
    public partial class PSCheckNameAvailabilityAttributes
    {
        /// <summary>
        /// Initializes a new instance of the CheckNameAvailability class.
        /// </summary>
        public PSCheckNameAvailabilityAttributes() { }

        /// <summary>
        /// Initializes a new instance of the CheckNameAvailability class.
        /// </summary>
        /// <param name="name">The Name to check the namespce name availability
        /// and The namespace name can contain only letters, numbers, and
        /// hyphens. The namespace must start with a letter, and it must end
        /// with a letter or number.</param>
        public PSCheckNameAvailabilityAttributes(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets the Name to check the namespce name availability and
        /// The namespace name can contain only letters, numbers, and hyphens.
        /// The namespace must start with a letter, and it must end with a
        /// letter or number.
        /// </summary>
        public string Name { get; set; }

    }
}