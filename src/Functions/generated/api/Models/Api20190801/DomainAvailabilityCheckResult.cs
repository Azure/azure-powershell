namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Domain availability check result.</summary>
    public partial class DomainAvailabilityCheckResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainAvailabilityCheckResult,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainAvailabilityCheckResultInternal
    {

        /// <summary>Backing field for <see cref="Available" /> property.</summary>
        private bool? _available;

        /// <summary>
        /// <code>true</code> if domain can be purchased using CreateDomain API; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Available { get => this._available; set => this._available = value; }

        /// <summary>Backing field for <see cref="DomainType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DomainType? _domainType;

        /// <summary>
        /// Valid values are Regular domain: Azure will charge the full price of domain registration, SoftDeleted: Purchasing this
        /// domain will simply restore it and this operation will not cost anything.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DomainType? DomainType { get => this._domainType; set => this._domainType = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="DomainAvailabilityCheckResult" /> instance.</summary>
        public DomainAvailabilityCheckResult()
        {

        }
    }
    /// Domain availability check result.
    public partial interface IDomainAvailabilityCheckResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// <code>true</code> if domain can be purchased using CreateDomain API; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if domain can be purchased using CreateDomain API; otherwise, <code>false</code>.",
        SerializedName = @"available",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Available { get; set; }
        /// <summary>
        /// Valid values are Regular domain: Azure will charge the full price of domain registration, SoftDeleted: Purchasing this
        /// domain will simply restore it and this operation will not cost anything.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Valid values are Regular domain: Azure will charge the full price of domain registration, SoftDeleted: Purchasing this domain will simply restore it and this operation will not cost anything.",
        SerializedName = @"domainType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DomainType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DomainType? DomainType { get; set; }
        /// <summary>Name of the domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the domain.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Domain availability check result.
    internal partial interface IDomainAvailabilityCheckResultInternal

    {
        /// <summary>
        /// <code>true</code> if domain can be purchased using CreateDomain API; otherwise, <code>false</code>.
        /// </summary>
        bool? Available { get; set; }
        /// <summary>
        /// Valid values are Regular domain: Azure will charge the full price of domain registration, SoftDeleted: Purchasing this
        /// domain will simply restore it and this operation will not cost anything.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DomainType? DomainType { get; set; }
        /// <summary>Name of the domain.</summary>
        string Name { get; set; }

    }
}