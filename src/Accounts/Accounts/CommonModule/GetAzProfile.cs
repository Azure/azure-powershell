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
using Microsoft.Azure.Commands.Profile.CommonModule;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using static Microsoft.Azure.Commands.Common.Profile;

namespace Microsoft.Azure.Commands.Common
{
    /// <summary>
    /// Returns the current Azure profile (no parameters).
    /// Returns the Azure profiles available from a module if ModuleName is provided.
    /// </summary>
    [OutputType(typeof(PSAzureServiceProfile))]
    [Cmdlet(VerbsCommon.Get, @"AzProfile")]
    public class GetAzProfile : PSCmdlet
    {
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string[] ModuleName { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter ListAvailable { get; set; }

        protected override void ProcessRecord()
        {
            try
            {
                var includesModuleNames = this.IsBound(nameof(ModuleName));
                var isListAvailable = this.IsBound(nameof(ListAvailable));
                var moduleNames = includesModuleNames ? ModuleName : new string[] { };
                var profiles = includesModuleNames || isListAvailable
                    ? GetProfiles(InvokeCommand, isListAvailable, moduleNames)
                    : new []{ ContextAdapter.Instance.SelectedProfile };
                if (profiles.Any((p) => !string.IsNullOrWhiteSpace(p)))
                {
                    WriteObject(profiles.Where((profile) => !string.IsNullOrWhiteSpace(profile))
                        .Select((p) => PSAzureServiceProfile.Create(p)), true);
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
