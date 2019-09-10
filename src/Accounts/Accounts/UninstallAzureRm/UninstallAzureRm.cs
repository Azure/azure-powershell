// ----------------------------------------------------------------------------------
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.UninstallAzureRm
{
    /// <summary>
    /// Cmdlet to remove AzureRM modules. 
    /// </summary>
    [Cmdlet("Uninstall", "AzureRm", SupportsShouldProcess = true)]
    [OutputType(typeof(string))]
    public class UninstallAzureRmCommand : AzureRMCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Return list of Modules removed if specified.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.SessionState != null)
            {
                var version = (this.SessionState.PSVariable.Get("PSVersionTable").Value as Hashtable)["PSVersion"];
                if (Convert.ToInt64(version.ToString().Substring(0, 1)) >= 6)
                {
                    WriteWarning("Running this cmdlet in PowerShell Core will only remove the modules from PowerShell Core. " +
                        "Please rerun this cmdlet in a PowerShell 5.1 session to remove the modules from PowerShell 5.1.");
                }
            }

            List<string> AzureModules = new List<string> { "Azure.AnalysisServices", "Azure.Storage", "AzureRM", "AzureRM.AnalysisServices",
                "AzureRM.ApiManagement", "AzureRM.ApplicationInsights", "AzureRM.Automation", "AzureRM.Backup", "AzureRM.Batch", "AzureRM.Billing",
                "AzureRM.Cdn", "AzureRM.CognitiveServices", "AzureRM.Compute", "AzureRM.Compute.Experiments", "AzureRM.Consumption",
                "AzureRM.ContainerInstance", "AzureRM.ContainerRegistry", "AzureRM.DataFactories", "AzureRM.DataFactoryV2", "AzureRM.DataLakeAnalytics",
                "AzureRM.DataLakeStore", "AzureRM.DataMigration", "AzureRM.DevTestLabs", "AzureRM.Dns", "AzureRM.EventGrid", "AzureRM.EventHub",
                "AzureRM.HDInsight", "AzureRM.Insights", "AzureRM.IotHub", "AzureRM.KeyVault", "AzureRM.LogicApp", "AzureRM.MachineLearning",
                "AzureRM.MachineLearningCompute", "AzureRM.ManagementPartner", "AzureRM.Maps", "AzureRM.MarketplaceOrdering", "AzureRM.Media",
                "AzureRM.Network", "AzureRM.NotificationHubs", "AzureRM.OperationalInsights", "AzureRM.PolicyInsights", "AzureRM.PowerBIEmbedded",
                "AzureRM.profile", "AzureRM.RecoveryServices", "AzureRM.RecoveryServices.Backup", "AzureRM.RecoveryServices.SiteRecovery",
                "AzureRM.RedisCache", "AzureRM.Relay", "AzureRM.Reservations", "AzureRM.Resources", "AzureRM.Scheduler", "AzureRM.ServerManagement",
                "AzureRM.ServiceBus", "AzureRM.ServiceFabric", "AzureRM.SignalR", "AzureRM.SiteRecovery", "AzureRM.Sql", "AzureRM.Storage",
                "AzureRM.StreamAnalytics", "AzureRM.Subscription.Preview", "AzureRM.Tags", "AzureRM.TrafficManager", "AzureRM.UsageAggregates",
                "AzureRM.Websites", "AzureRM.Websites.Experiments"};

            IDataStore dataStore = AzureSession.Instance.DataStore;
            var paths = Environment.GetEnvironmentVariable("PSModulePath").Split(Path.PathSeparator);
            foreach (var path in paths)
            {
                if (dataStore.DirectoryExists(path))
                {
                    var modules = dataStore.GetDirectories(path);
                    foreach (var module in modules)
                    {
                        var moduleName = module.Split(Path.DirectorySeparatorChar).LastOrDefault();
                        if (AzureModules.Any(x => x.Equals(moduleName, StringComparison.OrdinalIgnoreCase)))
                        {
                            if (ShouldProcess(module, string.Format(Properties.Resources.ShouldRemoveModule, moduleName)))
                            {
                                try
                                {
                                    dataStore.DeleteDirectory(module);
                                    if (PassThru)
                                    {
                                        WriteObject(moduleName);
                                    }
                                }
                                catch (UnauthorizedAccessException accessException)
                                {
                                    throw new UnauthorizedAccessException(Properties.Resources.RemoveModuleError, accessException);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
