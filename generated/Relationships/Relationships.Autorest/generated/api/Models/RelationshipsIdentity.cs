// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Extensions;

    public partial class RelationshipsIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipsIdentity,
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipsIdentityInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource identity path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of dependencyOf relationship.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="ResourceUri" /> property.</summary>
        private string _resourceUri;

        /// <summary>The fully qualified Azure Resource manager identifier of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        public string ResourceUri { get => this._resourceUri; set => this._resourceUri = value; }

        /// <summary>Creates an new <see cref="RelationshipsIdentity" /> instance.</summary>
        public RelationshipsIdentity()
        {

        }
    }
    public partial interface IRelationshipsIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.IJsonSerializable
    {
        /// <summary>Resource identity path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Resource identity path",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>Name of dependencyOf relationship.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of dependencyOf relationship.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The fully qualified Azure Resource manager identifier of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The fully qualified Azure Resource manager identifier of the resource.",
        SerializedName = @"resourceUri",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceUri { get; set; }

    }
    internal partial interface IRelationshipsIdentityInternal

    {
        /// <summary>Resource identity path</summary>
        string Id { get; set; }
        /// <summary>Name of dependencyOf relationship.</summary>
        string Name { get; set; }
        /// <summary>The fully qualified Azure Resource manager identifier of the resource.</summary>
        string ResourceUri { get; set; }

    }
}