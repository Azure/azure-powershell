namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// AddressSpace contains an array of IP address ranges that can be used by subnets of the virtual network.
    /// </summary>
    public partial class AddressSpace :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAddressSpace,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAddressSpaceInternal
    {

        /// <summary>Backing field for <see cref="AddressPrefix" /> property.</summary>
        private string[] _addressPrefix;

        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] AddressPrefix { get => this._addressPrefix; set => this._addressPrefix = value; }

        /// <summary>Creates an new <see cref="AddressSpace" /> instance.</summary>
        public AddressSpace()
        {

        }
    }
    /// AddressSpace contains an array of IP address ranges that can be used by subnets of the virtual network.
    public partial interface IAddressSpace :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of address blocks reserved for this virtual network in CIDR notation.",
        SerializedName = @"addressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] AddressPrefix { get; set; }

    }
    /// AddressSpace contains an array of IP address ranges that can be used by subnets of the virtual network.
    internal partial interface IAddressSpaceInternal

    {
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        string[] AddressPrefix { get; set; }

    }
}