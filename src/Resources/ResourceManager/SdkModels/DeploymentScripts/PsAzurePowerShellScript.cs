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

using Microsoft.Azure.Management.ResourceManager.Models;
using System.Xml;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PsAzurePowerShellScript : PsDeploymentScript
    {
        public string AzPowerShellVersion { get; set; }

        internal static PsAzurePowerShellScript ToPsAzurePowerShellScript(AzurePowerShellScript script)
        {
            return new PsAzurePowerShellScript
            {
                Name = script.Name,
                Type = script.Type,
                Id = script.Id,
                Identity = script.Identity,
                Location = script.Location,
                Tags = script.Tags,
                CleanupPreference = script.CleanupPreference,
                ProvisioningState = script.ProvisioningState,
                Status = script.Status,
                Outputs = script.Outputs,
                PrimaryScriptUri = script.PrimaryScriptUri,
                SupportingScriptUris = script.SupportingScriptUris,
                ScriptContent = script.ScriptContent,
                Arguments = script.Arguments,
                EnvironmentVariables = script.EnvironmentVariables,
                ForceUpdateTag = script.ForceUpdateTag,
                RetentionInterval = XmlConvert.ToString(script.RetentionInterval),
                Timeout = script.Timeout.HasValue ? XmlConvert.ToString(script.Timeout.Value) : null,
                AzPowerShellVersion = script.AzPowerShellVersion,
                ScriptKind = "AzurePowerShell"
            };
        }
    }
}