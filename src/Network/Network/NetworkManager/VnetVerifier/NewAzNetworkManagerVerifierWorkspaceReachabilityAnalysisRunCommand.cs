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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerVerifierWorkspaceReachabilityAnalysisRun", SupportsShouldProcess = true), OutputType(typeof(PSReachabilityAnalysisRun))]

    public class NewAzNetworkManagerVerifierWorkspaceReachabilityAnalysisRunCommand : ReachabilityAnalysisRunBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Reachability Analysis Run name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
         Mandatory = true,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "Verifier Workspace name.")]
         [ValidateNotNullOrEmpty]
        public virtual string VerifierWorkspaceName { get; set; }

        [Parameter(
         Mandatory = false,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "Description.")]
        public virtual string Description { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Intent ID.")]
        [ValidateNotNullOrEmpty]
        public virtual string IntentId { get; set; }


        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }
        public override void Execute()
        {
            base.Execute();
            var present = this.IsAnalysisRunPresent(this.ResourceGroupName, this.NetworkManagerName, this.VerifierWorkspaceName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var analysisRun = this.CreateAnalysisRun();
                    WriteObject(analysisRun);
                },
                () => present);
        }

        private PSReachabilityAnalysisRun CreateAnalysisRun()
        {
            var analysisRun = new PSReachabilityAnalysisRun();
            analysisRun.Name = this.Name;
            analysisRun.Properties = new PSReachabilityAnalysisRunProperties();

            if (this.IntentId != null)
            {
                analysisRun.Properties.IntentId = this.IntentId;
            }

            if (!string.IsNullOrEmpty(this.Description))
            {
                analysisRun.Properties.Description = this.Description;
            }
            // Map to the sdk object
            var analysisRunModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ReachabilityAnalysisRun>(analysisRun);

            // Execute the Create Network call 
            this.ReachabilityAnalysisRunClient.Create(this.ResourceGroupName, this.NetworkManagerName, this.VerifierWorkspaceName, this.Name, analysisRunModel);
            var psAnalysisRun = this.GetAnalysisRun(this.ResourceGroupName, this.NetworkManagerName, this.VerifierWorkspaceName, this.Name);
            return psAnalysisRun;
        }
    }
}