namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Domain purchase consent object, representing acceptance of applicable legal agreements.
    /// </summary>
    public partial class DomainPurchaseConsent :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPurchaseConsent,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainPurchaseConsentInternal
    {

        /// <summary>Backing field for <see cref="AgreedAt" /> property.</summary>
        private global::System.DateTime? _agreedAt;

        /// <summary>Timestamp when the agreements were accepted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? AgreedAt { get => this._agreedAt; set => this._agreedAt = value; }

        /// <summary>Backing field for <see cref="AgreedBy" /> property.</summary>
        private string _agreedBy;

        /// <summary>Client IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AgreedBy { get => this._agreedBy; set => this._agreedBy = value; }

        /// <summary>Backing field for <see cref="AgreementKey" /> property.</summary>
        private string[] _agreementKey;

        /// <summary>
        /// List of applicable legal agreement keys. This list can be retrieved using ListLegalAgreements API under <code>TopLevelDomain</code>
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] AgreementKey { get => this._agreementKey; set => this._agreementKey = value; }

        /// <summary>Creates an new <see cref="DomainPurchaseConsent" /> instance.</summary>
        public DomainPurchaseConsent()
        {

        }
    }
    /// Domain purchase consent object, representing acceptance of applicable legal agreements.
    public partial interface IDomainPurchaseConsent :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Timestamp when the agreements were accepted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Timestamp when the agreements were accepted.",
        SerializedName = @"agreedAt",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? AgreedAt { get; set; }
        /// <summary>Client IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Client IP address.",
        SerializedName = @"agreedBy",
        PossibleTypes = new [] { typeof(string) })]
        string AgreedBy { get; set; }
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
        string[] AgreementKey { get; set; }

    }
    /// Domain purchase consent object, representing acceptance of applicable legal agreements.
    internal partial interface IDomainPurchaseConsentInternal

    {
        /// <summary>Timestamp when the agreements were accepted.</summary>
        global::System.DateTime? AgreedAt { get; set; }
        /// <summary>Client IP address.</summary>
        string AgreedBy { get; set; }
        /// <summary>
        /// List of applicable legal agreement keys. This list can be retrieved using ListLegalAgreements API under <code>TopLevelDomain</code>
        /// resource.
        /// </summary>
        string[] AgreementKey { get; set; }

    }
}