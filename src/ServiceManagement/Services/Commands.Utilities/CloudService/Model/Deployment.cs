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
using System.Linq;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService.Model
{
    /// <summary>
    /// Class describing a deployment
    /// </summary>
    public class Deployment
    {
        public Deployment()
        {
            RoleInstanceList = new List<RoleInstance>();
            RoleList = new List<Role>();
            ExtendedProperties = new Dictionary<string, string>();
            VirtualIPs = new List<VirtualIP>();
        }

        internal Deployment(DeploymentGetResponse response)
            : this()
        {
            if (response.PersistentVMDowntime != null)
            {
                PersistentVMDowntime = new PersistentVMDowntimeInfo(response.PersistentVMDowntime);
            }

            Name = response.Name;
            DeploymentSlot = response.DeploymentSlot == Management.Compute.Models.DeploymentSlot.Staging ? "Staging" : "Production";
            PrivateID = response.PrivateId;
            Status = DeploymentStatusFactory.From(response.Status);
            Label = response.Label;
            Url = response.Uri;
            Configuration = response.Configuration;
            foreach (var roleInstance in response.RoleInstances.Select(ri => new RoleInstance(ri)))
            {
                RoleInstanceList.Add(roleInstance);
            }

            if (response.UpgradeStatus != null)
            {
                UpgradeStatus = new UpgradeStatus(response.UpgradeStatus);
            }

            UpgradeDomainCount = response.UpgradeDomainCount;
            if (response.Roles != null)
            {
                foreach (var role in response.Roles.Select(r => new Role(r)))
                {
                    RoleList.Add(role);
                }
            }
            SdkVersion = response.SdkVersion;
            Locked = response.Locked;
            RollbackAllowed = response.RollbackAllowed;
            VirtualNetworkName = response.VirtualNetworkName;
            CreatedTime = response.CreatedTime;
            LastModifiedTime = response.LastModifiedTime;

            if (response.ExtendedProperties != null)
            {
                foreach (var prop in response.ExtendedProperties.Keys)
                {
                    ExtendedProperties[prop] = response.ExtendedProperties[prop];
                }
            }

            if (response.DnsSettings != null)
            {
                Dns = new DnsSettings(response.DnsSettings);
            }
            if (response.VirtualIPAddresses != null)
            {
                foreach (var vip in response.VirtualIPAddresses.Select(v => new VirtualIP(v)))
                {
                    VirtualIPs.Add(vip);
                }
            }
        }

        public PersistentVMDowntimeInfo PersistentVMDowntime { get; set; }
        public string Name { get; set; }
        public string DeploymentSlot { get; set; }
        public string PrivateID { get; set; }
        public DeploymentStatus Status { get; set; }
        public string Label { get; set; }
        public Uri Url { get; set; }
        public string Configuration { get; set; }
        public IList<RoleInstance> RoleInstanceList { get; private set; }
        public UpgradeStatus UpgradeStatus { get; set; }
        public int UpgradeDomainCount { get; set; }
        public IList<Role> RoleList { get; set; }
        public string SdkVersion { get; set; }
        public bool? Locked { get; set; }
        public bool? RollbackAllowed { get; set; }
        public string VirtualNetworkName { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public IDictionary<string, string> ExtendedProperties { get; private set; }
        public DnsSettings Dns { get; set; }
        public IList<VirtualIP> VirtualIPs { get; set; }
    }
}
