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
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceConfigurationSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.CloudService.Development.Scaffolding
{
    /// <summary>
    /// Create scaffolding for a new php web role, change cscfg file and csdef to include the added web role
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzurePHPWebRole"), OutputType(typeof(RoleSettings))]
    public class AddAzurePHPWebRoleCommand : AddRole
    {
        public AddAzurePHPWebRoleCommand() :
            base(Path.Combine(Resources.PHPScaffolding, RoleType.WebRole.ToString()), Resources.AddRoleMessageCreatePHP, true)
        {

        }
    }
}