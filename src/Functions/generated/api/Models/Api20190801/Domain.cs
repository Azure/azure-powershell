namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Information about a domain.</summary>
    public partial class Domain :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomain,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Resource();

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AuthCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).AuthCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).AuthCode = value; }

        /// <summary>
        /// <code>true</code> if the domain should be automatically renewed; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? AutoRenew { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).AutoRenew; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).AutoRenew = value; }

        /// <summary>Timestamp when the agreements were accepted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? ConsentAgreedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ConsentAgreedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ConsentAgreedAt = value; }

        /// <summary>Client IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ConsentAgreedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ConsentAgreedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ConsentAgreedBy = value; }

        /// <summary>
        /// List of applicable legal agreement keys. This list can be retrieved using ListLegalAgreements API under <code>TopLevelDomain</code>
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] ConsentAgreementKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ConsentAgreementKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ConsentAgreementKey = value; }

        /// <summary>First line of an Address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminAddressMailingAddress1 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminAddressMailingAddress1; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminAddressMailingAddress1 = value; }

        /// <summary>The second line of the Address. Optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminAddressMailingAddress2 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminAddressMailingAddress2; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminAddressMailingAddress2 = value; }

        /// <summary>The city for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminAddressMailingCity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminAddressMailingCity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminAddressMailingCity = value; }

        /// <summary>The country for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminAddressMailingCountry { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminAddressMailingCountry; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminAddressMailingCountry = value; }

        /// <summary>The postal code for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminAddressMailingPostalCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminAddressMailingPostalCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminAddressMailingPostalCode = value; }

        /// <summary>The state or province for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminAddressMailingState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminAddressMailingState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminAddressMailingState = value; }

        /// <summary>Email address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminEmail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminEmail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminEmail = value; }

        /// <summary>Fax number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminFax { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminFax; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminFax = value; }

        /// <summary>Job title.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminJobTitle { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminJobTitle; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminJobTitle = value; }

        /// <summary>First name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminNameFirst { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminNameFirst; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminNameFirst = value; }

        /// <summary>Last name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminNameLast { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminNameLast; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminNameLast = value; }

        /// <summary>Middle name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminNameMiddle { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminNameMiddle; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminNameMiddle = value; }

        /// <summary>Organization contact belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminOrganization { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminOrganization; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminOrganization = value; }

        /// <summary>Phone number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactAdminPhone { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminPhone; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminPhone = value; }

        /// <summary>First line of an Address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingAddressMailingAddress1 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingAddressMailingAddress1; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingAddressMailingAddress1 = value; }

        /// <summary>The second line of the Address. Optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingAddressMailingAddress2 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingAddressMailingAddress2; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingAddressMailingAddress2 = value; }

        /// <summary>The city for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingAddressMailingCity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingAddressMailingCity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingAddressMailingCity = value; }

        /// <summary>The country for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingAddressMailingCountry { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingAddressMailingCountry; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingAddressMailingCountry = value; }

        /// <summary>The postal code for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingAddressMailingPostalCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingAddressMailingPostalCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingAddressMailingPostalCode = value; }

        /// <summary>The state or province for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingAddressMailingState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingAddressMailingState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingAddressMailingState = value; }

        /// <summary>Email address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingEmail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingEmail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingEmail = value; }

        /// <summary>Fax number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingFax { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingFax; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingFax = value; }

        /// <summary>Job title.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingJobTitle { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingJobTitle; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingJobTitle = value; }

        /// <summary>First name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingNameFirst { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingNameFirst; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingNameFirst = value; }

        /// <summary>Last name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingNameLast { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingNameLast; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingNameLast = value; }

        /// <summary>Middle name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingNameMiddle { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingNameMiddle; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingNameMiddle = value; }

        /// <summary>Organization contact belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingOrganization { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingOrganization; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingOrganization = value; }

        /// <summary>Phone number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactBillingPhone { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingPhone; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingPhone = value; }

        /// <summary>First line of an Address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantAddressMailingAddress1 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantAddressMailingAddress1; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantAddressMailingAddress1 = value; }

        /// <summary>The second line of the Address. Optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantAddressMailingAddress2 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantAddressMailingAddress2; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantAddressMailingAddress2 = value; }

        /// <summary>The city for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantAddressMailingCity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantAddressMailingCity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantAddressMailingCity = value; }

        /// <summary>The country for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantAddressMailingCountry { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantAddressMailingCountry; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantAddressMailingCountry = value; }

        /// <summary>The postal code for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantAddressMailingPostalCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantAddressMailingPostalCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantAddressMailingPostalCode = value; }

        /// <summary>The state or province for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantAddressMailingState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantAddressMailingState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantAddressMailingState = value; }

        /// <summary>Email address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantEmail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantEmail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantEmail = value; }

        /// <summary>Fax number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantFax { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantFax; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantFax = value; }

        /// <summary>Job title.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantJobTitle { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantJobTitle; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantJobTitle = value; }

        /// <summary>First name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantNameFirst { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantNameFirst; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantNameFirst = value; }

        /// <summary>Last name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantNameLast { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantNameLast; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantNameLast = value; }

        /// <summary>Middle name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantNameMiddle { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantNameMiddle; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantNameMiddle = value; }

        /// <summary>Organization contact belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantOrganization { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantOrganization; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantOrganization = value; }

        /// <summary>Phone number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactRegistrantPhone { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantPhone; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantPhone = value; }

        /// <summary>First line of an Address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechAddressMailingAddress1 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechAddressMailingAddress1; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechAddressMailingAddress1 = value; }

        /// <summary>The second line of the Address. Optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechAddressMailingAddress2 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechAddressMailingAddress2; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechAddressMailingAddress2 = value; }

        /// <summary>The city for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechAddressMailingCity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechAddressMailingCity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechAddressMailingCity = value; }

        /// <summary>The country for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechAddressMailingCountry { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechAddressMailingCountry; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechAddressMailingCountry = value; }

        /// <summary>The postal code for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechAddressMailingPostalCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechAddressMailingPostalCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechAddressMailingPostalCode = value; }

        /// <summary>The state or province for the address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechAddressMailingState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechAddressMailingState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechAddressMailingState = value; }

        /// <summary>Email address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechEmail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechEmail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechEmail = value; }

        /// <summary>Fax number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechFax { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechFax; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechFax = value; }

        /// <summary>Job title.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechJobTitle { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechJobTitle; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechJobTitle = value; }

        /// <summary>First name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechNameFirst { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechNameFirst; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechNameFirst = value; }

        /// <summary>Last name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechNameLast { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechNameLast; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechNameLast = value; }

        /// <summary>Middle name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechNameMiddle { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechNameMiddle; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechNameMiddle = value; }

        /// <summary>Organization contact belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechOrganization { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechOrganization; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechOrganization = value; }

        /// <summary>Phone number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContactTechPhone { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechPhone; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechPhone = value; }

        /// <summary>Domain creation timestamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? CreatedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).CreatedTime; }

        /// <summary>Current DNS type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsType? DnsType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).DnsType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).DnsType = value; }

        /// <summary>Azure DNS Zone to use</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DnsZoneId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).DnsZoneId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).DnsZoneId = value; }

        /// <summary>Domain expiration timestamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? ExpirationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ExpirationTime; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Kind = value; }

        /// <summary>Timestamp when the domain was renewed last time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? LastRenewedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).LastRenewedTime; }

        /// <summary>Resource Location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Location = value; }

        /// <summary>All hostnames derived from the domain and assigned to Azure resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostName[] ManagedHostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ManagedHostName; }

        /// <summary>Internal Acessors for Consent</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPurchaseConsent Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.Consent { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).Consent; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).Consent = value; }

        /// <summary>Internal Acessors for ContactAdmin</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.ContactAdmin { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdmin; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdmin = value; }

        /// <summary>Internal Acessors for ContactAdminAddressMailing</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.ContactAdminAddressMailing { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminAddressMailing; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactAdminAddressMailing = value; }

        /// <summary>Internal Acessors for ContactBilling</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.ContactBilling { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBilling; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBilling = value; }

        /// <summary>Internal Acessors for ContactBillingAddressMailing</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.ContactBillingAddressMailing { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingAddressMailing; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactBillingAddressMailing = value; }

        /// <summary>Internal Acessors for ContactRegistrant</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.ContactRegistrant { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrant; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrant = value; }

        /// <summary>Internal Acessors for ContactRegistrantAddressMailing</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.ContactRegistrantAddressMailing { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantAddressMailing; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactRegistrantAddressMailing = value; }

        /// <summary>Internal Acessors for ContactTech</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.ContactTech { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTech; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTech = value; }

        /// <summary>Internal Acessors for ContactTechAddressMailing</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.ContactTechAddressMailing { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechAddressMailing; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ContactTechAddressMailing = value; }

        /// <summary>Internal Acessors for CreatedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.CreatedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).CreatedTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).CreatedTime = value; }

        /// <summary>Internal Acessors for ExpirationTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.ExpirationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ExpirationTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ExpirationTime = value; }

        /// <summary>Internal Acessors for LastRenewedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.LastRenewedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).LastRenewedTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).LastRenewedTime = value; }

        /// <summary>Internal Acessors for ManagedHostName</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostName[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.ManagedHostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ManagedHostName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ManagedHostName = value; }

        /// <summary>Internal Acessors for NameServer</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.NameServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).NameServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).NameServer = value; }

        /// <summary>Internal Acessors for NotRenewableReason</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.NotRenewableReason { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).DomainNotRenewableReason; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).DomainNotRenewableReason = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DomainProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for ReadyForDnsRecordManagement</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.ReadyForDnsRecordManagement { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ReadyForDnsRecordManagement; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ReadyForDnsRecordManagement = value; }

        /// <summary>Internal Acessors for RegistrationStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DomainStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainInternal.RegistrationStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).RegistrationStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).RegistrationStatus = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Name; }

        /// <summary>Name servers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] NameServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).NameServer; }

        /// <summary>Reasons why domain is not renewable.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] NotRenewableReason { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).DomainNotRenewableReason; }

        /// <summary>
        /// <code>true</code> if domain privacy is enabled for this domain; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? Privacy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).Privacy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).Privacy = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainProperties _property;

        /// <summary>Domain resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DomainProperties()); set => this._property = value; }

        /// <summary>Domain provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// <code>true</code> if Azure can assign this domain to App Service apps; otherwise, <code>false</code>. This value will
        /// be <code>true</code> if domain registration status is active and
        /// it is hosted on name servers Azure has programmatic access to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? ReadyForDnsRecordManagement { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).ReadyForDnsRecordManagement; }

        /// <summary>Domain registration status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DomainStatus? RegistrationStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).RegistrationStatus; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Tag = value; }

        /// <summary>Target DNS type (would be used for migration)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsType? TargetDnsType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).TargetDnsType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPropertiesInternal)Property).TargetDnsType = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="Domain" /> instance.</summary>
        public Domain()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Information about a domain.
    public partial interface IDomain :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResource
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
        /// <summary>Reasons why domain is not renewable.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Reasons why domain is not renewable.",
        SerializedName = @"domainNotRenewableReasons",
        PossibleTypes = new [] { typeof(string) })]
        string[] NotRenewableReason { get;  }
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
    /// Information about a domain.
    internal partial interface IDomainInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal
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
        /// <summary>Domain expiration timestamp.</summary>
        global::System.DateTime? ExpirationTime { get; set; }
        /// <summary>Timestamp when the domain was renewed last time.</summary>
        global::System.DateTime? LastRenewedTime { get; set; }
        /// <summary>All hostnames derived from the domain and assigned to Azure resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostName[] ManagedHostName { get; set; }
        /// <summary>Name servers.</summary>
        string[] NameServer { get; set; }
        /// <summary>Reasons why domain is not renewable.</summary>
        string[] NotRenewableReason { get; set; }
        /// <summary>
        /// <code>true</code> if domain privacy is enabled for this domain; otherwise, <code>false</code>.
        /// </summary>
        bool? Privacy { get; set; }
        /// <summary>Domain resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainProperties Property { get; set; }
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