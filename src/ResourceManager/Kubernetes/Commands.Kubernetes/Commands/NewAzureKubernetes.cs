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

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using Microsoft.Azure.Commands.Kubernetes.Generated;
using Microsoft.Azure.Commands.Kubernetes.Generated.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.Kubernetes
{
    [Cmdlet(VerbsCommon.New, KubeNounStr, DefaultParameterSetName = DefaultParamSet)]
    [OutputType(typeof(PSObject), typeof(List<PSObject>))]
    public class New : KubeCmdletBase
    {
        private const string DefaultParamSet = "defaultParameterSet";
        private const string SpParamSet = "servicePrincipalParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = DefaultParamSet,
            HelpMessage = "Resource Group Name.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = SpParamSet,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = DefaultParamSet,
            HelpMessage = "Kubernetes managed cluster Name.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = SpParamSet,
            HelpMessage = "Kubernetes managed cluster Name.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^[a-zA-Z0-9][a-zA-Z0-9_.-]*$")]
        [ValidateLength(2, 64)]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = SpParamSet,
            HelpMessage =
                "The client ID of the AAD application / service principal used for cluster authentication to Azure APIs.")]
        public string ClientId { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = SpParamSet,
            HelpMessage = "The secret associated with the AAD application / service principal.")]
        public string ClientSecret { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure location for the cluster. Defaults to the location of the resource group.")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "User name for the Linux Virtual Machines.")]
        public string AdminUserName { get; set; } = "azureuser";

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The DNS name prefix for the cluster.")]
        public string DnsNamePrefix { get; set; }


        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The version of Kubernetes to use for creating the cluster.")]
        [ValidateSet("1.7.7", "1.8.1")]
        public string KubernetesVersion { get; set; } = "1.8.1";

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The default number of nodes for the node pools.")]
        public int NodeCount { get; set; } = 3;

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The default number of nodes for the node pools.")]
        public int? NodeOsDiskSize { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The size of the Virtual Machine.")]
        public string NodeVmSize { get; set; } = "Standard_D2_v2";

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "SSH key file value or key file path. Defaults to {HOME}/.ssh/id_rsa.pub.")]
        public string SshKeyValue { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tags { get; set; }


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!string.IsNullOrEmpty(ResourceGroupName))
            {
                var rg = RmClient.ResourceGroups.Get(ResourceGroupName);
                Location = rg.Location;
            }

            if (string.IsNullOrEmpty(SshKeyValue))
            {
                var path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    ".ssh",
                    "id_rsa.pub");
                if (File.Exists(path))
                {
                    SshKeyValue = File.ReadAllText(path);
                }
                else
                {
                    throw new ArgumentException(string.Format("Could not find SSH public key in {0}", path));
                }
            }

            var defaultAgentPoolProfile = new ContainerServiceAgentPoolProfile(
                "default",
                NodeVmSize,
                NodeCount,
                NodeOsDiskSize,
                DnsNamePrefix);

            var pubKey = new List<ContainerServiceSshPublicKey> {new ContainerServiceSshPublicKey(SshKeyValue)};

            var linuxProfile =
                new ContainerServiceLinuxProfile(AdminUserName, new ContainerServiceSshConfiguration(pubKey));


            ContainerServiceServicePrincipalProfile spProfile;
            if (ParameterSetName == SpParamSet)
            {
                // build service principal
                spProfile = null;
            }
            else
            {
                spProfile = new ContainerServiceServicePrincipalProfile(ClientId, ClientSecret);
            }

            var managedCluster = new ManagedCluster(
                Location,
                name: Name,
                tags: TagsConversionHelper.CreateTagDictionary(Tags, true),
                dnsPrefix: DnsNamePrefix,
                kubernetesVersion: KubernetesVersion,
                agentPoolProfiles: new List<ContainerServiceAgentPoolProfile> {defaultAgentPoolProfile},
                linuxProfile: linuxProfile,
                servicePrincipalProfile: spProfile);

            RunCmdLet(() =>
            {
                var cluster = Client.ManagedClusters.CreateOrUpdate(ResourceGroupName, Name, managedCluster);
                WriteObject(cluster);
            });
        }

        private void EnsureServicePrincipal()
        {
            GraphClient.Applications.Create(new ApplicationCreateParameters(false, ))
            GraphClient.ServicePrincipals.Create()

        }
    }
}