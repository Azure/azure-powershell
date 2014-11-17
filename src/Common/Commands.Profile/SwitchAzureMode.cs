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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.Profile
{
    /// <summary>
    /// Switches between ServiceManagement and ResourceManager modes.
    /// </summary>
    [Cmdlet(VerbsCommon.Switch, "AzureMode")]
    public class SwitchAzureMode : AzurePSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Name of the mode to switch to. Valid values are AzureServiceManagement and AzureResourceManager")]
        [ValidateSet("AzureServiceManagement", "AzureResourceManager", IgnoreCase = false)]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = false, HelpMessage = "If specified, save the module switch at machine level")]
        public SwitchParameter Global { get; set; }

        public override void ExecuteCmdlet()
        {
            AzureModule moduleToImport = (AzureModule)Enum.Parse(typeof(AzureModule), Name, false);
            AzureModule moduleToRemove = moduleToImport == AzureModule.AzureResourceManager ? AzureModule.AzureServiceManagement : AzureModule.AzureResourceManager;
            RemoveAzureModule(FileUtilities.GetModuleName(moduleToRemove), FileUtilities.GetPSModulePathForModule(moduleToRemove));
            ImportAzureModule(FileUtilities.GetModuleName(moduleToImport), FileUtilities.GetPSModulePathForModule(moduleToImport));
        }

        private void ImportAzureModule(string name, string path)
        {
            if (!IsLoaded(name))
            {
                WriteVerbose(string.Format("Adding {0} module path to PSModulePath...", path));
                PowerShellUtilities.AddModuleToPSModulePath(path);

                WriteVerbose(string.Format("Importing {0} module...", name));
                this.ImportModule(name);

                if (Global)
                {
                    PowerShellUtilities.AddModuleToPSModulePath(path, EnvironmentVariableTarget.Machine);
                }
            }
        }

        private bool IsLoaded(string moduleName)
        {
            return this.GetLoadedModules().Exists(m => m.Name.Equals(moduleName));
        }

        private void RemoveAzureModule(string name, string path)
        {
            if (IsLoaded(name))
            {
                WriteVerbose(string.Format("Removing {0} module...", name));
                this.RemoveModule(name);

                if (name.Equals(FileUtilities.GetModuleName(AzureModule.AzureServiceManagement)))
                {
                    this.RemoveAzureAliases();
                }

                WriteVerbose(string.Format("Removing {0} module path from PSModulePath...", path));
                PowerShellUtilities.RemoveModuleFromPSModulePath(path);

                if (Global)
                {
                    PowerShellUtilities.RemoveModuleFromPSModulePath(path, EnvironmentVariableTarget.Machine);
                }
            }
        }
    }
}