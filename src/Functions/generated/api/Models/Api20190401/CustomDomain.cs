namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The custom domain assigned to this storage account. This can be set via Update.</summary>
    public partial class CustomDomain :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICustomDomain,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICustomDomainInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="UseSubDomainName" /> property.</summary>
        private bool? _useSubDomainName;

        /// <summary>
        /// Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? UseSubDomainName { get => this._useSubDomainName; set => this._useSubDomainName = value; }

        /// <summary>Creates an new <see cref="CustomDomain" /> instance.</summary>
        public CustomDomain()
        {

        }
    }
    /// The custom domain assigned to this storage account. This can be set via Update.
    public partial interface ICustomDomain :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.",
        SerializedName = @"useSubDomainName",
        PossibleTypes = new [] { typeof(bool) })]
        bool? UseSubDomainName { get; set; }

    }
    /// The custom domain assigned to this storage account. This can be set via Update.
    internal partial interface ICustomDomainInternal

    {
        /// <summary>
        /// Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.
        /// </summary>
        bool? UseSubDomainName { get; set; }

    }
}