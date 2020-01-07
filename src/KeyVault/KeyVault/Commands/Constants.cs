
namespace Microsoft.Azure.Commands.KeyVault
{
    public static class Constants
    {
        public const string AccountName = "AccountName";
        public const string KeyVaultHelpUri = "https://msdn.microsoft.com/en-us/library/dn868052.aspx";
        public const string Name = "Name";
        public const string KeyName = "KeyName";
        public const string SecretName = "SecretName";
        public const string CertificateName = "CertificateName";
        public const string IssuerName = "IssuerName";
        public const string Pkcs12ContentType = "application/x-pkcs12";
        public const string PemContentType = "application/x-pem-file";
        public const string RSA = "RSA";
        public const string RSAHSM = "RSA-HSM";
        public const string SasDefinitionName = "SasDefinitionName";
        public const string StorageAccountName = "StorageAccountName";
        public const string StorageAccountResourceId = "StorageAccountResourceId";
        public const string TagsAlias = "Tags";
    }

    public static class CmdletNoun
    {
        // certificates
        public const string AzureKeyVaultCertificate = "AzKeyVaultCertificate";
        public const string AzureKeyVaultCertificatePolicy = "AzKeyVaultCertificatePolicy";
        public const string AzureKeyVaultCertificateContact = "AzKeyVaultCertificateContact";
        public const string AzureKeyVaultCertificateIssuer = "AzKeyVaultCertificateIssuer";
        public const string AzureKeyVaultCertificateOrganizationDetails = "AzKeyVaultCertificateOrganizationDetails";
        public const string AzureKeyVaultCertificateAdministratorDetails = "AzKeyVaultCertificateAdministratorDetails";
        public const string AzureKeyVaultCertificateOperation = "AzKeyVaultCertificateOperation";

        // managed storage accounts
        public const string AzureKeyVaultManagedStorageAccount = "AzKeyVaultManagedStorageAccount";
        public const string AzureKeyVaultManagedStorageAccountKey = "AzKeyVaultManagedStorageAccountKey";
        public const string AzureKeyVaultManagedStorageSasDefinition = "AzKeyVaultManagedStorageSasDefinition";
        public const string AzureKeyVaultManagedStorageAccountSasParameters = "AzKeyVaultManagedStorageAccountSasParameters";
        public const string AzureKeyVaultManagedStorageBlobSasParameters = "AzKeyVaultManagedStorageBlobSasParameters";
        public const string AzureKeyVaultManagedStorageContainerSasParameters = "AzKeyVaultManagedStorageContainerSasParameters";
        public const string AzureKeyVaultManagedStorageFileSasParameters = "AzKeyVaultManagedStorageFileSasParameters";
        public const string AzureKeyVaultManagedStorageQueueSasParameters = "AzKeyVaultManagedStorageQueueSasParameters";
        public const string AzureKeyVaultManagedStorageShareSasParameters = "AzKeyVaultManagedStorageShareSasParameters";
        public const string AzureKeyVaultManagedStorageTableSasParameters = "AzKeyVaultManagedStorageTableSasParameters";
    }
}
