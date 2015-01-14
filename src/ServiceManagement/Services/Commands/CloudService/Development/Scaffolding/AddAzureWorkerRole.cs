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
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceConfigurationSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.CloudService.Development.Scaffolding
{
    /// <summary>
    /// Create scaffolding for a new worker role, change cscfg file and csdef to include the added worker role
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureWorkerRole"), OutputType(typeof(RoleSettings))]
    public class AddAzureWorkerRoleCommand : AddRole
    {
        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Role scaffolding template folder")]
        [ValidateNotNullOrEmpty]
        public string TemplateFolder { get; set; }

        public AddAzureWorkerRoleCommand() :
            base(Path.Combine(Resources.GeneralScaffolding, RoleType.WorkerRole.ToString()), Resources.AddRoleMessageCreate, false)
        {

        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            // Set scaffolding to use the provided template if it's set.
            Scaffolding = string.IsNullOrEmpty(TemplateFolder) ? Scaffolding : this.ResolvePath(TemplateFolder);

            base.ExecuteCmdlet();
        }
    }
}