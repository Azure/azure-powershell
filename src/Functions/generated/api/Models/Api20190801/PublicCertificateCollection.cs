namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Collection of public certificates</summary>
    public partial class PublicCertificateCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPublicCertificateCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPublicCertificateCollectionInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPublicCertificateCollectionInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Link to next page of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPublicCertificate[] _value;

        /// <summary>Collection of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPublicCertificate[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="PublicCertificateCollection" /> instance.</summary>
        public PublicCertificateCollection()
        {

        }
    }
    /// Collection of public certificates
    public partial interface IPublicCertificateCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Link to next page of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Link to next page of resources.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>Collection of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Collection of resources.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPublicCertificate) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPublicCertificate[] Value { get; set; }

    }
    /// Collection of public certificates
    internal partial interface IPublicCertificateCollectionInternal

    {
        /// <summary>Link to next page of resources.</summary>
        string NextLink { get; set; }
        /// <summary>Collection of resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPublicCertificate[] Value { get; set; }

    }
}