// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.RecoveryServices.Models
{
    using System.Linq;

    /// <summary>
    /// A resource identity that is managed by the user of the service.
    /// </summary>
    public partial class UserIdentity
    {
        /// <summary>
        /// Initializes a new instance of the UserIdentity class.
        /// </summary>
        public UserIdentity()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the UserIdentity class.
        /// </summary>

        /// <param name="principalId">The principal ID of the user-assigned identity.
        /// </param>

        /// <param name="clientId">The client ID of the user-assigned identity.
        /// </param>
        public UserIdentity(string principalId = default(string), string clientId = default(string))

        {
            this.PrincipalId = principalId;
            this.ClientId = clientId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets the principal ID of the user-assigned identity.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "principalId")]
        public string PrincipalId {get; private set; }

        /// <summary>
        /// Gets the client ID of the user-assigned identity.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "clientId")]
        public string ClientId {get; private set; }
    }
}