// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Map of user assigned managed identities.</summary>
    public partial class UserAssignedIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityUserAssignedIdentities,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityUserAssignedIdentitiesInternal
    {

        /// <summary>
        /// Creates an new <see cref="UserAssignedIdentityUserAssignedIdentities" /> instance.
        /// </summary>
        public UserAssignedIdentityUserAssignedIdentities()
        {

        }
    }
    /// Map of user assigned managed identities.
    public partial interface IUserAssignedIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserIdentity>
    {

    }
    /// Map of user assigned managed identities.
    internal partial interface IUserAssignedIdentityUserAssignedIdentitiesInternal

    {

    }
}