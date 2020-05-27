namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>Locations response</summary>
    public partial class LocationsResponse :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationsResponse,
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationsResponseInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocation[] _value;

        /// <summary>locations</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocation[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="LocationsResponse" /> instance.</summary>
        public LocationsResponse()
        {

        }
    }
    /// Locations response
    public partial interface ILocationsResponse :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.IJsonSerializable
    {
        /// <summary>locations</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"locations",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocation) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocation[] Value { get; set; }

    }
    /// Locations response
    internal partial interface ILocationsResponseInternal

    {
        /// <summary>locations</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocation[] Value { get; set; }

    }
}