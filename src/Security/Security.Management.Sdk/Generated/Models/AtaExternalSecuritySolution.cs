// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.Security.Models
{
    using System.Linq;

    /// <summary>
    /// Represents an ATA security solution which sends logs to an OMS workspace
    /// </summary>
    [Newtonsoft.Json.JsonObject("ATA")]
    public partial class AtaExternalSecuritySolution : ExternalSecuritySolution
    {
        /// <summary>
        /// Initializes a new instance of the AtaExternalSecuritySolution class.
        /// </summary>
        public AtaExternalSecuritySolution()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AtaExternalSecuritySolution class.
        /// </summary>

        /// <param name="id">Resource Id
        /// </param>

        /// <param name="name">Resource name
        /// </param>

        /// <param name="type">Resource type
        /// </param>

        /// <param name="kind">The kind of the external solution
        /// Possible values include: 'CEF', 'ATA', 'AAD'</param>

        /// <param name="location">Location where the resource is stored
        /// </param>

        /// <param name="properties">The external security solution properties for ATA solutions
        /// </param>
        public AtaExternalSecuritySolution(string id = default(string), string name = default(string), string type = default(string), string kind = default(string), string location = default(string), AtaSolutionProperties properties = default(AtaSolutionProperties))

        : base(id, name, type, kind, location)
        {
            this.Properties = properties;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the external security solution properties for ATA solutions
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties")]
        public AtaSolutionProperties Properties {get; set; }
    }
}