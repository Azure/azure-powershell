// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.EventHub.Models
{
    using System.Linq;

    /// <summary>
    /// Properties of the Application Group policy
    /// </summary>
    [Newtonsoft.Json.JsonObject("ApplicationGroupPolicy")]
    public partial class ApplicationGroupPolicy
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationGroupPolicy class.
        /// </summary>
        public ApplicationGroupPolicy()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ApplicationGroupPolicy class.
        /// </summary>

        /// <param name="name">The Name of this policy
        /// </param>
        public ApplicationGroupPolicy(string name)

        {
            this.Name = name;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the Name of this policy
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (this.Name == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "Name");
            }

        }
    }
}