// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.Attestation.Models
{
    using System.Linq;

    /// <summary>
    /// List of supported operations.
    /// </summary>
    public partial class OperationList
    {
        /// <summary>
        /// Initializes a new instance of the OperationList class.
        /// </summary>
        public OperationList()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the OperationList class.
        /// </summary>

        /// <param name="value">List of supported operations.
        /// </param>
        public OperationList(System.Collections.Generic.IList<OperationsDefinition> value = default(System.Collections.Generic.IList<OperationsDefinition>))

        {
            this.Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets list of supported operations.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "value")]
        public System.Collections.Generic.IList<OperationsDefinition> Value {get; set; }
    }
}