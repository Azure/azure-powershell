namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>SKU of a public IP prefix.</summary>
    public partial class PublicIPPrefixSku :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixSku,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixSkuInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPPrefixSkuName? _name;

        /// <summary>Name of a public IP prefix SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPPrefixSkuName? Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="PublicIPPrefixSku" /> instance.</summary>
        public PublicIPPrefixSku()
        {

        }
    }
    /// SKU of a public IP prefix.
    public partial interface IPublicIPPrefixSku :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Name of a public IP prefix SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of a public IP prefix SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPPrefixSkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPPrefixSkuName? Name { get; set; }

    }
    /// SKU of a public IP prefix.
    internal partial interface IPublicIPPrefixSkuInternal

    {
        /// <summary>Name of a public IP prefix SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPPrefixSkuName? Name { get; set; }

    }
}