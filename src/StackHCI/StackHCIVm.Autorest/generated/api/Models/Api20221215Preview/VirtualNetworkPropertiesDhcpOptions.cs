namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>
    /// DhcpOptions contains an array of DNS servers available to VMs deployed in the virtual network. Standard DHCP option for
    /// a subnet overrides VNET DHCP options.
    /// </summary>
    public partial class VirtualNetworkPropertiesDhcpOptions :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesDhcpOptions,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesDhcpOptionsInternal
    {

        /// <summary>Backing field for <see cref="DnsServer" /> property.</summary>
        private string[] _dnsServer;

        /// <summary>The list of DNS servers IP addresses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string[] DnsServer { get => this._dnsServer; set => this._dnsServer = value; }

        /// <summary>Creates an new <see cref="VirtualNetworkPropertiesDhcpOptions" /> instance.</summary>
        public VirtualNetworkPropertiesDhcpOptions()
        {

        }
    }
    /// DhcpOptions contains an array of DNS servers available to VMs deployed in the virtual network. Standard DHCP option for
    /// a subnet overrides VNET DHCP options.
    public partial interface IVirtualNetworkPropertiesDhcpOptions :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>The list of DNS servers IP addresses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of DNS servers IP addresses.",
        SerializedName = @"dnsServers",
        PossibleTypes = new [] { typeof(string) })]
        string[] DnsServer { get; set; }

    }
    /// DhcpOptions contains an array of DNS servers available to VMs deployed in the virtual network. Standard DHCP option for
    /// a subnet overrides VNET DHCP options.
    internal partial interface IVirtualNetworkPropertiesDhcpOptionsInternal

    {
        /// <summary>The list of DNS servers IP addresses.</summary>
        string[] DnsServer { get; set; }

    }
}