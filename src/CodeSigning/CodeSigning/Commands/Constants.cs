
namespace Microsoft.Azure.Commands.CodeSigning
{
    public static class Constants
    {
        public const string AccountName = "AccountName";
        public const string CertificateProfileName = "CertificateProfileName";
        public const string Endpoint = "Endpoint";
        public const string Name = "Name";
        public const string KeyName = "KeyName";
        public const string CertificateName = "CertificateName";
        public const string IssuerName = "IssuerName";
        public const string Pkcs12ContentType = "application/x-pkcs12";
        public const string PemContentType = "application/x-pem-file";
        public const string RSA = "RSA";
        public const string RSAHSM = "RSA-HSM";
        public const string EC = "EC";
        public const string ECHSM = "EC-HSM";
        public const string P256 = "P-256";
        public const string P384 = "P-384";
        public const string P521 = "P-521";
        public const string P256K = "P-256K";
        public const string SECP256K1 = "SECP256K1";

        public const int MinSoftDeleteRetentionDays = 7;
        public const int MaxSoftDeleteRetentionDays = 90;
        public const int DefaultSoftDeleteRetentionDays = 90;
        public const string DefaultSoftDeleteRetentionDaysString = "90";
    }

    public static class CmdletNoun
    {
        // certificates
        public const string AzureCodeSigningCertificateEku = "AzureCodeSigningCertificateEku";
        public const string AzureCodeSigningCertificateRootCert = "AzureCodeSigningCertificateRootCert";        
    }

}
