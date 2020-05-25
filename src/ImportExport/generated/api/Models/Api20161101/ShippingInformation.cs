namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>
    /// Contains information about the Microsoft datacenter to which the drives should be shipped.
    /// </summary>
    public partial class ShippingInformation :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IShippingInformation,
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IShippingInformationInternal
    {

        /// <summary>Backing field for <see cref="City" /> property.</summary>
        private string _city;

        /// <summary>The city name to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string City { get => this._city; set => this._city = value; }

        /// <summary>Backing field for <see cref="CountryOrRegion" /> property.</summary>
        private string _countryOrRegion;

        /// <summary>The country or region to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string CountryOrRegion { get => this._countryOrRegion; set => this._countryOrRegion = value; }

        /// <summary>Backing field for <see cref="Phone" /> property.</summary>
        private string _phone;

        /// <summary>Phone number of the recipient of the returned drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string Phone { get => this._phone; set => this._phone = value; }

        /// <summary>Backing field for <see cref="PostalCode" /> property.</summary>
        private string _postalCode;

        /// <summary>The postal code to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string PostalCode { get => this._postalCode; set => this._postalCode = value; }

        /// <summary>Backing field for <see cref="RecipientName" /> property.</summary>
        private string _recipientName;

        /// <summary>
        /// The name of the recipient who will receive the hard drives when they are returned.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string RecipientName { get => this._recipientName; set => this._recipientName = value; }

        /// <summary>Backing field for <see cref="StateOrProvince" /> property.</summary>
        private string _stateOrProvince;

        /// <summary>The state or province to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string StateOrProvince { get => this._stateOrProvince; set => this._stateOrProvince = value; }

        /// <summary>Backing field for <see cref="StreetAddress1" /> property.</summary>
        private string _streetAddress1;

        /// <summary>The first line of the street address to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string StreetAddress1 { get => this._streetAddress1; set => this._streetAddress1 = value; }

        /// <summary>Backing field for <see cref="StreetAddress2" /> property.</summary>
        private string _streetAddress2;

        /// <summary>The second line of the street address to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string StreetAddress2 { get => this._streetAddress2; set => this._streetAddress2 = value; }

        /// <summary>Creates an new <see cref="ShippingInformation" /> instance.</summary>
        public ShippingInformation()
        {

        }
    }
    /// Contains information about the Microsoft datacenter to which the drives should be shipped.
    public partial interface IShippingInformation :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.IJsonSerializable
    {
        /// <summary>The city name to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The city name to use when returning the drives.",
        SerializedName = @"city",
        PossibleTypes = new [] { typeof(string) })]
        string City { get; set; }
        /// <summary>The country or region to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The country or region to use when returning the drives. ",
        SerializedName = @"countryOrRegion",
        PossibleTypes = new [] { typeof(string) })]
        string CountryOrRegion { get; set; }
        /// <summary>Phone number of the recipient of the returned drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Phone number of the recipient of the returned drives.",
        SerializedName = @"phone",
        PossibleTypes = new [] { typeof(string) })]
        string Phone { get; set; }
        /// <summary>The postal code to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The postal code to use when returning the drives.",
        SerializedName = @"postalCode",
        PossibleTypes = new [] { typeof(string) })]
        string PostalCode { get; set; }
        /// <summary>
        /// The name of the recipient who will receive the hard drives when they are returned.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the recipient who will receive the hard drives when they are returned. ",
        SerializedName = @"recipientName",
        PossibleTypes = new [] { typeof(string) })]
        string RecipientName { get; set; }
        /// <summary>The state or province to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The state or province to use when returning the drives.",
        SerializedName = @"stateOrProvince",
        PossibleTypes = new [] { typeof(string) })]
        string StateOrProvince { get; set; }
        /// <summary>The first line of the street address to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The first line of the street address to use when returning the drives. ",
        SerializedName = @"streetAddress1",
        PossibleTypes = new [] { typeof(string) })]
        string StreetAddress1 { get; set; }
        /// <summary>The second line of the street address to use when returning the drives.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The second line of the street address to use when returning the drives. ",
        SerializedName = @"streetAddress2",
        PossibleTypes = new [] { typeof(string) })]
        string StreetAddress2 { get; set; }

    }
    /// Contains information about the Microsoft datacenter to which the drives should be shipped.
    internal partial interface IShippingInformationInternal

    {
        /// <summary>The city name to use when returning the drives.</summary>
        string City { get; set; }
        /// <summary>The country or region to use when returning the drives.</summary>
        string CountryOrRegion { get; set; }
        /// <summary>Phone number of the recipient of the returned drives.</summary>
        string Phone { get; set; }
        /// <summary>The postal code to use when returning the drives.</summary>
        string PostalCode { get; set; }
        /// <summary>
        /// The name of the recipient who will receive the hard drives when they are returned.
        /// </summary>
        string RecipientName { get; set; }
        /// <summary>The state or province to use when returning the drives.</summary>
        string StateOrProvince { get; set; }
        /// <summary>The first line of the street address to use when returning the drives.</summary>
        string StreetAddress1 { get; set; }
        /// <summary>The second line of the street address to use when returning the drives.</summary>
        string StreetAddress2 { get; set; }

    }
}