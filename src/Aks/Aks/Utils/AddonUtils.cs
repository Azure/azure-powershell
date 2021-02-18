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

using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Management.ContainerService.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Aks.Utils
{
    static class AddonUtils
    {
        public static string TrimWorkspaceResourceId(string workspaceResourceId)
        {
            return string.Format("/{0}", workspaceResourceId.Trim().Trim('/'));
        }

        public static IDictionary<string, ManagedClusterAddonProfile> EnableAddonsProfile(
            IDictionary<string, ManagedClusterAddonProfile> addonProfiles, 
            string[] addOnParameterValue, string addOnParameterName, 
            string workspaceResourceIdValue, string workspaceResourceIdParameterName,
            string subnetNameValue, string subnetNameParameterName)
        {
            foreach (var addOn in addOnParameterValue)
            {
                if (addOn.Equals(Constants.AddOnNameMonitoring))
                {
                    addonProfiles = EnableAddonMonitoring(addonProfiles, workspaceResourceIdValue, workspaceResourceIdParameterName);
                }
                else if (addOn.Equals(Constants.AddOnNameVirtualNode))
                {
                    addonProfiles = EnableAddonVirtualNode(addonProfiles, subnetNameValue, subnetNameParameterName);
                }
                else
                {
                    string addonServiceName = Constants.AddOnUserReadNameToServiceNameMapper.GetValueOrDefault(addOn, null);
                    if (addonServiceName == null)
                    {
                        var message = string.Format(Resources.AddonNotDefined, addOn, string.Join(",", Constants.AddOnUserReadNameToServiceNameMapper.Keys));
                        throw new AzPSArgumentException(
                            message,
                            addOnParameterName,
                            desensitizedMessage: message);
                    }
                    ManagedClusterAddonProfile addonProfile = new ManagedClusterAddonProfile(true, null);
                    addonProfiles = EnableAddonsProfile(addonProfiles, addonServiceName, addonProfile);
                }
            }

            return addonProfiles;
        }

        private static IDictionary<string, ManagedClusterAddonProfile> EnableAddonsProfile(IDictionary<string, ManagedClusterAddonProfile> addonProfiles, string addonServiceName, ManagedClusterAddonProfile addonProfile)
        {
            addonProfiles[addonServiceName] = addonProfile;

            return addonProfiles;
        }

        private static IDictionary<string, ManagedClusterAddonProfile> EnableAddonMonitoring(
            IDictionary<string, ManagedClusterAddonProfile> addonProfiles, 
            string workspaceResourceIdValue, string workspaceResourceIdParameterName)
        {
            if (workspaceResourceIdValue == null)
            {
                throw new AzPSArgumentException(
                    Resources.AddonMonitoringShouldWorkWithWorkspaceResourceId,
                    workspaceResourceIdParameterName,
                    desensitizedMessage: Resources.AddonMonitoringShouldWorkWithWorkspaceResourceId);
            }
            string addonServiceName = Constants.AddOnUserReadNameToServiceNameMapper.GetValueOrDefault(Constants.AddOnNameMonitoring, null);
            Dictionary<string, string> config = new Dictionary<string, string>
            {
                { "logAnalyticsWorkspaceResourceID", TrimWorkspaceResourceId(workspaceResourceIdValue) }
            };
            ManagedClusterAddonProfile addonProfile = new ManagedClusterAddonProfile(true, config);
            addonProfiles = EnableAddonsProfile(addonProfiles, addonServiceName, addonProfile);
            return addonProfiles;
        }

        private static IDictionary<string, ManagedClusterAddonProfile> EnableAddonVirtualNode(
            IDictionary<string, ManagedClusterAddonProfile> addonProfiles, 
            string subnetNameValue, string subnetNameParameterName)
        {
            if (subnetNameValue == null)
            {
                throw new AzPSArgumentNullException(
                    Resources.AddonVirtualNodeShouldWorkWithSubnetName,
                    subnetNameParameterName,
                    desensitizedMessage: Resources.AddonVirtualNodeShouldWorkWithSubnetName);
            }
            string osType = "Linux";
            string addonServiceName = string.Format("{0}{1}", Constants.AddOnUserReadNameToServiceNameMapper.GetValueOrDefault(Constants.AddOnNameVirtualNode, null), osType);
            Dictionary<string, string> config = new Dictionary<string, string>
            {
                { "SubnetName", subnetNameValue }
            };
            ManagedClusterAddonProfile addonProfile = new ManagedClusterAddonProfile(true, config);
            addonProfiles = EnableAddonsProfile(addonProfiles, addonServiceName, addonProfile);
            return addonProfiles;
        }
    }
}
