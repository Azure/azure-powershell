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
using System.Collections;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Common
{
    /// <summary>
    /// Returns the current Azure profile (no parameters).
    /// Returns the Azure profiles available from a module if ModuleName is provided.
    /// </summary>
    [OutputType(typeof(string), typeof(string[]))]
    [Cmdlet(VerbsCommon.Get, @"AzProfile", SupportsShouldProcess = true)]
    public class GetAzProfile : PSCmdlet
    {
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string ModuleName { get; set; }

        protected override void ProcessRecord()
        {
            try
            {
                var isForModule = this.IsBound(nameof(ModuleName)) && !String.IsNullOrEmpty(ModuleName);
                var profiles = isForModule ? new string[] {} : new []{ ContextAdapter.Instance.SelectedProfile };
                if (isForModule)
                {
                    var module = InvokeCommand.NewScriptBlock($"Get-Module -Name {ModuleName}").Invoke().FirstOrDefault();
                    var moduleInfo = module?.BaseObject as PSModuleInfo;
                    var moduleProfileInfo = ((moduleInfo?.PrivateData as Hashtable)?["PSData"] as Hashtable)?["Profiles"];
                    var moduleProfiles = moduleProfileInfo as object[] ?? (moduleProfileInfo != null ? new []{ moduleProfileInfo } : null);
                    profiles = moduleProfiles != null && moduleProfiles.Any() ? moduleProfiles.Cast<string>().ToArray() : profiles;
                }

                if (profiles.Any() && !profiles.All(String.IsNullOrEmpty))
                {
                    WriteObject(profiles, true);
                }
            }
            catch (Exception exception)
            {
                // Write exception out to error channel.
                WriteError(new ErrorRecord(exception, string.Empty, ErrorCategory.CloseError, null));
            }
        }
    }
}
