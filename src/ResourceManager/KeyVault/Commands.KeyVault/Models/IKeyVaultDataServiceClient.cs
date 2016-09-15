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

using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public interface IKeyVaultDataServiceClient
    {
        KeyBundle CreateKey(string vaultName, string keyName, KeyAttributes keyAttributes);

        KeyBundle ImportKey(string vaultName, string keyName, KeyAttributes keyAttributes, JsonWebKey webKey, bool? importToHsm);

        KeyBundle UpdateKey(string vaultName, string keyName, string keyVersion, KeyAttributes keyAttributes);

        KeyBundle GetKey(string vaultName, string keyName, string keyVersion);

        IEnumerable<KeyIdentityItem> GetKeys(KeyVaultObjectFilterOptions options);

        IEnumerable<KeyIdentityItem> GetKeyVersions(KeyVaultObjectFilterOptions options);

        KeyBundle DeleteKey(string vaultName, string keyName);

        Secret SetSecret(string vaultName, string secretName, SecureString secretValue, SecretAttributes secretAttributes);

        Secret UpdateSecret(string vaultName, string secretName, string secretVersion, SecretAttributes secretAttributes);

        Secret GetSecret(string vaultName, string secretName, string secretVersion);

        IEnumerable<SecretIdentityItem> GetSecrets(KeyVaultObjectFilterOptions options);

        IEnumerable<SecretIdentityItem> GetSecretVersions(KeyVaultObjectFilterOptions options);

        Secret DeleteSecret(string vaultName, string secretName);

        string BackupKey(string vaultName, string keyName, string outputBlobPath);

        KeyBundle RestoreKey(string vaultName, string inputBlobPath);

        #region Certificate actions

        Contacts SetCertificateContacts(string vaultName, Contacts contacts);

        Contacts GetCertificateContacts(string vaultName);

        CertificateBundle GetCertificate(string vaultName, string certName, string certificateVersion);

        IEnumerable<CertificateIdentityItem> GetCertificates(KeyVaultObjectFilterOptions options);

        IEnumerable<CertificateIdentityItem> GetCertificateVersions(KeyVaultObjectFilterOptions options);

        CertificateBundle MergeCertificate(string vaultName, string certName, X509Certificate2Collection certs, IDictionary<string, string> tags);

        CertificateBundle ImportCertificate(string vaultName, string certName, string base64CertColl, SecureString certPassword, IDictionary<string, string> tags);

        CertificateBundle ImportCertificate(string vaultName, string certName, X509Certificate2Collection certificateCollection, IDictionary<string, string> tags);

        CertificateBundle DeleteCertificate(string vaultName, string certName);

        CertificateOperation EnrollCertificate(string vaultName, string certificateName, CertificatePolicy certificatePolicy, IDictionary<string, string> tags);

        CertificateBundle UpdateCertificate(string vaultName, string certificateName, string certificateVersion, CertificateAttributes certificateAttributes, IDictionary<string, string> tags);

        CertificateOperation GetCertificateOperation(string vaultName, string certificateName);

        CertificateOperation DeleteCertificateOperation(string vaultName, string certificateName);

        CertificateOperation CancelCertificateOperation(string vaultName, string certificateName);

        CertificatePolicy GetCertificatePolicy(string vaultName, string certificateName);

        CertificatePolicy UpdateCertificatePolicy(string vaultName, string certificateName, CertificatePolicy certificatePolicy);

        IssuerBundle GetCertificateIssuer(string vaultName, string issuerName);

        IEnumerable<CertificateIssuerIdentityItem> GetCertificateIssuers(KeyVaultObjectFilterOptions options);

        IssuerBundle SetCertificateIssuer(string vaultName, string issuerName, string issuerProvider, string accountId, SecureString apiKey, KeyVaultCertificateOrganizationDetails organizationDetails);  
              
        IssuerBundle DeleteCertificateIssuer(string vaultName, string issuerName);
        
        #endregion
    }
}
