using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network.NetworkWatcher.ConnectionMonitor
{
    [Cmdlet("Migrate", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherClassicConnectionMonitor", SupportsShouldProcess = true, DefaultParameterSetName = "SetByName"), OutputType(typeof(PSConnectionMonitorResultV1), typeof(PSConnectionMonitorResultV2))]
    public class MigrateNetworkWatcherClassicConnectionMonitor : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = "SetByName")]
        [ResourceNameCompleter("Microsoft.Network/networkWatchers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string NetworkWatcherName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = "SetByName")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ConnectionMonitorName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The classic connection monitor name.",
            ParameterSetName = "SetByName")]
        [ResourceNameCompleter("Microsoft.Network/networkWatchers/connectionMonitors", "ResourceGroupName", "NetworkWatcherName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            string connectionMonitorName = this.Name;
            string resourceGroupName = this.ResourceGroupName;
            string networkWatcherName = this.NetworkWatcherName;

            if (ShouldGetByName(resourceGroupName, connectionMonitorName))
            {
                var connectionMonitorResult = this.ConnectionMonitors.Get(resourceGroupName, networkWatcherName, connectionMonitorName);

                if (connectionMonitorResult != null)
                {
                    if (connectionMonitorResult.ConnectionMonitorType.Equals(ConnectionMonitorTypeV2, StringComparison.OrdinalIgnoreCase))
                    {
                        WriteInformation($"This Connection Monitor is already V2.\n", new string[] { "PSHOST" });
                    }
                    else
                    {
                        PSConnectionMonitorResultV2 PSConnectionMonitorResultV2 = MapConnectionMonitorResultToPSConnectionMonitorResultV2(connectionMonitorResult);
                        MNM.ConnectionMonitor connectionMonitor = this.PopulateConnectionMonitorParametersFromV2Request
                            (PSConnectionMonitorResultV2.TestGroups.ToArray(), PSConnectionMonitorResultV2.Outputs.ToArray(),
                            PSConnectionMonitorResultV2.Notes);
                        if (connectionMonitor != null)
                        {
                            connectionMonitor.Location = PSConnectionMonitorResultV2.Location;
                            connectionMonitor.Tags = PSConnectionMonitorResultV2.Tags;
                            this.ConnectionMonitors.CreateOrUpdate(resourceGroupName, networkWatcherName, connectionMonitorName, connectionMonitor, "true");
                        }

                        PSConnectionMonitorResult psConnectionMonitorResult = this.GetConnectionMonitor(resourceGroupName, networkWatcherName, this.Name, true);
                        WriteInformation($"Migration is successfully.\n", new string[] { "PSHOST" });
                        WriteObject(psConnectionMonitorResult);
                    }
                }
                else
                {
                    WriteInformation($"No Connection Monitor found.", new string[] { "PSHOST" });
                }
            }
        }

        private const string ConnectionMonitorTypeV1 = "SingleSourceDestination";
        private const string ConnectionMonitorTypeV2 = "MultiEndpoint";
    }
}
