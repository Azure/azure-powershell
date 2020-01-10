namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters that define the representation of topology.</summary>
    public partial class TopologyParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITopologyParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITopologyParametersInternal
    {

        /// <summary>Internal Acessors for TargetSubnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITopologyParametersInternal.TargetSubnet { get => (this._targetSubnet = this._targetSubnet ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_targetSubnet = value;} } }

        /// <summary>Internal Acessors for TargetVnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITopologyParametersInternal.TargetVnet { get => (this._targetVnet = this._targetVnet ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_targetVnet = value;} } }

        /// <summary>Backing field for <see cref="TargetResourceGroupName" /> property.</summary>
        private string _targetResourceGroupName;

        /// <summary>The name of the target resource group to perform topology on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TargetResourceGroupName { get => this._targetResourceGroupName; set => this._targetResourceGroupName = value; }

        /// <summary>Backing field for <see cref="TargetSubnet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _targetSubnet;

        /// <summary>The reference of the Subnet resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource TargetSubnet { get => (this._targetSubnet = this._targetSubnet ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._targetSubnet = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string TargetSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)TargetSubnet).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)TargetSubnet).Id = value; }

        /// <summary>Backing field for <see cref="TargetVnet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _targetVnet;

        /// <summary>The reference of the Virtual Network resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource TargetVnet { get => (this._targetVnet = this._targetVnet ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._targetVnet = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string TargetVnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)TargetVnet).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)TargetVnet).Id = value; }

        /// <summary>Creates an new <see cref="TopologyParameters" /> instance.</summary>
        public TopologyParameters()
        {

        }
    }
    /// Parameters that define the representation of topology.
    public partial interface ITopologyParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The name of the target resource group to perform topology on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the target resource group to perform topology on.",
        SerializedName = @"targetResourceGroupName",
        PossibleTypes = new [] { typeof(string) })]
        string TargetResourceGroupName { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string TargetSubnetId { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string TargetVnetId { get; set; }

    }
    /// Parameters that define the representation of topology.
    internal partial interface ITopologyParametersInternal

    {
        /// <summary>The name of the target resource group to perform topology on.</summary>
        string TargetResourceGroupName { get; set; }
        /// <summary>The reference of the Subnet resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource TargetSubnet { get; set; }
        /// <summary>Resource ID.</summary>
        string TargetSubnetId { get; set; }
        /// <summary>The reference of the Virtual Network resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource TargetVnet { get; set; }
        /// <summary>Resource ID.</summary>
        string TargetVnetId { get; set; }

    }
}