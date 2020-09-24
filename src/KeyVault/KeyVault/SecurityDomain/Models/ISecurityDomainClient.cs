using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    public interface ISecurityDomainClient
    {
        string DownloadSecurityDomain(string hsmName, IEnumerable<X509Certificate2> certificates, int required);

        X509Certificate2 DownloadSecurityDomainExchangeKey(string hsmName);

        string EncryptSecurityDomainByCert(KeyPath[] keys, SecurityDomainData data, X509Certificate2 restore_cert);

        bool RestoreSecurityDomain(string hsmName, string securityDomainData);
    }
}
