using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsLifecycle.Invoke, "AzExpressRouteCrossConnectionShutDownBgpForMigration", DefaultParameterSetName = ParameterSetNames.ByName, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType(typeof(PSExpressRouteCircuitMigrationResult))]
    public class InvokeAzureRMExpressRouteCrossConnectionShutDownBgpForMigrationCommand : ExpressRouteCrossConnectionMigrationPortActionBaseCmdlet
    {
        protected override MigrateExpressRouteCircuitHealthCheckResponse SendMigrationRequest(MigrateExpressRouteCircuitRequest request)
        {
            return ExpressRouteCrossConnectionClient.ShutDownBgpForCircuitMigration(ResourceGroupName, Name, request);
        }
    }
}