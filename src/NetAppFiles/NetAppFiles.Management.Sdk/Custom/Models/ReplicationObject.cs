// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.NetApp.Models
{
    using System.Linq;

    /// <summary>
    /// Replication properties
    /// </summary>
    public partial class ReplicationObject
    {

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>

        public virtual void Validate()
        {
            if (this.RemoteVolumeResourceId == null && this.RemotePath == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "RemoteVolumeResourceId");
            }


            if (this.RemotePath != null)
            {
                this.RemotePath.Validate();
            }

        }
    }
}