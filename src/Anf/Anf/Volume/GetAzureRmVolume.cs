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

using System.Management.Automation;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Anf.Common;
using Microsoft.Azure.Commands.Anf.Helpers;
using Microsoft.Azure.Commands.Anf.Models;
using Microsoft.Azure.Management.NetApp;
using System.Linq;

namespace Microsoft.Azure.Commands.Anf.Volume
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AnfVolume"), OutputType(typeof(PSAnfVolume))]
    public class GetAzureRmAnfVolume : AzureAnfCmdletBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group of the ANF volume",
            ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF account",
            ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF pool",
            ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string PoolName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the ANF volume",
            ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string VolumeName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource id of the ANF volume",
            ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                var parentResources = resourceIdentifier.ParentResource.Split('/');
                AccountName = parentResources[1];
                PoolName = parentResources[3];
                VolumeName = resourceIdentifier.ResourceName;
            }

            if (VolumeName != null)
            {
                var anfVolume = AzureNetAppFilesManagementClient.Volumes.Get(ResourceGroupName, AccountName, PoolName, VolumeName);
                WriteObject(anfVolume.ToPsAnfVolume());
            }
            else
            {
                var anfSnapshot = AzureNetAppFilesManagementClient.Volumes.List(ResourceGroupName, AccountName, PoolName).Select(e => e.ToPsAnfVolume());
                WriteObject(anfSnapshot, true);
            }
        }
    }
}
