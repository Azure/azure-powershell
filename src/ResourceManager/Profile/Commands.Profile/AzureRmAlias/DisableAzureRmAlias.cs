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
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Profile.AzureRmAlias
{
    /// <summary>
    /// Cmdlet to clear default options. 
    /// </summary>
    [Cmdlet("Disable", "AzureRmAlias", SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class DisableAzureRmAlias : AzureRMCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Indicates what scope aliases should be disabled for.  Default is 'Process'")]
        [ValidateSet("Process", "CurrentUser", "LocalMachine")]
        public string Scope { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indicates which modules to disable aliases for. If none are specified, default is all enabled modules.")]
        public string[] Module { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If specified, cmdlet will return a boolean indicating success")]
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
                        if (SessionState.PSVariable.GetValue("Alias:" + modulemapping[name]) != null)
                        {
                            SessionState.PSVariable.Remove("Alias:" + modulemapping[name]);
                        }
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
                            if (SessionState.PSVariable.GetValue("Alias:" + modulemapping[name]) != null)
                            {
                                SessionState.PSVariable.Remove("Alias:" + modulemapping[name]);
                            }
                        }
                    }
                    else
                    {
                        WriteWarning("Module '" + module + "' is not a valid Az module.");
                    }
                }
            }

            object userprofile = "";
            if (Scope != null && Scope.Equals("CurrentUser"))
            {
                userprofile = SessionState.PSVariable.GetValue("env:USERPROFILE") + "\\Documents\\PowerShell\\profile.ps1";
            }

            else if (Scope != null && Scope.Equals("LocalMachine"))
            {
                userprofile = SessionState.PSVariable.GetValue("PSHOME") + "\\profile.ps1";
            }

            if (Scope != null && (Scope.Equals("CurrentUser") || Scope.Equals("LocalMachine")))
            {
                if (File.Exists(userprofile.ToString()))
                {
                    List<string> modulesToKeep = new List<String>();
                    string filecontent = "";
                    string originalText = File.ReadAllText(userprofile.ToString());
                    if (originalText.Contains("#Begin Azure PowerShell alias import"))
                    {
                        var splitOriginalText = originalText.Split(new string[] { "#Begin Azure PowerShell alias import", "#End Azure PowerShell alias import" }, StringSplitOptions.None);
                        filecontent += splitOriginalText[0];
                        if (splitOriginalText.Length > 2)
                        {
                            filecontent += splitOriginalText[2];
                        }

                        if (Module != null)
                        {
                            var regex = new Regex(@"Az.[a-zA-Z0-9\.]+;");
                            Match match = regex.Match(splitOriginalText[1]);
                            while (match.Success)
                            {
                                if (!Module.Contains(match.ToString().Substring(0, match.ToString().Length - 1)))
                                {
                                    modulesToKeep.Add(match.ToString().Substring(0, match.ToString().Length - 1));
                                }
                                match = match.NextMatch();
                            }
                        }
                    }

                    if (modulesToKeep.Count > 0)
                    {
                        filecontent = "#Begin Azure PowerShell alias import" + Environment.NewLine + "`$error.clear()" + Environment.NewLine + "Import-Module Az.Profile" +
                        Environment.NewLine + "if (!`$error) { " + Environment.NewLine;
                        
                        foreach (var name in modulesToKeep)
                        {
                            if (mapping.ContainsKey(name))
                            {
                                filecontent += "    Enable-AzureRmAlias -Module " + name + "; " + Environment.NewLine;
                            }
                        }

                        filecontent += "}" + Environment.NewLine + "#End Azure PowerShell alias import";
                    }

                    using (System.Management.Automation.PowerShell PowerShellInstance = System.Management.Automation.PowerShell.Create())
                    {
                        PowerShellInstance.AddScript("Set-Content -Path '" + userprofile + "' -Value \"" + filecontent + "\"");
                        Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                        if (PowerShellInstance.Streams.Error.Count > 0)
                        {
                            foreach (var error in PowerShellInstance.Streams.Error)
                            {
                                if (error.ToString().Contains("Access to the path") && error.ToString().Contains("is denied."))
                                {
                                    throw new Exception("LocalMachine scope can only be set in PowerShell administrative mode.");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
