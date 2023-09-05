namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    public partial class InterfaceDnsSettings :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IInterfaceDnsSettings,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IInterfaceDnsSettingsInternal
    {

        /// <summary>Backing field for <see cref="DnsServer" /> property.</summary>
        private string[] _dnsServer;

        /// <summary>List of DNS server IP Addresses for the interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string[] DnsServer { get => this._dnsServer; set => this._dnsServer = value; }

        /// <summary>Creates an new <see cref="InterfaceDnsSettings" /> instance.</summary>
        public InterfaceDnsSettings()
        {

        }
    }
    public partial interface IInterfaceDnsSettings :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>List of DNS server IP Addresses for the interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of DNS server IP Addresses for the interface",
        SerializedName = @"dnsServers",
        PossibleTypes = new [] { typeof(string) })]
        string[] DnsServer { get; set; }

    }
    internal partial interface IInterfaceDnsSettingsInternal

    {
        /// <summary>List of DNS server IP Addresses for the interface</summary>
        string[] DnsServer { get; set; }

    }
}