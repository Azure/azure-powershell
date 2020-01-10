namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters for VirtualWAN</summary>
    public partial class VirtualWanProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AllowBranchToBranchTraffic" /> property.</summary>
        private bool? _allowBranchToBranchTraffic;

        /// <summary>True if branch to branch traffic is allowed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? AllowBranchToBranchTraffic { get => this._allowBranchToBranchTraffic; set => this._allowBranchToBranchTraffic = value; }

        /// <summary>Backing field for <see cref="AllowVnetToVnetTraffic" /> property.</summary>
        private bool? _allowVnetToVnetTraffic;

        /// <summary>True if Vnet to Vnet traffic is allowed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? AllowVnetToVnetTraffic { get => this._allowVnetToVnetTraffic; set => this._allowVnetToVnetTraffic = value; }

        /// <summary>Backing field for <see cref="DisableVpnEncryption" /> property.</summary>
        private bool? _disableVpnEncryption;

        /// <summary>Vpn encryption to be disabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? DisableVpnEncryption { get => this._disableVpnEncryption; set => this._disableVpnEncryption = value; }

        /// <summary>Internal Acessors for Office365LocalBreakoutCategory</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal.Office365LocalBreakoutCategory { get => this._office365LocalBreakoutCategory; set { {_office365LocalBreakoutCategory = value;} } }

        /// <summary>Internal Acessors for VirtualHub</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal.VirtualHub { get => this._virtualHub; set { {_virtualHub = value;} } }

        /// <summary>Internal Acessors for VpnSite</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal.VpnSite { get => this._vpnSite; set { {_vpnSite = value;} } }

        /// <summary>Backing field for <see cref="Office365LocalBreakoutCategory" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory? _office365LocalBreakoutCategory;

        /// <summary>The office local breakout category.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory? Office365LocalBreakoutCategory { get => this._office365LocalBreakoutCategory; }

        /// <summary>Backing field for <see cref="P2SVpnServerConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration[] _p2SVpnServerConfiguration;

        /// <summary>List of all P2SVpnServerConfigurations associated with the virtual wan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration[] P2SVpnServerConfiguration { get => this._p2SVpnServerConfiguration; set => this._p2SVpnServerConfiguration = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="SecurityProviderName" /> property.</summary>
        private string _securityProviderName;

        /// <summary>The Security Provider name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SecurityProviderName { get => this._securityProviderName; set => this._securityProviderName = value; }

        /// <summary>Backing field for <see cref="VirtualHub" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] _virtualHub;

        /// <summary>List of VirtualHubs in the VirtualWAN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] VirtualHub { get => this._virtualHub; }

        /// <summary>Backing field for <see cref="VpnSite" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] _vpnSite;

        /// <summary>List of VpnSites in the VirtualWAN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] VpnSite { get => this._vpnSite; }

        /// <summary>Creates an new <see cref="VirtualWanProperties" /> instance.</summary>
        public VirtualWanProperties()
        {

        }
    }
    /// Parameters for VirtualWAN
    public partial interface IVirtualWanProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>True if branch to branch traffic is allowed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"True if branch to branch traffic is allowed.",
        SerializedName = @"allowBranchToBranchTraffic",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowBranchToBranchTraffic { get; set; }
        /// <summary>True if Vnet to Vnet traffic is allowed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"True if Vnet to Vnet traffic is allowed.",
        SerializedName = @"allowVnetToVnetTraffic",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowVnetToVnetTraffic { get; set; }
        /// <summary>Vpn encryption to be disabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Vpn encryption to be disabled or not.",
        SerializedName = @"disableVpnEncryption",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DisableVpnEncryption { get; set; }
        /// <summary>The office local breakout category.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The office local breakout category.",
        SerializedName = @"office365LocalBreakoutCategory",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory? Office365LocalBreakoutCategory { get;  }
        /// <summary>List of all P2SVpnServerConfigurations associated with the virtual wan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of all P2SVpnServerConfigurations associated with the virtual wan.",
        SerializedName = @"p2SVpnServerConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration[] P2SVpnServerConfiguration { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The Security Provider name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Security Provider name.",
        SerializedName = @"securityProviderName",
        PossibleTypes = new [] { typeof(string) })]
        string SecurityProviderName { get; set; }
        /// <summary>List of VirtualHubs in the VirtualWAN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of VirtualHubs in the VirtualWAN.",
        SerializedName = @"virtualHubs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] VirtualHub { get;  }
        /// <summary>List of VpnSites in the VirtualWAN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of VpnSites in the VirtualWAN.",
        SerializedName = @"vpnSites",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] VpnSite { get;  }

    }
    /// Parameters for VirtualWAN
    internal partial interface IVirtualWanPropertiesInternal

    {
        /// <summary>True if branch to branch traffic is allowed.</summary>
        bool? AllowBranchToBranchTraffic { get; set; }
        /// <summary>True if Vnet to Vnet traffic is allowed.</summary>
        bool? AllowVnetToVnetTraffic { get; set; }
        /// <summary>Vpn encryption to be disabled or not.</summary>
        bool? DisableVpnEncryption { get; set; }
        /// <summary>The office local breakout category.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory? Office365LocalBreakoutCategory { get; set; }
        /// <summary>List of all P2SVpnServerConfigurations associated with the virtual wan.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration[] P2SVpnServerConfiguration { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The Security Provider name.</summary>
        string SecurityProviderName { get; set; }
        /// <summary>List of VirtualHubs in the VirtualWAN.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] VirtualHub { get; set; }
        /// <summary>List of VpnSites in the VirtualWAN.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] VpnSite { get; set; }

    }
}