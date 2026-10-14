// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Cluster properties of a server.</summary>
    public partial class Cluster :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICluster,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IClusterInternal
    {

        /// <summary>Backing field for <see cref="DefaultDatabaseName" /> property.</summary>
        private string _defaultDatabaseName;

        /// <summary>Default database name for the elastic cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string DefaultDatabaseName { get => this._defaultDatabaseName; set => this._defaultDatabaseName = value; }

        /// <summary>Backing field for <see cref="Size" /> property.</summary>
        private int? _size;

        /// <summary>Number of nodes assigned to the elastic cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? Size { get => this._size; set => this._size = value; }

        /// <summary>Creates an new <see cref="Cluster" /> instance.</summary>
        public Cluster()
        {

        }
    }
    /// Cluster properties of a server.
    public partial interface ICluster :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Default database name for the elastic cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Default database name for the elastic cluster.",
        SerializedName = @"defaultDatabaseName",
        PossibleTypes = new [] { typeof(string) })]
        string DefaultDatabaseName { get; set; }
        /// <summary>Number of nodes assigned to the elastic cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Number of nodes assigned to the elastic cluster.",
        SerializedName = @"clusterSize",
        PossibleTypes = new [] { typeof(int) })]
        int? Size { get; set; }

    }
    /// Cluster properties of a server.
    internal partial interface IClusterInternal

    {
        /// <summary>Default database name for the elastic cluster.</summary>
        string DefaultDatabaseName { get; set; }
        /// <summary>Number of nodes assigned to the elastic cluster.</summary>
        int? Size { get; set; }

    }
}