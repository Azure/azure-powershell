// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Extensions;

    /// <summary>Provides information about the relationship properties.</summary>
    public partial class RelationshipMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadata,
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadataInternal
    {

        /// <summary>Internal Acessors for SourceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadataInternal.SourceType { get => this._sourceType; set { {_sourceType = value;} } }

        /// <summary>Internal Acessors for TargetType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadataInternal.TargetType { get => this._targetType; set { {_targetType = value;} } }

        /// <summary>Backing field for <see cref="SourceType" /> property.</summary>
        private string _sourceType;

        /// <summary>The type of the relationship source resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        public string SourceType { get => this._sourceType; }

        /// <summary>Backing field for <see cref="TargetType" /> property.</summary>
        private string _targetType;

        /// <summary>The type of the relationship target resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        public string TargetType { get => this._targetType; }

        /// <summary>Creates an new <see cref="RelationshipMetadata" /> instance.</summary>
        public RelationshipMetadata()
        {

        }
    }
    /// Provides information about the relationship properties.
    public partial interface IRelationshipMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.IJsonSerializable
    {
        /// <summary>The type of the relationship source resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The type of the relationship source resource.",
        SerializedName = @"sourceType",
        PossibleTypes = new [] { typeof(string) })]
        string SourceType { get;  }
        /// <summary>The type of the relationship target resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The type of the relationship target resource.",
        SerializedName = @"targetType",
        PossibleTypes = new [] { typeof(string) })]
        string TargetType { get;  }

    }
    /// Provides information about the relationship properties.
    internal partial interface IRelationshipMetadataInternal

    {
        /// <summary>The type of the relationship source resource.</summary>
        string SourceType { get; set; }
        /// <summary>The type of the relationship target resource.</summary>
        string TargetType { get; set; }

    }
}