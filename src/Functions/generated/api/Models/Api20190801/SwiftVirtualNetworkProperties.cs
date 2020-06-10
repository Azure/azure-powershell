namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>SwiftVirtualNetwork resource specific properties</summary>
    public partial class SwiftVirtualNetworkProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISwiftVirtualNetworkProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISwiftVirtualNetworkPropertiesInternal
    {

        /// <summary>Backing field for <see cref="SubnetResourceId" /> property.</summary>
        private string _subnetResourceId;

        /// <summary>
        /// The Virtual Network subnet's resource ID. This is the subnet that this Web App will join. This subnet must have a delegation
        /// to Microsoft.Web/serverFarms defined first.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SubnetResourceId { get => this._subnetResourceId; set => this._subnetResourceId = value; }

        /// <summary>Backing field for <see cref="SwiftSupported" /> property.</summary>
        private bool? _swiftSupported;

        /// <summary>
        /// A flag that specifies if the scale unit this Web App is on supports Swift integration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? SwiftSupported { get => this._swiftSupported; set => this._swiftSupported = value; }

        /// <summary>Creates an new <see cref="SwiftVirtualNetworkProperties" /> instance.</summary>
        public SwiftVirtualNetworkProperties()
        {

        }
    }
    /// SwiftVirtualNetwork resource specific properties
    public partial interface ISwiftVirtualNetworkProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The Virtual Network subnet's resource ID. This is the subnet that this Web App will join. This subnet must have a delegation
        /// to Microsoft.Web/serverFarms defined first.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Virtual Network subnet's resource ID. This is the subnet that this Web App will join. This subnet must have a delegation to Microsoft.Web/serverFarms defined first.",
        SerializedName = @"subnetResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetResourceId { get; set; }
        /// <summary>
        /// A flag that specifies if the scale unit this Web App is on supports Swift integration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A flag that specifies if the scale unit this Web App is on supports Swift integration.",
        SerializedName = @"swiftSupported",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SwiftSupported { get; set; }

    }
    /// SwiftVirtualNetwork resource specific properties
    internal partial interface ISwiftVirtualNetworkPropertiesInternal

    {
        /// <summary>
        /// The Virtual Network subnet's resource ID. This is the subnet that this Web App will join. This subnet must have a delegation
        /// to Microsoft.Web/serverFarms defined first.
        /// </summary>
        string SubnetResourceId { get; set; }
        /// <summary>
        /// A flag that specifies if the scale unit this Web App is on supports Swift integration.
        /// </summary>
        bool? SwiftSupported { get; set; }

    }
}