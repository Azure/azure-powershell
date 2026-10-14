// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>
    /// User assigned identity IDs to be used by workloads as federated credentials running on supercomputer. The key value must
    /// be the resource ID of the identity resource.
    /// </summary>
    public partial class SupercomputerIdentitiesWorkloadIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentitiesInternal
    {

        /// <summary>
        /// Creates an new <see cref="SupercomputerIdentitiesWorkloadIdentities" /> instance.
        /// </summary>
        public SupercomputerIdentitiesWorkloadIdentities()
        {

        }
    }
    /// User assigned identity IDs to be used by workloads as federated credentials running on supercomputer. The key value must
    /// be the resource ID of the identity resource.
    public partial interface ISupercomputerIdentitiesWorkloadIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IUserAssignedIdentity>
    {

    }
    /// User assigned identity IDs to be used by workloads as federated credentials running on supercomputer. The key value must
    /// be the resource ID of the identity resource.
    internal partial interface ISupercomputerIdentitiesWorkloadIdentitiesInternal

    {

    }
}