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
using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.Azure.Management.ContainerInstance.Models;

namespace Microsoft.Azure.Commands.ContainerInstance.Models
{
    /// <summary>
    /// PSObject for a container group.
    /// </summary>
    public class PSContainerGroup
    {
        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName
        {
            get
            {
                if (string.IsNullOrEmpty(this.Id)) return null;
                Regex r = new Regex(@"(.*?)/resourcegroups/(?<rgname>\S+)/providers/(.*?)", RegexOptions.IgnoreCase);
                Match m = r.Match(this.Id);
                return m.Success ? m.Groups["rgname"].Value : null;
            }
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the provisioning state.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets the containers.
        /// </summary>
        public IList<PSContainer> Containers { get; set; }

        /// <summary>
        /// Gets or sets the image registry credentials.
        /// </summary>
        public IList<ImageRegistryCredential> ImageRegistryCredentials { get; set; }

        /// <summary>
        /// Gets or sets the restart policy.
        /// </summary>
        public string RestartPolicy { get; set; }

        /// <summary>
        /// Gets or sets the IP address.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the DNS name label.
        /// </summary>
        public string DnsNameLabel { get; set; }

        /// <summary>
        /// Gets the FQDN.
        /// </summary>
        public string Fqdn { get; set; }

        /// <summary>
        /// Gets or sets the ports.
        /// </summary>
        public IList<PSPort> Ports { get; set; }

        /// <summary>
        /// Gets or sets the OS type.
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        /// Gets or sets the volumes.
        /// </summary>
        public IList<Volume> Volumes { get; set; }

        /// <summary>
        /// Gets or sets the state of the container group.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        public IList<PSEvent> Events { get; set; }

        /// <summary>
        /// Build a PSContainerGroup from a ContainerGroup object.
        /// </summary>
        public static PSContainerGroup FromContainerGroup(ContainerGroup containerGroup)
        {
            return new PSContainerGroup()
            {
                Id = containerGroup?.Id,
                Name = containerGroup?.Name,
                Type = containerGroup?.Type,
                Location = containerGroup?.Location,
                Tags = containerGroup?.Tags,
                ProvisioningState = containerGroup?.ProvisioningState,
                Containers = containerGroup?.Containers?.Select(c => PSContainer.FromContainer(c)).ToList(),
                ImageRegistryCredentials = containerGroup?.ImageRegistryCredentials,
                RestartPolicy = containerGroup?.RestartPolicy,
                IpAddress = containerGroup?.IpAddress?.Ip,
                DnsNameLabel = containerGroup?.IpAddress?.DnsNameLabel,
                Fqdn = containerGroup?.IpAddress?.Fqdn,
                Ports = containerGroup?.IpAddress?.Ports?.Select(p => ContainerInstanceAutoMapperProfile.Mapper.Map<PSPort>(p)).ToList(),
                OsType = containerGroup?.OsType,
                Volumes = containerGroup?.Volumes,
                State = containerGroup?.InstanceView?.State,
                Events = containerGroup?.InstanceView?.Events?.Select(e => ContainerInstanceAutoMapperProfile.Mapper.Map<PSEvent>(e)).ToList()
            };
        }
    }
}
