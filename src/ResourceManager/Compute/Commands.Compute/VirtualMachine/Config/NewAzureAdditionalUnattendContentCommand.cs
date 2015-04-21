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

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// Create Additional Unattend Content Object
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        ProfileNouns.AdditionalUnattendContent),
    OutputType(
        typeof(PSAdditionalUnattendContent))]
    public class NewAzureAdditionalUnattendContentCommand : AzurePSCmdlet
    {
        private const string defaultComponentName = "Microsoft-Windows-Shell-Setup";
        private const string defaultPassName = "oobeSystem";

        [Parameter(
            DontShow = true, // Currently, the only allowable value is 'Microsoft-Windows-Shell-Setup'.
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Component Name.")]
        [ValidateNotNullOrEmpty]
        public string ComponentName { get; set; }

        [Parameter(
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "XML Formatted Content.")]
        [ValidateNotNullOrEmpty]
        public string Content { get; set; }

        [Parameter(
            DontShow = true, // Currently, the only allowable value is 'oobeSystem'.
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Pass name")]
        [ValidateNotNullOrEmpty]
        public string PassName { get; set; }

        [Parameter(
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Setting Name.")]
        [ValidateNotNullOrEmpty]
        public string SettingName { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(new PSAdditionalUnattendContent
            {
                ComponentName = defaultComponentName,
                Content = this.Content,
                PassName = defaultPassName,
                SettingName = this.SettingName,
            });
        }
    }
}
