// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Management.NetApp.Models
{
    using System.Linq;

    /// <summary>
    /// Backup Vault information
    /// </summary>    
    public partial class BackupVault : TrackedResource 
    {
        /// <param name="id">Fully qualified resource ID for the resource. E.g.
        /// &#34;/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}&#34;
        /// </param>

        /// <param name="name">The name of the resource
        /// </param>

        /// <param name="type">The type of the resource. E.g. &#34;Microsoft.Compute/virtualMachines&#34; or
        /// &#34;Microsoft.Storage/storageAccounts&#34;
        /// </param>

        /// <param name="systemData">Azure Resource Manager metadata containing createdBy and modifiedBy
        /// information.
        /// </param>

        /// <param name="tags">Resource tags.
        /// </param>

        /// <param name="location">The geo-location where the resource lives
        /// </param>
        
        public BackupVault(string location, string id = default(string), string name = default(string), string type = default(string), SystemData systemData = default(SystemData), System.Collections.Generic.IDictionary<string, string> tags = default(System.Collections.Generic.IDictionary<string, string>), string provisioningState = default(string))

        : base(location, id, name, type, systemData, tags)
        {
            this.ProvisioningState = provisioningState;
            CustomInit();
        }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();

        }
    }
}
