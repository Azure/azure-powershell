namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>SSL certificate details.</summary>
    public partial class CertificateDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal
    {

        /// <summary>Backing field for <see cref="Issuer" /> property.</summary>
        private string _issuer;

        /// <summary>Certificate Issuer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Issuer { get => this._issuer; }

        /// <summary>Internal Acessors for Issuer</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal.Issuer { get => this._issuer; set { {_issuer = value;} } }

        /// <summary>Internal Acessors for NotAfter</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal.NotAfter { get => this._notAfter; set { {_notAfter = value;} } }

        /// <summary>Internal Acessors for NotBefore</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal.NotBefore { get => this._notBefore; set { {_notBefore = value;} } }

        /// <summary>Internal Acessors for RawData</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal.RawData { get => this._rawData; set { {_rawData = value;} } }

        /// <summary>Internal Acessors for SerialNumber</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal.SerialNumber { get => this._serialNumber; set { {_serialNumber = value;} } }

        /// <summary>Internal Acessors for SignatureAlgorithm</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal.SignatureAlgorithm { get => this._signatureAlgorithm; set { {_signatureAlgorithm = value;} } }

        /// <summary>Internal Acessors for Subject</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal.Subject { get => this._subject; set { {_subject = value;} } }

        /// <summary>Internal Acessors for Thumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal.Thumbprint { get => this._thumbprint; set { {_thumbprint = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Backing field for <see cref="NotAfter" /> property.</summary>
        private global::System.DateTime? _notAfter;

        /// <summary>Date Certificate is valid to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? NotAfter { get => this._notAfter; }

        /// <summary>Backing field for <see cref="NotBefore" /> property.</summary>
        private global::System.DateTime? _notBefore;

        /// <summary>Date Certificate is valid from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? NotBefore { get => this._notBefore; }

        /// <summary>Backing field for <see cref="RawData" /> property.</summary>
        private string _rawData;

        /// <summary>Raw certificate data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RawData { get => this._rawData; }

        /// <summary>Backing field for <see cref="SerialNumber" /> property.</summary>
        private string _serialNumber;

        /// <summary>Certificate Serial Number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SerialNumber { get => this._serialNumber; }

        /// <summary>Backing field for <see cref="SignatureAlgorithm" /> property.</summary>
        private string _signatureAlgorithm;

        /// <summary>Certificate Signature algorithm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SignatureAlgorithm { get => this._signatureAlgorithm; }

        /// <summary>Backing field for <see cref="Subject" /> property.</summary>
        private string _subject;

        /// <summary>Certificate Subject.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Subject { get => this._subject; }

        /// <summary>Backing field for <see cref="Thumbprint" /> property.</summary>
        private string _thumbprint;

        /// <summary>Certificate Thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Thumbprint { get => this._thumbprint; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private int? _version;

        /// <summary>Certificate Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Version { get => this._version; }

        /// <summary>Creates an new <see cref="CertificateDetails" /> instance.</summary>
        public CertificateDetails()
        {

        }
    }
    /// SSL certificate details.
    public partial interface ICertificateDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Certificate Issuer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Issuer.",
        SerializedName = @"issuer",
        PossibleTypes = new [] { typeof(string) })]
        string Issuer { get;  }
        /// <summary>Date Certificate is valid to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Date Certificate is valid to.",
        SerializedName = @"notAfter",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? NotAfter { get;  }
        /// <summary>Date Certificate is valid from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Date Certificate is valid from.",
        SerializedName = @"notBefore",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? NotBefore { get;  }
        /// <summary>Raw certificate data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Raw certificate data.",
        SerializedName = @"rawData",
        PossibleTypes = new [] { typeof(string) })]
        string RawData { get;  }
        /// <summary>Certificate Serial Number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Serial Number.",
        SerializedName = @"serialNumber",
        PossibleTypes = new [] { typeof(string) })]
        string SerialNumber { get;  }
        /// <summary>Certificate Signature algorithm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Signature algorithm.",
        SerializedName = @"signatureAlgorithm",
        PossibleTypes = new [] { typeof(string) })]
        string SignatureAlgorithm { get;  }
        /// <summary>Certificate Subject.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Subject.",
        SerializedName = @"subject",
        PossibleTypes = new [] { typeof(string) })]
        string Subject { get;  }
        /// <summary>Certificate Thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Thumbprint.",
        SerializedName = @"thumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string Thumbprint { get;  }
        /// <summary>Certificate Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Version.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(int) })]
        int? Version { get;  }

    }
    /// SSL certificate details.
    internal partial interface ICertificateDetailsInternal

    {
        /// <summary>Certificate Issuer.</summary>
        string Issuer { get; set; }
        /// <summary>Date Certificate is valid to.</summary>
        global::System.DateTime? NotAfter { get; set; }
        /// <summary>Date Certificate is valid from.</summary>
        global::System.DateTime? NotBefore { get; set; }
        /// <summary>Raw certificate data.</summary>
        string RawData { get; set; }
        /// <summary>Certificate Serial Number.</summary>
        string SerialNumber { get; set; }
        /// <summary>Certificate Signature algorithm.</summary>
        string SignatureAlgorithm { get; set; }
        /// <summary>Certificate Subject.</summary>
        string Subject { get; set; }
        /// <summary>Certificate Thumbprint.</summary>
        string Thumbprint { get; set; }
        /// <summary>Certificate Version.</summary>
        int? Version { get; set; }

    }
}