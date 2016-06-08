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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Model
{
    using PVM = Model;

    public class DeploymentInfoContext : ServiceOperationContext
    {
        private readonly XNamespace ns = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration";


        public string SdkVersion
        {
            get;
            protected set;
        }

        public bool? RollbackAllowed
        {
            get;
            protected set;
        }

        public string Slot
        {
            get;
            protected set;
        }

        public string Name
        {
            get;
            protected set;
        }

        public string DeploymentName
        {
            get;
            protected set;
        }

        public Uri Url
        {
            get;
            protected set;
        }

        public string Status
        {
            get;
            protected set;
        }

        public int CurrentUpgradeDomain
        {
            get;
            set;
        }

        public string CurrentUpgradeDomainState
        {
            get;
            set;
        }

        public string UpgradeType
        {
            get;
            set;
        }

        public IList<Microsoft.WindowsAzure.Management.Compute.Models.RoleInstance> RoleInstanceList
        {
            get;
            protected set;
        }

        public string Configuration
        {
            get;
            protected set;
        }

        public string DeploymentId
        {
            get;
            protected set;
        }

        public string Label
        {
            get;
            protected set;
        }

        public string VNetName
        {
            get;
            protected set;
        }

        public Microsoft.WindowsAzure.Commands.ServiceManagement.Model.DnsSettings DnsSettings
        {
            get;
            protected set;
        }

        public string OSVersion
        {
            get;
            set;
        }

        public IDictionary<string, RoleConfiguration> RolesConfiguration
        {
            get;
            protected set;
        }

        public PVM.VirtualIPList VirtualIPs
        {
            get;
            protected set;
        }

        public string ReservedIPName
        {
            get;
            protected set;
        }

        public DateTime? CreatedTime
        {
            get;
            protected set;
        }

        public DateTime? LastModifiedTime
        {
            get;
            protected set;
        }

        public bool? Locked
        {
            get;
            protected set;
        }

        public string InternalLoadBalancerName
        {
            get;
            protected set;
        }

        public PVM.LoadBalancerList LoadBalancers
        {
            get;
            protected set;
        }

        public PVM.ExtensionConfiguration ExtensionConfiguration
        {
            get;
            protected set;
        }

        public DeploymentInfoContext(DeploymentGetResponse deployment)
        {
            this.Slot             = deployment.DeploymentSlot.ToString();
            this.Name             = deployment.Name;
            this.DeploymentName   = deployment.Name;
            this.Url              = deployment.Uri;
            this.Status           = deployment.Status.ToString();
            this.DeploymentId     = deployment.PrivateId;
            this.VNetName         = deployment.VirtualNetworkName;
            this.SdkVersion       = deployment.SdkVersion;
            this.CreatedTime      = deployment.CreatedTime;
            this.LastModifiedTime = deployment.LastModifiedTime;
            this.Locked           = deployment.Locked;

            // IP Related
            this.ReservedIPName = deployment.ReservedIPName;
            this.VirtualIPs = deployment.VirtualIPAddresses == null ? null : new PVM.VirtualIPList(
                deployment.VirtualIPAddresses.Select(a =>
                    new PVM.VirtualIP
                    {
                        Address = a.Address,
                        IsDnsProgrammed = a.IsDnsProgrammed,
                        Name = a.Name,
                        ReservedIPName = a.ReservedIPName
                    }));

            // DNS
            if (deployment.DnsSettings != null)
            {
                this.DnsSettings = new Microsoft.WindowsAzure.Commands.ServiceManagement.Model.DnsSettings
                {
                    DnsServers = new Microsoft.WindowsAzure.Commands.ServiceManagement.Model.DnsServerList()
                };

                foreach (var dns in deployment.DnsSettings.DnsServers)
                {
                    var newDns = new Microsoft.WindowsAzure.Commands.ServiceManagement.Model.DnsServer
                    {
                        Name = dns.Name,
                        Address = dns.Address.ToString()
                    };
                    this.DnsSettings.DnsServers.Add(newDns);
                }
            }

            this.RollbackAllowed = deployment.RollbackAllowed;
            if (deployment.UpgradeStatus != null)
            {
                this.CurrentUpgradeDomain = deployment.UpgradeStatus.CurrentUpgradeDomain;
                this.CurrentUpgradeDomainState = deployment.UpgradeStatus.CurrentUpgradeDomainState.ToString();
                this.UpgradeType = deployment.UpgradeStatus.UpgradeType.ToString();
            }

            this.Configuration = string.IsNullOrEmpty(deployment.Configuration) ? string.Empty : deployment.Configuration;

            this.Label = string.IsNullOrEmpty(deployment.Label) ? string.Empty : deployment.Label;

            this.RoleInstanceList = deployment.RoleInstances;

            if (!string.IsNullOrEmpty(deployment.Configuration))
            {
                string xmlString = this.Configuration;

                XDocument doc;
                using (var stringReader = new StringReader(xmlString))
                {
                    XmlReader reader = XmlReader.Create(stringReader);
                    doc = XDocument.Load(reader);
                }

                this.OSVersion = doc.Root.Attribute("osVersion") != null ?
                                 doc.Root.Attribute("osVersion").Value :
                                 string.Empty;

                this.RolesConfiguration = new Dictionary<string, RoleConfiguration>();

                var roles = doc.Root.Descendants(this.ns + "Role").Where(t => t.Parent == doc.Root);

                foreach (var role in roles)
                {
                    this.RolesConfiguration.Add(role.Attribute("name").Value, new RoleConfiguration(role));
                }
            }

            // ILB
            if (deployment.LoadBalancers != null)
            {
                this.LoadBalancers = new PVM.LoadBalancerList(
                    from b in deployment.LoadBalancers
                    select new PVM.LoadBalancer
                    {
                        Name = b.Name,
                        FrontEndIpConfiguration = b.FrontendIPConfiguration == null ? null : new PVM.IpConfiguration
                        {
                            StaticVirtualNetworkIPAddress = b.FrontendIPConfiguration.StaticVirtualNetworkIPAddress,
                            SubnetName = b.FrontendIPConfiguration.SubnetName,
                            Type = string.Equals(
                                       b.FrontendIPConfiguration.Type,
                                       PVM.LoadBalancerType.Private.ToString(),
                                       StringComparison.OrdinalIgnoreCase)
                                 ? PVM.LoadBalancerType.Private : PVM.LoadBalancerType.Unknown
                        }
                    });

                this.InternalLoadBalancerName = this.LoadBalancers == null || !this.LoadBalancers.Any() ? null
                                              : this.LoadBalancers.First().Name;
            }

            // ExtensionConfiguration
            if (deployment.ExtensionConfiguration != null)
            {
                this.ExtensionConfiguration = new PVM.ExtensionConfiguration();
                if (deployment.ExtensionConfiguration.AllRoles != null)
                {
                    this.ExtensionConfiguration.AllRoles = new PVM.AllRoles(
                        from all in deployment.ExtensionConfiguration.AllRoles
                        select new PVM.Extension(all.Id, 0, all.State));
                }

                if (deployment.ExtensionConfiguration.NamedRoles != null)
                {
                    this.ExtensionConfiguration.NamedRoles = new PVM.NamedRoles();
                    foreach (var role in deployment.ExtensionConfiguration.NamedRoles)
                    {
                        var extList = new PVM.ExtensionList(
                            from ext in role.Extensions
                            select new PVM.Extension(ext.Id, 0, ext.State));

                        this.ExtensionConfiguration.NamedRoles.Add(new PVM.RoleExtensions
                        {
                            RoleName = role.RoleName,
                            Extensions = extList
                        });
                    }
                }
            }
        }

        public XDocument SerializeRolesConfiguration()
        {
            XDocument document = new XDocument();

            XElement rootElement = new XElement(this.ns + "ServiceConfiguration");
            document.Add(rootElement);

            rootElement.SetAttributeValue("serviceName", this.ServiceName);
            rootElement.SetAttributeValue("osVersion", this.OSVersion);
            rootElement.SetAttributeValue("xmlns", this.ns.ToString());

            foreach (var roleConfig in this.RolesConfiguration)
            {
                rootElement.Add(roleConfig.Value.Serialize());
            }

            return document;
        }
    }
}
