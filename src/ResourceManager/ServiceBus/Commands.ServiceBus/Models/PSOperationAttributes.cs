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
    using Azure.Management.ServiceBus.Models;

    /// <summary>
    /// A ServiceBus REST API operation
    /// </summary>
    public partial class PSOperationAttributes
    {
        /// <summary>
        /// Initializes a new instance of the Operation class.
        /// </summary>
        public PSOperationAttributes() { }

        /// <summary>
        /// Initializes a new instance of the Operation class.
        /// </summary>
        /// <param name="name">Operation name:
        /// {provider}/{resource}/{operation}</param>
        /// <param name="display">The object that represents the
        /// operation.</param>
        public PSOperationAttributes(string name = default(string), PSOperationDisplayAttributes display = default(PSOperationDisplayAttributes))
        {
            Name = name;
            Display = display;
        }

        public PSOperationAttributes(Operation operation)
        {
            Name = operation.Name;
            if (operation.Display != null)
            {
                Display = new PSOperationDisplayAttributes(operation.Display.Operation);
            }
        }


        /// <summary>
        /// Gets operation name: {provider}/{resource}/{operation}
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the object that represents the operation.
        /// </summary>
        public PSOperationDisplayAttributes Display { get; set; }

    }
}
