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
        PSKeyBundle CreateKey(string vaultName, string keyName, KeyAttributes keyAttributes);

        PSKeyBundle ImportKey(string vaultName, string keyName, KeyAttributes keyAttributes, JsonWebKey webKey, bool? importToHsm);

        PSKeyBundle UpdateKey(string vaultName, string keyName, string keyVersion, KeyAttributes keyAttributes);

        PSKeyBundle GetKey(string vaultName, string keyName, string keyVersion);

        PSDeletedKeyBundle GetDeletedKey(string vaultName, string name);

        IEnumerable<PSKeyIdentityItem> GetKeys(KeyVaultObjectFilterOptions options);

        IEnumerable<PSKeyIdentityItem> GetKeyVersions(KeyVaultObjectFilterOptions options);

        IEnumerable<PSDeletedKeyIdentityItem> GetDeletedKeys(KeyVaultObjectFilterOptions options);

        PSDeletedKeyBundle DeleteKey(string vaultName, string keyName);

        void PurgeKey(string vaultName, string name);

        PSKeyBundle RecoverKey(string vaultName, string keyName);

        PSSecret SetSecret(string vaultName, string secretName, SecureString secretValue, SecretAttributes secretAttributes);

        PSSecret UpdateSecret(string vaultName, string secretName, string secretVersion, SecretAttributes secretAttributes);

        PSSecret GetSecret(string vaultName, string secretName, string secretVersion);

        PSDeletedSecret GetDeletedSecret(string vaultName, string name);

        IEnumerable<PSSecretIdentityItem> GetSecrets(KeyVaultObjectFilterOptions options);

        IEnumerable<PSSecretIdentityItem> GetSecretVersions(KeyVaultObjectFilterOptions options);

        IEnumerable<PSDeletedSecretIdentityItem> GetDeletedSecrets(KeyVaultObjectFilterOptions options);

        PSDeletedSecret DeleteSecret(string vaultName, string secretName);

        void PurgeSecret(string vaultName, string secretName);

        PSSecret RecoverSecret(string vaultName, string secretName);

        string BackupKey(string vaultName, string keyName, string outputBlobPath);

        PSKeyBundle RestoreKey(string vaultName, string inputBlobPath);

        string BackupSecret(string vaultName, string secretName, string outputBlobPath);

        PSSecret RestoreSecret(string vaultName, string inputBlobPath);

        #region Certificate actions

        Contacts SetCertificateContacts(string vaultName, Contacts contacts);

        Contacts GetCertificateContacts(string vaultName);

        CertificateBundle GetCertificate(string vaultName, string certName, string certificateVersion);

        DeletedCertificateBundle GetDeletedCertificate( string vaultName, string certName );

        IEnumerable<PSCertificateIdentityItem> GetCertificates(KeyVaultObjectFilterOptions options);

        IEnumerable<PSDeletedCertificateIdentityItem> GetDeletedCertificates( KeyVaultObjectFilterOptions options );

        IEnumerable<PSCertificateIdentityItem> GetCertificateVersions(KeyVaultObjectFilterOptions options);

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

        IEnumerable<PSCertificateIssuerIdentityItem> GetCertificateIssuers(KeyVaultObjectFilterOptions options);

        IssuerBundle SetCertificateIssuer(string vaultName, string issuerName, string issuerProvider, string accountId, SecureString apiKey, KeyVaultCertificateOrganizationDetails organizationDetails);  
              
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
