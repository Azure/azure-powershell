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
using Microsoft.Azure.Commands.Kubernetes.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Kubernetes
{
    [Cmdlet(VerbsCommon.Set, KubeNounStr, DefaultParameterSetName = DefaultParamSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSKubernetesCluster))]
    public class SetAzureRmKubernetes : CreateOrUpdateKubeBase
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
        [Alias("ResourceId")]
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
                    WriteVerbose(Resources.UsingClusterFromPipeline);
                    cluster = PSMapper.Instance.Map<ManagedCluster>(InputObject);
                    var resource = new ResourceIdentifier(cluster.Id);
                    ResourceGroupName = resource.ResourceGroupName;
                    Name = resource.ResourceName;
                    break;
                }
            }

            var msg = $"{Name} in {ResourceGroupName}";

            if (ShouldProcess(msg, Resources.UpdateOrCreateAManagedKubernetesCluster))
            {
                RunCmdLet(() =>
                {
                    if (Exists())
                    {
                        if (cluster == null)
                        {
                            cluster = Client.ManagedClusters.Get(ResourceGroupName, Name);
                        }

                        if (MyInvocation.BoundParameters.ContainsKey("Location"))
                        {
                            throw new CmdletInvocationException(Resources.LocationCannotBeUpdateForExistingCluster);
                        }

                        if (MyInvocation.BoundParameters.ContainsKey("DnsNamePrefix"))
                        {
                            WriteVerbose(Resources.UpdatingDnsNamePrefix);
                            cluster.DnsPrefix = DnsNamePrefix;
                        }

                        if (MyInvocation.BoundParameters.ContainsKey("SshKeyValue"))
                        {
                            WriteVerbose(Resources.UpdatingSshKeyValue);
                            cluster.LinuxProfile.Ssh.PublicKeys = new List<ContainerServiceSshPublicKey>
                            {
                                new ContainerServiceSshPublicKey(GetSshKey(SshKeyValue))
                            };
                        }

                        if (ParameterSetName == SpParamSet)
                        {
                            WriteVerbose(Resources.UpdatingServicePrincipal);
                            var acsServicePrincipal = EnsureServicePrincipal(ClientIdAndSecret.UserName, ClientIdAndSecret.Password.ToString());

                            var spProfile = new ContainerServiceServicePrincipalProfile(
                                acsServicePrincipal.SpId,
                                acsServicePrincipal.ClientSecret);
                            cluster.ServicePrincipalProfile = spProfile;
                        }

                        if (MyInvocation.BoundParameters.ContainsKey("AdminUserName"))
                        {
                            WriteVerbose(Resources.UpdatingAdminUsername);
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
                            WriteVerbose(Resources.UpdatingNodeVmSize);
                            defaultAgentPoolProfile.VmSize = NodeVmSize;
                        }

                        if (MyInvocation.BoundParameters.ContainsKey("NodeCount"))
                        {
                            WriteVerbose(Resources.UpdatingNodeCount);
                            defaultAgentPoolProfile.Count = NodeCount;
                        }

                        if (MyInvocation.BoundParameters.ContainsKey("NodeOsDiskSize"))
                        {
                            WriteVerbose(Resources.UpdatingNodeOsDiskSize);
                            defaultAgentPoolProfile.OsDiskSizeGB = NodeOsDiskSize;
                        }

                        if (MyInvocation.BoundParameters.ContainsKey("KubernetesVersion"))
                        {
                            WriteVerbose(Resources.UpdatingKubernetesVersion);
                            cluster.KubernetesVersion = KubernetesVersion;
                        }

                        if (MyInvocation.BoundParameters.ContainsKey("Tag"))
                        {
                            WriteVerbose(Resources.UpdatingTags);
                            cluster.Tags = TagsConversionHelper.CreateTagDictionary(Tag, true);
                        }

                        WriteVerbose(Resources.UpdatingYourManagedKubernetesCluster);
                    }
                    else
                    {
                        WriteVerbose(Resources.PreparingForDeploymentOfYourNewManagedKubernetesCluster);
                        cluster = BuildNewCluster();
                    }

                    var kubeCluster = Client.ManagedClusters.CreateOrUpdate(ResourceGroupName, Name, cluster);
                    WriteObject(PSMapper.Instance.Map<PSKubernetesCluster>(kubeCluster));
                });
            }
        }
    }
}