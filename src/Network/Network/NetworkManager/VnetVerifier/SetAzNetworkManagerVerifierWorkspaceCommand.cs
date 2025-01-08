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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerVerifierWorkspace", SupportsShouldProcess = true, DefaultParameterSetName = SetByInputObjectParameterSet), OutputType(typeof(PSVerifierWorkspace))]
    public class SetAzNetworkManagerVerifierWorkspaceCommand : VerifierWorkspaceBaseCmdlet
    {
        private const string SetByNameParameterSet = "ByNameParameters";
        private const string SetByResourceIdParameterSet = "ByResourceId";
        private const string SetByInputObjectParameterSet = "ByInputObject";

        [Alias("ResourceName")]
        [Parameter(
          ParameterSetName = SetByNameParameterSet,
          Mandatory = true,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/verifierWorkspaces", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = SetByInputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Verifier Workspace")]
        public PSVerifierWorkspace InputObject { get; set; }

        [Parameter(
           ParameterSetName = SetByResourceIdParameterSet,
           Mandatory = true,
           HelpMessage = "The network manager verifier workspace id.",
           ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("VerifierWorkspaceId")]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = SetByNameParameterSet,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = SetByNameParameterSet,
            Mandatory = true,
            HelpMessage = "The network manager name.")]
        [ValidateNotNullOrEmpty]
        public string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description.",
            ParameterSetName = SetByNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description.",
            ParameterSetName = SetByResourceIdParameterSet)]
        public string Description { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        //public override void Execute()
        //{
        //    if (this.ShouldProcess(this.InputObject.Name, VerbsLifecycle.Restart))
        //    {
        //        base.Execute();

        //        if (!this.IsVerifierWorkspacePresent(this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.Name))
        //        {
        //            throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, this.InputObject.Name));
        //        }

        //        // Map to the sdk object
        //        var verifierWorkspaceModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VerifierWorkspace>(this.InputObject);

        //        // Execute the PUT VerifierWorkspace call
        //        this.VerifierWorkspaceClient.Create(this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.Name, verifierWorkspaceModel);
        //        var psVerifierWorkspace = this.GetVerifierWorkspace(this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.Name);
        //        WriteObject(psVerifierWorkspace);
        //    }
        //}

        public override void Execute()
        {
            if (this.ShouldProcess(this.InputObject?.Name ?? this.Name, VerbsLifecycle.Restart))
            {
                base.Execute();

                var (resourceGroupName, networkManagerName, verfierWorkspaceName) = ExtractResourceDetails();

                var verifierWorkspaceModel = MapToSdkObject();

                var verifierWorkspaceResponse = this.VerifierWorkspaceClient.Create(
                    resourceGroupName,
                    networkManagerName,
                    verfierWorkspaceName,
                    verifierWorkspaceModel);

                var psVerifierWorkspace = this.ToPsVerifierWorkspace(verifierWorkspaceResponse);
                WriteObject(psVerifierWorkspace);
            }
        }

        private (string resourceGroupName, string networkManagerName, string verifierWorkspaceName) ExtractResourceDetails()
        {
            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);

                // Validate the format of the ResourceId
                var segments = parsedResourceId.ParentResource.Split('/');
                if (segments.Length < 2)
                {
                    throw new PSArgumentException("Invalid ResourceId format. Ensure the ResourceId is in the correct format.");
                }

                this.Name = parsedResourceId.ResourceName;
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.NetworkManagerName = segments[1];
                

                return (this.ResourceGroupName, this.NetworkManagerName, this.Name);
            }
            else if (this.InputObject != null)
            {
                return (
                    this.InputObject.ResourceGroupName,
                    this.InputObject.NetworkManagerName,
                    this.InputObject.Name
                );
            }
            else
            {
                return (
                    this.ResourceGroupName,
                    this.NetworkManagerName,
                    this.Name
                );
            }
        }

        private VerifierWorkspace MapToSdkObject()
        {
            if (this.InputObject != null)
            {
                if (this.InputObject is PSVerifierWorkspace)
                {
                    return NetworkResourceManagerProfile.Mapper.Map<VerifierWorkspace>(InputObject);
                }
                else
                {
                    throw new PSArgumentException("Invalid InputObject type. Expected type is PSNetworkManagerRoutingRule.");
                }
            }
            else
            {
                var verifierWorkspace = new VerifierWorkspace();

                if (verifierWorkspace.Properties == null)
                {
                    verifierWorkspace.Properties = new VerifierWorkspaceProperties();
                }
                if (!string.IsNullOrEmpty(this.Description))
                {
                    verifierWorkspace.Properties.Description = this.Description;
                }

                return verifierWorkspace;
            }
        }
    }
}