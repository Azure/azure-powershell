using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Services;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Cmdlet
{
    public abstract class AzureSqlManagedInstanceLinkCmdletBase : AzureSqlCmdletBase<IEnumerable<AzureSqlManagedInstanceLinkModel>, AzureSqlManagedInstanceLinkAdapter>
    {
        /// <summary>
        /// Intializes the model adapter
        /// </summary>
        /// <returns></returns>
        protected override AzureSqlManagedInstanceLinkAdapter InitModelAdapter()
        {
            return new AzureSqlManagedInstanceLinkAdapter(DefaultContext);
        }
    }
}