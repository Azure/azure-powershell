namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Filters limit rule actions to a subset of blobs within the storage account. If multiple filters are defined, a logical
    /// AND is performed on all filters.
    /// </summary>
    public partial class ManagementPolicyFilter :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyFilter,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyFilterInternal
    {

        /// <summary>Backing field for <see cref="BlobType" /> property.</summary>
        private string[] _blobType;

        /// <summary>An array of predefined enum values. Only blockBlob is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] BlobType { get => this._blobType; set => this._blobType = value; }

        /// <summary>Backing field for <see cref="PrefixMatch" /> property.</summary>
        private string[] _prefixMatch;

        /// <summary>An array of strings for prefixes to be match.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] PrefixMatch { get => this._prefixMatch; set => this._prefixMatch = value; }

        /// <summary>Creates an new <see cref="ManagementPolicyFilter" /> instance.</summary>
        public ManagementPolicyFilter()
        {

        }
    }
    /// Filters limit rule actions to a subset of blobs within the storage account. If multiple filters are defined, a logical
    /// AND is performed on all filters.
    public partial interface IManagementPolicyFilter :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>An array of predefined enum values. Only blockBlob is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"An array of predefined enum values. Only blockBlob is supported.",
        SerializedName = @"blobTypes",
        PossibleTypes = new [] { typeof(string) })]
        string[] BlobType { get; set; }
        /// <summary>An array of strings for prefixes to be match.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"An array of strings for prefixes to be match.",
        SerializedName = @"prefixMatch",
        PossibleTypes = new [] { typeof(string) })]
        string[] PrefixMatch { get; set; }

    }
    /// Filters limit rule actions to a subset of blobs within the storage account. If multiple filters are defined, a logical
    /// AND is performed on all filters.
    internal partial interface IManagementPolicyFilterInternal

    {
        /// <summary>An array of predefined enum values. Only blockBlob is supported.</summary>
        string[] BlobType { get; set; }
        /// <summary>An array of strings for prefixes to be match.</summary>
        string[] PrefixMatch { get; set; }

    }
}