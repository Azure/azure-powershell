using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzExpressRouteCrossConnectionMigrationInfo", DefaultParameterSetName = ParameterSetNames.ByName)]
    [OutputType(typeof(PSExpressRouteCircuitMigrationResult))]
    public class GetAzureRMExpressRouteCrossConnectionMigrationInfoCommand : ExpressRouteCrossConnectionMigrationDiagnosticBaseCmdlet
    {
        public override void Execute()
        {
            base.Execute();
            var result = ExpressRouteCrossConnectionClient.GetCircuitMigrationInfo(ResourceGroupName, Name, CreateRequest());
            WriteObject(NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteCircuitMigrationResult>(result));
        }
    }
}