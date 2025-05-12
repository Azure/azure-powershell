// ----------------------------------------------------------------------------------
//
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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Collections.Concurrent;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to get user tenant information. 
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Tenant")]
    [Alias("Get-AzureRmDomain", "Get-AzDomain")]
    [OutputType(typeof(PSAzureTenant))]
    public class GetAzureRMTenantCommand : AzureRMCmdlet
    {
        [Parameter(Mandatory = false, Position = 0, ValueFromPipelineByPropertyName = true)]
        [Alias("Domain", "Tenant")]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }


        public override void ExecuteCmdlet()
        {
            var profileClient = new RMProfileClient(AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>())
            {
                WarningLog = (s) => WriteWarning(s),
                CmdletContext = _cmdletContext
            };
            profileClient.WarningLog = (message) => _tasks.Enqueue(new Task(() => this.WriteWarning(message)));

            var tenants = profileClient.ListTenants(TenantId).Select((t) => new PSAzureTenant(t));
            HandleActions();
            WriteObject(tenants, enumerateCollection: true);
        }

        private ConcurrentQueue<Task> _tasks = new ConcurrentQueue<Task>();

        private void HandleActions()
        {
            Task task;
            while (_tasks.TryDequeue(out task))
            {
                task.RunSynchronously();
            }
        }
    }
}
