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
using Microsoft.Azure.Commands.Kubernetes.Generated;
using Microsoft.Azure.Commands.Kubernetes.Generated.Models;
using Microsoft.Azure.Commands.Kubernetes.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Kubernetes
{
    [Cmdlet(VerbsCommon.Set, KubeNounStr, DefaultParameterSetName = DefaultParamSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSKubernetesCluster))]
    public class Set : CreateOrUpdateKubeBase
    {
        private const string IdParameterSet = "IdParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";

        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "A PSKubernetesCluster object, normally passed through the pipeline.")]
        [ValidateNotNullOrEmpty]
        public PSKubernetesCluster InputObject { get; set; }

        /// <summary>
        /// Cluster name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = IdParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Id of a managed Kubernetes cluster")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ManagedCluster cluster = null;
            switch (ParameterSetName)
            {
                case IdParameterSet:
                {
                    var resource = new ResourceIdentifier(Id);
                    ResourceGroupName = resource.ResourceGroupName;
                    Name = resource.ResourceName;
                    break;
                }
                case InputObjectParameterSet:
                {
                    WriteVerbose("Using cluster from pipeline.");
                    cluster = PSMapper.Instance.Map<ManagedCluster>(InputObject);
                    var resource = new ResourceIdentifier(cluster.Id);
                    ResourceGroupName = resource.ResourceGroupName;
                    Name = resource.ResourceName;
                    break;
                }
            }

            var msg = string.Format("{0} in {1}", Name, ResourceGroupName);

            if (ShouldProcess(msg, "Update or create a managed Kubernetes cluster."))
            {
                RunCmdLet(() =>
                {
                    if (Exists())
                    {
                        if (cluster == null)
                        {
                            cluster = Client.ManagedClusters.Get(ResourceGroupName, Name);
                        }

                        WriteVerbose(string.Format("Resource group: {0}, Name: {1}", ResourceGroupName, Name));

                        if (MyInvocation.BoundParameters.ContainsKey("Location"))
                        {
                            throw new CmdletInvocationException("Location can't be updated for existing cluster.");
                        }

                        if (MyInvocation.BoundParameters.ContainsKey("DnsNamePrefix"))
                        {
                            WriteVerbose("Updating DnsNamePrefix");
                            cluster.DnsPrefix = DnsNamePrefix;
                        }

                        if (MyInvocation.BoundParameters.ContainsKey("SshKeyValue"))
                        {
                            WriteVerbose("Updating SshKeyValue");
                            cluster.LinuxProfile.Ssh.PublicKeys = new List<ContainerServiceSshPublicKey>
                            {
                                new ContainerServiceSshPublicKey(GetSshKey(SshKeyValue))
                            };
                        }

                        if (ParameterSetName == SpParamSet)
                        {
                            WriteVerbose("Updating service principal");
                            var acsServicePrincipal = EnsureServicePrincipal(ClientId, ClientSecret);

                            var spProfile = new ContainerServiceServicePrincipalProfile(
                                acsServicePrincipal.SpId,
                                acsServicePrincipal.ClientSecret);
                            cluster.ServicePrincipalProfile = spProfile;
                        }

                        if (MyInvocation.BoundParameters.ContainsKey("AdminUserName"))
                        {
                            WriteVerbose("Updating admin username");
                            cluster.LinuxProfile.AdminUsername = AdminUserName;
                        }

                        ContainerServiceAgentPoolProfile defaultAgentPoolProfile;
                        if (cluster.AgentPoolProfiles.Any(x => x.Name == "default"))
                        {
                            defaultAgentPoolProfile = cluster.AgentPoolProfiles.First(x => x.Name == "default");
                        }
                        else
                        {
                            defaultAgentPoolProfile = new ContainerServiceAgentPoolProfile(
                                "default",
                                NodeVmSize,
                                NodeCount,
                                NodeOsDiskSize,
                                DnsNamePrefix ?? DefaultDnsPrefix());
                            cluster.AgentPoolProfiles.Add(defaultAgentPoolProfile);
                        }

                        if (MyInvocation.BoundParameters.ContainsKey("NodeVmSize"))
                        {
                            WriteVerbose("Updating node VM size");
                            defaultAgentPoolProfile.VmSize = NodeVmSize;
                        }

                        if (MyInvocation.BoundParameters.ContainsKey("NodeCount"))
                        {
                            WriteVerbose("Updating node count");
                            defaultAgentPoolProfile.Count = NodeCount;
                        }

                        if (MyInvocation.BoundParameters.ContainsKey("NodeOsDiskSize"))
                        {
                            WriteVerbose("Updating node OS disk size");
                            defaultAgentPoolProfile.OsDiskSizeGB = NodeOsDiskSize;
                        }

                        if (MyInvocation.BoundParameters.ContainsKey("KubernetesVersion"))
                        {
                            WriteVerbose("Updating Kubernetes version");
                            cluster.KubernetesVersion = KubernetesVersion;
                        }

                        if (MyInvocation.BoundParameters.ContainsKey("Tags"))
                        {
                            WriteVerbose("Updating tags");
                            cluster.Tags = TagsConversionHelper.CreateTagDictionary(Tags, true);
                        }

                        WriteVerbose("Updating your managed Kubernetes cluster.");
                    }
                    else
                    {
                        WriteVerbose("Preparing for deployment of your new managed Kubernetes cluster.");
                        cluster = BuildNewCluster();
                    }

                    var kubeCluster = Client.ManagedClusters.CreateOrUpdate(ResourceGroupName, Name, cluster);
                    WriteObject(PSMapper.Instance.Map<PSKubernetesCluster>(kubeCluster));
                });
            }
        }
    }
}