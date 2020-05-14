namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Domain resource specific properties</summary>
    public partial class DomainProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AuthCode" /> property.</summary>
        private string _authCode;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AuthCode { get => this._authCode; set => this._authCode = value; }

        /// <summary>Backing field for <see cref="AutoRenew" /> property.</summary>
        private bool? _autoRenew;

        /// <summary>
        /// <code>true</code> if the domain should be automatically renewed; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? AutoRenew { get => this._autoRenew; set => this._autoRenew = value; }

        /// <summary>Backing field for <see cref="Consent" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPurchaseConsent _consent;

        /// <summary>Legal agreement consent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPurchaseConsent Consent { get => (this._consent = this._consent ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DomainPurchaseConsent()); set => this._consent = value; }

        /// <summary>Timestamp when the agreements were accepted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? ConsentAgreedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPurchaseConsentInternal)Consent).AgreedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPurchaseConsentInternal)Consent).AgreedAt = value; }

        /// <summary>Client IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ConsentAgreedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPurchaseConsentInternal)Consent).AgreedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPurchaseConsentInternal)Consent).AgreedBy = value; }

        /// <summary>
        /// List of applicable legal agreement keys. This list can be retrieved using ListLegalAgreements API under <code>TopLevelDomain</code>
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] ConsentAgreementKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPurchaseConsentInternal)Consent).AgreementKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPurchaseConsentInternal)Consent).AgreementKey = value; }

        /// <summary>Backing field for <see cref="ContactAdmin" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact _contactAdmin;

        /// <summary>Administrative contact.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact ContactAdmin { get => (this._contactAdmin = this._contactAdmin ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Contact()); set => this._contactAdmin = value; }

        /// <summary>First line of an Address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminAddressMailingAddress1 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).AddressMailingAddress1; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).AddressMailingAddress1 = value; }

        /// <summary>The second line of the Address. Optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminAddressMailingAddress2 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).AddressMailingAddress2; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).AddressMailingAddress2 = value; }

        /// <summary>The city for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminAddressMailingCity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).AddressMailingCity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).AddressMailingCity = value; }

        /// <summary>The country for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminAddressMailingCountry { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).AddressMailingCountry; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).AddressMailingCountry = value; }

        /// <summary>The postal code for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminAddressMailingPostalCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).AddressMailingPostalCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).AddressMailingPostalCode = value; }

        /// <summary>The state or province for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminAddressMailingState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).AddressMailingState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).AddressMailingState = value; }

        /// <summary>Email address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminEmail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).Email; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).Email = value; }

        /// <summary>Fax number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminFax { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).Fax; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).Fax = value; }

        /// <summary>Job title.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminJobTitle { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).JobTitle; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).JobTitle = value; }

        /// <summary>First name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminNameFirst { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).NameFirst; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).NameFirst = value; }

        /// <summary>Last name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminNameLast { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).NameLast; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).NameLast = value; }

        /// <summary>Middle name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminNameMiddle { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).NameMiddle; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).NameMiddle = value; }

        /// <summary>Organization contact belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminOrganization { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).Organization; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).Organization = value; }

        /// <summary>Phone number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminPhone { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).Phone; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).Phone = value; }

        /// <summary>Backing field for <see cref="ContactBilling" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact _contactBilling;

        /// <summary>Billing contact.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact ContactBilling { get => (this._contactBilling = this._contactBilling ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Contact()); set => this._contactBilling = value; }

        /// <summary>First line of an Address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingAddressMailingAddress1 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).AddressMailingAddress1; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).AddressMailingAddress1 = value; }

        /// <summary>The second line of the Address. Optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingAddressMailingAddress2 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).AddressMailingAddress2; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).AddressMailingAddress2 = value; }

        /// <summary>The city for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingAddressMailingCity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).AddressMailingCity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).AddressMailingCity = value; }

        /// <summary>The country for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingAddressMailingCountry { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).AddressMailingCountry; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).AddressMailingCountry = value; }

        /// <summary>The postal code for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingAddressMailingPostalCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).AddressMailingPostalCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).AddressMailingPostalCode = value; }

        /// <summary>The state or province for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingAddressMailingState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).AddressMailingState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).AddressMailingState = value; }

        /// <summary>Email address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingEmail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).Email; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).Email = value; }

        /// <summary>Fax number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingFax { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).Fax; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).Fax = value; }

        /// <summary>Job title.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingJobTitle { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).JobTitle; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).JobTitle = value; }

        /// <summary>First name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingNameFirst { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).NameFirst; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).NameFirst = value; }

        /// <summary>Last name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingNameLast { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).NameLast; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).NameLast = value; }

        /// <summary>Middle name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingNameMiddle { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).NameMiddle; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).NameMiddle = value; }

        /// <summary>Organization contact belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingOrganization { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).Organization; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).Organization = value; }

        /// <summary>Phone number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingPhone { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).Phone; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).Phone = value; }

        /// <summary>Backing field for <see cref="ContactRegistrant" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact _contactRegistrant;

        /// <summary>Registrant contact.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact ContactRegistrant { get => (this._contactRegistrant = this._contactRegistrant ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Contact()); set => this._contactRegistrant = value; }

        /// <summary>First line of an Address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantAddressMailingAddress1 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).AddressMailingAddress1; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).AddressMailingAddress1 = value; }

        /// <summary>The second line of the Address. Optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantAddressMailingAddress2 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).AddressMailingAddress2; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).AddressMailingAddress2 = value; }

        /// <summary>The city for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantAddressMailingCity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).AddressMailingCity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).AddressMailingCity = value; }

        /// <summary>The country for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantAddressMailingCountry { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).AddressMailingCountry; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).AddressMailingCountry = value; }

        /// <summary>The postal code for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantAddressMailingPostalCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).AddressMailingPostalCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).AddressMailingPostalCode = value; }

        /// <summary>The state or province for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantAddressMailingState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).AddressMailingState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).AddressMailingState = value; }

        /// <summary>Email address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantEmail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).Email; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).Email = value; }

        /// <summary>Fax number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantFax { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).Fax; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).Fax = value; }

        /// <summary>Job title.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantJobTitle { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).JobTitle; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).JobTitle = value; }

        /// <summary>First name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantNameFirst { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).NameFirst; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).NameFirst = value; }

        /// <summary>Last name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantNameLast { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).NameLast; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).NameLast = value; }

        /// <summary>Middle name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantNameMiddle { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).NameMiddle; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).NameMiddle = value; }

        /// <summary>Organization contact belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantOrganization { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).Organization; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).Organization = value; }

        /// <summary>Phone number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantPhone { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).Phone; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).Phone = value; }

        /// <summary>Backing field for <see cref="ContactTech" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact _contactTech;

        /// <summary>Technical contact.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact ContactTech { get => (this._contactTech = this._contactTech ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Contact()); set => this._contactTech = value; }

        /// <summary>First line of an Address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechAddressMailingAddress1 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).AddressMailingAddress1; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).AddressMailingAddress1 = value; }

        /// <summary>The second line of the Address. Optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechAddressMailingAddress2 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).AddressMailingAddress2; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).AddressMailingAddress2 = value; }

        /// <summary>The city for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechAddressMailingCity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).AddressMailingCity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).AddressMailingCity = value; }

        /// <summary>The country for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechAddressMailingCountry { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).AddressMailingCountry; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).AddressMailingCountry = value; }

        /// <summary>The postal code for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechAddressMailingPostalCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).AddressMailingPostalCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).AddressMailingPostalCode = value; }

        /// <summary>The state or province for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechAddressMailingState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).AddressMailingState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).AddressMailingState = value; }

        /// <summary>Email address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechEmail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).Email; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).Email = value; }

        /// <summary>Fax number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechFax { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).Fax; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).Fax = value; }

        /// <summary>Job title.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechJobTitle { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).JobTitle; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).JobTitle = value; }

        /// <summary>First name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechNameFirst { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).NameFirst; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).NameFirst = value; }

        /// <summary>Last name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechNameLast { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).NameLast; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).NameLast = value; }

        /// <summary>Middle name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechNameMiddle { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).NameMiddle; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).NameMiddle = value; }

        /// <summary>Organization contact belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechOrganization { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).Organization; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).Organization = value; }

        /// <summary>Phone number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechPhone { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).Phone; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).Phone = value; }

        /// <summary>Backing field for <see cref="CreatedTime" /> property.</summary>
        private global::System.DateTime? _createdTime;

        /// <summary>Domain creation timestamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? CreatedTime { get => this._createdTime; }

        /// <summary>Backing field for <see cref="DnsType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsType? _dnsType;

        /// <summary>Current DNS type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsType? DnsType { get => this._dnsType; set => this._dnsType = value; }

        /// <summary>Backing field for <see cref="DnsZoneId" /> property.</summary>
        private string _dnsZoneId;

        /// <summary>Azure DNS Zone to use</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DnsZoneId { get => this._dnsZoneId; set => this._dnsZoneId = value; }

        /// <summary>Backing field for <see cref="DomainNotRenewableReason" /> property.</summary>
        private string[] _domainNotRenewableReason;

        /// <summary>Reasons why domain is not renewable.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] DomainNotRenewableReason { get => this._domainNotRenewableReason; }

        /// <summary>Backing field for <see cref="ExpirationTime" /> property.</summary>
        private global::System.DateTime? _expirationTime;

        /// <summary>Domain expiration timestamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? ExpirationTime { get => this._expirationTime; }

        /// <summary>Backing field for <see cref="LastRenewedTime" /> property.</summary>
        private global::System.DateTime? _lastRenewedTime;

        /// <summary>Timestamp when the domain was renewed last time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? LastRenewedTime { get => this._lastRenewedTime; }

        /// <summary>Backing field for <see cref="ManagedHostName" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostName[] _managedHostName;

        /// <summary>All hostnames derived from the domain and assigned to Azure resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostName[] ManagedHostName { get => this._managedHostName; }

        /// <summary>Internal Acessors for Consent</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPurchaseConsent Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal.Consent { get => (this._consent = this._consent ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DomainPurchaseConsent()); set { {_consent = value;} } }

        /// <summary>Internal Acessors for ContactAdmin</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal.ContactAdmin { get => (this._contactAdmin = this._contactAdmin ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Contact()); set { {_contactAdmin = value;} } }

        /// <summary>Internal Acessors for ContactAdminAddressMailing</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal.ContactAdminAddressMailing { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).AddressMailing; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactAdmin).AddressMailing = value; }

        /// <summary>Internal Acessors for ContactBilling</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal.ContactBilling { get => (this._contactBilling = this._contactBilling ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Contact()); set { {_contactBilling = value;} } }

        /// <summary>Internal Acessors for ContactBillingAddressMailing</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal.ContactBillingAddressMailing { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).AddressMailing; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactBilling).AddressMailing = value; }

        /// <summary>Internal Acessors for ContactRegistrant</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal.ContactRegistrant { get => (this._contactRegistrant = this._contactRegistrant ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Contact()); set { {_contactRegistrant = value;} } }

        /// <summary>Internal Acessors for ContactRegistrantAddressMailing</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal.ContactRegistrantAddressMailing { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).AddressMailing; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactRegistrant).AddressMailing = value; }

        /// <summary>Internal Acessors for ContactTech</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal.ContactTech { get => (this._contactTech = this._contactTech ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Contact()); set { {_contactTech = value;} } }

        /// <summary>Internal Acessors for ContactTechAddressMailing</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal.ContactTechAddressMailing { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).AddressMailing; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)ContactTech).AddressMailing = value; }

        /// <summary>Internal Acessors for CreatedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal.CreatedTime { get => this._createdTime; set { {_createdTime = value;} } }

        /// <summary>Internal Acessors for DomainNotRenewableReason</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal.DomainNotRenewableReason { get => this._domainNotRenewableReason; set { {_domainNotRenewableReason = value;} } }

        /// <summary>Internal Acessors for ExpirationTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal.ExpirationTime { get => this._expirationTime; set { {_expirationTime = value;} } }

        /// <summary>Internal Acessors for LastRenewedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal.LastRenewedTime { get => this._lastRenewedTime; set { {_lastRenewedTime = value;} } }

        /// <summary>Internal Acessors for ManagedHostName</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostName[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal.ManagedHostName { get => this._managedHostName; set { {_managedHostName = value;} } }

        /// <summary>Internal Acessors for NameServer</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal.NameServer { get => this._nameServer; set { {_nameServer = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for ReadyForDnsRecordManagement</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal.ReadyForDnsRecordManagement { get => this._readyForDnsRecordManagement; set { {_readyForDnsRecordManagement = value;} } }

        /// <summary>Internal Acessors for RegistrationStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DomainStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal.RegistrationStatus { get => this._registrationStatus; set { {_registrationStatus = value;} } }

        /// <summary>Backing field for <see cref="NameServer" /> property.</summary>
        private string[] _nameServer;

        /// <summary>Name servers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] NameServer { get => this._nameServer; }

        /// <summary>Backing field for <see cref="Privacy" /> property.</summary>
        private bool? _privacy;

        /// <summary>
        /// <code>true</code> if domain privacy is enabled for this domain; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Privacy { get => this._privacy; set => this._privacy = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? _provisioningState;

        /// <summary>Domain provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="ReadyForDnsRecordManagement" /> property.</summary>
        private bool? _readyForDnsRecordManagement;

        /// <summary>
        /// <code>true</code> if Azure can assign this domain to App Service apps; otherwise, <code>false</code>. This value will
        /// be <code>true</code> if domain registration status is active and
        /// it is hosted on name servers Azure has programmatic access to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? ReadyForDnsRecordManagement { get => this._readyForDnsRecordManagement; }

        /// <summary>Backing field for <see cref="RegistrationStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DomainStatus? _registrationStatus;

        /// <summary>Domain registration status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DomainStatus? RegistrationStatus { get => this._registrationStatus; }

        /// <summary>Backing field for <see cref="TargetDnsType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsType? _targetDnsType;

        /// <summary>Target DNS type (would be used for migration)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsType? TargetDnsType { get => this._targetDnsType; set => this._targetDnsType = value; }

        /// <summary>Creates an new <see cref="DomainProperties" /> instance.</summary>
        public DomainProperties()
        {

        }
    }
    /// Domain resource specific properties
    public partial interface IDomainProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"authCode",
        PossibleTypes = new [] { typeof(string) })]
        string AuthCode { get; set; }
        /// <summary>
        /// <code>true</code> if the domain should be automatically renewed; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if the domain should be automatically renewed; otherwise, <code>false</code>.",
        SerializedName = @"autoRenew",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AutoRenew { get; set; }
        /// <summary>Timestamp when the agreements were accepted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Timestamp when the agreements were accepted.",
        SerializedName = @"agreedAt",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ConsentAgreedAt { get; set; }
        /// <summary>Client IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Client IP address.",
        SerializedName = @"agreedBy",
        PossibleTypes = new [] { typeof(string) })]
        string ConsentAgreedBy { get; set; }
        /// <summary>
        /// List of applicable legal agreement keys. This list can be retrieved using ListLegalAgreements API under <code>TopLevelDomain</code>
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of applicable legal agreement keys. This list can be retrieved using ListLegalAgreements API under <code>TopLevelDomain</code> resource.",
        SerializedName = @"agreementKeys",
        PossibleTypes = new [] { typeof(string) })]
        string[] ConsentAgreementKey { get; set; }
        /// <summary>First line of an Address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"First line of an Address.",
        SerializedName = @"address1",
        PossibleTypes = new [] { typeof(string) })]
        string ContactAdminAddressMailingAddress1 { get; set; }
        /// <summary>The second line of the Address. Optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The second line of the Address. Optional.",
        SerializedName = @"address2",
        PossibleTypes = new [] { typeof(string) })]
        string ContactAdminAddressMailingAddress2 { get; set; }
        /// <summary>The city for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The city for the address.",
        SerializedName = @"city",
        PossibleTypes = new [] { typeof(string) })]
        string ContactAdminAddressMailingCity { get; set; }
        /// <summary>The country for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The country for the address.",
        SerializedName = @"country",
        PossibleTypes = new [] { typeof(string) })]
        string ContactAdminAddressMailingCountry { get; set; }
        /// <summary>The postal code for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The postal code for the address.",
        SerializedName = @"postalCode",
        PossibleTypes = new [] { typeof(string) })]
        string ContactAdminAddressMailingPostalCode { get; set; }
        /// <summary>The state or province for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The state or province for the address.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string ContactAdminAddressMailingState { get; set; }
        /// <summary>Email address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Email address.",
        SerializedName = @"email",
        PossibleTypes = new [] { typeof(string) })]
        string ContactAdminEmail { get; set; }
        /// <summary>Fax number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fax number.",
        SerializedName = @"fax",
        PossibleTypes = new [] { typeof(string) })]
        string ContactAdminFax { get; set; }
        /// <summary>Job title.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job title.",
        SerializedName = @"jobTitle",
        PossibleTypes = new [] { typeof(string) })]
        string ContactAdminJobTitle { get; set; }
        /// <summary>First name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"First name.",
        SerializedName = @"nameFirst",
        PossibleTypes = new [] { typeof(string) })]
        string ContactAdminNameFirst { get; set; }
        /// <summary>Last name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Last name.",
        SerializedName = @"nameLast",
        PossibleTypes = new [] { typeof(string) })]
        string ContactAdminNameLast { get; set; }
        /// <summary>Middle name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Middle name.",
        SerializedName = @"nameMiddle",
        PossibleTypes = new [] { typeof(string) })]
        string ContactAdminNameMiddle { get; set; }
        /// <summary>Organization contact belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Organization contact belongs to.",
        SerializedName = @"organization",
        PossibleTypes = new [] { typeof(string) })]
        string ContactAdminOrganization { get; set; }
        /// <summary>Phone number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Phone number.",
        SerializedName = @"phone",
        PossibleTypes = new [] { typeof(string) })]
        string ContactAdminPhone { get; set; }
        /// <summary>First line of an Address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"First line of an Address.",
        SerializedName = @"address1",
        PossibleTypes = new [] { typeof(string) })]
        string ContactBillingAddressMailingAddress1 { get; set; }
        /// <summary>The second line of the Address. Optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The second line of the Address. Optional.",
        SerializedName = @"address2",
        PossibleTypes = new [] { typeof(string) })]
        string ContactBillingAddressMailingAddress2 { get; set; }
        /// <summary>The city for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The city for the address.",
        SerializedName = @"city",
        PossibleTypes = new [] { typeof(string) })]
        string ContactBillingAddressMailingCity { get; set; }
        /// <summary>The country for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The country for the address.",
        SerializedName = @"country",
        PossibleTypes = new [] { typeof(string) })]
        string ContactBillingAddressMailingCountry { get; set; }
        /// <summary>The postal code for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The postal code for the address.",
        SerializedName = @"postalCode",
        PossibleTypes = new [] { typeof(string) })]
        string ContactBillingAddressMailingPostalCode { get; set; }
        /// <summary>The state or province for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The state or province for the address.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string ContactBillingAddressMailingState { get; set; }
        /// <summary>Email address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Email address.",
        SerializedName = @"email",
        PossibleTypes = new [] { typeof(string) })]
        string ContactBillingEmail { get; set; }
        /// <summary>Fax number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fax number.",
        SerializedName = @"fax",
        PossibleTypes = new [] { typeof(string) })]
        string ContactBillingFax { get; set; }
        /// <summary>Job title.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job title.",
        SerializedName = @"jobTitle",
        PossibleTypes = new [] { typeof(string) })]
        string ContactBillingJobTitle { get; set; }
        /// <summary>First name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"First name.",
        SerializedName = @"nameFirst",
        PossibleTypes = new [] { typeof(string) })]
        string ContactBillingNameFirst { get; set; }
        /// <summary>Last name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Last name.",
        SerializedName = @"nameLast",
        PossibleTypes = new [] { typeof(string) })]
        string ContactBillingNameLast { get; set; }
        /// <summary>Middle name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Middle name.",
        SerializedName = @"nameMiddle",
        PossibleTypes = new [] { typeof(string) })]
        string ContactBillingNameMiddle { get; set; }
        /// <summary>Organization contact belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Organization contact belongs to.",
        SerializedName = @"organization",
        PossibleTypes = new [] { typeof(string) })]
        string ContactBillingOrganization { get; set; }
        /// <summary>Phone number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Phone number.",
        SerializedName = @"phone",
        PossibleTypes = new [] { typeof(string) })]
        string ContactBillingPhone { get; set; }
        /// <summary>First line of an Address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"First line of an Address.",
        SerializedName = @"address1",
        PossibleTypes = new [] { typeof(string) })]
        string ContactRegistrantAddressMailingAddress1 { get; set; }
        /// <summary>The second line of the Address. Optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The second line of the Address. Optional.",
        SerializedName = @"address2",
        PossibleTypes = new [] { typeof(string) })]
        string ContactRegistrantAddressMailingAddress2 { get; set; }
        /// <summary>The city for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The city for the address.",
        SerializedName = @"city",
        PossibleTypes = new [] { typeof(string) })]
        string ContactRegistrantAddressMailingCity { get; set; }
        /// <summary>The country for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The country for the address.",
        SerializedName = @"country",
        PossibleTypes = new [] { typeof(string) })]
        string ContactRegistrantAddressMailingCountry { get; set; }
        /// <summary>The postal code for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The postal code for the address.",
        SerializedName = @"postalCode",
        PossibleTypes = new [] { typeof(string) })]
        string ContactRegistrantAddressMailingPostalCode { get; set; }
        /// <summary>The state or province for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The state or province for the address.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string ContactRegistrantAddressMailingState { get; set; }
        /// <summary>Email address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Email address.",
        SerializedName = @"email",
        PossibleTypes = new [] { typeof(string) })]
        string ContactRegistrantEmail { get; set; }
        /// <summary>Fax number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fax number.",
        SerializedName = @"fax",
        PossibleTypes = new [] { typeof(string) })]
        string ContactRegistrantFax { get; set; }
        /// <summary>Job title.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job title.",
        SerializedName = @"jobTitle",
        PossibleTypes = new [] { typeof(string) })]
        string ContactRegistrantJobTitle { get; set; }
        /// <summary>First name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"First name.",
        SerializedName = @"nameFirst",
        PossibleTypes = new [] { typeof(string) })]
        string ContactRegistrantNameFirst { get; set; }
        /// <summary>Last name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Last name.",
        SerializedName = @"nameLast",
        PossibleTypes = new [] { typeof(string) })]
        string ContactRegistrantNameLast { get; set; }
        /// <summary>Middle name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Middle name.",
        SerializedName = @"nameMiddle",
        PossibleTypes = new [] { typeof(string) })]
        string ContactRegistrantNameMiddle { get; set; }
        /// <summary>Organization contact belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Organization contact belongs to.",
        SerializedName = @"organization",
        PossibleTypes = new [] { typeof(string) })]
        string ContactRegistrantOrganization { get; set; }
        /// <summary>Phone number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Phone number.",
        SerializedName = @"phone",
        PossibleTypes = new [] { typeof(string) })]
        string ContactRegistrantPhone { get; set; }
        /// <summary>First line of an Address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"First line of an Address.",
        SerializedName = @"address1",
        PossibleTypes = new [] { typeof(string) })]
        string ContactTechAddressMailingAddress1 { get; set; }
        /// <summary>The second line of the Address. Optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The second line of the Address. Optional.",
        SerializedName = @"address2",
        PossibleTypes = new [] { typeof(string) })]
        string ContactTechAddressMailingAddress2 { get; set; }
        /// <summary>The city for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The city for the address.",
        SerializedName = @"city",
        PossibleTypes = new [] { typeof(string) })]
        string ContactTechAddressMailingCity { get; set; }
        /// <summary>The country for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The country for the address.",
        SerializedName = @"country",
        PossibleTypes = new [] { typeof(string) })]
        string ContactTechAddressMailingCountry { get; set; }
        /// <summary>The postal code for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The postal code for the address.",
        SerializedName = @"postalCode",
        PossibleTypes = new [] { typeof(string) })]
        string ContactTechAddressMailingPostalCode { get; set; }
        /// <summary>The state or province for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The state or province for the address.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string ContactTechAddressMailingState { get; set; }
        /// <summary>Email address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Email address.",
        SerializedName = @"email",
        PossibleTypes = new [] { typeof(string) })]
        string ContactTechEmail { get; set; }
        /// <summary>Fax number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fax number.",
        SerializedName = @"fax",
        PossibleTypes = new [] { typeof(string) })]
        string ContactTechFax { get; set; }
        /// <summary>Job title.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job title.",
        SerializedName = @"jobTitle",
        PossibleTypes = new [] { typeof(string) })]
        string ContactTechJobTitle { get; set; }
        /// <summary>First name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"First name.",
        SerializedName = @"nameFirst",
        PossibleTypes = new [] { typeof(string) })]
        string ContactTechNameFirst { get; set; }
        /// <summary>Last name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Last name.",
        SerializedName = @"nameLast",
        PossibleTypes = new [] { typeof(string) })]
        string ContactTechNameLast { get; set; }
        /// <summary>Middle name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Middle name.",
        SerializedName = @"nameMiddle",
        PossibleTypes = new [] { typeof(string) })]
        string ContactTechNameMiddle { get; set; }
        /// <summary>Organization contact belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Organization contact belongs to.",
        SerializedName = @"organization",
        PossibleTypes = new [] { typeof(string) })]
        string ContactTechOrganization { get; set; }
        /// <summary>Phone number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Phone number.",
        SerializedName = @"phone",
        PossibleTypes = new [] { typeof(string) })]
        string ContactTechPhone { get; set; }
        /// <summary>Domain creation timestamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Domain creation timestamp.",
        SerializedName = @"createdTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedTime { get;  }
        /// <summary>Current DNS type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Current DNS type",
        SerializedName = @"dnsType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsType? DnsType { get; set; }
        /// <summary>Azure DNS Zone to use</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Azure DNS Zone to use",
        SerializedName = @"dnsZoneId",
        PossibleTypes = new [] { typeof(string) })]
        string DnsZoneId { get; set; }
        /// <summary>Reasons why domain is not renewable.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Reasons why domain is not renewable.",
        SerializedName = @"domainNotRenewableReasons",
        PossibleTypes = new [] { typeof(string) })]
        string[] DomainNotRenewableReason { get;  }
        /// <summary>Domain expiration timestamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Domain expiration timestamp.",
        SerializedName = @"expirationTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ExpirationTime { get;  }
        /// <summary>Timestamp when the domain was renewed last time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp when the domain was renewed last time.",
        SerializedName = @"lastRenewedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastRenewedTime { get;  }
        /// <summary>All hostnames derived from the domain and assigned to Azure resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"All hostnames derived from the domain and assigned to Azure resources.",
        SerializedName = @"managedHostNames",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostName[] ManagedHostName { get;  }
        /// <summary>Name servers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name servers.",
        SerializedName = @"nameServers",
        PossibleTypes = new [] { typeof(string) })]
        string[] NameServer { get;  }
        /// <summary>
        /// <code>true</code> if domain privacy is enabled for this domain; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if domain privacy is enabled for this domain; otherwise, <code>false</code>.",
        SerializedName = @"privacy",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Privacy { get; set; }
        /// <summary>Domain provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Domain provisioning state.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>
        /// <code>true</code> if Azure can assign this domain to App Service apps; otherwise, <code>false</code>. This value will
        /// be <code>true</code> if domain registration status is active and
        /// it is hosted on name servers Azure has programmatic access to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"<code>true</code> if Azure can assign this domain to App Service apps; otherwise, <code>false</code>. This value will be <code>true</code> if domain registration status is active and
         it is hosted on name servers Azure has programmatic access to.",
        SerializedName = @"readyForDnsRecordManagement",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ReadyForDnsRecordManagement { get;  }
        /// <summary>Domain registration status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Domain registration status.",
        SerializedName = @"registrationStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DomainStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DomainStatus? RegistrationStatus { get;  }
        /// <summary>Target DNS type (would be used for migration)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target DNS type (would be used for migration)",
        SerializedName = @"targetDnsType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsType? TargetDnsType { get; set; }

    }
    /// Domain resource specific properties
    internal partial interface IDomainPropertiesInternal

    {
        string AuthCode { get; set; }
        /// <summary>
        /// <code>true</code> if the domain should be automatically renewed; otherwise, <code>false</code>.
        /// </summary>
        bool? AutoRenew { get; set; }
        /// <summary>Legal agreement consent.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPurchaseConsent Consent { get; set; }
        /// <summary>Timestamp when the agreements were accepted.</summary>
        global::System.DateTime? ConsentAgreedAt { get; set; }
        /// <summary>Client IP address.</summary>
        string ConsentAgreedBy { get; set; }
        /// <summary>
        /// List of applicable legal agreement keys. This list can be retrieved using ListLegalAgreements API under <code>TopLevelDomain</code>
        /// resource.
        /// </summary>
        string[] ConsentAgreementKey { get; set; }
        /// <summary>Administrative contact.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact ContactAdmin { get; set; }
        /// <summary>Mailing address.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress ContactAdminAddressMailing { get; set; }
        /// <summary>First line of an Address.</summary>
        string ContactAdminAddressMailingAddress1 { get; set; }
        /// <summary>The second line of the Address. Optional.</summary>
        string ContactAdminAddressMailingAddress2 { get; set; }
        /// <summary>The city for the address.</summary>
        string ContactAdminAddressMailingCity { get; set; }
        /// <summary>The country for the address.</summary>
        string ContactAdminAddressMailingCountry { get; set; }
        /// <summary>The postal code for the address.</summary>
        string ContactAdminAddressMailingPostalCode { get; set; }
        /// <summary>The state or province for the address.</summary>
        string ContactAdminAddressMailingState { get; set; }
        /// <summary>Email address.</summary>
        string ContactAdminEmail { get; set; }
        /// <summary>Fax number.</summary>
        string ContactAdminFax { get; set; }
        /// <summary>Job title.</summary>
        string ContactAdminJobTitle { get; set; }
        /// <summary>First name.</summary>
        string ContactAdminNameFirst { get; set; }
        /// <summary>Last name.</summary>
        string ContactAdminNameLast { get; set; }
        /// <summary>Middle name.</summary>
        string ContactAdminNameMiddle { get; set; }
        /// <summary>Organization contact belongs to.</summary>
        string ContactAdminOrganization { get; set; }
        /// <summary>Phone number.</summary>
        string ContactAdminPhone { get; set; }
        /// <summary>Billing contact.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact ContactBilling { get; set; }
        /// <summary>Mailing address.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress ContactBillingAddressMailing { get; set; }
        /// <summary>First line of an Address.</summary>
        string ContactBillingAddressMailingAddress1 { get; set; }
        /// <summary>The second line of the Address. Optional.</summary>
        string ContactBillingAddressMailingAddress2 { get; set; }
        /// <summary>The city for the address.</summary>
        string ContactBillingAddressMailingCity { get; set; }
        /// <summary>The country for the address.</summary>
        string ContactBillingAddressMailingCountry { get; set; }
        /// <summary>The postal code for the address.</summary>
        string ContactBillingAddressMailingPostalCode { get; set; }
        /// <summary>The state or province for the address.</summary>
        string ContactBillingAddressMailingState { get; set; }
        /// <summary>Email address.</summary>
        string ContactBillingEmail { get; set; }
        /// <summary>Fax number.</summary>
        string ContactBillingFax { get; set; }
        /// <summary>Job title.</summary>
        string ContactBillingJobTitle { get; set; }
        /// <summary>First name.</summary>
        string ContactBillingNameFirst { get; set; }
        /// <summary>Last name.</summary>
        string ContactBillingNameLast { get; set; }
        /// <summary>Middle name.</summary>
        string ContactBillingNameMiddle { get; set; }
        /// <summary>Organization contact belongs to.</summary>
        string ContactBillingOrganization { get; set; }
        /// <summary>Phone number.</summary>
        string ContactBillingPhone { get; set; }
        /// <summary>Registrant contact.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact ContactRegistrant { get; set; }
        /// <summary>Mailing address.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress ContactRegistrantAddressMailing { get; set; }
        /// <summary>First line of an Address.</summary>
        string ContactRegistrantAddressMailingAddress1 { get; set; }
        /// <summary>The second line of the Address. Optional.</summary>
        string ContactRegistrantAddressMailingAddress2 { get; set; }
        /// <summary>The city for the address.</summary>
        string ContactRegistrantAddressMailingCity { get; set; }
        /// <summary>The country for the address.</summary>
        string ContactRegistrantAddressMailingCountry { get; set; }
        /// <summary>The postal code for the address.</summary>
        string ContactRegistrantAddressMailingPostalCode { get; set; }
        /// <summary>The state or province for the address.</summary>
        string ContactRegistrantAddressMailingState { get; set; }
        /// <summary>Email address.</summary>
        string ContactRegistrantEmail { get; set; }
        /// <summary>Fax number.</summary>
        string ContactRegistrantFax { get; set; }
        /// <summary>Job title.</summary>
        string ContactRegistrantJobTitle { get; set; }
        /// <summary>First name.</summary>
        string ContactRegistrantNameFirst { get; set; }
        /// <summary>Last name.</summary>
        string ContactRegistrantNameLast { get; set; }
        /// <summary>Middle name.</summary>
        string ContactRegistrantNameMiddle { get; set; }
        /// <summary>Organization contact belongs to.</summary>
        string ContactRegistrantOrganization { get; set; }
        /// <summary>Phone number.</summary>
        string ContactRegistrantPhone { get; set; }
        /// <summary>Technical contact.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact ContactTech { get; set; }
        /// <summary>Mailing address.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress ContactTechAddressMailing { get; set; }
        /// <summary>First line of an Address.</summary>
        string ContactTechAddressMailingAddress1 { get; set; }
        /// <summary>The second line of the Address. Optional.</summary>
        string ContactTechAddressMailingAddress2 { get; set; }
        /// <summary>The city for the address.</summary>
        string ContactTechAddressMailingCity { get; set; }
        /// <summary>The country for the address.</summary>
        string ContactTechAddressMailingCountry { get; set; }
        /// <summary>The postal code for the address.</summary>
        string ContactTechAddressMailingPostalCode { get; set; }
        /// <summary>The state or province for the address.</summary>
        string ContactTechAddressMailingState { get; set; }
        /// <summary>Email address.</summary>
        string ContactTechEmail { get; set; }
        /// <summary>Fax number.</summary>
        string ContactTechFax { get; set; }
        /// <summary>Job title.</summary>
        string ContactTechJobTitle { get; set; }
        /// <summary>First name.</summary>
        string ContactTechNameFirst { get; set; }
        /// <summary>Last name.</summary>
        string ContactTechNameLast { get; set; }
        /// <summary>Middle name.</summary>
        string ContactTechNameMiddle { get; set; }
        /// <summary>Organization contact belongs to.</summary>
        string ContactTechOrganization { get; set; }
        /// <summary>Phone number.</summary>
        string ContactTechPhone { get; set; }
        /// <summary>Domain creation timestamp.</summary>
        global::System.DateTime? CreatedTime { get; set; }
        /// <summary>Current DNS type</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsType? DnsType { get; set; }
        /// <summary>Azure DNS Zone to use</summary>
        string DnsZoneId { get; set; }
        /// <summary>Reasons why domain is not renewable.</summary>
        string[] DomainNotRenewableReason { get; set; }
        /// <summary>Domain expiration timestamp.</summary>
        global::System.DateTime? ExpirationTime { get; set; }
        /// <summary>Timestamp when the domain was renewed last time.</summary>
        global::System.DateTime? LastRenewedTime { get; set; }
        /// <summary>All hostnames derived from the domain and assigned to Azure resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostName[] ManagedHostName { get; set; }
        /// <summary>Name servers.</summary>
        string[] NameServer { get; set; }
        /// <summary>
        /// <code>true</code> if domain privacy is enabled for this domain; otherwise, <code>false</code>.
        /// </summary>
        bool? Privacy { get; set; }
        /// <summary>Domain provisioning state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>
        /// <code>true</code> if Azure can assign this domain to App Service apps; otherwise, <code>false</code>. This value will
        /// be <code>true</code> if domain registration status is active and
        /// it is hosted on name servers Azure has programmatic access to.
        /// </summary>
        bool? ReadyForDnsRecordManagement { get; set; }
        /// <summary>Domain registration status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DomainStatus? RegistrationStatus { get; set; }
        /// <summary>Target DNS type (would be used for migration)</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsType? TargetDnsType { get; set; }

    }
}