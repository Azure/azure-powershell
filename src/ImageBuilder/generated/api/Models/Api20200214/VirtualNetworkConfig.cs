namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>Virtual Network configuration.</summary>
    public partial class VirtualNetworkConfig :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IVirtualNetworkConfig,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IVirtualNetworkConfigInternal
    {

        /// <summary>Backing field for <see cref="SubnetId" /> property.</summary>
        private string _subnetId;

        /// <summary>Resource id of a pre-existing subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string SubnetId { get => this._subnetId; set => this._subnetId = value; }

        /// <summary>Creates an new <see cref="VirtualNetworkConfig" /> instance.</summary>
        public VirtualNetworkConfig()
        {

        }
    }
    /// Virtual Network configuration.
    public partial interface IVirtualNetworkConfig :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable
    {
        /// <summary>Resource id of a pre-existing subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource id of a pre-existing subnet.",
        SerializedName = @"subnetId",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetId { get; set; }

    }
    /// Virtual Network configuration.
    public partial interface IVirtualNetworkConfigInternal

    {
        /// <summary>Resource id of a pre-existing subnet.</summary>
        string SubnetId { get; set; }

    }
}