// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Extensions;

    /// <summary>contains relationship properties.</summary>
    public partial class ContainsRelationshipProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IContainsRelationshipProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IContainsRelationshipPropertiesInternal
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
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadata Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IContainsRelationshipPropertiesInternal.Metadata { get => (this._metadata = this._metadata ?? new Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.RelationshipMetadata()); set { {_metadata = value;} } }

        /// <summary>Internal Acessors for MetadataSourceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IContainsRelationshipPropertiesInternal.MetadataSourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadataInternal)Metadata).SourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadataInternal)Metadata).SourceType = value ?? null; }

        /// <summary>Internal Acessors for MetadataTargetType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IContainsRelationshipPropertiesInternal.MetadataTargetType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadataInternal)Metadata).TargetType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadataInternal)Metadata).TargetType = value ?? null; }

        /// <summary>Internal Acessors for OriginInformation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformation Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IContainsRelationshipPropertiesInternal.OriginInformation { get => (this._originInformation = this._originInformation ?? new Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.RelationshipOriginInformation()); set { {_originInformation = value;} } }

        /// <summary>Internal Acessors for OriginInformationDiscoveryEngine</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IContainsRelationshipPropertiesInternal.OriginInformationDiscoveryEngine { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformationInternal)OriginInformation).DiscoveryEngine; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformationInternal)OriginInformation).DiscoveryEngine = value ?? null; }

        /// <summary>Internal Acessors for OriginInformationRelationshipOriginType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IContainsRelationshipPropertiesInternal.OriginInformationRelationshipOriginType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformationInternal)OriginInformation).RelationshipOriginType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformationInternal)OriginInformation).RelationshipOriginType = value ?? null; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IContainsRelationshipPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for SourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IContainsRelationshipPropertiesInternal.SourceId { get => this._sourceId; set { {_sourceId = value;} } }

        /// <summary>Internal Acessors for TargetId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IContainsRelationshipPropertiesInternal.TargetId { get => this._targetId; set { {_targetId = value;} } }

        /// <summary>Internal Acessors for TargetTenant</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IContainsRelationshipPropertiesInternal.TargetTenant { get => this._targetTenant; set { {_targetTenant = value;} } }

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

        /// <summary>The relationship source resource id. Must be a subscription or resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        public string SourceId { get => this._sourceId; }

        /// <summary>Backing field for <see cref="TargetId" /> property.</summary>
        private string _targetId;

        /// <summary>The relationship target resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        public string TargetId { get => this._targetId; }

        /// <summary>Backing field for <see cref="TargetTenant" /> property.</summary>
        private string _targetTenant;

        /// <summary>The relationship target tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        public string TargetTenant { get => this._targetTenant; }

        /// <summary>Creates an new <see cref="ContainsRelationshipProperties" /> instance.</summary>
        public ContainsRelationshipProperties()
        {

        }
    }
    /// contains relationship properties.
    public partial interface IContainsRelationshipProperties :
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
        /// <summary>The relationship source resource id. Must be a subscription or resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The relationship source resource id. Must be a subscription or resource group.",
        SerializedName = @"sourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceId { get;  }
        /// <summary>The relationship target resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The relationship target resource id.",
        SerializedName = @"targetId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetId { get;  }
        /// <summary>The relationship target tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The relationship target tenant id.",
        SerializedName = @"targetTenant",
        PossibleTypes = new [] { typeof(string) })]
        string TargetTenant { get;  }

    }
    /// contains relationship properties.
    internal partial interface IContainsRelationshipPropertiesInternal

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
        /// <summary>The relationship source resource id. Must be a subscription or resource group.</summary>
        string SourceId { get; set; }
        /// <summary>The relationship target resource id.</summary>
        string TargetId { get; set; }
        /// <summary>The relationship target tenant id.</summary>
        string TargetTenant { get; set; }

    }
}