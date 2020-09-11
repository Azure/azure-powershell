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

using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.Azure.Management.ContainerService.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Aks.Utils
{
    static class AddonUtils
    {
        public static string TrimWorkspaceResourceId(string workspaceResourceId)
        {
            return string.Format("/{0}", workspaceResourceId.Trim().Trim('/'));
        }

        public static IDictionary<string, ManagedClusterAddonProfile> EnableAddonsProfile(IDictionary<string, ManagedClusterAddonProfile> addonProfiles, string[] addOnName, string workspaceResourceId, string subnetName)
        {
            foreach (var addOn in addOnName)
            {
                if (addOn.Equals(Constants.AddOnNameMonitoring))
                {
                    addonProfiles = EnableAddonMonitoring(addonProfiles, workspaceResourceId);
                }
                else if (addOn.Equals(Constants.AddOnNameVirtualNode))
                {
                    addonProfiles = EnableAddonVirtualNode(addonProfiles, subnetName);
                }
                else
                {
                    string addonServiceName = Constants.AddOnUserReadNameToServiceNameMapper.GetValueOrDefault(addOn, null);
                    if (addonServiceName == null)
                    {
                        throw new ArgumentException(string.Format(Resources.AddonNotDefined, addOn));
                    }
                    ManagedClusterAddonProfile addonProfile = new ManagedClusterAddonProfile(true, null);
                    addonProfiles = EnableAddonsProfile(addonProfiles, addonServiceName, addonProfile);
                }
            }

            return addonProfiles;
        }

        private static IDictionary<string, ManagedClusterAddonProfile> EnableAddonsProfile(IDictionary<string, ManagedClusterAddonProfile> addonProfiles, string addonServiceName, ManagedClusterAddonProfile addonProfile)
        {
            if (!addonProfiles.ContainsKey(addonServiceName))
            {
                addonProfiles.Add(addonServiceName, addonProfile);
            }
            else
            {
                addonProfiles[addonServiceName] = addonProfile;
            }

            return addonProfiles;
        }

        private static IDictionary<string, ManagedClusterAddonProfile> EnableAddonMonitoring(IDictionary<string, ManagedClusterAddonProfile> addonProfiles, string workspaceResourceId)
        {
            if (workspaceResourceId == null)
            {
                throw new ArgumentException(Resources.AddonMonitoringShouldWorkWithWorkspaceResourceId);
            }
            string addonServiceName = Constants.AddOnUserReadNameToServiceNameMapper.GetValueOrDefault(Constants.AddOnNameMonitoring, null);
            Dictionary<string, string> config = new Dictionary<string, string>
            {
                { "logAnalyticsWorkspaceResourceID", TrimWorkspaceResourceId(workspaceResourceId) }
            };
            ManagedClusterAddonProfile addonProfile = new ManagedClusterAddonProfile(true, config);
            addonProfiles = EnableAddonsProfile(addonProfiles, addonServiceName, addonProfile);
            return addonProfiles;
        }

        private static IDictionary<string, ManagedClusterAddonProfile> EnableAddonVirtualNode(IDictionary<string, ManagedClusterAddonProfile> addonProfiles, string subnetName)
        {
            if (subnetName == null)
            {
                throw new ArgumentException(Resources.AddonVirtualNodeShouldWorkWithSubnetName);
            }
            string osType = "Linux";
            string addonServiceName = string.Format("{0}{1}", Constants.AddOnUserReadNameToServiceNameMapper.GetValueOrDefault(Constants.AddOnNameVirtualNode, null), osType);
            Dictionary<string, string> config = new Dictionary<string, string>
            {
                { "SubnetName", subnetName }
            };
            ManagedClusterAddonProfile addonProfile = new ManagedClusterAddonProfile(true, config);
            addonProfiles = EnableAddonsProfile(addonProfiles, addonServiceName, addonProfile);
            return addonProfiles;
        }
    }
}
