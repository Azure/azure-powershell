// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>
    /// User assigned identity IDs to be used by knowledgebase workloads. The key value must be the resource ID of the identity
    /// resource.
    /// </summary>
    public partial class BookshelfPropertiesWorkloadIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesWorkloadIdentities,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesWorkloadIdentitiesInternal
    {

        /// <summary>Creates an new <see cref="BookshelfPropertiesWorkloadIdentities" /> instance.</summary>
        public BookshelfPropertiesWorkloadIdentities()
        {

        }
    }
    /// User assigned identity IDs to be used by knowledgebase workloads. The key value must be the resource ID of the identity
    /// resource.
    public partial interface IBookshelfPropertiesWorkloadIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IUserAssignedIdentity>
    {

    }
    /// User assigned identity IDs to be used by knowledgebase workloads. The key value must be the resource ID of the identity
    /// resource.
    internal partial interface IBookshelfPropertiesWorkloadIdentitiesInternal

    {

    }
}