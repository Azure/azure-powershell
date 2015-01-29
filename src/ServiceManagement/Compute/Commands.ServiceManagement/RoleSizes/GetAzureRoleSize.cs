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
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.HostedServices
{
    /// <summary>
    /// Retrieve a Microsoft Azure Role Size.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRoleSize"), OutputType(typeof(RoleSizeContext))]
    public class AzureRoleSizeCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "The Role Instance Size Name.")]
        [ValidateNotNullOrEmpty]
        public string InstanceSize
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.ManagementClient.RoleSizes.List(),
                (op, response) => response.RoleSizes.Where(roleSize => string.IsNullOrEmpty(this.InstanceSize) ||
                                                                       string.Equals(this.InstanceSize, roleSize.Name, StringComparison.OrdinalIgnoreCase))
                                                    .Select(roleSize => ContextFactory<RoleSizeListResponse.RoleSize, RoleSizeContext>(roleSize, op)));
        }
    }
}
