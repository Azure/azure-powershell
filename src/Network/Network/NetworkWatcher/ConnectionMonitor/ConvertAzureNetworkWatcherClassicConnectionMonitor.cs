using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network.NetworkWatcher.ConnectionMonitor
{
    [Cmdlet("Convert", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherClassicConnectionMonitor", SupportsShouldProcess = true, DefaultParameterSetName = "SetByName"), OutputType(typeof(PSConnectionMonitorResultV1), typeof(PSConnectionMonitorResultV2))]
    public class ConvertAzureNetworkWatcherClassicConnectionMonitor : ConnectionMonitorBaseCmdlet
    {
        private const string ConnectionMonitorTypeV2 = "MultiEndpoint";

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
            
            ConnectionMonitorResult connectionMonitorResult = this.ConnectionMonitors.Get(this.ResourceGroupName, this.NetworkWatcherName, this.Name);
            if (connectionMonitorResult.ConnectionMonitorType.Equals(ConnectionMonitorTypeV2, StringComparison.OrdinalIgnoreCase))
            {
                WriteInformation($"This Connection Monitor is already V2.\n", new string[] { "PSHOST" });
                return;
            }

            PSConnectionMonitorResultV2 PSConnectionMonitorResultV2 = MapConnectionMonitorResultToPSConnectionMonitorResultV2(connectionMonitorResult);
            if (PSConnectionMonitorResultV2 == null)
            {
                WriteExceptionError(new NullReferenceException());
            }

            MNM.ConnectionMonitor connectionMonitor = this.PopulateConnectionMonitorParametersFromV2Request
                (PSConnectionMonitorResultV2?.TestGroups?.ToArray(), PSConnectionMonitorResultV2?.Outputs?.ToArray(),
                PSConnectionMonitorResultV2?.Notes);

            //Updating the location and tags
            connectionMonitor.Location = PSConnectionMonitorResultV2?.Location;
            connectionMonitor.Tags = PSConnectionMonitorResultV2?.Tags;
            this.ConnectionMonitors.CreateOrUpdate(this.ResourceGroupName, this.NetworkWatcherName, this.Name, connectionMonitor, "true");

            PSConnectionMonitorResult psConnectionMonitorResult = this.GetConnectionMonitor(this.ResourceGroupName, this.NetworkWatcherName, this.Name, true);
            WriteInformation($"Migration is successful.\n", new string[] { "PSHOST" });
            WriteObject(psConnectionMonitorResult);
        }
    }
}
