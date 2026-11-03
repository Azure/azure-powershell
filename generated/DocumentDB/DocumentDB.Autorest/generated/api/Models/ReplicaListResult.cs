// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>The response of a Replica list operation.</summary>
    public partial class ReplicaListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaListResult,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link to the next page of items</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplica> _value;

        /// <summary>The Replica items on this page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplica> Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ReplicaListResult" /> instance.</summary>
        public ReplicaListResult()
        {

        }
    }
    /// The response of a Replica list operation.
    public partial interface IReplicaListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>The link to the next page of items</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The link to the next page of items",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The Replica items on this page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Replica items on this page",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplica) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplica> Value { get; set; }

    }
    /// The response of a Replica list operation.
    internal partial interface IReplicaListResultInternal

    {
        /// <summary>The link to the next page of items</summary>
        string NextLink { get; set; }
        /// <summary>The Replica items on this page</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplica> Value { get; set; }

    }
}