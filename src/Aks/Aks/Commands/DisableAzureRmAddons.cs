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
using Microsoft.Azure.Commands.Aks.Utils;
using Microsoft.Azure.Management.ContainerService.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Microsoft.Azure.Commands.Aks.Commands
{
    [Cmdlet(VerbsLifecycle.Disable, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AksAddOn", DefaultParameterSetName = DefaultParamSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSKubernetesCluster))]
    public class DisableAzureRmAddons : UpdateAddonsBase
    {
        protected override IDictionary<string, ManagedClusterAddonProfile> UpdateAddonsProfile(IDictionary<string, ManagedClusterAddonProfile> addonProfiles)
        {
            foreach (var addOn in Name)
            {
                string addonServiceName = Constants.AddOnUserReadNameToServiceNameMapper.GetValueOrDefault(addOn, null);
                if (addonServiceName == null)
                {
                    throw new ArgumentException(string.Format(Resources.AddonNotDefined, addOn));
                }
                if (!addonProfiles.ContainsKey(addonServiceName))
                {
                    throw new ArgumentException(string.Format(Resources.AddonIsNotInstalled, addOn));
                }
                ManagedClusterAddonProfile addonProfile = addonProfiles[addonServiceName];
                addonProfile.Config = null;
                addonProfile.Enabled = false;
            }

            return addonProfiles;
        }
    }
}
