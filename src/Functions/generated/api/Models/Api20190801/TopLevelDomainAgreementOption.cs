namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Options for retrieving the list of top level domain legal agreements.</summary>
    public partial class TopLevelDomainAgreementOption :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITopLevelDomainAgreementOption,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITopLevelDomainAgreementOptionInternal
    {

        /// <summary>Backing field for <see cref="ForTransfer" /> property.</summary>
        private bool? _forTransfer;

        /// <summary>
        /// If <code>true</code>, then the list of agreements will include agreements for domain transfer as well; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? ForTransfer { get => this._forTransfer; set => this._forTransfer = value; }

        /// <summary>Backing field for <see cref="IncludePrivacy" /> property.</summary>
        private bool? _includePrivacy;

        /// <summary>
        /// If <code>true</code>, then the list of agreements will include agreements for domain privacy as well; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IncludePrivacy { get => this._includePrivacy; set => this._includePrivacy = value; }

        /// <summary>Creates an new <see cref="TopLevelDomainAgreementOption" /> instance.</summary>
        public TopLevelDomainAgreementOption()
        {

        }
    }
    /// Options for retrieving the list of top level domain legal agreements.
    public partial interface ITopLevelDomainAgreementOption :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// If <code>true</code>, then the list of agreements will include agreements for domain transfer as well; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If <code>true</code>, then the list of agreements will include agreements for domain transfer as well; otherwise, <code>false</code>.",
        SerializedName = @"forTransfer",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ForTransfer { get; set; }
        /// <summary>
        /// If <code>true</code>, then the list of agreements will include agreements for domain privacy as well; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If <code>true</code>, then the list of agreements will include agreements for domain privacy as well; otherwise, <code>false</code>.",
        SerializedName = @"includePrivacy",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IncludePrivacy { get; set; }

    }
    /// Options for retrieving the list of top level domain legal agreements.
    internal partial interface ITopLevelDomainAgreementOptionInternal

    {
        /// <summary>
        /// If <code>true</code>, then the list of agreements will include agreements for domain transfer as well; otherwise, <code>false</code>.
        /// </summary>
        bool? ForTransfer { get; set; }
        /// <summary>
        /// If <code>true</code>, then the list of agreements will include agreements for domain privacy as well; otherwise, <code>false</code>.
        /// </summary>
        bool? IncludePrivacy { get; set; }

    }
}