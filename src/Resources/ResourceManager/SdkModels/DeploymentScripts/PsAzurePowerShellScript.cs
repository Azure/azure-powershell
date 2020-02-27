using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PsAzurePowerShellScript : PsDeploymentScript
    {
        public string AzPowerShellVersion { get; set; }

        internal static PsAzurePowerShellScript ToPsAzurePowerShellScript(AzurePowerShellScript script)
        {
            return new PsAzurePowerShellScript
            {
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
                RetentionInterval = script.RetentionInterval,
                Timeout = script.Timeout,
                AzPowerShellVersion = script.AzPowerShellVersion
            };
        }
    }
}
