// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models
{
    using System.Linq;

    /// <summary>
    /// Implements the Event class.
    /// </summary>
    public partial class EventModel : Resource
    {
        /// <summary>
        /// Initializes a new instance of the EventModel class.
        /// </summary>
        public EventModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the EventModel class.
        /// </summary>

        /// <param name="id">Resource Id
        /// </param>

        /// <param name="name">Resource Name
        /// </param>

        /// <param name="type">Resource Type
        /// </param>

        /// <param name="location">Resource Location
        /// </param>

        /// <param name="properties">Event related data.
        /// </param>
        public EventModel(string id = default(string), string name = default(string), string type = default(string), string location = default(string), EventProperties properties = default(EventProperties))

        : base(id, name, type, location)
        {
            this.Properties = properties;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets event related data.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties")]
        public EventProperties Properties {get; set; }
    }
}