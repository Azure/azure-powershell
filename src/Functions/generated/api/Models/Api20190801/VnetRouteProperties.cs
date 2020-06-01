namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>VnetRoute resource specific properties</summary>
    public partial class VnetRouteProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRouteProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoutePropertiesInternal
    {

        /// <summary>Backing field for <see cref="EndAddress" /> property.</summary>
        private string _endAddress;

        /// <summary>
        /// The ending address for this route. If the start address is specified in CIDR notation, this must be omitted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string EndAddress { get => this._endAddress; set => this._endAddress = value; }

        /// <summary>Backing field for <see cref="RouteType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RouteType? _routeType;

        /// <summary>
        /// The type of route this is:
        /// DEFAULT - By default, every app has routes to the local address ranges specified by RFC1918
        /// INHERITED - Routes inherited from the real Virtual Network routes
        /// STATIC - Static route set on the app only
        /// These values will be used for syncing an app's routes with those from a Virtual Network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RouteType? RouteType { get => this._routeType; set => this._routeType = value; }

        /// <summary>Backing field for <see cref="StartAddress" /> property.</summary>
        private string _startAddress;

        /// <summary>
        /// The starting address for this route. This may also include a CIDR notation, in which case the end address must not be
        /// specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string StartAddress { get => this._startAddress; set => this._startAddress = value; }

        /// <summary>Creates an new <see cref="VnetRouteProperties" /> instance.</summary>
        public VnetRouteProperties()
        {

        }
    }
    /// VnetRoute resource specific properties
    public partial interface IVnetRouteProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The ending address for this route. If the start address is specified in CIDR notation, this must be omitted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ending address for this route. If the start address is specified in CIDR notation, this must be omitted.",
        SerializedName = @"endAddress",
        PossibleTypes = new [] { typeof(string) })]
        string EndAddress { get; set; }
        /// <summary>
        /// The type of route this is:
        /// DEFAULT - By default, every app has routes to the local address ranges specified by RFC1918
        /// INHERITED - Routes inherited from the real Virtual Network routes
        /// STATIC - Static route set on the app only
        /// These values will be used for syncing an app's routes with those from a Virtual Network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of route this is:
        DEFAULT - By default, every app has routes to the local address ranges specified by RFC1918
        INHERITED - Routes inherited from the real Virtual Network routes
        STATIC - Static route set on the app only

        These values will be used for syncing an app's routes with those from a Virtual Network.",
        SerializedName = @"routeType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RouteType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RouteType? RouteType { get; set; }
        /// <summary>
        /// The starting address for this route. This may also include a CIDR notation, in which case the end address must not be
        /// specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The starting address for this route. This may also include a CIDR notation, in which case the end address must not be specified.",
        SerializedName = @"startAddress",
        PossibleTypes = new [] { typeof(string) })]
        string StartAddress { get; set; }

    }
    /// VnetRoute resource specific properties
    internal partial interface IVnetRoutePropertiesInternal

    {
        /// <summary>
        /// The ending address for this route. If the start address is specified in CIDR notation, this must be omitted.
        /// </summary>
        string EndAddress { get; set; }
        /// <summary>
        /// The type of route this is:
        /// DEFAULT - By default, every app has routes to the local address ranges specified by RFC1918
        /// INHERITED - Routes inherited from the real Virtual Network routes
        /// STATIC - Static route set on the app only
        /// These values will be used for syncing an app's routes with those from a Virtual Network.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RouteType? RouteType { get; set; }
        /// <summary>
        /// The starting address for this route. This may also include a CIDR notation, in which case the end address must not be
        /// specified.
        /// </summary>
        string StartAddress { get; set; }

    }
}