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

namespace Microsoft.Azure.Commands.Aks.Models
{
    /// <summary>
    /// Identity for the managed cluster.
    /// </summary>
    public class PSManagedClusterPropertiesIdentityProfile
    {
        //
        // Summary:
        //     Initializes a new instance of the UserAssignedIdentity class.
        //
        // Parameters:
        //   resourceId:
        //     The resource id of the user assigned identity.
        //
        //   clientId:
        //     The client id of the user assigned identity.
        //
        //   objectId:
        //     The object id of the user assigned identity.
        public PSManagedClusterPropertiesIdentityProfile(string resourceId = null, string clientId = null, string objectId = null)
        {
            ResourceId = resourceId;
            ClientId = clientId;
            ObjectId = objectId;
        }

        //
        // Summary:
        //     Gets or sets the resource id of the user assigned identity.
        public string ResourceId { get; set; }
        //
        // Summary:
        //     Gets or sets the client id of the user assigned identity.
        public string ClientId { get; set; }
        //
        // Summary:
        //     Gets or sets the object id of the user assigned identity.
        public string ObjectId { get; set; }
    }
}
