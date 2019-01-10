// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the 'License');
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an 'AS IS' BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.ResourceManager.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Linq;
using Microsoft.Azure.Commands.Profile.Properties;

namespace Microsoft.Azure.Commands.Profile.AzureRmAlias
{
    /// <summary>
    /// Cmdlet to clear default options. 
    /// </summary>
    [Cmdlet("Enable", "AzureRmAlias", SupportsShouldProcess = true)]
    [OutputType(typeof(string))]
    public class EnableAzureRmAlias : AzureRMCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Indicates what scope aliases should be enabled for.  Default is 'Local'")]
        [ValidateSet("Local", "Process", "CurrentUser", "LocalMachine")]
        public string Scope { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indicates which modules to enable aliases for. If none are specified, default is all modules.")]
        public string[] Module { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If specified, cmdlet will return all aliases enabled")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            Dictionary<string, object> mapping = Mappings.GetCaseInsensitiveMapping();

            // If no modules are specified, enable all aliases
            if (Module == null)
            {
                EnableLocalAliases(mapping.Keys.ToArray(), mapping);
            }
            else
            {
                EnableLocalAliases(Module, mapping);
            }

            // Set path to user profile based on the Scope
            string userprofile = AliasHelper.GetProfilePath(Scope, SessionState);

            if (Scope != null && (Scope.Equals("CurrentUser") || Scope.Equals("LocalMachine")))
            {
                var helper = new AliasHelper();
                helper.AddAliasesToProfile(userprofile, Module, mapping);
            }
        }

        public void EnableLocalAliases(string[] modulesToEnable, Dictionary<string, object> mapping)
        {
            foreach (var module in modulesToEnable)
            {
                if (ShouldProcess(module, Resources.AddAlias))
                {
                    if (mapping.ContainsKey(module))
                    {
                        Dictionary<string, string> modulemapping =
                            (Dictionary<string, string>)JsonConvert.DeserializeObject(mapping[module].ToString(), typeof(Dictionary<string, string>));
                        foreach (var name in modulemapping.Keys)
                        {
                            // For every alias, add a pairing in the Alias provider
                            if (Scope != null && string.Equals(Scope, "Process", StringComparison.OrdinalIgnoreCase))
                            {
                                this.InvokeCommand.InvokeScript("Set-Alias -Scope Global -Name " + modulemapping[name] + " -Value " + name);
                            }
                            else
                            {
                                SessionState.PSVariable.Set("Alias:" + modulemapping[name], name);
                            }

                            if (PassThru)
                            {
                                WriteObject(modulemapping[name] + " : " + name);
                            }
                        }
                    }
                    else
                    {
                        WriteWarning("Module '" + module + "' is not a valid Az module.");
                    }
                }
            }
        }
    }
}
