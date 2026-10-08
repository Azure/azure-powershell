using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsLifecycle.Invoke, "AzExpressRouteCrossConnectionRestoreBgpForMigration", DefaultParameterSetName = ParameterSetNames.ByName, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType(typeof(PSExpressRouteCircuitMigrationResult))]
    public class InvokeAzureRMExpressRouteCrossConnectionRestoreBgpForMigrationCommand : ExpressRouteCrossConnectionMigrationPortActionBaseCmdlet
    {
        protected override MigrateExpressRouteCircuitHealthCheckResponse SendMigrationRequest(MigrateExpressRouteCircuitRequest request)
        {
            return ExpressRouteCrossConnectionClient.RestoreBgpForCircuitMigration(ResourceGroupName, Name, request);
        }
    }
}