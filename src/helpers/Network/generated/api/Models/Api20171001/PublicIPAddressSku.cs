namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>SKU of a public IP address</summary>
    public partial class PublicIPAddressSku :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressSku,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressSkuInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName? _name;

        /// <summary>Name of a public IP address SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName? Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="PublicIPAddressSku" /> instance.</summary>
        public PublicIPAddressSku()
        {

        }
    }
    /// SKU of a public IP address
    public partial interface IPublicIPAddressSku :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Name of a public IP address SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of a public IP address SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName? Name { get; set; }

    }
    /// SKU of a public IP address
    internal partial interface IPublicIPAddressSkuInternal

    {
        /// <summary>Name of a public IP address SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName? Name { get; set; }

    }
}