using Azure.Security.KeyVault.Keys;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.KeyVault.Models;
using Org.BouncyCastle.X509;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault.Track2Models
{
    internal class Track2KeyVaultDataServiceClient : IKeyVaultDataServiceClient
    {
        public Track2KeyVaultDataServiceClient(IAuthenticationFactory authFactory, IAzureContext context)
        {
            _authFactory = authFactory ?? throw new ArgumentNullException(nameof(authFactory));
            _context = context ?? throw new ArgumentNullException(nameof(context));

            if (context.Environment == null)
            {
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidAzureEnvironment);
            }
        }

        private IAuthenticationFactory _authFactory;
        private IAzureContext _context;

        /// <summary>
        /// For lazy instanciating. Please use properties instead of fields.
        /// </summary>
        private Track2VaultClient VaultClient => _vaultClient ?? (_vaultClient = new Track2VaultClient(_authFactory, _context));
        private Track2HsmClient HsmClient => _hsmClient ?? (_hsmClient = new Track2HsmClient(_authFactory, _context));
        private Track2VaultClient _vaultClient;
        private Track2HsmClient _hsmClient;

        #region KeyVault key actions
        public string BackupKey(string vaultName, string keyName, string outputBlobPath)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultKey CreateKey(string vaultName, string keyName, PSKeyVaultKeyAttributes keyAttributes, int? size, string curveName)
        {
            return VaultClient.CreateKey(vaultName, keyName, keyAttributes, size, curveName);
        }

        public PSKeyOperationResult Decrypt(string vaultName, string keyName, string version, byte[] value, string encryptAlgorithm)
        {
            return VaultClient.Decrypt(vaultName, keyName, version, value, encryptAlgorithm);
        }

        public PSDeletedKeyVaultKey DeleteKey(string vaultName, string keyName)
        {
            throw new NotImplementedException();
        }

        public PSKeyOperationResult Encrypt(string vaultName, string keyName, string version, byte[] value, string encryptAlgorithm)
        {
            return VaultClient.Encrypt(vaultName, keyName, version, value, encryptAlgorithm);
        }

        public PSDeletedKeyVaultKey GetDeletedKey(string vaultName, string keyName)
        {
            return VaultClient.GetDeletedKey(vaultName, keyName);
        }

        public IEnumerable<PSDeletedKeyVaultKeyIdentityItem> GetDeletedKeys(KeyVaultObjectFilterOptions options)
        {
            return VaultClient.GetDeletedKeys(options.VaultName);
        }


        public PSKeyVaultKey GetKey(string vaultName, string keyName, string keyVersion)
        {
            return VaultClient.GetKey(vaultName, keyName, keyVersion);
        }

        public IEnumerable<PSKeyVaultKeyIdentityItem> GetKeys(KeyVaultObjectFilterOptions options)
        {
            return VaultClient.GetKeys(options.VaultName);
        }

        public IEnumerable<PSKeyVaultKeyIdentityItem> GetKeyVersions(KeyVaultObjectFilterOptions options)
        {
            return VaultClient.GetKeyVersions(options.VaultName, options.Name);
        }

        public PSKeyVaultKey ImportKey(string vaultName, string keyName, PSKeyVaultKeyAttributes keyAttributes, Microsoft.Azure.KeyVault.WebKey.JsonWebKey webKey, bool? importToHsm)
        {
            throw new NotImplementedException();
        }

        public PSKeyOperationResult UnwrapKey(string vaultName, string keyName, string keyVersion, byte[] value, string wrapAlgorithm)
        {
            return VaultClient.UnwrapKey(vaultName, keyName, keyVersion, wrapAlgorithm, value);
        }

        public PSKeyOperationResult WrapKey(string vaultName, string keyName, string keyVersion, byte[] wrapKey, string wrapAlgorithm)
        {
            return VaultClient.WrapKey(vaultName, keyName, keyVersion, wrapAlgorithm, wrapKey);
        }

        public void PurgeKey(string vaultName, string name)
        {
            throw new NotImplementedException();
        }
        public PSKeyVaultKey RecoverKey(string vaultName, string keyName)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultKey RestoreKey(string vaultName, string inputBlobPath)
        {
            throw new NotImplementedException();
        }

        public byte[] GetRandomNumber()
        {
            throw new NotImplementedException();
        }

        #region Key rotation
        public PSKeyVaultKey RotateKey(string vaultName, string keyName)
        {
            return VaultClient.RotateKey(vaultName, keyName);
        }

        public PSKeyRotationPolicy GetKeyRotationPolicy(string vaultName, string keyName)
        {
            return VaultClient.GetKeyRotationPolicy(vaultName, keyName);
        }

        public PSKeyRotationPolicy SetKeyRotationPolicy(PSKeyRotationPolicy psKeyRotationPolicy)
        {
            return VaultClient.SetKeyRotationPolicy(psKeyRotationPolicy);
        }
        #endregion

        public PSKeyVaultKey UpdateKey(string vaultName, string keyName, string keyVersion, PSKeyVaultKeyAttributes keyAttributes)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Certificate actions
        public string BackupCertificate(string vaultName, string certificateName, string outputBlobPath)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultCertificate UpdateCertificate(string vaultName, string certificateName, string certificateVersion, CertificateAttributes certificateAttributes, IDictionary<string, string> tags)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultCertificatePolicy UpdateCertificatePolicy(string vaultName, string certificateName, CertificatePolicy certificatePolicy)
        {
            throw new NotImplementedException();
        }


        public PSKeyVaultCertificateOperation CancelCertificateOperation(string vaultName, string certificateName)
        {
            throw new NotImplementedException();
        }

        public PSDeletedKeyVaultCertificate DeleteCertificate(string vaultName, string certName)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultCertificateIssuer DeleteCertificateIssuer(string vaultName, string issuerName)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultCertificateOperation DeleteCertificateOperation(string vaultName, string certificateName)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultCertificateOperation EnrollCertificate(string vaultName, string certificateName, CertificatePolicy certificatePolicy, IDictionary<string, string> tags)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultCertificate GetCertificate(string vaultName, string certName, string certificateVersion)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PSKeyVaultCertificateContact> GetCertificateContacts(string vaultName)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultCertificateIssuer GetCertificateIssuer(string vaultName, string issuerName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PSKeyVaultCertificateIssuerIdentityItem> GetCertificateIssuers(KeyVaultObjectFilterOptions options)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultCertificateOperation GetCertificateOperation(string vaultName, string certificateName)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultCertificatePolicy GetCertificatePolicy(string vaultName, string certificateName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PSKeyVaultCertificateIdentityItem> GetCertificates(KeyVaultCertificateFilterOptions options)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PSKeyVaultCertificateIdentityItem> GetCertificateVersions(KeyVaultObjectFilterOptions options)
        {
            throw new NotImplementedException();
        }

        public PSDeletedKeyVaultCertificate GetDeletedCertificate(string vaultName, string certName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PSDeletedKeyVaultCertificateIdentityItem> GetDeletedCertificates(KeyVaultCertificateFilterOptions options)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultCertificate ImportCertificate(string vaultName, string certName, string certificate, SecureString certPassword, IDictionary<string, string> tags, string contentType = Constants.Pkcs12ContentType, PSKeyVaultCertificatePolicy certPolicy = null)
        {
            return VaultClient.ImportCertificate(vaultName, certName, Convert.FromBase64String(certificate), certPassword, tags, contentType, certPolicy);
        }

        public PSKeyVaultCertificate ImportCertificate(string vaultName, string certName, byte[] certificate, SecureString certPassword, IDictionary<string, string> tags, string contentType = Constants.Pkcs12ContentType, PSKeyVaultCertificatePolicy certPolicy = null)
        {
            return VaultClient.ImportCertificate(vaultName, certName, certificate, certPassword, tags, contentType, certPolicy);
        }

        public PSKeyVaultCertificate ImportCertificate(string vaultName, string certName, X509Certificate2Collection certificateCollection, SecureString certPassword, IDictionary<string, string> tags, string contentType = Constants.Pkcs12ContentType, PSKeyVaultCertificatePolicy certPolicy = null)
        {
            // Export contentType ref: https://github.com/Azure/azure-sdk-for-net/blob/376b04164356dc9821923b75f2223163a2701669/sdk/keyvault/Microsoft.Azure.KeyVault/src/Customized/KeyVaultClientExtensions.cs#L605
            return VaultClient.ImportCertificate(vaultName, certName, certificateCollection.Export(X509ContentType.Pfx), certPassword, tags, contentType, certPolicy);
        }

        public PSKeyVaultCertificate MergeCertificate(string vaultName, string certName, X509Certificate2Collection certs, IDictionary<string, string> tags)
        {
            // Export content ref: https://github.com/Azure/azure-sdk-for-net/blob/376b04164356dc9821923b75f2223163a2701669/sdk/keyvault/Microsoft.Azure.KeyVault/src/Customized/KeyVaultClientExtensions.cs#L634
            var X5C = new List<byte[]>();
            foreach (var cert in certs)
            {
                X5C.Add(cert.Export(X509ContentType.Cert));
            }
            return VaultClient.MergeCertificate(vaultName, certName, X5C, tags);
        }

        public PSKeyVaultCertificate MergeCertificate(string vaultName, string name, IEnumerable<byte[]> certBytes, Dictionary<string, string> tags)
        {
            return VaultClient.MergeCertificate(vaultName, name, certBytes, tags);
        }

        public void PurgeCertificate(string vaultName, string certName)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultCertificate RecoverCertificate(string vaultName, string certName)
        {
            throw new NotImplementedException();
        }
        public PSKeyVaultCertificate RestoreCertificate(string vaultName, string inputBlobPath)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<PSKeyVaultCertificateContact> SetCertificateContacts(string vaultName, IEnumerable<PSKeyVaultCertificateContact> contacts)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultCertificateIssuer SetCertificateIssuer(string vaultName, string issuerName, string issuerProvider, string accountId, SecureString apiKey, PSKeyVaultCertificateOrganizationDetails organizationDetails)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Secret actions
        public string BackupSecret(string vaultName, string secretName, string outputBlobPath)
        {
            throw new NotImplementedException();
        }

        public PSDeletedKeyVaultSecret DeleteSecret(string vaultName, string secretName)
        {
            throw new NotImplementedException();
        }

        public PSDeletedKeyVaultSecret GetDeletedSecret(string vaultName, string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PSDeletedKeyVaultSecretIdentityItem> GetDeletedSecrets(KeyVaultObjectFilterOptions options)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultSecret GetSecret(string vaultName, string secretName, string secretVersion)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PSKeyVaultSecretIdentityItem> GetSecrets(KeyVaultObjectFilterOptions options)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PSKeyVaultSecretIdentityItem> GetSecretVersions(KeyVaultObjectFilterOptions options)
        {
            throw new NotImplementedException();
        }

        public void PurgeSecret(string vaultName, string secretName)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultSecret RecoverSecret(string vaultName, string secretName)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultSecret RestoreSecret(string vaultName, string inputBlobPath)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultSecret SetSecret(string vaultName, string secretName, SecureString secretValue, PSKeyVaultSecretAttributes secretAttributes)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultSecret UpdateSecret(string vaultName, string secretName, string secretVersion, PSKeyVaultSecretAttributes secretAttributes)
        {
            throw new NotImplementedException();
        }

        #endregion Secret actions

        #region Managed storage actions
        public string BackupManagedStorageAccount(string vaultName, string managedStorageAccountName, string outputBlobPath)
        {
            throw new NotImplementedException();
        }

        public PSDeletedKeyVaultManagedStorageAccount DeleteManagedStorageAccount(string vaultName, string managedStorageAccountName)
        {
            throw new NotImplementedException();
        }

        public PSDeletedKeyVaultManagedStorageSasDefinition DeleteManagedStorageSasDefinition(string vaultName, string managedStorageAccountName, string sasDefinitionName)
        {
            throw new NotImplementedException();
        }

        public PSDeletedKeyVaultManagedStorageAccount GetDeletedManagedStorageAccount(string vaultName, string managedStorageAccountName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PSDeletedKeyVaultManagedStorageAccountIdentityItem> GetDeletedManagedStorageAccounts(KeyVaultObjectFilterOptions options)
        {
            throw new NotImplementedException();
        }

        public PSDeletedKeyVaultManagedStorageSasDefinition GetDeletedManagedStorageSasDefinition(string vaultName, string managedStorageAccountName, string sasDefinitionName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PSDeletedKeyVaultManagedStorageSasDefinitionIdentityItem> GetDeletedManagedStorageSasDefinitions(KeyVaultStorageSasDefinitiontFilterOptions options)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultManagedStorageAccount GetManagedStorageAccount(string vaultName, string managedStorageAccountName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PSKeyVaultManagedStorageAccountIdentityItem> GetManagedStorageAccounts(KeyVaultObjectFilterOptions options)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultManagedStorageSasDefinition GetManagedStorageSasDefinition(string vaultName, string managedStorageAccountName, string sasDefinitionName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PSKeyVaultManagedStorageSasDefinitionIdentityItem> GetManagedStorageSasDefinitions(KeyVaultStorageSasDefinitiontFilterOptions options)
        {
            throw new NotImplementedException();
        }

        public void PurgeManagedStorageAccount(string vaultName, string managedStorageAccountName)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultManagedStorageAccount RecoverManagedStorageAccount(string vaultName, string deletedManagedStorageAccountName)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultManagedStorageSasDefinition RecoverManagedStorageSasDefinition(string vaultname, string managedStorageAccountName, string sasDefinitionName)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultManagedStorageAccount RegenerateManagedStorageAccountKey(string vaultName, string managedStorageAccountName, string keyName)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultManagedStorageAccount RestoreManagedStorageAccount(string vaultName, string inputBlobPath)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultManagedStorageAccount SetManagedStorageAccount(string vaultName, string managedStorageAccountName, string storageResourceId, string activeKeyName, bool? autoRegenerateKey, TimeSpan? regenerationPeriod, PSKeyVaultManagedStorageAccountAttributes managedStorageAccountAttributes, Hashtable tags)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultManagedStorageSasDefinition SetManagedStorageSasDefinition(string vaultName, string managedStorageAccountName, string sasDefinitionName, string templateUri, string sasType, string validityPeriod, PSKeyVaultManagedStorageSasDefinitionAttributes sasDefinitionAttributes, Hashtable tags)
        {
            throw new NotImplementedException();
        }

        public PSKeyVaultManagedStorageAccount UpdateManagedStorageAccount(string vaultName, string managedStorageAccountName, string activeKeyName, bool? autoRegenerateKey, TimeSpan? regenerationPeriod, PSKeyVaultManagedStorageAccountAttributes managedStorageAccountAttributes, Hashtable tags)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Full backup restore
        public Uri BackupHsm(string hsmName, Uri blobStorageUri, string sasToken)
        {
            return HsmClient.BackupHsm(hsmName, blobStorageUri, sasToken).FolderUri;
        }

        public void RestoreHsm(string hsmName, Uri backupLocation, string sasToken, string backupFolder)
        {
            var backupUri = new Uri(System.IO.Path.Combine(backupLocation.ToString(), backupFolder));
            HsmClient.RestoreHsm(hsmName, backupUri, sasToken);
        }

        public void SelectiveRestoreHsm(string hsmName, string keyName, Uri backupLocation, string sasToken, string backupFolder)
        {
            var backupUri = new Uri(System.IO.Path.Combine(backupLocation.ToString(), backupFolder));
            HsmClient.SelectiveRestoreHsm(hsmName, keyName, backupUri, sasToken);
        }
        #endregion

        #region RBAC
        public PSKeyVaultRoleDefinition CreateOrUpdateHsmRoleDefinition(string hsmName, string scope, PSKeyVaultRoleDefinition role)
        {
            return HsmClient.CreateOrUpdateHsmRoleDefinition(hsmName, scope, role);
        }

        public PSKeyVaultRoleDefinition[] GetHsmRoleDefinitions(string hsmName, string scope)
        {
            return HsmClient.GetHsmRoleDefinitions(hsmName, scope);
        }

        public PSKeyVaultRoleAssignment[] GetHsmRoleAssignments(string hsmName, string scope)
        {
            return HsmClient.GetHsmRoleAssignments(hsmName, scope);
        }

        public PSKeyVaultRoleAssignment GetHsmRoleAssignment(string hsmName, string scope, string name)
        {
            return HsmClient.GetHsmRoleAssignment(hsmName, scope, name);
        }

        public PSKeyVaultRoleAssignment CreateHsmRoleAssignment(string hsmName, string scope, string roleDefinitionId, string principalId)
        {
            return HsmClient.CreateHsmRoleAssignment(hsmName, scope, roleDefinitionId, principalId);
        }

        public void RemoveHsmRoleAssignment(string hsmName, string scope, string roleAssignmentName)
        {
            HsmClient.RemoveHsmRoleAssignment(hsmName, scope, roleAssignmentName);
        }

        /// <summary>
        /// Remove a custom role definition from an HSM.
        /// </summary>
        /// <param name="hsmName"></param>
        /// <param name="scope"></param>
        /// <param name="name">Name of the role. A GUID.</param>
        public void RemoveHsmRoleDefinition(string hsmName, string scope, string name)
        {
            HsmClient.RemoveHsmRoleDefinition(hsmName, scope, name);
        }
        #endregion

        #region ManagedHsm key methods

        public string BackupManagedHsmKey(string managedHsmName, string keyName, string outputBlobPath)
        {
            return HsmClient.BackupKey(managedHsmName, keyName, outputBlobPath);
        }

        public PSKeyVaultKey CreateManagedHsmKey(string managedHsmName, string keyName, PSKeyVaultKeyAttributes keyAttributes, int? size, string curveName)
        {
            return HsmClient.CreateKey(managedHsmName, keyName, keyAttributes, size, curveName);
        }

        public PSDeletedKeyVaultKey DeleteManagedHsmKey(string managedHsmName, string keyName)
        {
            return HsmClient.DeleteKey(managedHsmName, keyName);
        }
        public PSKeyOperationResult ManagedHsmKeyDecrypt(string managedHsmName, string keyName, string version, byte[] value, string encryptAlgorithm)
        {
            return HsmClient.Decrypt(managedHsmName, keyName, version, value, encryptAlgorithm);
        }

        public PSKeyOperationResult ManagedHsmKeyEncrypt(string managedHsmName, string keyName, string version, byte[] value, string encryptAlgorithm)
        {
            return HsmClient.Encrypt(managedHsmName, keyName, version, value, encryptAlgorithm);
        }

        public PSKeyOperationResult ManagedHsmUnwrapKey(string managedHsmName, string keyName, string version, byte[] value, string wrapAlgorithm)
        {
            return HsmClient.UnwrapKey(managedHsmName, keyName, version, wrapAlgorithm, value);
        }

        public PSKeyOperationResult ManagedHsmWrapKey(string managedHsmName, string keyName, string keyVersion, byte[] wrapKey, string wrapAlgorithm)
        {
            return HsmClient.WrapKey(managedHsmName, keyName, keyVersion, wrapAlgorithm, wrapKey);
        }

        public PSKeyVaultKey UpdateManagedHsmKey(string managedHsmName, string keyName, string keyVersion, PSKeyVaultKeyAttributes keyAttributes)
        {
            return HsmClient.UpdateKey(managedHsmName, keyName, keyVersion, keyAttributes);
        }

        public PSKeyVaultKey RecoverManagedHsmKey(string managedHsmName, string keyName)
        {
            return HsmClient.RecoverKey(managedHsmName, keyName);
        }

        public PSDeletedKeyVaultKey GetManagedHsmDeletedKey(string managedHsmName, string keyName)
        {
            return HsmClient.GetDeletedKey(managedHsmName, keyName);
        }

        public IEnumerable<PSDeletedKeyVaultKeyIdentityItem> GetManagedHsmDeletedKeys(string managedHsmName)
        {
            return HsmClient.GetDeletedKeys(managedHsmName);
        }

        public PSKeyVaultKey GetManagedHsmKey(string managedHsmName, string keyName, string keyVersion)
        {
            return HsmClient.GetKey(managedHsmName, keyName, keyVersion);
        }

        public IEnumerable<PSKeyVaultKeyIdentityItem> GetManagedHsmKeys(string managedHsmName)
        {
            return HsmClient.GetKeys(managedHsmName);
        }

        public IEnumerable<PSKeyVaultKeyIdentityItem> GetManagedHsmKeyAllVersions(string managedHsmName, string keyName)
        {
            return HsmClient.GetKeyAllVersions(managedHsmName, keyName);
        }

        public PSKeyVaultKey ImportManagedHsmKey(string managedHsmName, string keyName, JsonWebKey webKey)
        {
            return HsmClient.ImportKey(managedHsmName, keyName, webKey);
        }

        public void PurgeManagedHsmKey(string managedHsmName, string keyName)
        {
            HsmClient.PurgeKey(managedHsmName, keyName);
        }

        public PSKeyVaultKey RestoreManagedHsmKey(string managedHsmName, string inputBlobPath)
        {
            return HsmClient.RestoreKey(managedHsmName, inputBlobPath);
        }

        public byte[] GetManagedHsmRandomNumber(string managedHsmName, int count)
        {
            return HsmClient.GetRandomNumberBytes(managedHsmName, count);
        }

        #endregion

        #region Key rotation
        public PSKeyVaultKey RotateManagedHsmKey(string managedHsmName, string keyName)
        {
            return HsmClient.RotateKey(managedHsmName, keyName);
        }

        public PSKeyRotationPolicy GetManagedHsmKeyRotationPolicy(string managedHsmName, string keyName)
        {
            return HsmClient.GetKeyRotationPolicy(managedHsmName, keyName);
        }

        public PSKeyRotationPolicy SetManagedHsmKeyRotationPolicy(PSKeyRotationPolicy keyRotationPolicy)
        {
            return HsmClient.SetKeyRotationPolicy(keyRotationPolicy);
        }
        #endregion

        #region Setting
        public IEnumerable<PSKeyVaultSetting> GetManagedHsmSettings(string managedHsm)
        {
            return HsmClient.GetSettings(managedHsm);
        }

        public PSKeyVaultSetting GetManagedHsmSetting(string managedHsm, string settingName)
        {
            return HsmClient.GetSetting(managedHsm, settingName);
        }

        public PSKeyVaultSetting UpdateManagedHsmSetting(PSKeyVaultSetting psSettingParams)
        {
            return HsmClient.UpdateSetting(psSettingParams);
        }
        #endregion

    }
}