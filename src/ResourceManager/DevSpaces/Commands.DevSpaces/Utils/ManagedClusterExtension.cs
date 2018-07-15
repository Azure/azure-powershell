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
using Microsoft.Azure.Commands.Aks.Generated.Version2017_08_31.Models;
using Microsoft.Azure.Commands.DevSpaces.Properties;
using Microsoft.Azure.Management.DevSpaces.Models;

namespace Microsoft.Azure.Commands.DevSpaces.Utils
{
    public static class ManagedClusterExtension
    {
        public static Controller GetNewDevSpaceControllerParam(this ManagedCluster managedCluster, ManagedClusterAccessProfile accessProfile, dynamic armProperties)
        {
            var clusterLocation =  managedCluster.Location;
            dynamic httpApplicationRouting = armProperties?.addonProfiles?.httpApplicationRouting;
            var clusterDnsZone = httpApplicationRouting?.config?.HTTPApplicationRoutingZoneName;

            var createParameters = new Controller()
            {
                Location = clusterLocation,
                Sku = new Azure.Management.DevSpaces.Models.Sku(),
                Tags = null,
                HostSuffix = clusterDnsZone,
                TargetContainerHostResourceId = managedCluster.Id,
                TargetContainerHostCredentialsBase64 = accessProfile.KubeConfig
            };

            return createParameters;
        } 

        public static bool IsDevSpacesSupported(this ManagedCluster managedCluster,out string reason)
        {
            reason = string.Empty;
            if (new Version(managedCluster.KubernetesVersion) < new Version(DevSpacesConstants.MinimumKubernetesVersion))
            {
                reason = string.Format(Resources.NotSupportedTargetClusterVersion, managedCluster.Name, managedCluster.KubernetesVersion, DevSpacesConstants.MinimumKubernetesVersion);
                return false;
            }

            return true;
        }
    }
}
