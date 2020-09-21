using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    public interface ISecurityDomainClient
    {
        Task<string> DownloadSecurityDomainAsync(string hsmName, IEnumerable<X509Certificate2> certificates, int required);

        Task<X509Certificate2> DownloadSecurityDomainExchangeKeyAsync(string hsmName);

        string EncryptSecurityDomainByCert(KeyPath[] keys, SecurityDomainData data, X509Certificate2 restore_cert);

        Task<bool> RestoreSecurityDomainAsync(string hsmName, string securityDomainData);
    }
}
