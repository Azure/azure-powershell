// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Extensions;

    /// <summary>Provides information about the origin of a relationship.</summary>
    public partial class RelationshipOriginInformation :
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformation,
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformationInternal
    {

        /// <summary>Backing field for <see cref="DiscoveryEngine" /> property.</summary>
        private string _discoveryEngine;

        /// <summary>The name of the discovery engine that created the relationship.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        public string DiscoveryEngine { get => this._discoveryEngine; }

        /// <summary>Internal Acessors for DiscoveryEngine</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformationInternal.DiscoveryEngine { get => this._discoveryEngine; set { {_discoveryEngine = value;} } }

        /// <summary>Internal Acessors for RelationshipOriginType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformationInternal.RelationshipOriginType { get => this._relationshipOriginType; set { {_relationshipOriginType = value;} } }

        /// <summary>Backing field for <see cref="RelationshipOriginType" /> property.</summary>
        private string _relationshipOriginType;

        /// <summary>Identifies the origin type of the relationship.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        public string RelationshipOriginType { get => this._relationshipOriginType; }

        /// <summary>Creates an new <see cref="RelationshipOriginInformation" /> instance.</summary>
        public RelationshipOriginInformation()
        {

        }
    }
    /// Provides information about the origin of a relationship.
    public partial interface IRelationshipOriginInformation :
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.IJsonSerializable
    {
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
        string DiscoveryEngine { get;  }
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
        string RelationshipOriginType { get;  }

    }
    /// Provides information about the origin of a relationship.
    internal partial interface IRelationshipOriginInformationInternal

    {
        /// <summary>The name of the discovery engine that created the relationship.</summary>
        string DiscoveryEngine { get; set; }
        /// <summary>Identifies the origin type of the relationship.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Relationships.PSArgumentCompleterAttribute("ServiceExplicitlyCreated", "SystemDiscoveredByRule", "UserExplicitlyCreated", "UserDiscoveredByRule")]
        string RelationshipOriginType { get; set; }

    }
}