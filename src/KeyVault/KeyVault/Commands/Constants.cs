
namespace Microsoft.Azure.Commands.KeyVault
{
    public static class Constants
    {
        public const string AccountName = "AccountName";
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

        public const string KeyOpsImport = "import";
    }

    public static class CmdletNoun
    {
        // certificates
        public const string AzureKeyVaultCertificate = "AzureKeyVaultCertificate";
        public const string AzureKeyVaultCertificatePolicy = "AzureKeyVaultCertificatePolicy";
        public const string AzureKeyVaultCertificateContact = "AzureKeyVaultCertificateContact";
        public const string AzureKeyVaultCertificateIssuer = "AzureKeyVaultCertificateIssuer";
        public const string AzureKeyVaultCertificateOrganizationDetails = "AzureKeyVaultCertificateOrganizationDetails";
        public const string AzureKeyVaultCertificateAdministratorDetails = "AzureKeyVaultCertificateAdministratorDetails";
        public const string AzureKeyVaultCertificateOperation = "AzureKeyVaultCertificateOperation";

        // managed storage accounts
        public const string AzureKeyVaultManagedStorageAccount = "AzureKeyVaultManagedStorageAccount";
        public const string AzureKeyVaultManagedStorageAccountKey = "AzureKeyVaultManagedStorageAccountKey";
        public const string AzureKeyVaultManagedStorageSasDefinition = "AzureKeyVaultManagedStorageSasDefinition";
        public const string AzureKeyVaultManagedStorageAccountSasParameters = "AzureKeyVaultManagedStorageAccountSasParameters";
        public const string AzureKeyVaultManagedStorageBlobSasParameters = "AzureKeyVaultManagedStorageBlobSasParameters";
        public const string AzureKeyVaultManagedStorageContainerSasParameters = "AzureKeyVaultManagedStorageContainerSasParameters";
        public const string AzureKeyVaultManagedStorageFileSasParameters = "AzureKeyVaultManagedStorageFileSasParameters";
        public const string AzureKeyVaultManagedStorageQueueSasParameters = "AzureKeyVaultManagedStorageQueueSasParameters";
        public const string AzureKeyVaultManagedStorageShareSasParameters = "AzureKeyVaultManagedStorageShareSasParameters";
        public const string AzureKeyVaultManagedStorageTableSasParameters = "AzureKeyVaultManagedStorageTableSasParameters";

        public const string ManagedHsm = "ManagedHsm";
        public const string ManagedHsmRoleDefinition = ManagedHsm + "RoleDefinition";
        public const string ManagedHsmRoleAssignment = ManagedHsm + "RoleAssignment";
    }

    public static class ResourceType
    {
        public const string ManagedHsm = "Microsoft.KeyVault/managedHSMs";
    }
}
