using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.OperationalInsights.Models;


namespace Microsoft.Azure.Commands.OperationalInsights.Operations
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsOperations", SupportsShouldProcess = true), OutputType(typeof(IList<PSOperation>))]
    public class GetAzureOperationalInsightsOperationsCommand : OperationalInsightsBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            WriteObject(this.OperationalInsightsClient.GetPSOperations(), true);
        }
    }
}
