// ----------------------------------------------------------------------------------
//
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

using System;
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Properties;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane
{
    /// <summary>
    /// Cmdlet to export an Analysis Services server log to file
    /// </summary>
    [Cmdlet("Export", ResourceManager.Common.AzureRMConstants.AzurePrefix + "AnalysisServicesInstanceLog", SupportsShouldProcess = true)]
    [Alias("Export-AzureAsInstanceLog", "Export-AzAsInstanceLog")]
    [OutputType(typeof(void))]
    public class ExportAzureAnalysisServerLog : AsAzureDataplaneCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Path to file to write Azure Analysis Services log")]
        [ValidateNotNullOrEmpty]
        public string OutputPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Overwrite file if exists")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Force { get; set; }

        public ExportAzureAnalysisServerLog()
        {
        }

        protected override IAzureContext DefaultContext
        {
            get
            {
                // Nothing to do with Azure Resource Management context
                return null;
            }
        }

        protected override string DataCollectionWarning
        {
            get
            {
                return Resources.ARMDataCollectionMessage;
            }
        }

        protected override void InitializeQosEvent()
        {
            // nothing to do here.
        }

        public override void ExecuteCmdlet()
        {
            if (!ShouldProcess(Instance, Resources.ExportingLogFromAnalysisServicesServer))
            {
                return;
            }

            var logfileEndpoint = string.Format(AsAzureEndpoints.LogfileEndpointPathFormat, ServerName);

            AsAzureDataplaneClient.resetHttpClient();
            using (var message = AsAzureDataplaneClient.CallGetAsync(logfileEndpoint).ConfigureAwait(false).GetAwaiter().GetResult())
            {
                message.EnsureSuccessStatusCode();
                var actionWarning = string.Format(CultureInfo.CurrentCulture, Resources.ExportingLogOverwriteWarning, OutputPath);
                if (AzureSession.Instance.DataStore.FileExists(OutputPath) && !Force.IsPresent && !ShouldContinue(actionWarning, Resources.Confirm))
                {
                    return;
                }
                AzureSession.Instance.DataStore.WriteFile(OutputPath, message.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
