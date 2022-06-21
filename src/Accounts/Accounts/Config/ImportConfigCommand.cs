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

using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.PowerShell.Common.Config;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    [Cmdlet("Import", AzureRMConstants.AzureRMPrefix + "Config", SupportsShouldProcess = true)]
    [CmdletPreview(ConfigCommandBase.PreviewMessage)]
    [OutputType(typeof(bool))]
    public class ImportConfigCommand : AzureRMCmdlet
    {
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Specifies the path to configuration saved by using Export-AzConfig.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(HelpMessage = "Returns a boolean value indicating success or failure.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Path = ResolveUserPath(Path);
            WriteDebugWithTimestamp($"[{nameof(ImportConfigCommand)}] Importing configs from {Path}.");
            base.ConfirmAction($"Import configs from config file", Path, () =>
            {
                AzureSession.Instance.TryGetComponent<IConfigManager>(nameof(IConfigManager), out var configManager);
                new JsonConfigHelper(configManager.ConfigFilePath, AzureSession.Instance.DataStore).ImportConfigFile(Path);
                WriteDebugWithTimestamp($"[{nameof(ImportConfigCommand)}] Configs are imported from {Path} successfully. Rebuilding config manager.");
                configManager.BuildConfig();
                WriteDebugWithTimestamp($"[{nameof(ImportConfigCommand)}] Rebuilt config manager.");
                if (PassThru)
                {
                    WriteObject(true);
                }
            });
        }
    }
}
