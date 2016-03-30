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


using System.IO;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.CloudService.Development.Scaffolding
{
    /// <summary>
    /// Creates new azure template for web/worker role.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRoleTemplate"), OutputType(typeof(PSObject))]
    public class NewAzureRoleTemplateCommand : AzureSMCmdlet
    {
        const string DefaultWebRoleTemplate = "WebRoleTemplate";

        const string DefaultWorkerRoleTemplate = "WorkerRoleTemplate";

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "WebRole", HelpMessage = "Specifies that the generated template should be for web role")]
        public SwitchParameter Web { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "WorkerRole", HelpMessage = "Specifies that the generated template should be for worker role")]
        public SwitchParameter Worker { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Output path for the generated template")]
        public string Output { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            string output = !string.IsNullOrEmpty(Output) ? this.TryResolvePath(Output) :
                Web.IsPresent ?
                Path.Combine(CurrentPath(), DefaultWebRoleTemplate) :
                Path.Combine(CurrentPath(), DefaultWorkerRoleTemplate);
            string source = Web.IsPresent ? Path.Combine(Resources.GeneralScaffolding, Resources.WebRole) : Path.Combine(Resources.GeneralScaffolding, Resources.WorkerRole);

            FileUtilities.DirectoryCopy(FileUtilities.GetContentFilePath(source), output, true);

            SafeWriteOutputPSObject(null, Parameters.Path, output);
        }
    }
}