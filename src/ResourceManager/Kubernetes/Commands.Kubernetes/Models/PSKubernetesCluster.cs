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
using Microsoft.Azure.Commands.Kubernetes.Generated.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Kubernetes.Models
{
    public class PSKubernetesCluster : PSResource
    {
        /// <summary>
        /// Initializes a new instance of the ManagedCluster class.
        /// </summary>
        /// <param name="location">Resource location</param>
        /// <param name="id">Resource Id</param>
        /// <param name="name">Resource name</param>
        /// <param name="type">Resource type</param>
        /// <param name="tags">Resource tags</param>
        /// <param name="provisioningState">The current deployment or
        /// provisioning state, which only appears in the response.</param>
        /// <param name="dnsPrefix">DNS prefix specified when creating the
        /// managed cluster.</param>
        /// <param name="fqdn">FDQN for the master pool.</param>
        /// <param name="kubernetesVersion">Version of Kubernetes specified
        /// when creating the managed cluster.</param>
        /// <param name="agentPoolProfiles">Properties of the agent
        /// pool.</param>
        /// <param name="linuxProfile">Profile for Linux VMs in the container
        /// service cluster.</param>
        /// <param name="servicePrincipalProfile">Information about a service
        /// principal identity for the cluster to use for manipulating Azure
        /// APIs. Either secret or keyVaultSecretRef must be specified.</param>
        public PSKubernetesCluster(string location, string id = default(string), string name = default(string),
            string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>),
            string provisioningState = default(string), string dnsPrefix = default(string),
            string fqdn = default(string), string kubernetesVersion = default(string),
            IList<PSContainerServiceAgentPoolProfile> agentPoolProfiles =
                default(IList<PSContainerServiceAgentPoolProfile>),
            PSContainerServiceLinuxProfile linuxProfile = default(PSContainerServiceLinuxProfile),
            PSContainerServiceServicePrincipalProfile servicePrincipalProfile =
                default(PSContainerServiceServicePrincipalProfile))
            : base(location, id, name, type, tags)
        {
            ProvisioningState = provisioningState;
            DnsPrefix = dnsPrefix;
            Fqdn = fqdn;
            KubernetesVersion = kubernetesVersion;
            AgentPoolProfiles = agentPoolProfiles;
            LinuxProfile = linuxProfile;
            ServicePrincipalProfile = servicePrincipalProfile;
        }

        /// <summary>
        /// Gets the current deployment or provisioning state, which only
        /// appears in the response.
        /// </summary>
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Gets or sets DNS prefix specified when creating the managed
        /// cluster.
        /// </summary>
        public string DnsPrefix { get; set; }

        /// <summary>
        /// Gets FDQN for the master pool.
        /// </summary>
        public string Fqdn { get; private set; }

        /// <summary>
        /// Gets or sets version of Kubernetes specified when creating the
        /// managed cluster.
        /// </summary>
        public string KubernetesVersion { get; set; }

        /// <summary>
        /// Gets or sets properties of the agent pool.
        /// </summary>
        public IList<PSContainerServiceAgentPoolProfile> AgentPoolProfiles { get; set; }

        /// <summary>
        /// Gets or sets profile for Linux VMs in the container service
        /// cluster.
        /// </summary>
        public PSContainerServiceLinuxProfile LinuxProfile { get; set; }

        /// <summary>
        /// Gets or sets information about a service principal identity for the
        /// cluster to use for manipulating Azure APIs. Either secret or
        /// keyVaultSecretRef must be specified.
        /// </summary>
        public PSContainerServiceServicePrincipalProfile ServicePrincipalProfile { get; set; }
    }
}