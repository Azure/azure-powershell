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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.PowerShell.Common.Config;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    [Cmdlet("Export", AzureRMConstants.AzureRMPrefix + "Config", SupportsShouldProcess = true)]
    [CmdletPreview(ConfigCommandBase.PreviewMessage)]
    [OutputType(typeof(bool))]
    public class ExportConfigCommand : AzureRMCmdlet
    {
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Specifies the path of the file to which to save the configs.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(HelpMessage = "Overwrites the given file if it exists.")]
        public SwitchParameter Force { get; set; }

        [Parameter(HelpMessage = "Returns a boolean value indicating success or failure.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            var dataStore = AzureSession.Instance.DataStore;
            AzureSession.Instance.TryGetComponent<IConfigManager>(nameof(IConfigManager), out var configManager);
            if (!dataStore.FileExists(configManager.ConfigFilePath))
            {
                throw new AzPSApplicationException("No configs to export. Make sure at least one config is set by `Update-AzConfig` with the `CurrentUser` scope.", ErrorKind.UserError);
            }

            Path = ResolveUserPath(Path);
            WriteDebugWithTimestamp($"[{nameof(ExportConfigCommand)}] Exporting configs to {Path}.");
            ConfirmAction(
                Force,
                $"Overwrite existing file at {Path}",
                $"Export configs to file at {Path}",
                $"all the configs at {ConfigScope.CurrentUser} scope",
                () =>
                {
                    new JsonConfigHelper(configManager.ConfigFilePath, dataStore).ExportConfigFile(Path);
                    WriteDebugWithTimestamp($"[{nameof(ExportConfigCommand)}] Configs are exported to {Path} successfully.");
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                },
                () => dataStore.FileExists(Path)); // only ask for confirmation if file exists
        }
    }
}
