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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.CloudService.Development
{
    /// <summary>
    /// Retrieve a list of role runtimes available in the cloud
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureServiceProjectRoleRuntime"), OutputType(typeof(List<CloudRuntimePackage>))]
    public class GetAzureServiceProjectRoleRuntimeCommand : AzureSMCmdlet
    {
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Runtime { get; set; }

        /// <summary>
        /// Retrieve the runtimes from the given manifest, or from the default cloud location, if none given.
        /// The manifest parameter is mainly a testing hook.
        /// </summary>
        /// <param name="runtimeType">The runtime type to filter by</param>
        /// <param name="manifest">The path to the manifest file, if null, the default cloud manifest is used (test hook)</param>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void GetAzureRuntimesProcess(string runtimeType, string manifest = null)
        {
            CloudRuntimeCollection runtimes;
            CloudRuntimeCollection.CreateCloudRuntimeCollection(out runtimes, manifest);
            WriteObject(runtimes.Where<CloudRuntimePackage>(p => string.IsNullOrEmpty(runtimeType) ||
                p.Runtime == CloudRuntime.GetRuntimeByType(runtimeType)).ToList<CloudRuntimePackage>(), true);
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            this.GetAzureRuntimesProcess(Runtime);
        }        
    }
}