﻿// ----------------------------------------------------------------------------------
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

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Aks.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ContainerService;

namespace Microsoft.Azure.Commands.Aks.Commands
{
    [Cmdlet("Get", AzureRMConstants.AzureRMPrefix + "AksVersion")]
    [OutputType(typeof(PSOrchestratorVersionProfile))]
    public class GetAzureRMAksVersion : KubeCmdletBase
    {
        [Parameter(Mandatory = true,
            HelpMessage = "Azure location for the cluster.")]
        [LocationCompleter("Microsoft.ContainerService/managedClusters")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                var profileList = Client.ContainerServices.ListOrchestrators(Location, "managedClusters");

                WriteObject(profileList.Orchestrators.Select(
                    item => PSMapper.Instance.Map<PSOrchestratorVersionProfile>(item)), true);
            });
        }
    }
}
