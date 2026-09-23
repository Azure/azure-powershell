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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerVerifierWorkspaceReachabilityAnalysisIntent", SupportsShouldProcess = true, DefaultParameterSetName = CreateByNameParameterSet), OutputType(typeof(PSReachabilityAnalysisIntent))]

    public class NewAzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntentCommand : ReachabilityAnalysisIntentBaseCmdlet
    {
        private const string CreateByNameParameterSet = "ByName";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Reachability Analysis Intent name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
         Mandatory = true,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "Verifier Workspace name.",
            ParameterSetName = CreateByNameParameterSet)]
         [ValidateNotNullOrEmpty]
        public virtual string VerifierWorkspaceName { get; set; }

        [Parameter(
         Mandatory = false,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "Description.",
            ParameterSetName = CreateByNameParameterSet)]
        public virtual string Description { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Source resource ID.",
            ParameterSetName = CreateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string SourceResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Destination resource ID.",
            ParameterSetName = CreateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string DestinationResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IP traffic details.",
            ParameterSetName = CreateByNameParameterSet)]
        public virtual PSIPTraffic IpTraffic { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }
        public override void Execute()
        {
            base.Execute();
            var present = this.IsAnalysisIntentPresent(this.ResourceGroupName, this.NetworkManagerName, this.VerifierWorkspaceName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var analysisIntent = this.CreateAnalysisIntent();
                    WriteObject(analysisIntent);
                },
                () => present);
        }

        private PSReachabilityAnalysisIntent CreateAnalysisIntent()
        {
            var analysisIntent = new PSReachabilityAnalysisIntent();
            analysisIntent.Name = this.Name;
            analysisIntent.Properties = new PSReachabilityAnalysisIntentProperties();

            if (this.SourceResourceId != null)
            {
                analysisIntent.Properties.SourceResourceId = this.SourceResourceId;
            }

            if (this.DestinationResourceId != null)
            {
                analysisIntent.Properties.DestinationResourceId = this.DestinationResourceId;
            }

            if (this.IpTraffic != null)
            {
                analysisIntent.Properties.IpTraffic = this.IpTraffic;
            }

            if (!string.IsNullOrEmpty(this.Description))
            {
                analysisIntent.Properties.Description = this.Description;
            }
            // Map to the sdk object
            var analysisIntentModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ReachabilityAnalysisIntent>(analysisIntent);

            // Execute the Create Network call 
            this.ReachabilityAnalysisIntentClient.Create(this.ResourceGroupName, this.NetworkManagerName, this.VerifierWorkspaceName, this.Name, analysisIntentModel);
            var psAnalysisIntent = this.GetAnalysisIntent(this.ResourceGroupName, this.NetworkManagerName, this.VerifierWorkspaceName, this.Name);
            return psAnalysisIntent;
        }
    }
}