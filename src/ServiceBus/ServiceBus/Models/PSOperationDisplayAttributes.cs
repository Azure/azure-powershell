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
    /// The object that represents the operation.
    /// </summary>
    public partial class PSOperationDisplayAttributes
    {
        /// <summary>
        /// Initializes a new instance of the OperationDisplay class.
        /// </summary>
        public PSOperationDisplayAttributes() { }

        /// <summary>
        /// Initializes a new instance of the OperationDisplay class.
        /// </summary>
        /// <param name="provider">Service provider: Microsoft.RelayName</param>
        /// <param name="resource">Resource on which the operation is
        /// performed: Invoice, etc.</param>
        /// <param name="operation">Operation type: Read, write, delete,
        /// etc.</param>
        public PSOperationDisplayAttributes(string provider = default(string), string resource = default(string), string operation = default(string))
        {
            Provider = provider;
            Resource = resource;
            Operation = operation;
        }

        public PSOperationDisplayAttributes(OperationDisplay operationDisplay)
        {
            Provider = operationDisplay.Provider;
            Resource = operationDisplay.Resource;
            Operation = operationDisplay.Operation;
        }

        /// <summary>
        /// Gets service provider: Microsoft.RelayName
        /// </summary>
        public string Provider { get; protected set; }

        /// <summary>
        /// Gets resource on which the operation is performed: Invoice, etc.
        /// </summary>
        public string Resource { get; protected set; }

        /// <summary>
        /// Gets operation type: Read, write, delete, etc.
        /// </summary>
        public string Operation { get; protected set; }

    }
}
