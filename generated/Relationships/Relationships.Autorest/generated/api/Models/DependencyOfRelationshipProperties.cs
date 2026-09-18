// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Extensions;

    /// <summary>dependencyOf relationship properties.</summary>
    public partial class DependencyOfRelationshipProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IDependencyOfRelationshipProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IDependencyOfRelationshipPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Metadata" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadata _metadata;

        /// <summary>Metadata about the relationship.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadata Metadata { get => (this._metadata = this._metadata ?? new Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.RelationshipMetadata()); }

        /// <summary>The type of the relationship source resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inlined)]
        public string MetadataSourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadataInternal)Metadata).SourceType; }

        /// <summary>The type of the relationship target resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inlined)]
        public string MetadataTargetType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadataInternal)Metadata).TargetType; }

        /// <summary>Internal Acessors for Metadata</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadata Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IDependencyOfRelationshipPropertiesInternal.Metadata { get => (this._metadata = this._metadata ?? new Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.RelationshipMetadata()); set { {_metadata = value;} } }

        /// <summary>Internal Acessors for MetadataSourceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IDependencyOfRelationshipPropertiesInternal.MetadataSourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadataInternal)Metadata).SourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadataInternal)Metadata).SourceType = value ?? null; }

        /// <summary>Internal Acessors for MetadataTargetType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IDependencyOfRelationshipPropertiesInternal.MetadataTargetType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadataInternal)Metadata).TargetType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadataInternal)Metadata).TargetType = value ?? null; }

        /// <summary>Internal Acessors for OriginInformation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformation Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IDependencyOfRelationshipPropertiesInternal.OriginInformation { get => (this._originInformation = this._originInformation ?? new Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.RelationshipOriginInformation()); set { {_originInformation = value;} } }

        /// <summary>Internal Acessors for OriginInformationDiscoveryEngine</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IDependencyOfRelationshipPropertiesInternal.OriginInformationDiscoveryEngine { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformationInternal)OriginInformation).DiscoveryEngine; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformationInternal)OriginInformation).DiscoveryEngine = value ?? null; }

        /// <summary>Internal Acessors for OriginInformationRelationshipOriginType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IDependencyOfRelationshipPropertiesInternal.OriginInformationRelationshipOriginType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformationInternal)OriginInformation).RelationshipOriginType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformationInternal)OriginInformation).RelationshipOriginType = value ?? null; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IDependencyOfRelationshipPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for SourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IDependencyOfRelationshipPropertiesInternal.SourceId { get => this._sourceId; set { {_sourceId = value;} } }

        /// <summary>Backing field for <see cref="OriginInformation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformation _originInformation;

        /// <summary>Information about the origin of the relationship.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformation OriginInformation { get => (this._originInformation = this._originInformation ?? new Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.RelationshipOriginInformation()); }

        /// <summary>The name of the discovery engine that created the relationship.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inlined)]
        public string OriginInformationDiscoveryEngine { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformationInternal)OriginInformation).DiscoveryEngine; }

        /// <summary>Identifies the origin type of the relationship.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inlined)]
        public string OriginInformationRelationshipOriginType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformationInternal)OriginInformation).RelationshipOriginType; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The provisioning state of the relationship.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="SourceId" /> property.</summary>
        private string _sourceId;

        /// <summary>The relationship source resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        public string SourceId { get => this._sourceId; }

        /// <summary>Backing field for <see cref="TargetId" /> property.</summary>
        private string _targetId;

        /// <summary>The relationship target resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        public string TargetId { get => this._targetId; set => this._targetId = value; }

        /// <summary>Backing field for <see cref="TargetTenant" /> property.</summary>
        private string _targetTenant;

        /// <summary>The relationship target tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        public string TargetTenant { get => this._targetTenant; set => this._targetTenant = value; }

        /// <summary>Creates an new <see cref="DependencyOfRelationshipProperties" /> instance.</summary>
        public DependencyOfRelationshipProperties()
        {

        }
    }
    /// dependencyOf relationship properties.
    public partial interface IDependencyOfRelationshipProperties :
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
        string MetadataSourceType { get;  }
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
        string MetadataTargetType { get;  }
        /// <summary>The name of the discovery engine that created the relationship.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The name of the discovery engine that created the relationship.",
        SerializedName = @"discoveryEngine",
        PossibleTypes = new [] { typeof(string) })]
        string OriginInformationDiscoveryEngine { get;  }
        /// <summary>Identifies the origin type of the relationship.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Identifies the origin type of the relationship.",
        SerializedName = @"relationshipOriginType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Relationships.PSArgumentCompleterAttribute("ServiceExplicitlyCreated", "SystemDiscoveredByRule", "UserExplicitlyCreated", "UserDiscoveredByRule")]
        string OriginInformationRelationshipOriginType { get;  }
        /// <summary>The provisioning state of the relationship.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The provisioning state of the relationship.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Relationships.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Provisioning", "Updating", "Deleting", "Accepted")]
        string ProvisioningState { get;  }
        /// <summary>The relationship source resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The relationship source resource id.",
        SerializedName = @"sourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceId { get;  }
        /// <summary>The relationship target resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The relationship target resource id.",
        SerializedName = @"targetId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetId { get; set; }
        /// <summary>The relationship target tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The relationship target tenant id.",
        SerializedName = @"targetTenant",
        PossibleTypes = new [] { typeof(string) })]
        string TargetTenant { get; set; }

    }
    /// dependencyOf relationship properties.
    internal partial interface IDependencyOfRelationshipPropertiesInternal

    {
        /// <summary>Metadata about the relationship.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadata Metadata { get; set; }
        /// <summary>The type of the relationship source resource.</summary>
        string MetadataSourceType { get; set; }
        /// <summary>The type of the relationship target resource.</summary>
        string MetadataTargetType { get; set; }
        /// <summary>Information about the origin of the relationship.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformation OriginInformation { get; set; }
        /// <summary>The name of the discovery engine that created the relationship.</summary>
        string OriginInformationDiscoveryEngine { get; set; }
        /// <summary>Identifies the origin type of the relationship.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Relationships.PSArgumentCompleterAttribute("ServiceExplicitlyCreated", "SystemDiscoveredByRule", "UserExplicitlyCreated", "UserDiscoveredByRule")]
        string OriginInformationRelationshipOriginType { get; set; }
        /// <summary>The provisioning state of the relationship.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Relationships.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Provisioning", "Updating", "Deleting", "Accepted")]
        string ProvisioningState { get; set; }
        /// <summary>The relationship source resource id.</summary>
        string SourceId { get; set; }
        /// <summary>The relationship target resource id.</summary>
        string TargetId { get; set; }
        /// <summary>The relationship target tenant id.</summary>
        string TargetTenant { get; set; }

    }
}