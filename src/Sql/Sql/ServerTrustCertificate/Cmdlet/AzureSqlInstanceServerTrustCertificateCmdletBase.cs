using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Model;
using Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Services;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Cmdlet
{
    public abstract class AzureSqlInstanceServerTrustCertificateCmdletBase : AzureSqlCmdletBase<IEnumerable<AzureSqlInstanceServerTrustCertificateModel>, AzureSqlInstanceServerTrustCertificateAdapter>
    {
        /// <summary>
        /// Intializes the model adapter
        /// </summary>
        /// <returns></returns>
        protected override AzureSqlInstanceServerTrustCertificateAdapter InitModelAdapter()
        {
            return new AzureSqlInstanceServerTrustCertificateAdapter(DefaultContext);
        }
    }
}
