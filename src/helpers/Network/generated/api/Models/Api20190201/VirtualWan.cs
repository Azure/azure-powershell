namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>VirtualWAN Resource.</summary>
    public partial class VirtualWan :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWan,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.Resource();

        /// <summary>True if branch to branch traffic is allowed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 3, Label = @"Branch-Branch Traffic Allowed")]
        public bool? AllowBranchToBranchTraffic { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).AllowBranchToBranchTraffic; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).AllowBranchToBranchTraffic = value; }

        /// <summary>True if Vnet to Vnet traffic is allowed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 4, Label = @"Vnet-Vnet Traffic Allowed")]
        public bool? AllowVnetToVnetTraffic { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).AllowVnetToVnetTraffic; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).AllowVnetToVnetTraffic = value; }

        /// <summary>Vpn encryption to be disabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 5, Label = @"VPN Encryption Disabled")]
        public bool? DisableVpnEncryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).DisableVpnEncryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).DisableVpnEncryption = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Etag { get => this._etag; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 1)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for Etag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanInternal.Etag { get => this._etag; set { {_etag = value;} } }

        /// <summary>Internal Acessors for Office365LocalBreakoutCategory</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanInternal.Office365LocalBreakoutCategory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).Office365LocalBreakoutCategory; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).Office365LocalBreakoutCategory = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanProperties Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualWanProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for VirtualHub</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanInternal.VirtualHub { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).VirtualHub; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).VirtualHub = value; }

        /// <summary>Internal Acessors for VpnSite</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanInternal.VpnSite { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).VpnSite; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).VpnSite = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; }

        /// <summary>The office local breakout category.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory? Office365LocalBreakoutCategory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).Office365LocalBreakoutCategory; }

        /// <summary>List of all P2SVpnServerConfigurations associated with the virtual wan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration[] P2SVpnServerConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).P2SVpnServerConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).P2SVpnServerConfiguration = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanProperties _property;

        /// <summary>Properties of the virtual WAN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualWanProperties()); set => this._property = value; }

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 6, Label = @"Provisioning State")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>The Security Provider name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 2, Label = @"Security Provider Name")]
        public string SecurityProviderName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).SecurityProviderName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).SecurityProviderName = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; }

        /// <summary>List of VirtualHubs in the VirtualWAN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] VirtualHub { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).VirtualHub; }

        /// <summary>List of VpnSites in the VirtualWAN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] VpnSite { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)Property).VpnSite; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }

        /// <summary>Creates an new <see cref="VirtualWan" /> instance.</summary>
        public VirtualWan()
        {

        }
    }
    /// VirtualWAN Resource.
    public partial interface IVirtualWan :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource
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
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get;  }
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
    /// VirtualWAN Resource.
    internal partial interface IVirtualWanInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal
    {
        /// <summary>True if branch to branch traffic is allowed.</summary>
        bool? AllowBranchToBranchTraffic { get; set; }
        /// <summary>True if Vnet to Vnet traffic is allowed.</summary>
        bool? AllowVnetToVnetTraffic { get; set; }
        /// <summary>Vpn encryption to be disabled or not.</summary>
        bool? DisableVpnEncryption { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>The office local breakout category.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory? Office365LocalBreakoutCategory { get; set; }
        /// <summary>List of all P2SVpnServerConfigurations associated with the virtual wan.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration[] P2SVpnServerConfiguration { get; set; }
        /// <summary>Properties of the virtual WAN.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanProperties Property { get; set; }
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