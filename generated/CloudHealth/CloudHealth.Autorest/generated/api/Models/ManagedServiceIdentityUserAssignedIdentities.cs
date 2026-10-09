// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Extensions;

    /// <summary>The identities assigned to this resource by the user.</summary>
    public partial class ManagedServiceIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IManagedServiceIdentityUserAssignedIdentities,
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IManagedServiceIdentityUserAssignedIdentitiesInternal
    {

        /// <summary>
        /// Creates an new <see cref="ManagedServiceIdentityUserAssignedIdentities" /> instance.
        /// </summary>
        public ManagedServiceIdentityUserAssignedIdentities()
        {

        }
    }
    /// The identities assigned to this resource by the user.
    public partial interface IManagedServiceIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IUserAssignedIdentity>
    {

    }
    /// The identities assigned to this resource by the user.
    internal partial interface IManagedServiceIdentityUserAssignedIdentitiesInternal

    {

    }
}