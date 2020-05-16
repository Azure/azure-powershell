namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>AddressResponse resource specific properties</summary>
    public partial class AddressResponseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressResponseProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressResponsePropertiesInternal
    {

        /// <summary>Backing field for <see cref="InternalIPAddress" /> property.</summary>
        private string _internalIPAddress;

        /// <summary>
        /// Virtual Network internal IP address of the App Service Environment if it is in internal load-balancing mode.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string InternalIPAddress { get => this._internalIPAddress; set => this._internalIPAddress = value; }

        /// <summary>Backing field for <see cref="OutboundIPAddress" /> property.</summary>
        private string[] _outboundIPAddress;

        /// <summary>IP addresses appearing on outbound connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] OutboundIPAddress { get => this._outboundIPAddress; set => this._outboundIPAddress = value; }

        /// <summary>Backing field for <see cref="ServiceIPAddress" /> property.</summary>
        private string _serviceIPAddress;

        /// <summary>Main public virtual IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ServiceIPAddress { get => this._serviceIPAddress; set => this._serviceIPAddress = value; }

        /// <summary>Backing field for <see cref="VipMapping" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping[] _vipMapping;

        /// <summary>Additional virtual IPs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping[] VipMapping { get => this._vipMapping; set => this._vipMapping = value; }

        /// <summary>Creates an new <see cref="AddressResponseProperties" /> instance.</summary>
        public AddressResponseProperties()
        {

        }
    }
    /// AddressResponse resource specific properties
    public partial interface IAddressResponseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Virtual Network internal IP address of the App Service Environment if it is in internal load-balancing mode.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Virtual Network internal IP address of the App Service Environment if it is in internal load-balancing mode.",
        SerializedName = @"internalIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string InternalIPAddress { get; set; }
        /// <summary>IP addresses appearing on outbound connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IP addresses appearing on outbound connections.",
        SerializedName = @"outboundIpAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string[] OutboundIPAddress { get; set; }
        /// <summary>Main public virtual IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Main public virtual IP.",
        SerializedName = @"serviceIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceIPAddress { get; set; }
        /// <summary>Additional virtual IPs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Additional virtual IPs.",
        SerializedName = @"vipMappings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping[] VipMapping { get; set; }

    }
    /// AddressResponse resource specific properties
    internal partial interface IAddressResponsePropertiesInternal

    {
        /// <summary>
        /// Virtual Network internal IP address of the App Service Environment if it is in internal load-balancing mode.
        /// </summary>
        string InternalIPAddress { get; set; }
        /// <summary>IP addresses appearing on outbound connections.</summary>
        string[] OutboundIPAddress { get; set; }
        /// <summary>Main public virtual IP.</summary>
        string ServiceIPAddress { get; set; }
        /// <summary>Additional virtual IPs.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping[] VipMapping { get; set; }

    }
}