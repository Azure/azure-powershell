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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.AzureRmAlias
{
    /// <summary>
    /// Cmdlet to clear default options. 
    /// </summary>
    [Cmdlet("Disable", "AzureRmAlias", SupportsShouldProcess = true)]
    [OutputType(typeof(string))]
    public class DisableAzureRmAlias : AzureRMCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Indicates what scope aliases should be disabled for.  Default is 'Process'")]
        [ValidateSet("Process", "CurrentUser", "LocalMachine")]
        public string Scope { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indicates which modules to disable aliases for. If none are specified, default is all enabled modules.")]
        public string[] Module { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If specified, cmdlet will return all disabled aliases")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            Dictionary<string, object> mapping = Mappings.GetCaseInsensitiveMapping();

            // If no modules are specified, disable all aliases
            if (Module == null)
            {
                DisableLocalAliases(mapping.Keys.ToArray(), mapping);
            }
            else
            {
                DisableLocalAliases(Module, mapping);
            }

            // Set path to user profile based on the Scope
            string userprofile = AliasHelper.GetProfilePath(Scope, SessionState);

            if (Scope != null && (Scope.Equals("CurrentUser") || Scope.Equals("LocalMachine")))
            {
                if (AzureSession.Instance.DataStore.FileExists(userprofile))
                {
                    var helper = new AliasHelper();
                    helper.RemoveAliasesInProfile(userprofile, Module, mapping);
                }
            }
        }

        public void DisableLocalAliases(string[] modulesToDisable, Dictionary<string, object> mapping)
        {
            foreach (var module in modulesToDisable)
            {
                if (mapping.ContainsKey(module))
                {
                    Dictionary<string, string> modulemapping =
                        (Dictionary<string, string>)JsonConvert.DeserializeObject(mapping[module].ToString(), typeof(Dictionary<string, string>));
                    foreach (var name in modulemapping.Keys)
                    {
                        // For every alias, remove pairing in the Alias provider if it exists
                        if (SessionState.PSVariable.GetValue("Alias:" + modulemapping[name]) != null)
                        {
                            SessionState.PSVariable.Remove("Alias:" + modulemapping[name]);
                            if (PassThru)
                            {
                                WriteObject("Removed: " + modulemapping[name] + " : " + name);
                            }
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
