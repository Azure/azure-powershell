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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerVerifierWorkspace", SupportsShouldProcess = true, DefaultParameterSetName = CreateByNameParameterSet), OutputType(typeof(PSVerifierWorkspace))]
    public class NewAzNetworkManagerVerifierWorkspaceCommand : VerifierWorkspaceBaseCmdlet
    {
        private const string CreateByNameParameterSet = "ByName";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The resource name.",
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
         HelpMessage = "location.",
            ParameterSetName = CreateByNameParameterSet)]
        [LocationCompleter("Microsoft.Network/networkManagers/verifierWorkspaces")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        
        [Parameter(
         Mandatory = false,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "Description.",
            ParameterSetName = CreateByNameParameterSet)]
        public virtual string Description { get; set; }


        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.",
            ParameterSetName = CreateByNameParameterSet)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsVerifierWorkspacePresent(this.ResourceGroupName, this.NetworkManagerName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var verifierWorkspace = this.CreateVerifierWorkspace();
                    WriteObject(verifierWorkspace);
                },
                () => present);
        }

        private PSVerifierWorkspace CreateVerifierWorkspace()
        {
            var verifierWorkspace = new PSVerifierWorkspace();
            verifierWorkspace.Name = this.Name;
            verifierWorkspace.Location = this.Location;
            verifierWorkspace.Properties = new PSVerifierWorkspaceProperties();

            if (!string.IsNullOrEmpty(this.Description))
            {
                verifierWorkspace.Properties.Description = this.Description;
            }

            // Map to the sdk object
            var verifierWorkspaceModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VerifierWorkspace>(verifierWorkspace);
            verifierWorkspaceModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create Network call
            this.VerifierWorkspaceClient.Create(this.ResourceGroupName, this.NetworkManagerName, this.Name, verifierWorkspaceModel);
            var psVerifierWorkspace = this.GetVerifierWorkspace(this.ResourceGroupName, this.NetworkManagerName, this.Name);
            return psVerifierWorkspace;
        }
    }
}