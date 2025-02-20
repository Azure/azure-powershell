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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using System.Linq;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Deploy", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerCommit", SupportsShouldProcess = true), OutputType(typeof(PSNetworkManagerCommit))]
    public class PostAzNetworkManagerCommitCommand : NetworkManagerBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "List of target locations.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string[] TargetLocation { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "List of configuration ids.")]
        [ResourceGroupCompleter]
        [AllowEmptyCollection]
        [SupportsWildcards]
        public virtual string[] ConfigurationId { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Commit Type.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        [ValidateSet("SecurityAdmin", "Connectivity", "Routing", "SecurityUser", IgnoreCase = true)]
        public virtual string CommitType { get; set; }

        public override void Execute()
        {
            base.Execute();
            List<string> configIdList = new List<string>();
            if (this.ConfigurationId != null)
            {
                configIdList = this.ConfigurationId.ToList();
            }
            var commitResult = this.PostNetworkManagerCommit(this.ResourceGroupName, this.Name, this.TargetLocation.ToList(), configIdList, this.CommitType);
            WriteObject(commitResult);
        }
    }
}

