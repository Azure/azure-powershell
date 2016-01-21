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

using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Models;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to enable or disable telemetry collection.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureTelemetryCollection")]
    [OutputType(typeof(PSAzureProfile))]
    [CliCommandAlias("telemetry")]
    public class SetTelemetryCollectionCommand : AzureRMCmdlet
    {
        private const string EnabledParameterSet = "Enable";
        private const string DisableParameterSet = "Disable";


        [Parameter(ParameterSetName = EnabledParameterSet, 
            Mandatory = true, HelpMessage = "Enable telemetry collection.")]
        [Alias("e")]
        public SwitchParameter Enable { get; set; }

        [Parameter(ParameterSetName = DisableParameterSet,
            Mandatory = true, HelpMessage = "Disable telemetry collection.")]
        [Alias("d")]
        public SwitchParameter Disable { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            if (Enable.IsPresent)
            {
                DefaultProfile.IsTelemetryCollectionEnabled = true;
            }
            else if (Disable.IsPresent)
            {
                DefaultProfile.IsTelemetryCollectionEnabled = false;
            }

            var collectTelemetryEnv = System.Environment.GetEnvironmentVariable(AddAzureRMAccountCommand.CollectTelemetryEnvironmentVariable);
            if (!string.IsNullOrEmpty(collectTelemetryEnv))
            {
                bool collectTelemetry = false;
                if (bool.TryParse(collectTelemetryEnv, out collectTelemetry))
                {
                    throw new PSInvalidOperationException(
                            $"Environment variable '{AddAzureRMAccountCommand.CollectTelemetryEnvironmentVariable}' is already to set to {collectTelemetryEnv}. This environment variable should be removed before executing the command.");
                }
            }

            DefaultProfile.Save();
            WriteObject((PSAzureProfile)DefaultProfile);
        }        
    }
}
