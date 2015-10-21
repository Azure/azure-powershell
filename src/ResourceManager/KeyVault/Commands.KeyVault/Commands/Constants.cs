
namespace Microsoft.Azure.Commands.KeyVault
{
    public static class Constants
    {
        public const string KeyVaultHelpUri = "https://msdn.microsoft.com/en-us/library/dn868052.aspx";
        public const string ObjectNameRegExString = "^[0-9a-zA-Z-]+$";
        public const string VaultNameRegExString = "^[a-zA-Z0-9-]{3,24}$";
        public const string KeyName = "KeyName";
        public const string SecretName = "SecretName";
        public const string CertificateName = "CertificateName";
        public const string IssuerName = "IssuerName";
        public const string Pkcs12ContentType = "application/x-pkcs12";
        public const string PemContentType = "application/x-pem-file";
        public const string RSA = "RSA";
        public const string RSAHSM = "RSA-HSM";
    }

    public static class CmdletNoun
    {
        public const string AzureKeyVaultCertificate = "AzureKeyVaultCertificate";
        public const string AzureKeyVaultCertificatePolicy = "AzureKeyVaultCertificatePolicy";
        public const string AzureKeyVaultCertificateContact = "AzureKeyVaultCertificateContact";
        public const string AzureKeyVaultCertificateIssuer = "AzureKeyVaultCertificateIssuer";
        public const string AzureKeyVaultCertificateOrganizationDetails = "AzureKeyVaultCertificateOrganizationDetails";
        public const string AzureKeyVaultCertificateAdministratorDetails = "AzureKeyVaultCertificateAdministratorDetails";
        public const string AzureKeyVaultCertificateSigningRequest = "AzureKeyVaultCertificateSigningRequest";
        public const string AzureKeyVaultCertificateOperation = "AzureKeyVaultCertificateOperation";
    }
}
