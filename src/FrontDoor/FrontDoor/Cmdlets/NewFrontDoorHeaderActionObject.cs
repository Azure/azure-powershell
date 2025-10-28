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

using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    [CmdletOutputBreakingChangeAttribute(typeof(PSHeaderAction), "15.0.0", "6.0.0", ReplacementCmdletOutputTypeName = "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.HeaderAction", ChangeDescription = "no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSHeaderAction'.")]
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoor" + "HeaderActionObject"), OutputType(typeof(PSHeaderAction))]
    public class NewFrontDoorHeaderActionObject : AzureFrontDoorCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of the header this action will apply to.")]
        public string HeaderName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Which type of manipulation to apply to the header. Possible values include 'Append', 'Delete', or 'Overwrite'")]
        [CmdletParameterBreakingChangeWithVersion("HeaderActionType", "15.0.0", "6.0.0", ReplacementCmdletParameterTypeName = "System.String", ChangeDescription = "parameter 'HeaderActionType' is changing from type 'Microsoft.Azure.Commands.FrontDoor.Models.PSHeaderActionType' to type 'System.String'.")]
        public PSHeaderActionType HeaderActionType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The value to update the given header name with. This value is not used if the actionType is Delete.")]
        public string Value { get; set; }

        public override void ExecuteCmdlet()
        {
            var headerAction = new PSHeaderAction
            {
                HeaderName = HeaderName,
                HeaderActionType = HeaderActionType,
                Value = this.IsParameterBound(c => c.Value) ? Value : ""
            };

            WriteObject(headerAction);
        }
    }
}
