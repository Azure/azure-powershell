namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Extensions;

    /// <summary>Confluent Agreements Resource.</summary>
    public partial class ConfluentAgreementResource :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementResource,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementResourceInternal
    {

        /// <summary>If any version of the terms have been accepted, otherwise false.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public bool? Accepted { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementPropertiesInternal)Property).Accepted; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementPropertiesInternal)Property).Accepted = value ?? default(bool); }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>ARM id of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Link to HTML with Microsoft and Publisher terms.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string LicenseTextLink { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementPropertiesInternal)Property).LicenseTextLink; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementPropertiesInternal)Property).LicenseTextLink = value ?? null; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementResourceInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementResourceInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementProperties Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.ConfluentAgreementProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementResourceInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the agreement.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Plan identifier string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string Plan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementPropertiesInternal)Property).Plan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementPropertiesInternal)Property).Plan = value ?? null; }

        /// <summary>Link to the privacy policy of the publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string PrivacyPolicyLink { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementPropertiesInternal)Property).PrivacyPolicyLink; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementPropertiesInternal)Property).PrivacyPolicyLink = value ?? null; }

        /// <summary>Product identifier string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string Product { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementPropertiesInternal)Property).Product; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementPropertiesInternal)Property).Product = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementProperties _property;

        /// <summary>Represents the properties of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.ConfluentAgreementProperties()); set => this._property = value; }

        /// <summary>Publisher identifier string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string Publisher { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementPropertiesInternal)Property).Publisher; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementPropertiesInternal)Property).Publisher = value ?? null; }

        /// <summary>
        /// Date and time in UTC of when the terms were accepted. This is empty if Accepted is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public global::System.DateTime? RetrieveDatetime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementPropertiesInternal)Property).RetrieveDatetime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementPropertiesInternal)Property).RetrieveDatetime = value ?? default(global::System.DateTime); }

        /// <summary>Terms signature.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string Signature { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementPropertiesInternal)Property).Signature; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementPropertiesInternal)Property).Signature = value ?? null; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="ConfluentAgreementResource" /> instance.</summary>
        public ConfluentAgreementResource()
        {

        }
    }
    /// Confluent Agreements Resource.
    public partial interface IConfluentAgreementResource :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.IJsonSerializable
    {
        /// <summary>If any version of the terms have been accepted, otherwise false.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If any version of the terms have been accepted, otherwise false.",
        SerializedName = @"accepted",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Accepted { get; set; }
        /// <summary>ARM id of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ARM id of the resource.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Link to HTML with Microsoft and Publisher terms.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Link to HTML with Microsoft and Publisher terms.",
        SerializedName = @"licenseTextLink",
        PossibleTypes = new [] { typeof(string) })]
        string LicenseTextLink { get; set; }
        /// <summary>Name of the agreement.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the agreement.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Plan identifier string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Plan identifier string.",
        SerializedName = @"plan",
        PossibleTypes = new [] { typeof(string) })]
        string Plan { get; set; }
        /// <summary>Link to the privacy policy of the publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Link to the privacy policy of the publisher.",
        SerializedName = @"privacyPolicyLink",
        PossibleTypes = new [] { typeof(string) })]
        string PrivacyPolicyLink { get; set; }
        /// <summary>Product identifier string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Product identifier string.",
        SerializedName = @"product",
        PossibleTypes = new [] { typeof(string) })]
        string Product { get; set; }
        /// <summary>Publisher identifier string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Publisher identifier string.",
        SerializedName = @"publisher",
        PossibleTypes = new [] { typeof(string) })]
        string Publisher { get; set; }
        /// <summary>
        /// Date and time in UTC of when the terms were accepted. This is empty if Accepted is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Date and time in UTC of when the terms were accepted. This is empty if Accepted is false.",
        SerializedName = @"retrieveDatetime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RetrieveDatetime { get; set; }
        /// <summary>Terms signature.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Terms signature.",
        SerializedName = @"signature",
        PossibleTypes = new [] { typeof(string) })]
        string Signature { get; set; }
        /// <summary>The type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of the resource.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// Confluent Agreements Resource.
    internal partial interface IConfluentAgreementResourceInternal

    {
        /// <summary>If any version of the terms have been accepted, otherwise false.</summary>
        bool? Accepted { get; set; }
        /// <summary>ARM id of the resource.</summary>
        string Id { get; set; }
        /// <summary>Link to HTML with Microsoft and Publisher terms.</summary>
        string LicenseTextLink { get; set; }
        /// <summary>Name of the agreement.</summary>
        string Name { get; set; }
        /// <summary>Plan identifier string.</summary>
        string Plan { get; set; }
        /// <summary>Link to the privacy policy of the publisher.</summary>
        string PrivacyPolicyLink { get; set; }
        /// <summary>Product identifier string.</summary>
        string Product { get; set; }
        /// <summary>Represents the properties of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementProperties Property { get; set; }
        /// <summary>Publisher identifier string.</summary>
        string Publisher { get; set; }
        /// <summary>
        /// Date and time in UTC of when the terms were accepted. This is empty if Accepted is false.
        /// </summary>
        global::System.DateTime? RetrieveDatetime { get; set; }
        /// <summary>Terms signature.</summary>
        string Signature { get; set; }
        /// <summary>The type of the resource.</summary>
        string Type { get; set; }

    }
}