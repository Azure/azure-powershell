// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerRoleType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Kailani.Hfs.V1.Data.Contracts.ResourceEntity
{
    public enum ServerRoleType
    {
        // Stadalone server, not participating in a cluster
        Standalone = 0,
        // A node in a cluster
        ClusterNode,
        // The CNO of a cluster
        ClusterName
    }
}
