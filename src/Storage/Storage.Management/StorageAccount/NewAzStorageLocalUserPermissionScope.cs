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

using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageLocalUserPermissionScope"), OutputType(typeof(PSPermissionScope))]
    public class NewAzureStorageLocalUserPermissionScopeCommand : StorageAccountBaseCmdlet
    {
        [Parameter(Mandatory = true,
            HelpMessage = "Specify the permissions for the local user. Possible values include: Read(r), Write (w), Delete (d), List (l), and Create (c).")]
        [ValidateNotNullOrEmpty]
        public string Permission { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Specify the service used by the local user, e.g. blob, file.")]
        [PSArgumentCompleter("blob", "file")]
        [ValidateNotNullOrEmpty]
        public string Service { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Specify the name of resource, normally the container name or the file share name, used by the local user.")]
        [ValidateNotNullOrEmpty]
        public string ResourceName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            PSPermissionScope scope = new PSPermissionScope()
            {
                Permissions = this.Permission,
                ResourceName = this.ResourceName,
                Service = this.Service
            };

            WriteObject(scope);
        }
    }
}
