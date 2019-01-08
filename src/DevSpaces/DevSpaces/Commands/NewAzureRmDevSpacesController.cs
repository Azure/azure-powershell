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
using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.Aks.Generated.Version2017_08_31;
using Microsoft.Azure.Commands.Aks.Generated.Version2017_08_31.Models;
using Microsoft.Azure.Commands.DevSpaces.Models;
using Microsoft.Azure.Commands.DevSpaces.Properties;
using Microsoft.Azure.Commands.DevSpaces.Utils;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.DevSpaces;
using Microsoft.Azure.Management.DevSpaces.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;

namespace Microsoft.Azure.Commands.DevSpaces.Commands
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DevSpacesController", SupportsShouldProcess = true)]
    [OutputType(typeof(PSController))]
    public class NewAzureRmDevSpacesController : DevSpacesCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "DevSpaces Controller Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = "Target Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string TargetResourceGroupName { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            HelpMessage = "Target Cluster Name.")]
        [ValidateNotNullOrEmpty]
        public string TargetClusterName { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            var msg = $"{Name} in {ResourceGroupName}";
            if (ShouldProcess(msg, Resources.CreatingADevSpacesController))
            {
                RunCmdLet(NewDevSpacesControllerAction);
            }
        }

        private void NewDevSpacesControllerAction()
        {
            string devSpacesNotSupportedReason = String.Empty;

            WriteVerbose(string.Format(Resources.FetchCluster, TargetClusterName, TargetResourceGroupName));
            ManagedCluster cluster = ContainerClient.ManagedClusters.Get(TargetResourceGroupName, TargetClusterName);
            if (!cluster.IsDevSpacesSupported(out devSpacesNotSupportedReason))
            {
                throw new Exception(devSpacesNotSupportedReason);
            }

            WriteVerbose(string.Format(Resources.FetchClusterAccessProfile, TargetClusterName, TargetResourceGroupName));
            ManagedClusterAccessProfile accessProfile = ContainerClient.ManagedClusters.GetAccessProfiles(TargetResourceGroupName, TargetClusterName, "clusterUser");
            if (accessProfile == null || string.IsNullOrEmpty(accessProfile.KubeConfig))
            {
                throw new Exception(String.Format(Resources.CanNotFetchKubeConfig, TargetClusterName));
            }

            GenericResource resource = RmClient.Resources.Get(TargetResourceGroupName, "Microsoft.ContainerService", "", "managedClusters", TargetClusterName, "2018-03-31");
            if (!resource.IsDevSpacesSupported(out devSpacesNotSupportedReason))
            {
                throw new Exception(devSpacesNotSupportedReason);
            }

            Controller createControllerParam = cluster.GetNewDevSpaceControllerParam(accessProfile, resource.Properties);
            createControllerParam.Tags = TagsConversionHelper.CreateTagDictionary(Tag, true);
            WriteVerbose(string.Format(Resources.CreatingDevSpaces, Name, ResourceGroupName));
            Controller controller = Client.Controllers.Create(ResourceGroupName, Name, createControllerParam);
            WriteObject(new PSController(controller));
        }
    }
}
