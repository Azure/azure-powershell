namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Address information for domain registration.</summary>
    public partial class Address :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressInternal
    {

        /// <summary>Backing field for <see cref="Address1" /> property.</summary>
        private string _address1;

        /// <summary>First line of an Address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Address1 { get => this._address1; set => this._address1 = value; }

        /// <summary>Backing field for <see cref="Address2" /> property.</summary>
        private string _address2;

        /// <summary>The second line of the Address. Optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Address2 { get => this._address2; set => this._address2 = value; }

        /// <summary>Backing field for <see cref="City" /> property.</summary>
        private string _city;

        /// <summary>The city for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string City { get => this._city; set => this._city = value; }

        /// <summary>Backing field for <see cref="Country" /> property.</summary>
        private string _country;

        /// <summary>The country for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Country { get => this._country; set => this._country = value; }

        /// <summary>Backing field for <see cref="PostalCode" /> property.</summary>
        private string _postalCode;

        /// <summary>The postal code for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PostalCode { get => this._postalCode; set => this._postalCode = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private string _state;

        /// <summary>The state or province for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string State { get => this._state; set => this._state = value; }

        /// <summary>Creates an new <see cref="Address" /> instance.</summary>
        public Address()
        {

        }
    }
    /// Address information for domain registration.
    public partial interface IAddress :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>First line of an Address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"First line of an Address.",
        SerializedName = @"address1",
        PossibleTypes = new [] { typeof(string) })]
        string Address1 { get; set; }
        /// <summary>The second line of the Address. Optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The second line of the Address. Optional.",
        SerializedName = @"address2",
        PossibleTypes = new [] { typeof(string) })]
        string Address2 { get; set; }
        /// <summary>The city for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The city for the address.",
        SerializedName = @"city",
        PossibleTypes = new [] { typeof(string) })]
        string City { get; set; }
        /// <summary>The country for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The country for the address.",
        SerializedName = @"country",
        PossibleTypes = new [] { typeof(string) })]
        string Country { get; set; }
        /// <summary>The postal code for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The postal code for the address.",
        SerializedName = @"postalCode",
        PossibleTypes = new [] { typeof(string) })]
        string PostalCode { get; set; }
        /// <summary>The state or province for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The state or province for the address.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string State { get; set; }

    }
    /// Address information for domain registration.
    internal partial interface IAddressInternal

    {
        /// <summary>First line of an Address.</summary>
        string Address1 { get; set; }
        /// <summary>The second line of the Address. Optional.</summary>
        string Address2 { get; set; }
        /// <summary>The city for the address.</summary>
        string City { get; set; }
        /// <summary>The country for the address.</summary>
        string Country { get; set; }
        /// <summary>The postal code for the address.</summary>
        string PostalCode { get; set; }
        /// <summary>The state or province for the address.</summary>
        string State { get; set; }

    }
}