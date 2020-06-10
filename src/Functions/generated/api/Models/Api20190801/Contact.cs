namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Contact information for domain registration. If 'Domain Privacy' option is not selected then the contact information is
    /// made publicly available through the Whois
    /// directories as per ICANN requirements.
    /// </summary>
    public partial class Contact :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal
    {

        /// <summary>Backing field for <see cref="AddressMailing" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress _addressMailing;

        /// <summary>Mailing address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress AddressMailing { get => (this._addressMailing = this._addressMailing ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Address()); set => this._addressMailing = value; }

        /// <summary>First line of an Address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AddressMailingAddress1 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressInternal)AddressMailing).Address1; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressInternal)AddressMailing).Address1 = value; }

        /// <summary>The second line of the Address. Optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AddressMailingAddress2 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressInternal)AddressMailing).Address2; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressInternal)AddressMailing).Address2 = value; }

        /// <summary>The city for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AddressMailingCity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressInternal)AddressMailing).City; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressInternal)AddressMailing).City = value; }

        /// <summary>The country for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AddressMailingCountry { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressInternal)AddressMailing).Country; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressInternal)AddressMailing).Country = value; }

        /// <summary>The postal code for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AddressMailingPostalCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressInternal)AddressMailing).PostalCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressInternal)AddressMailing).PostalCode = value; }

        /// <summary>The state or province for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AddressMailingState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressInternal)AddressMailing).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressInternal)AddressMailing).State = value; }

        /// <summary>Backing field for <see cref="Email" /> property.</summary>
        private string _email;

        /// <summary>Email address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Email { get => this._email; set => this._email = value; }

        /// <summary>Backing field for <see cref="Fax" /> property.</summary>
        private string _fax;

        /// <summary>Fax number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Fax { get => this._fax; set => this._fax = value; }

        /// <summary>Backing field for <see cref="JobTitle" /> property.</summary>
        private string _jobTitle;

        /// <summary>Job title.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string JobTitle { get => this._jobTitle; set => this._jobTitle = value; }

        /// <summary>Internal Acessors for AddressMailing</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal.AddressMailing { get => (this._addressMailing = this._addressMailing ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Address()); set { {_addressMailing = value;} } }

        /// <summary>Backing field for <see cref="NameFirst" /> property.</summary>
        private string _nameFirst;

        /// <summary>First name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string NameFirst { get => this._nameFirst; set => this._nameFirst = value; }

        /// <summary>Backing field for <see cref="NameLast" /> property.</summary>
        private string _nameLast;

        /// <summary>Last name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string NameLast { get => this._nameLast; set => this._nameLast = value; }

        /// <summary>Backing field for <see cref="NameMiddle" /> property.</summary>
        private string _nameMiddle;

        /// <summary>Middle name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string NameMiddle { get => this._nameMiddle; set => this._nameMiddle = value; }

        /// <summary>Backing field for <see cref="Organization" /> property.</summary>
        private string _organization;

        /// <summary>Organization contact belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Organization { get => this._organization; set => this._organization = value; }

        /// <summary>Backing field for <see cref="Phone" /> property.</summary>
        private string _phone;

        /// <summary>Phone number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Phone { get => this._phone; set => this._phone = value; }

        /// <summary>Creates an new <see cref="Contact" /> instance.</summary>
        public Contact()
        {

        }
    }
    /// Contact information for domain registration. If 'Domain Privacy' option is not selected then the contact information is
    /// made publicly available through the Whois
    /// directories as per ICANN requirements.
    public partial interface IContact :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>First line of an Address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"First line of an Address.",
        SerializedName = @"address1",
        PossibleTypes = new [] { typeof(string) })]
        string AddressMailingAddress1 { get; set; }
        /// <summary>The second line of the Address. Optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The second line of the Address. Optional.",
        SerializedName = @"address2",
        PossibleTypes = new [] { typeof(string) })]
        string AddressMailingAddress2 { get; set; }
        /// <summary>The city for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The city for the address.",
        SerializedName = @"city",
        PossibleTypes = new [] { typeof(string) })]
        string AddressMailingCity { get; set; }
        /// <summary>The country for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The country for the address.",
        SerializedName = @"country",
        PossibleTypes = new [] { typeof(string) })]
        string AddressMailingCountry { get; set; }
        /// <summary>The postal code for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The postal code for the address.",
        SerializedName = @"postalCode",
        PossibleTypes = new [] { typeof(string) })]
        string AddressMailingPostalCode { get; set; }
        /// <summary>The state or province for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The state or province for the address.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string AddressMailingState { get; set; }
        /// <summary>Email address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Email address.",
        SerializedName = @"email",
        PossibleTypes = new [] { typeof(string) })]
        string Email { get; set; }
        /// <summary>Fax number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fax number.",
        SerializedName = @"fax",
        PossibleTypes = new [] { typeof(string) })]
        string Fax { get; set; }
        /// <summary>Job title.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job title.",
        SerializedName = @"jobTitle",
        PossibleTypes = new [] { typeof(string) })]
        string JobTitle { get; set; }
        /// <summary>First name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"First name.",
        SerializedName = @"nameFirst",
        PossibleTypes = new [] { typeof(string) })]
        string NameFirst { get; set; }
        /// <summary>Last name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Last name.",
        SerializedName = @"nameLast",
        PossibleTypes = new [] { typeof(string) })]
        string NameLast { get; set; }
        /// <summary>Middle name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Middle name.",
        SerializedName = @"nameMiddle",
        PossibleTypes = new [] { typeof(string) })]
        string NameMiddle { get; set; }
        /// <summary>Organization contact belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Organization contact belongs to.",
        SerializedName = @"organization",
        PossibleTypes = new [] { typeof(string) })]
        string Organization { get; set; }
        /// <summary>Phone number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Phone number.",
        SerializedName = @"phone",
        PossibleTypes = new [] { typeof(string) })]
        string Phone { get; set; }

    }
    /// Contact information for domain registration. If 'Domain Privacy' option is not selected then the contact information is
    /// made publicly available through the Whois
    /// directories as per ICANN requirements.
    internal partial interface IContactInternal

    {
        /// <summary>Mailing address.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress AddressMailing { get; set; }
        /// <summary>First line of an Address.</summary>
        string AddressMailingAddress1 { get; set; }
        /// <summary>The second line of the Address. Optional.</summary>
        string AddressMailingAddress2 { get; set; }
        /// <summary>The city for the address.</summary>
        string AddressMailingCity { get; set; }
        /// <summary>The country for the address.</summary>
        string AddressMailingCountry { get; set; }
        /// <summary>The postal code for the address.</summary>
        string AddressMailingPostalCode { get; set; }
        /// <summary>The state or province for the address.</summary>
        string AddressMailingState { get; set; }
        /// <summary>Email address.</summary>
        string Email { get; set; }
        /// <summary>Fax number.</summary>
        string Fax { get; set; }
        /// <summary>Job title.</summary>
        string JobTitle { get; set; }
        /// <summary>First name.</summary>
        string NameFirst { get; set; }
        /// <summary>Last name.</summary>
        string NameLast { get; set; }
        /// <summary>Middle name.</summary>
        string NameMiddle { get; set; }
        /// <summary>Organization contact belongs to.</summary>
        string Organization { get; set; }
        /// <summary>Phone number.</summary>
        string Phone { get; set; }

    }
}