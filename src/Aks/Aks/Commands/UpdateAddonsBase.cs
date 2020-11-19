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
using Microsoft.Rest.Azure;

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Aks.Commands
{
    public abstract class UpdateAddonsBase : KubeCmdletBase
    {
        private const string IdParameterSet = "IdParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";
        protected const string DefaultParamSet = "defaultParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = DefaultParamSet,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = DefaultParamSet,
            HelpMessage = "Kubernetes managed cluster Name.")]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "A PSKubernetesCluster object, normally passed through the pipeline.")]
        [ValidateNotNullOrEmpty]
        public PSKubernetesCluster ClusterObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Add-on names to be enabled when cluster is created.")]
        [ValidateNotNullOrEmpty()]
        [PSArgumentCompleter("HttpApplicationRouting", "Monitoring", "VirtualNode", "AzurePolicy", "KubeDashboard")]
        public string[] Name { get; set; }

        public override void ExecuteCmdlet()
        {
            ManagedCluster cluster = null;
            switch (ParameterSetName)
            {
                case InputObjectParameterSet:
                    {
                        WriteVerbose(Resources.UsingClusterFromPipeline);
                        cluster = PSMapper.Instance.Map<ManagedCluster>(ClusterObject);
                        var resource = new ResourceIdentifier(cluster.Id);
                        ResourceGroupName = resource.ResourceGroupName;
                        ClusterName = resource.ResourceName;
                        break;
                    }
            }

            var msg = $"{Name} in {ResourceGroupName}";

            if (ShouldProcess(msg, Resources.UpdateOrCreateAManagedKubernetesCluster))
            {
                if (cluster == null)
                {
                    cluster = GetManagedClusterWithResourceGroupNameAndName();
                }
                cluster.AddonProfiles = UpdateAddonsProfile(cluster.AddonProfiles);
                cluster.ServicePrincipalProfile = null;
                cluster.AadProfile = null;
                cluster.AgentPoolProfiles = null;
                var kubeCluster = Client.ManagedClusters.CreateOrUpdate(ResourceGroupName, ClusterName, cluster);
                WriteObject(PSMapper.Instance.Map<PSKubernetesCluster>(kubeCluster));
            }
        }

        protected abstract IDictionary<string, ManagedClusterAddonProfile> UpdateAddonsProfile(IDictionary<string, ManagedClusterAddonProfile> addonProfiles);

        private ManagedCluster GetManagedClusterWithResourceGroupNameAndName()
        {
            try
            {
                var cluster = Client.ManagedClusters.Get(ResourceGroupName, ClusterName);
                WriteVerbose(string.Format(Resources.ClusterExists, cluster.Id));
                return cluster;
            }
            catch (CloudException exception)
            {
                // Write exception out to error channel.
                WriteError(new ErrorRecord(exception, Resources.ClusterDoesNotExist, ErrorCategory.CloseError, null));
                return null;
            }
        }
    }
}
