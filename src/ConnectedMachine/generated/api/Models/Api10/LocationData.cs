namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Metadata pertaining to the geographic location of the resource.</summary>
    public partial class LocationData :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationData,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationDataInternal
    {

        /// <summary>Backing field for <see cref="City" /> property.</summary>
        private string _city;

        /// <summary>The city or locality where the resource is located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string City { get => this._city; set => this._city = value; }

        /// <summary>Backing field for <see cref="CountryOrRegion" /> property.</summary>
        private string _countryOrRegion;

        /// <summary>The country or region where the resource is located</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string CountryOrRegion { get => this._countryOrRegion; set => this._countryOrRegion = value; }

        /// <summary>Backing field for <see cref="District" /> property.</summary>
        private string _district;

        /// <summary>The district, state, or province where the resource is located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string District { get => this._district; set => this._district = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>A canonical name for the geographic or physical location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="LocationData" /> instance.</summary>
        public LocationData()
        {

        }
    }
    /// Metadata pertaining to the geographic location of the resource.
    public partial interface ILocationData :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable
    {
        /// <summary>The city or locality where the resource is located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The city or locality where the resource is located.",
        SerializedName = @"city",
        PossibleTypes = new [] { typeof(string) })]
        string City { get; set; }
        /// <summary>The country or region where the resource is located</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The country or region where the resource is located",
        SerializedName = @"countryOrRegion",
        PossibleTypes = new [] { typeof(string) })]
        string CountryOrRegion { get; set; }
        /// <summary>The district, state, or province where the resource is located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The district, state, or province where the resource is located.",
        SerializedName = @"district",
        PossibleTypes = new [] { typeof(string) })]
        string District { get; set; }
        /// <summary>A canonical name for the geographic or physical location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A canonical name for the geographic or physical location.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Metadata pertaining to the geographic location of the resource.
    internal partial interface ILocationDataInternal

    {
        /// <summary>The city or locality where the resource is located.</summary>
        string City { get; set; }
        /// <summary>The country or region where the resource is located</summary>
        string CountryOrRegion { get; set; }
        /// <summary>The district, state, or province where the resource is located.</summary>
        string District { get; set; }
        /// <summary>A canonical name for the geographic or physical location.</summary>
        string Name { get; set; }

    }
}