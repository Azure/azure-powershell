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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.AzureRmAlias
{
    /// <summary>
    /// Cmdlet to clear default options. 
    /// </summary>
    [Cmdlet("Enable","AzureRmAlias", SupportsShouldProcess = true)]
    [OutputType(typeof(Hashtable))]
    public class EnableAzureRmAlias : AzureRMCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Indicates what scope aliases should be enabled for.  Default is 'Process'")]
        [ValidateSet("Process", "CurrentUser", "LocalMachine")]
        public string Scope { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indicates which modules to enable aliases for. If none are specified, default is all modules.")]
        public string[] Module { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If specified, cmdlet will return all aliases enabled")]
        public string PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            string jsonmapping = Mappings.jsonMappings;
            Dictionary<string, object> mapping = (Dictionary<string, object>)JsonConvert.DeserializeObject(jsonmapping, typeof(Dictionary<string, object>));

            if (Module == null)
            {
                foreach (var key in mapping.Keys)
                {
                    Dictionary<string, string> modulemapping = (Dictionary<string, string>)JsonConvert.DeserializeObject(mapping[key].ToString(), typeof(Dictionary<string, string>));
                    
                    foreach (var name in modulemapping.Keys)
                    {
                        SessionState.PSVariable.Set("Alias:" + name, modulemapping[name]);
                    }
                }
            }
            else
            {
                foreach (var module in Module)
                {
                    if (mapping.ContainsKey(module))
                    {
                        Dictionary<string, string> modulemapping = 
                            (Dictionary<string, string>)JsonConvert.DeserializeObject(mapping[module].ToString(), typeof(Dictionary<string, string>));
                        foreach (var name in modulemapping.Keys)
                        {
                            SessionState.PSVariable.Set("Alias:" + name, modulemapping[name]);
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
