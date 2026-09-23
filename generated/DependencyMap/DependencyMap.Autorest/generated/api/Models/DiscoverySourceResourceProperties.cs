// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Extensions;

    /// <summary>The properties of Discovery Source resource</summary>
    public partial class DiscoverySourceResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourcePropertiesInternal
    {

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourcePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for SourceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourcePropertiesInternal.SourceType { get => this._sourceType; set { {_sourceType = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>Provisioning state of Discovery Source resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="SourceId" /> property.</summary>
        private string _sourceId;

        /// <summary>Source ArmId of Discovery Source resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Owned)]
        public string SourceId { get => this._sourceId; set => this._sourceId = value; }

        /// <summary>Backing field for <see cref="SourceType" /> property.</summary>
        private string _sourceType= @"OffAzure";

        /// <summary>Source type of Discovery Source resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Owned)]
        public string SourceType { get => this._sourceType; }

        /// <summary>Creates an new <see cref="DiscoverySourceResourceProperties" /> instance.</summary>
        public DiscoverySourceResourceProperties()
        {

        }
    }
    /// The properties of Discovery Source resource
    public partial interface IDiscoverySourceResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.IJsonSerializable
    {
        /// <summary>Provisioning state of Discovery Source resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Provisioning state of Discovery Source resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Provisioning", "Updating", "Deleting", "Accepted")]
        string ProvisioningState { get;  }
        /// <summary>Source ArmId of Discovery Source resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Source ArmId of Discovery Source resource",
        SerializedName = @"sourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceId { get; set; }
        /// <summary>Source type of Discovery Source resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Source type of Discovery Source resource.",
        SerializedName = @"sourceType",
        PossibleTypes = new [] { typeof(string) })]
        string SourceType { get;  }

    }
    /// The properties of Discovery Source resource
    internal partial interface IDiscoverySourceResourcePropertiesInternal

    {
        /// <summary>Provisioning state of Discovery Source resource.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Provisioning", "Updating", "Deleting", "Accepted")]
        string ProvisioningState { get; set; }
        /// <summary>Source ArmId of Discovery Source resource</summary>
        string SourceId { get; set; }
        /// <summary>Source type of Discovery Source resource.</summary>
        string SourceType { get; set; }

    }
}