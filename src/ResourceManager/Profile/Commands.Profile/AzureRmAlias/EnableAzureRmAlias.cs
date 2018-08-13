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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Text.RegularExpressions;
using System.Linq;

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
                        SessionState.PSVariable.Set("Alias:" + modulemapping[name], name);
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
                            SessionState.PSVariable.Set("Alias:" + modulemapping[name], name);
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
                using (System.Management.Automation.PowerShell PowerShellInstance = System.Management.Automation.PowerShell.Create())
                {
                    PowerShellInstance.AddScript("if (!(Test-Path '" + userprofile + "')) { New-Item '" + userprofile + "' -ItemType file -Force }");
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

                    string filecontent = "";
                    string originalText = System.IO.File.ReadAllText(userprofile.ToString());
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
                                var moduleList = Module.ToList();
                                if (!moduleList.Contains(match.ToString().Substring(0, match.ToString().Length - 1)))
                                {
                                    moduleList.Add(match.ToString().Substring(0, match.ToString().Length - 1));
                                }
                                Module = moduleList.ToArray();
                                match = match.NextMatch();
                            }
                        }
                    }

                    filecontent = "\"#Begin Azure PowerShell alias import" + Environment.NewLine + "`$error.clear()" + Environment.NewLine + "Import-Module Az.Profile" + 
                        Environment.NewLine + "if (!`$error) { " + Environment.NewLine;
                    if (Module == null)
                    {
                        foreach (var name in mapping.Keys)
                        {
                            filecontent += "    Enable-AzureRmAlias -Module " + name + "; " + Environment.NewLine;
                        }
                    }

                    else
                    {
                        foreach (var name in Module)
                        {
                            if (mapping.ContainsKey(name))
                            {
                                filecontent += "    Enable-AzureRmAlias -Module " + name + "; " + Environment.NewLine;
                            }
                        }
                    }

                    filecontent += "}" + Environment.NewLine + "#End Azure PowerShell alias import";
                    PowerShellInstance.AddScript("Set-Content -Path '" + userprofile + "' -Value " + filecontent + "\"");
                    PSOutput = PowerShellInstance.Invoke();

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
