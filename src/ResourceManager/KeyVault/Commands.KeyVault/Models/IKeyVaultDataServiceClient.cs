// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public interface IKeyVaultDataServiceClient
    {
        PSKeyVaultKey CreateKey(string vaultName, string keyName, PSKeyVaultKeyAttributes keyAttributes);

        PSKeyVaultKey ImportKey(string vaultName, string keyName, PSKeyVaultKeyAttributes keyAttributes, JsonWebKey webKey, bool? importToHsm);

        PSKeyVaultKey UpdateKey(string vaultName, string keyName, string keyVersion, PSKeyVaultKeyAttributes keyAttributes);

        PSKeyVaultKey GetKey(string vaultName, string keyName, string keyVersion);

        PSDeletedKeyVaultKey GetDeletedKey(string vaultName, string name);

        IEnumerable<PSKeyVaultKeyIdentityItem> GetKeys(KeyVaultObjectFilterOptions options);

        IEnumerable<PSKeyVaultKeyIdentityItem> GetKeyVersions(KeyVaultObjectFilterOptions options);

        IEnumerable<PSDeletedKeyVaultKeyIdentityItem> GetDeletedKeys(KeyVaultObjectFilterOptions options);

        PSDeletedKeyVaultKey DeleteKey(string vaultName, string keyName);

        void PurgeKey(string vaultName, string name);

        PSKeyVaultKey RecoverKey(string vaultName, string keyName);

        PSKeyVaultSecret SetSecret(string vaultName, string secretName, SecureString secretValue, PSKeyVaultSecretAttributes secretAttributes);

        PSKeyVaultSecret UpdateSecret(string vaultName, string secretName, string secretVersion, PSKeyVaultSecretAttributes secretAttributes);

        PSKeyVaultSecret GetSecret(string vaultName, string secretName, string secretVersion);

        PSDeletedKeyVaultSecret GetDeletedSecret(string vaultName, string name);

        IEnumerable<PSKeyVaultSecretIdentityItem> GetSecrets(KeyVaultObjectFilterOptions options);

        IEnumerable<PSKeyVaultSecretIdentityItem> GetSecretVersions(KeyVaultObjectFilterOptions options);

        IEnumerable<PSDeletedKeyVaultSecretIdentityItem> GetDeletedSecrets(KeyVaultObjectFilterOptions options);

        PSDeletedKeyVaultSecret DeleteSecret(string vaultName, string secretName);

        void PurgeSecret(string vaultName, string secretName);

        PSKeyVaultSecret RecoverSecret(string vaultName, string secretName);

        string BackupKey(string vaultName, string keyName, string outputBlobPath);

        PSKeyVaultKey RestoreKey(string vaultName, string inputBlobPath);

        string BackupSecret(string vaultName, string secretName, string outputBlobPath);

        PSKeyVaultSecret RestoreSecret(string vaultName, string inputBlobPath);

        #region Certificate actions

        Contacts SetCertificateContacts(string vaultName, Contacts contacts);

        Contacts GetCertificateContacts(string vaultName);

        CertificateBundle GetCertificate(string vaultName, string certName, string certificateVersion);

        DeletedCertificateBundle GetDeletedCertificate( string vaultName, string certName );

        IEnumerable<PSKeyVaultCertificateIdentityItem> GetCertificates(KeyVaultObjectFilterOptions options);

        IEnumerable<PSDeletedKeyVaultCertificateIdentityItem> GetDeletedCertificates( KeyVaultObjectFilterOptions options );

        IEnumerable<PSKeyVaultCertificateIdentityItem> GetCertificateVersions(KeyVaultObjectFilterOptions options);

        CertificateBundle MergeCertificate(string vaultName, string certName, X509Certificate2Collection certs, IDictionary<string, string> tags);

        CertificateBundle ImportCertificate(string vaultName, string certName, string base64CertColl, SecureString certPassword, IDictionary<string, string> tags);

        CertificateBundle ImportCertificate(string vaultName, string certName, X509Certificate2Collection certificateCollection, IDictionary<string, string> tags);

        DeletedCertificateBundle DeleteCertificate(string vaultName, string certName);

        void PurgeCertificate( string vaultName, string certName );

        CertificateBundle RecoverCertificate( string vaultName, string certName );

        CertificateOperation EnrollCertificate(string vaultName, string certificateName, CertificatePolicy certificatePolicy, IDictionary<string, string> tags);

        CertificateBundle UpdateCertificate(string vaultName, string certificateName, string certificateVersion, CertificateAttributes certificateAttributes, IDictionary<string, string> tags);

        CertificateOperation GetCertificateOperation(string vaultName, string certificateName);

        CertificateOperation DeleteCertificateOperation(string vaultName, string certificateName);

        CertificateOperation CancelCertificateOperation(string vaultName, string certificateName);

        CertificatePolicy GetCertificatePolicy(string vaultName, string certificateName);

        CertificatePolicy UpdateCertificatePolicy(string vaultName, string certificateName, CertificatePolicy certificatePolicy);

        IssuerBundle GetCertificateIssuer(string vaultName, string issuerName);

        IEnumerable<PSKeyVaultCertificateIssuerIdentityItem> GetCertificateIssuers(KeyVaultObjectFilterOptions options);

        IssuerBundle SetCertificateIssuer(string vaultName, string issuerName, string issuerProvider, string accountId, SecureString apiKey, PSKeyVaultCertificateOrganizationDetails organizationDetails);  
              
        IssuerBundle DeleteCertificateIssuer(string vaultName, string issuerName);
        
        #endregion

        #region Managed Storage actions
        IEnumerable<ManagedStorageAccountListItem> GetManagedStorageAccounts( KeyVaultObjectFilterOptions options );

        ManagedStorageAccount GetManagedStorageAccount( string vaultName, string managedStorageAccountName );

        ManagedStorageAccount SetManagedStorageAccount( string vaultName, string managedStorageAccountName, string storageResourceId, string activeKeyName, bool? autoRegenerateKey, TimeSpan? regenerationPeriod, ManagedStorageAccountAttributes managedStorageAccountAttributes, Hashtable tags );

        ManagedStorageAccount UpdateManagedStorageAccount( string vaultName, string managedStorageAccountName, string activeKeyName, bool? autoRegenerateKey, TimeSpan? regenerationPeriod, ManagedStorageAccountAttributes managedStorageAccountAttributes, Hashtable tags );

        ManagedStorageAccount DeleteManagedStorageAccount( string vaultName, string managedStorageAccountName );

        ManagedStorageAccount RegenerateManagedStorageAccountKey( string vaultName, string managedStorageAccountName, string keyName );

        ManagedStorageSasDefinition GetManagedStorageSasDefinition( string vaultName, string managedStorageAccountName, string sasDefinitionName );

        IEnumerable<ManagedStorageSasDefinitionListItem> GetManagedStorageSasDefinitions( KeyVaultStorageSasDefinitiontFilterOptions options );

        ManagedStorageSasDefinition SetManagedStorageSasDefinition( string vaultName, string managedStorageAccountName, string sasDefinitionName, IDictionary<string, string> parameters, ManagedStorageSasDefinitionAttributes sasDefinitionAttributes, Hashtable tags );

        ManagedStorageSasDefinition DeleteManagedStorageSasDefinition( string vaultName, string managedStorageAccountName, string sasDefinitionName );
        #endregion
    }
}
