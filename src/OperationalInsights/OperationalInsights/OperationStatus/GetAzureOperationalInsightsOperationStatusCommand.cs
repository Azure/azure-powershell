using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.OperationalInsights.OperationStatus
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsOperationStatus", DefaultParameterSetName = GetByNameParameterSet), OutputType(typeof(PSOperationStatus))]
    public class GetAzureOperationalInsightsOperationStatusCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet,
            HelpMessage = "The region name of operation.")]
        [LocationCompleter("Microsoft.OperationalInsights/workspaces")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet,
            HelpMessage = "The Id (Guid) of the operation.")]
        [ValidateNotNullOrEmpty]
        public string OperationId { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(this.OperationalInsightsClient.GetOperationStatus(this.OperationId, this.Location), true);
        }
    }
}
