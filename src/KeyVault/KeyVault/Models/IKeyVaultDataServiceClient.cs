﻿// ----------------------------------------------------------------------------------
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
using Track2Sdk = Azure.Security.KeyVault.Keys;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public interface IKeyVaultDataServiceClient
    {
        #region Key actions
        PSKeyVaultKey CreateKey(string vaultName, string keyName, PSKeyVaultKeyAttributes keyAttributes, int? size, string curveName);
       
        PSKeyVaultKey CreateManagedHsmKey(string managedHsmName, string keyName, PSKeyVaultKeyAttributes keyAttributes, int? size, string curveName);

        PSKeyVaultKey ImportKey(string vaultName, string keyName, PSKeyVaultKeyAttributes keyAttributes, JsonWebKey webKey, bool? importToHsm);

        PSKeyVaultKey ImportManagedHsmKey(string managedHsmName, string keyName, Track2Sdk.JsonWebKey webKey);

        PSKeyVaultKey UpdateKey(string vaultName, string keyName, string keyVersion, PSKeyVaultKeyAttributes keyAttributes);

        PSKeyVaultKey UpdateManagedHsmKey(string managedHsmName, string keyName, string keyVersion, PSKeyVaultKeyAttributes keyAttributes);

        PSKeyVaultKey GetKey(string vaultName, string keyName, string keyVersion);

        PSKeyVaultKey GetManagedHsmKey(string managedHsmName, string keyName, string keyVersion);

        PSDeletedKeyVaultKey GetDeletedKey(string managedHsmName, string keyName);

        PSDeletedKeyVaultKey GetManagedHsmDeletedKey(string managedHsmName, string keyName);

        IEnumerable<PSKeyVaultKeyIdentityItem> GetKeys(KeyVaultObjectFilterOptions options);

        IEnumerable<PSKeyVaultKeyIdentityItem> GetManagedHsmKeys(string managedHsmName);

        IEnumerable<PSKeyVaultKeyIdentityItem> GetKeyVersions(KeyVaultObjectFilterOptions options);

        IEnumerable<PSKeyVaultKeyIdentityItem> GetManagedHsmKeyAllVersions(string managedHsmName, string keyName);

        IEnumerable<PSDeletedKeyVaultKeyIdentityItem> GetDeletedKeys(KeyVaultObjectFilterOptions options);

        IEnumerable<PSDeletedKeyVaultKeyIdentityItem> GetManagedHsmDeletedKeys(string managedHsmName);

        PSDeletedKeyVaultKey DeleteKey(string vaultName, string keyName);

        PSDeletedKeyVaultKey DeleteManagedHsmKey(string ManagedHsm, string keyName);

        void PurgeKey(string vaultName, string name);

        void PurgeManagedHsmKey(string managedHsmName, string keyName);

        PSKeyVaultKey RecoverKey(string vaultName, string keyName);

        PSKeyVaultKey RecoverManagedHsmKey(string managedHsmName, string keyName);

        string BackupKey(string vaultName, string keyName, string outputBlobPath);

        string BackupManagedHsmKey(string managedHsmName, string keyName, string outputBlobPath);

        PSKeyVaultKey RestoreKey(string vaultName, string inputBlobPath);

        PSKeyVaultKey RestoreManagedHsmKey(string managedHsmName, string inputBlobPath);
        #endregion

        #region Secret actions
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

        string BackupSecret(string vaultName, string secretName, string outputBlobPath);

        PSKeyVaultSecret RestoreSecret(string vaultName, string inputBlobPath);
        #endregion

        #region Certificate actions

        IEnumerable<PSKeyVaultCertificateContact> SetCertificateContacts(string vaultName, IEnumerable<PSKeyVaultCertificateContact> contacts);

        IEnumerable<PSKeyVaultCertificateContact> GetCertificateContacts(string vaultName);

        PSKeyVaultCertificate GetCertificate(string vaultName, string certName, string certificateVersion);

        PSDeletedKeyVaultCertificate GetDeletedCertificate( string vaultName, string certName );

        IEnumerable<PSKeyVaultCertificateIdentityItem> GetCertificates(KeyVaultCertificateFilterOptions options);

        IEnumerable<PSDeletedKeyVaultCertificateIdentityItem> GetDeletedCertificates( KeyVaultCertificateFilterOptions options );

        IEnumerable<PSKeyVaultCertificateIdentityItem> GetCertificateVersions(KeyVaultObjectFilterOptions options);

        PSKeyVaultCertificate MergeCertificate(string vaultName, string certName, X509Certificate2Collection certs, IDictionary<string, string> tags);

        PSKeyVaultCertificate ImportCertificate(string vaultName, string certName, string base64CertColl, SecureString certPassword, IDictionary<string, string> tags);

        PSKeyVaultCertificate ImportCertificate(string vaultName, string certName, X509Certificate2Collection certificateCollection, IDictionary<string, string> tags);

        PSDeletedKeyVaultCertificate DeleteCertificate(string vaultName, string certName);

        void PurgeCertificate( string vaultName, string certName );

        PSKeyVaultCertificate RecoverCertificate( string vaultName, string certName );

        PSKeyVaultCertificateOperation EnrollCertificate(string vaultName, string certificateName, CertificatePolicy certificatePolicy, IDictionary<string, string> tags);

        PSKeyVaultCertificate UpdateCertificate(string vaultName, string certificateName, string certificateVersion, CertificateAttributes certificateAttributes, IDictionary<string, string> tags);

        PSKeyVaultCertificateOperation GetCertificateOperation(string vaultName, string certificateName);

        PSKeyVaultCertificateOperation DeleteCertificateOperation(string vaultName, string certificateName);

        PSKeyVaultCertificateOperation CancelCertificateOperation(string vaultName, string certificateName);

        PSKeyVaultCertificatePolicy GetCertificatePolicy(string vaultName, string certificateName);

        PSKeyVaultCertificatePolicy UpdateCertificatePolicy(string vaultName, string certificateName, CertificatePolicy certificatePolicy);

        PSKeyVaultCertificateIssuer GetCertificateIssuer(string vaultName, string issuerName);

        IEnumerable<PSKeyVaultCertificateIssuerIdentityItem> GetCertificateIssuers(KeyVaultObjectFilterOptions options);

        PSKeyVaultCertificateIssuer SetCertificateIssuer(string vaultName, string issuerName, string issuerProvider, string accountId, SecureString apiKey, PSKeyVaultCertificateOrganizationDetails organizationDetails);

        PSKeyVaultCertificateIssuer DeleteCertificateIssuer(string vaultName, string issuerName);

        string BackupCertificate(string vaultName, string certificateName, string outputBlobPath);

        PSKeyVaultCertificate RestoreCertificate(string vaultName, string inputBlobPath);
        #endregion

        #region Managed Storage actions
        IEnumerable<PSKeyVaultManagedStorageAccountIdentityItem> GetManagedStorageAccounts( KeyVaultObjectFilterOptions options );

        PSKeyVaultManagedStorageAccount GetManagedStorageAccount( string vaultName, string managedStorageAccountName );

        PSKeyVaultManagedStorageAccount SetManagedStorageAccount( string vaultName, string managedStorageAccountName, string storageResourceId, string activeKeyName, bool? autoRegenerateKey, TimeSpan? regenerationPeriod, PSKeyVaultManagedStorageAccountAttributes managedStorageAccountAttributes, Hashtable tags );

        PSKeyVaultManagedStorageAccount UpdateManagedStorageAccount( string vaultName, string managedStorageAccountName, string activeKeyName, bool? autoRegenerateKey, TimeSpan? regenerationPeriod, PSKeyVaultManagedStorageAccountAttributes managedStorageAccountAttributes, Hashtable tags );

        PSDeletedKeyVaultManagedStorageAccount DeleteManagedStorageAccount( string vaultName, string managedStorageAccountName );

        PSKeyVaultManagedStorageAccount RegenerateManagedStorageAccountKey( string vaultName, string managedStorageAccountName, string keyName );

        PSKeyVaultManagedStorageSasDefinition GetManagedStorageSasDefinition( string vaultName, string managedStorageAccountName, string sasDefinitionName );

        IEnumerable<PSKeyVaultManagedStorageSasDefinitionIdentityItem> GetManagedStorageSasDefinitions( KeyVaultStorageSasDefinitiontFilterOptions options );

        PSKeyVaultManagedStorageSasDefinition SetManagedStorageSasDefinition( string vaultName, string managedStorageAccountName, string sasDefinitionName, string templateUri, string sasType, string validityPeriod, PSKeyVaultManagedStorageSasDefinitionAttributes sasDefinitionAttributes, Hashtable tags );

        PSDeletedKeyVaultManagedStorageSasDefinition DeleteManagedStorageSasDefinition( string vaultName, string managedStorageAccountName, string sasDefinitionName );

        PSDeletedKeyVaultManagedStorageAccount GetDeletedManagedStorageAccount(string vaultName, string managedStorageAccountName);

        PSDeletedKeyVaultManagedStorageSasDefinition GetDeletedManagedStorageSasDefinition(string vaultName, string managedStorageAccountName, string sasDefinitionName);

        IEnumerable<PSDeletedKeyVaultManagedStorageAccountIdentityItem> GetDeletedManagedStorageAccounts(KeyVaultObjectFilterOptions options);

        IEnumerable<PSDeletedKeyVaultManagedStorageSasDefinitionIdentityItem> GetDeletedManagedStorageSasDefinitions(KeyVaultStorageSasDefinitiontFilterOptions options);

        PSKeyVaultManagedStorageAccount RecoverManagedStorageAccount(string vaultName, string deletedManagedStorageAccountName);

        PSKeyVaultManagedStorageSasDefinition RecoverManagedStorageSasDefinition(string vaultname, string managedStorageAccountName, string sasDefinitionName);

        void PurgeManagedStorageAccount(string vaultName, string managedStorageAccountName);

        string BackupManagedStorageAccount(string vaultName, string managedStorageAccountName, string outputBlobPath);

        PSKeyVaultManagedStorageAccount RestoreManagedStorageAccount(string vaultName, string inputBlobPath);

        #endregion

        #region Full backup restore
        Uri BackupHsm(string hsmName, Uri blobStorageUri, string sasToken);
        
        void RestoreHsm(string hsmName, Uri backupLocation, string sasToken, string backupFolder);
       
        void SelectiveRestoreHsm(string hsmName, string keyName, Uri backupLocation, string sasToken, string backupFolder);
        #endregion

        #region RBAC
        PSKeyVaultRoleDefinition[] GetHsmRoleDefinitions(string hsmName, string scope);
        PSKeyVaultRoleAssignment[] GetHsmRoleAssignments(string hsmName, string scope);
        PSKeyVaultRoleAssignment GetHsmRoleAssignment(string hsmName, string scope, string roleAssignmentName);
        PSKeyVaultRoleAssignment CreateHsmRoleAssignment(string hsmName, string scope, string roleDefinitionId, string principalId);
        void RemoveHsmRoleAssignment(string hsmName, string scope, string roleAssignmentName);
        #endregion
    }
}
