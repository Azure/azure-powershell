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


using Microsoft.Azure.Commands.Aks.Models;
using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Azure.Management.ContainerService.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common;

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Aks.Commands
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AksCredential", SupportsShouldProcess = true, DefaultParameterSetName = ResetServicePrincipalWithGroupNameParameterSet)]
    [OutputType(typeof(bool))]
    class SetAzureRmAksCredential : KubeCmdletBase
    {
        private const string ResetServicePrincipalWithIdParameterSet = "ResetServicePrincipalWithIdParameterSet";
        private const string ResetServicePrincipalWithGroupNameParameterSet = "ResetServicePrincipalWithGroupNameParameterSet";
        private const string ResetServicePrincipalWithInputObjectParameterSet = "ResetServicePrincipalWithInputObjectParameterSet";
        private const string ResetAadWithIdParameterSet = "ResetAadWithIdParameterSet";
        private const string ResetAadWithGroupNameParameterSet = "ResetAadWithGroupNameParameterSet";
        private const string ResetAadWithInputObjectParameterSet = "ResetAadWithInputObjectParameterSet";

        [Parameter(Mandatory = true,
            ParameterSetName = ResetServicePrincipalWithInputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "A PSKubernetesCluster object, normally passed through the pipeline.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResetAadWithInputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "A PSKubernetesCluster object, normally passed through the pipeline.")]
        [ValidateNotNullOrEmpty]
        public PSKubernetesCluster InputObject { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ResetAadWithIdParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Id of a managed Kubernetes cluster")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResetServicePrincipalWithIdParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Id of a managed Kubernetes cluster")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceId")]
        public string Id { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResetServicePrincipalWithGroupNameParameterSet,
            HelpMessage = "Resource group name")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResetAadWithGroupNameParameterSet,
            HelpMessage = "Resource group name")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Cluster name
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = ResetServicePrincipalWithGroupNameParameterSet,
            HelpMessage = "Name of your managed Kubernetes cluster")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = ResetAadWithGroupNameParameterSet,
            HelpMessage = "Name of your managed Kubernetes cluster")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ResetServicePrincipalWithGroupNameParameterSet,
            HelpMessage = "The client app id associated with the AAD application / service principal.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResetServicePrincipalWithInputObjectParameterSet,
            HelpMessage = "The client app id associated with the AAD application / service principal.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResetServicePrincipalWithIdParameterSet,
            HelpMessage = "The client app id associated with the AAD application / service principal.")]
        [ValidateNotNullOrEmpty]
        public string ClientAppID { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ResetServicePrincipalWithGroupNameParameterSet,
            HelpMessage = "The tenant id with the AAD application / service principal.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResetServicePrincipalWithInputObjectParameterSet,
            HelpMessage = "The tenant id with the AAD application / service principal.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResetServicePrincipalWithIdParameterSet,
            HelpMessage = "The tenant id with the AAD application / service principal.")]
        [ValidateNotNullOrEmpty]
        public string TenantID { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ResetServicePrincipalWithGroupNameParameterSet,
            HelpMessage = "The server app id and server secret associated with the AAD application / service principal.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ResetServicePrincipalWithInputObjectParameterSet,
            HelpMessage = "The server app id and server secret associated with the AAD application / service principal.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ResetServicePrincipalWithIdParameterSet,
            HelpMessage = "The server app id and server secret associated with the AAD application / service principal.")]
        public PSCredential ServerAppIdAndSecret { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ResetAadWithGroupNameParameterSet,
            HelpMessage = "The client id and client secret associated with the AAD application / service principal.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ResetAadWithInputObjectParameterSet,
            HelpMessage = "The client id and client secret associated with the AAD application / service principal.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ResetAadWithIdParameterSet,
            HelpMessage = "The client id and client secret associated with the AAD application / service principal.")]
        public PSCredential ServicePrincipalIdAndSecret { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Remove managed Kubernetes cluster without prompt")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (ParameterSetName)
            {
                case ResetServicePrincipalWithIdParameterSet:
                case ResetAadWithIdParameterSet:
                {
                    var resource = new ResourceIdentifier(Id);
                    ResourceGroupName = resource.ResourceGroupName;
                    Name = resource.ResourceName;
                    break;
                }
                case ResetServicePrincipalWithInputObjectParameterSet:
                case ResetAadWithInputObjectParameterSet:
                {
                    var resource = new ResourceIdentifier(InputObject.Id);
                    ResourceGroupName = resource.ResourceGroupName;
                    Name = resource.ResourceName;
                    break;
                }
            }

            var msg = $"{Name} in {ResourceGroupName}";

            ConfirmAction(Force.IsPresent,
                Resources.DoYouWantToDeleteTheManagedKubernetesCluster,
                Resources.RemovingTheManagedKubernetesCluster,
                msg,
                () =>
                {
                    RunCmdLet(() =>
                    {
                        if (ParameterSetName.Equals(ResetServicePrincipalWithInputObjectParameterSet)
                         || ParameterSetName.Equals(ResetServicePrincipalWithGroupNameParameterSet)
                         || ParameterSetName.Equals(ResetServicePrincipalWithIdParameterSet))
                        {
                            ResetServicePrincipalProfile();
                        }
                        else
                        {
                            ResetAADProfile();
                        }
                        if (PassThru)
                        {
                            WriteObject(true);
                        }
                    });
                });
        }

        private void ResetAADProfile()
        {
            ManagedClusterAADProfile aadProfile = new ManagedClusterAADProfile()
            {
                ClientAppID = ClientAppID,
                TenantID = TenantID,
                ServerAppID = ServerAppIdAndSecret.UserName,
                ServerAppSecret = ServerAppIdAndSecret.Password.ConvertToString()
            };
            Client.ManagedClusters.ResetAADProfile(ResourceGroupName, Name, aadProfile);
        }

        private void ResetServicePrincipalProfile()
        {
            ManagedClusterServicePrincipalProfile servicePrincipalProfile = new ManagedClusterServicePrincipalProfile()
            {
                ClientId = ServicePrincipalIdAndSecret.UserName,
                Secret = ServicePrincipalIdAndSecret.Password.ConvertToString()
            };
            Client.ManagedClusters.ResetServicePrincipalProfile(ResourceGroupName, Name, servicePrincipalProfile);
        }
    }
}
