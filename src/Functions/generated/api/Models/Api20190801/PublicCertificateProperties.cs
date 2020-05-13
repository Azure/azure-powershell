namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>PublicCertificate resource specific properties</summary>
    public partial class PublicCertificateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPublicCertificateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPublicCertificatePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Blob" /> property.</summary>
        private byte[] _blob;

        /// <summary>Public Certificate byte array</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public byte[] Blob { get => this._blob; set => this._blob = value; }

        /// <summary>Internal Acessors for Thumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPublicCertificatePropertiesInternal.Thumbprint { get => this._thumbprint; set { {_thumbprint = value;} } }

        /// <summary>Backing field for <see cref="PublicCertificateLocation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublicCertificateLocation? _publicCertificateLocation;

        /// <summary>Public Certificate Location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublicCertificateLocation? PublicCertificateLocation { get => this._publicCertificateLocation; set => this._publicCertificateLocation = value; }

        /// <summary>Backing field for <see cref="Thumbprint" /> property.</summary>
        private string _thumbprint;

        /// <summary>Certificate Thumbprint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Thumbprint { get => this._thumbprint; }

        /// <summary>Creates an new <see cref="PublicCertificateProperties" /> instance.</summary>
        public PublicCertificateProperties()
        {

        }
    }
    /// PublicCertificate resource specific properties
    public partial interface IPublicCertificateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Public Certificate byte array</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Public Certificate byte array",
        SerializedName = @"blob",
        PossibleTypes = new [] { typeof(byte[]) })]
        byte[] Blob { get; set; }
        /// <summary>Public Certificate Location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Public Certificate Location",
        SerializedName = @"publicCertificateLocation",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublicCertificateLocation) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublicCertificateLocation? PublicCertificateLocation { get; set; }
        /// <summary>Certificate Thumbprint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Thumbprint",
        SerializedName = @"thumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string Thumbprint { get;  }

    }
    /// PublicCertificate resource specific properties
    internal partial interface IPublicCertificatePropertiesInternal

    {
        /// <summary>Public Certificate byte array</summary>
        byte[] Blob { get; set; }
        /// <summary>Public Certificate Location</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublicCertificateLocation? PublicCertificateLocation { get; set; }
        /// <summary>Certificate Thumbprint</summary>
        string Thumbprint { get; set; }

    }
}