// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.PolicyInsights.Models
{
    using System.Linq;

    /// <summary>
    /// Operation definition.
    /// </summary>
    public partial class Operation
    {
        /// <summary>
        /// Initializes a new instance of the Operation class.
        /// </summary>
        public Operation()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Operation class.
        /// </summary>

        /// <param name="name">Operation name.
        /// </param>

        /// <param name="display">Display metadata associated with the operation.
        /// </param>
        public Operation(string name = default(string), OperationDisplay display = default(OperationDisplay))

        {
            this.Name = name;
            this.Display = display;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets operation name.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name {get; set; }

        /// <summary>
        /// Gets or sets display metadata associated with the operation.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "display")]
        public OperationDisplay Display {get; set; }
    }
}