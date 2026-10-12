using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsDiagnostic.Test, "AzExpressRouteCrossConnectionMigration", DefaultParameterSetName = ParameterSetNames.ByName)]
    [OutputType(typeof(PSExpressRouteCircuitMigrationValidationResult))]
    public class TestAzureRMExpressRouteCrossConnectionMigrationCommand : ExpressRouteCrossConnectionMigrationDiagnosticBaseCmdlet
    {
        public override void Execute()
        {
            base.Execute();
            var result = ExpressRouteCrossConnectionClient.ValidateCircuitMigration(ResourceGroupName, Name, CreateRequest());
            WriteObject(NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteCircuitMigrationValidationResult>(result));
        }
    }
}