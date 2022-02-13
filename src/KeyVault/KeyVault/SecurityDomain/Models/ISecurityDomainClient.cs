using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    public interface ISecurityDomainClient
    {
        string DownloadSecurityDomain(string hsmName, IEnumerable<X509Certificate2> certificates, int quorum, CancellationToken cancellationToken);

        X509Certificate2 DownloadSecurityDomainExchangeKey(string hsmName, CancellationToken cancellationToken);

        PlaintextList DecryptSecurityDomain(SecurityDomainData data, KeyPath[] paths);

        SecurityDomainRestoreData EncryptForRestore(PlaintextList plaintextList, X509Certificate2 cert);

        void RestoreSecurityDomain(string hsmName, SecurityDomainRestoreData securityDomainData, CancellationToken cancellationToken);
    }
}
