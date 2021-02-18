namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>location properties</summary>
    public partial class LocationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AlternateLocation" /> property.</summary>
        private string[] _alternateLocation;

        /// <summary>
        /// A list of location IDs that should be used to ship shipping drives to for jobs created against the current location. If
        /// the current location is active, it will be part of the list. If it is temporarily closed due to maintenance, this list
        /// may contain other locations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string[] AlternateLocation { get => this._alternateLocation; set => this._alternateLocation = value; }

        /// <summary>Backing field for <see cref="City" /> property.</summary>
        private string _city;

        /// <summary>The city name to use when shipping the drives to the Azure data center.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string City { get => this._city; set => this._city = value; }

        /// <summary>Backing field for <see cref="CountryOrRegion" /> property.</summary>
        private string _countryOrRegion;

        /// <summary>
        /// The country or region to use when shipping the drives to the Azure data center.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string CountryOrRegion { get => this._countryOrRegion; set => this._countryOrRegion = value; }

        /// <summary>Backing field for <see cref="Phone" /> property.</summary>
        private string _phone;

        /// <summary>The phone number for the Azure data center.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string Phone { get => this._phone; set => this._phone = value; }

        /// <summary>Backing field for <see cref="PostalCode" /> property.</summary>
        private string _postalCode;

        /// <summary>The postal code to use when shipping the drives to the Azure data center.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string PostalCode { get => this._postalCode; set => this._postalCode = value; }

        /// <summary>Backing field for <see cref="RecipientName" /> property.</summary>
        private string _recipientName;

        /// <summary>The recipient name to use when shipping the drives to the Azure data center.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string RecipientName { get => this._recipientName; set => this._recipientName = value; }

        /// <summary>Backing field for <see cref="StateOrProvince" /> property.</summary>
        private string _stateOrProvince;

        /// <summary>
        /// The state or province to use when shipping the drives to the Azure data center.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string StateOrProvince { get => this._stateOrProvince; set => this._stateOrProvince = value; }

        /// <summary>Backing field for <see cref="StreetAddress1" /> property.</summary>
        private string _streetAddress1;

        /// <summary>
        /// The first line of the street address to use when shipping the drives to the Azure data center.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string StreetAddress1 { get => this._streetAddress1; set => this._streetAddress1 = value; }

        /// <summary>Backing field for <see cref="StreetAddress2" /> property.</summary>
        private string _streetAddress2;

        /// <summary>
        /// The second line of the street address to use when shipping the drives to the Azure data center.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string StreetAddress2 { get => this._streetAddress2; set => this._streetAddress2 = value; }

        /// <summary>Backing field for <see cref="SupportedCarrier" /> property.</summary>
        private string[] _supportedCarrier;

        /// <summary>A list of carriers that are supported at this location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string[] SupportedCarrier { get => this._supportedCarrier; set => this._supportedCarrier = value; }

        /// <summary>Creates an new <see cref="LocationProperties" /> instance.</summary>
        public LocationProperties()
        {

        }
    }
    /// location properties
    public partial interface ILocationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.IJsonSerializable
    {
        /// <summary>
        /// A list of location IDs that should be used to ship shipping drives to for jobs created against the current location. If
        /// the current location is active, it will be part of the list. If it is temporarily closed due to maintenance, this list
        /// may contain other locations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of location IDs that should be used to ship shipping drives to for jobs created against the current location. If the current location is active, it will be part of the list. If it is temporarily closed due to maintenance, this list may contain other locations. ",
        SerializedName = @"alternateLocations",
        PossibleTypes = new [] { typeof(string) })]
        string[] AlternateLocation { get; set; }
        /// <summary>The city name to use when shipping the drives to the Azure data center.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The city name to use when shipping the drives to the Azure data center. ",
        SerializedName = @"city",
        PossibleTypes = new [] { typeof(string) })]
        string City { get; set; }
        /// <summary>
        /// The country or region to use when shipping the drives to the Azure data center.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The country or region to use when shipping the drives to the Azure data center. ",
        SerializedName = @"countryOrRegion",
        PossibleTypes = new [] { typeof(string) })]
        string CountryOrRegion { get; set; }
        /// <summary>The phone number for the Azure data center.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The phone number for the Azure data center. ",
        SerializedName = @"phone",
        PossibleTypes = new [] { typeof(string) })]
        string Phone { get; set; }
        /// <summary>The postal code to use when shipping the drives to the Azure data center.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The postal code to use when shipping the drives to the Azure data center. ",
        SerializedName = @"postalCode",
        PossibleTypes = new [] { typeof(string) })]
        string PostalCode { get; set; }
        /// <summary>The recipient name to use when shipping the drives to the Azure data center.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recipient name to use when shipping the drives to the Azure data center. ",
        SerializedName = @"recipientName",
        PossibleTypes = new [] { typeof(string) })]
        string RecipientName { get; set; }
        /// <summary>
        /// The state or province to use when shipping the drives to the Azure data center.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The state or province to use when shipping the drives to the Azure data center. ",
        SerializedName = @"stateOrProvince",
        PossibleTypes = new [] { typeof(string) })]
        string StateOrProvince { get; set; }
        /// <summary>
        /// The first line of the street address to use when shipping the drives to the Azure data center.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The first line of the street address to use when shipping the drives to the Azure data center. ",
        SerializedName = @"streetAddress1",
        PossibleTypes = new [] { typeof(string) })]
        string StreetAddress1 { get; set; }
        /// <summary>
        /// The second line of the street address to use when shipping the drives to the Azure data center.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The second line of the street address to use when shipping the drives to the Azure data center. ",
        SerializedName = @"streetAddress2",
        PossibleTypes = new [] { typeof(string) })]
        string StreetAddress2 { get; set; }
        /// <summary>A list of carriers that are supported at this location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of carriers that are supported at this location. ",
        SerializedName = @"supportedCarriers",
        PossibleTypes = new [] { typeof(string) })]
        string[] SupportedCarrier { get; set; }

    }
    /// location properties
    internal partial interface ILocationPropertiesInternal

    {
        /// <summary>
        /// A list of location IDs that should be used to ship shipping drives to for jobs created against the current location. If
        /// the current location is active, it will be part of the list. If it is temporarily closed due to maintenance, this list
        /// may contain other locations.
        /// </summary>
        string[] AlternateLocation { get; set; }
        /// <summary>The city name to use when shipping the drives to the Azure data center.</summary>
        string City { get; set; }
        /// <summary>
        /// The country or region to use when shipping the drives to the Azure data center.
        /// </summary>
        string CountryOrRegion { get; set; }
        /// <summary>The phone number for the Azure data center.</summary>
        string Phone { get; set; }
        /// <summary>The postal code to use when shipping the drives to the Azure data center.</summary>
        string PostalCode { get; set; }
        /// <summary>The recipient name to use when shipping the drives to the Azure data center.</summary>
        string RecipientName { get; set; }
        /// <summary>
        /// The state or province to use when shipping the drives to the Azure data center.
        /// </summary>
        string StateOrProvince { get; set; }
        /// <summary>
        /// The first line of the street address to use when shipping the drives to the Azure data center.
        /// </summary>
        string StreetAddress1 { get; set; }
        /// <summary>
        /// The second line of the street address to use when shipping the drives to the Azure data center.
        /// </summary>
        string StreetAddress2 { get; set; }
        /// <summary>A list of carriers that are supported at this location.</summary>
        string[] SupportedCarrier { get; set; }

    }
}