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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Profile.AzureRmAlias
{
    public class AliasHelper
    {
        private const string STARTALIASIMPORTMARKER = "#Begin Azure PowerShell alias import";
        private const string ENDALIASIMPORTMARKER = "#End Azure PowerShell alias import";

        private IDataStore _dataStore;

        public AliasHelper(IDataStore dataStore)
        {
            _dataStore = dataStore;
            FileUtilities.DataStore = dataStore;
        }

        public AliasHelper() : this(AzureSession.Instance.DataStore)
        {
        }

        public static string GetProfilePath(string Scope, SessionState sessionState)
        {
            var userprofile = "";
            if (Scope != null && Scope.Equals("CurrentUser"))
            {
                var powershellProfile = sessionState.PSVariable.GetValue("PROFILE") as PSObject;
                if (powershellProfile == null || !powershellProfile.Members.ToList().Any(a => a.Name.Equals("CurrentUserAllHosts")))
                {
                    throw new PSInvalidOperationException(string.Format(Properties.Resources.ProfilePathNull, "PROFILE.CurrentUserAllHosts"));
                }
                userprofile = powershellProfile.Members.ToList().Where(a => a.Name.Equals("CurrentUserAllHosts")).First().Value.ToString();
            }

            else if (Scope != null && Scope.Equals("LocalMachine"))
            {
                var powershellProfile = sessionState.PSVariable.GetValue("PROFILE") as PSObject;
                if (powershellProfile == null || !powershellProfile.Members.ToList().Any(a => a.Name.Equals("AllUsersAllHosts")))
                {
                    throw new PSInvalidOperationException(string.Format(Properties.Resources.ProfilePathNull, "PROFILE.AllUsersAllHosts"));
                }
                userprofile = powershellProfile.Members.ToList().Where(a => a.Name.Equals("AllUsersAllHosts")).First().Value.ToString();
            }

            return userprofile;
        }

        public void RemoveAliasesInProfile(string userprofile, string[] Module, Dictionary<string, object> mapping)
        {
            ParseFile(userprofile, Module, out string filecontent, out List<string> modulesToKeep, add: false);

            // Add script to enable aliases to profile if there are any modules to keep
            CreateFileEntry(modulesToKeep, filecontent, userprofile, mapping);
        }

        public void AddAliasesToProfile(string userprofile, string[] Module, Dictionary<string, object> mapping)
        {
            CreateProfileIfNotExists(userprofile);

            ParseFile(userprofile, Module, out string filecontent, out List<string> modulesToKeep, add: true);

            if (Module == null)
            {
                CreateFileEntry(mapping.Keys.ToList(), filecontent, userprofile, mapping);
            }
            else
            {
                CreateFileEntry(modulesToKeep, filecontent, userprofile, mapping);
            }
        }

        public void ParseFile(string userprofile, string[] Module, out string filecontent, out List<string> modulesToKeep, bool add)
        {
            filecontent = "";
            modulesToKeep = new List<String>();
            if (add)
            {
                modulesToKeep = Module?.ToList();
            }

            
            string originalText = _dataStore.ReadFileAsText(userprofile.ToString());
            if (originalText.Contains(STARTALIASIMPORTMARKER))
            {
                // Add back profile code unrelated to Azure PowerShell aliases
                var splitOriginalText = originalText.Split(new string[] { STARTALIASIMPORTMARKER, ENDALIASIMPORTMARKER }, StringSplitOptions.None);
                filecontent += splitOriginalText[0].Trim();
                if (splitOriginalText.Length > 2)
                {
                    filecontent += Environment.NewLine + splitOriginalText[2].Trim() + Environment.NewLine;
                }

                if (Module != null)
                {
                    // Add modules currently in the profile to the list of modules to enable.
                    var regex = new Regex(@"Az\.[a-zA-Z0-9\.]+(,\s|\s-)");
                    Match match = regex.Match(splitOriginalText[1].Split(new string[] { "Import-Module Az.Accounts" }, StringSplitOptions.None)[1]);
                    while (match.Success)
                    {
                        if (add)
                        {
                            if (!modulesToKeep.Contains(match.ToString().Substring(0, match.ToString().Length - 2), StringComparer.CurrentCultureIgnoreCase))
                            {
                                modulesToKeep.Add(match.ToString().Substring(0, match.ToString().Length - 2));
                            }
                            match = match.NextMatch();
                        }
                        else
                        {
                            if (!Module.Contains(match.ToString().Substring(0, match.ToString().Length - 2), StringComparer.CurrentCultureIgnoreCase))
                            {
                                modulesToKeep.Add(match.ToString().Substring(0, match.ToString().Length - 2));
                            }
                            match = match.NextMatch();
                        }
                    }
                }
            }
            else
            {
                filecontent = originalText;
            }
        }

        public void CreateFileEntry(List<string> modulesToKeep, string filecontent, string userprofile, Dictionary<string, object> mapping)
        {
            if (modulesToKeep.Count > 0)
            {
                filecontent += STARTALIASIMPORTMARKER + Environment.NewLine + "Import-Module Az.Accounts -ErrorAction SilentlyContinue -ErrorVariable importError" + 
                    Environment.NewLine + "if ($importerror.Count -eq 0) { " + Environment.NewLine;

                var validModules = new List<string>();
                foreach (var name in modulesToKeep)
                {
                    if (mapping.ContainsKey(name))
                    {
                        validModules.Add(name);
                    }
                }
                filecontent += "    Enable-AzureRmAlias -Module " + string.Join(", ", validModules) + " -ErrorAction SilentlyContinue; " + Environment.NewLine;

                filecontent += "}" + Environment.NewLine + ENDALIASIMPORTMARKER;
            }

            ExecuteFileActionWithFriendlyError(() =>
            {
                FileUtilities.EnsureDirectoryExists(Path.GetDirectoryName(userprofile));
                _dataStore.WriteFile(userprofile, filecontent);
            });
        }

        public void CreateProfileIfNotExists(string userprofile)
        {
            ExecuteFileActionWithFriendlyError(() =>
            {
                FileUtilities.EnsureDirectoryExists(Path.GetDirectoryName(userprofile));
                if (!_dataStore.FileExists(userprofile))
                {
                    _dataStore.WriteFile(userprofile, Environment.NewLine);
                }
            });
        }

        private static void ExecuteFileActionWithFriendlyError(Action fileAction)
        {
            try
            {
                fileAction();
            }
            catch (UnauthorizedAccessException accessException) when (accessException?.Message != null && accessException.Message.ToLower().Contains("denied"))
            {
                throw new UnauthorizedAccessException(Properties.Resources.AliasImportFailure, accessException);
            }
        }
    }
}
