// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.SignalR.Models
{
    using System.Linq;

    /// <summary>
    /// Private link resource
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class PrivateLinkResource : ProxyResource
    {
        /// <summary>
        /// Initializes a new instance of the PrivateLinkResource class.
        /// </summary>
        public PrivateLinkResource()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PrivateLinkResource class.
        /// </summary>

        /// <param name="id">Fully qualified resource Id for the resource.
        /// </param>

        /// <param name="name">The name of the resource.
        /// </param>

        /// <param name="type">The type of the resource - e.g. &#34;Microsoft.SignalRService/SignalR&#34;
        /// </param>

        /// <param name="groupId">Group Id of the private link resource
        /// </param>

        /// <param name="requiredMembers">Required members of the private link resource
        /// </param>

        /// <param name="requiredZoneNames">Required private DNS zone names
        /// </param>

        /// <param name="shareablePrivateLinkResourceTypes">The list of resources that are onboarded to private link service
        /// </param>
        public PrivateLinkResource(string id = default(string), string name = default(string), string type = default(string), string groupId = default(string), System.Collections.Generic.IList<string> requiredMembers = default(System.Collections.Generic.IList<string>), System.Collections.Generic.IList<string> requiredZoneNames = default(System.Collections.Generic.IList<string>), System.Collections.Generic.IList<ShareablePrivateLinkResourceType> shareablePrivateLinkResourceTypes = default(System.Collections.Generic.IList<ShareablePrivateLinkResourceType>))

        : base(id, name, type)
        {
            this.GroupId = groupId;
            this.RequiredMembers = requiredMembers;
            this.RequiredZoneNames = requiredZoneNames;
            this.ShareablePrivateLinkResourceTypes = shareablePrivateLinkResourceTypes;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets group Id of the private link resource
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.groupId")]
        public string GroupId {get; set; }

        /// <summary>
        /// Gets or sets required members of the private link resource
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.requiredMembers")]
        public System.Collections.Generic.IList<string> RequiredMembers {get; set; }

        /// <summary>
        /// Gets or sets required private DNS zone names
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.requiredZoneNames")]
        public System.Collections.Generic.IList<string> RequiredZoneNames {get; set; }

        /// <summary>
        /// Gets or sets the list of resources that are onboarded to private link
        /// service
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.shareablePrivateLinkResourceTypes")]
        public System.Collections.Generic.IList<ShareablePrivateLinkResourceType> ShareablePrivateLinkResourceTypes {get; set; }
    }
}