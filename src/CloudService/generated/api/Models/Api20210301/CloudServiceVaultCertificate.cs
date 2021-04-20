namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>
    /// Describes a single certificate reference in a Key Vault, and where the certificate should reside on the role instance.
    /// </summary>
    public partial class CloudServiceVaultCertificate :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultCertificate,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultCertificateInternal
    {

        /// <summary>Backing field for <see cref="CertificateUrl" /> property.</summary>
        private string _certificateUrl;

        /// <summary>
        /// This is the URL of a certificate that has been uploaded to Key Vault as a secret.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string CertificateUrl { get => this._certificateUrl; set => this._certificateUrl = value; }

        /// <summary>Creates an new <see cref="CloudServiceVaultCertificate" /> instance.</summary>
        public CloudServiceVaultCertificate()
        {

        }
    }
    /// Describes a single certificate reference in a Key Vault, and where the certificate should reside on the role instance.
    public partial interface ICloudServiceVaultCertificate :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>
        /// This is the URL of a certificate that has been uploaded to Key Vault as a secret.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This is the URL of a certificate that has been uploaded to Key Vault as a secret.",
        SerializedName = @"certificateUrl",
        PossibleTypes = new [] { typeof(string) })]
        string CertificateUrl { get; set; }

    }
    /// Describes a single certificate reference in a Key Vault, and where the certificate should reside on the role instance.
    internal partial interface ICloudServiceVaultCertificateInternal

    {
        /// <summary>
        /// This is the URL of a certificate that has been uploaded to Key Vault as a secret.
        /// </summary>
        string CertificateUrl { get; set; }

    }
}