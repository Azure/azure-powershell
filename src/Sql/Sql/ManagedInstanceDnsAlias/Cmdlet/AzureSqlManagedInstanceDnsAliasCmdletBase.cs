using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Services;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Cmdlet
{
    public abstract class AzureSqlManagedInstanceDnsAliasCmdletBase : AzureSqlCmdletBase<IEnumerable<AzureSqlManagedInstanceDnsAliasModel>, AzureSqlManagedInstanceDnsAliasAdapter>
    {
        /// <summary>
        /// Initializes the model adapter.
        /// </summary>
        /// <returns></returns>
        protected override AzureSqlManagedInstanceDnsAliasAdapter InitModelAdapter()
        {
            return new AzureSqlManagedInstanceDnsAliasAdapter(DefaultProfile.DefaultContext);
        }
    }
}
