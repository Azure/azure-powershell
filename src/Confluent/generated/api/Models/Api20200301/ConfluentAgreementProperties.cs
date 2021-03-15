namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Extensions;

    /// <summary>Terms properties for Marketplace and Confluent.</summary>
    public partial class ConfluentAgreementProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Accepted" /> property.</summary>
        private bool? _accepted;

        /// <summary>If any version of the terms have been accepted, otherwise false.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public bool? Accepted { get => this._accepted; set => this._accepted = value; }

        /// <summary>Backing field for <see cref="LicenseTextLink" /> property.</summary>
        private string _licenseTextLink;

        /// <summary>Link to HTML with Microsoft and Publisher terms.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string LicenseTextLink { get => this._licenseTextLink; set => this._licenseTextLink = value; }

        /// <summary>Backing field for <see cref="Plan" /> property.</summary>
        private string _plan;

        /// <summary>Plan identifier string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string Plan { get => this._plan; set => this._plan = value; }

        /// <summary>Backing field for <see cref="PrivacyPolicyLink" /> property.</summary>
        private string _privacyPolicyLink;

        /// <summary>Link to the privacy policy of the publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string PrivacyPolicyLink { get => this._privacyPolicyLink; set => this._privacyPolicyLink = value; }

        /// <summary>Backing field for <see cref="Product" /> property.</summary>
        private string _product;

        /// <summary>Product identifier string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string Product { get => this._product; set => this._product = value; }

        /// <summary>Backing field for <see cref="Publisher" /> property.</summary>
        private string _publisher;

        /// <summary>Publisher identifier string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string Publisher { get => this._publisher; set => this._publisher = value; }

        /// <summary>Backing field for <see cref="RetrieveDatetime" /> property.</summary>
        private global::System.DateTime? _retrieveDatetime;

        /// <summary>
        /// Date and time in UTC of when the terms were accepted. This is empty if Accepted is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public global::System.DateTime? RetrieveDatetime { get => this._retrieveDatetime; set => this._retrieveDatetime = value; }

        /// <summary>Backing field for <see cref="Signature" /> property.</summary>
        private string _signature;

        /// <summary>Terms signature.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string Signature { get => this._signature; set => this._signature = value; }

        /// <summary>Creates an new <see cref="ConfluentAgreementProperties" /> instance.</summary>
        public ConfluentAgreementProperties()
        {

        }
    }
    /// Terms properties for Marketplace and Confluent.
    public partial interface IConfluentAgreementProperties :
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
        /// <summary>Link to HTML with Microsoft and Publisher terms.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Link to HTML with Microsoft and Publisher terms.",
        SerializedName = @"licenseTextLink",
        PossibleTypes = new [] { typeof(string) })]
        string LicenseTextLink { get; set; }
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

    }
    /// Terms properties for Marketplace and Confluent.
    internal partial interface IConfluentAgreementPropertiesInternal

    {
        /// <summary>If any version of the terms have been accepted, otherwise false.</summary>
        bool? Accepted { get; set; }
        /// <summary>Link to HTML with Microsoft and Publisher terms.</summary>
        string LicenseTextLink { get; set; }
        /// <summary>Plan identifier string.</summary>
        string Plan { get; set; }
        /// <summary>Link to the privacy policy of the publisher.</summary>
        string PrivacyPolicyLink { get; set; }
        /// <summary>Product identifier string.</summary>
        string Product { get; set; }
        /// <summary>Publisher identifier string.</summary>
        string Publisher { get; set; }
        /// <summary>
        /// Date and time in UTC of when the terms were accepted. This is empty if Accepted is false.
        /// </summary>
        global::System.DateTime? RetrieveDatetime { get; set; }
        /// <summary>Terms signature.</summary>
        string Signature { get; set; }

    }
}