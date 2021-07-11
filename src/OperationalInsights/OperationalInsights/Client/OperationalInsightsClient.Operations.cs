using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Management.OperationalInsights;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {
        public virtual IList<PSOperation> GetPSOperations()
        {
            var allOps = this.OperationalInsightsManagementClient.Operations.List().Select(singleOp => new PSOperation(singleOp)).ToList();
            return allOps;
        }
    }
}
