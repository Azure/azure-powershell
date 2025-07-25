
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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using System.Linq;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.NetAppFiles.SnapshotPolicy
{
    [Cmdlet(
        "Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesSnapshotPolicyVolumeList",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesSnapshotPolicy))]
    [Alias("Get-AnfSnapshotPolicyVolumeList")]
    public class GetAzureRmNetAppFilesSnapshotPolicyVolumeList : AzureNetAppFilesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The resource group of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccount",
            nameof(ResourceGroupName))]
        public string AccountName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the ANF snapshot policy",
            ParameterSetName = FieldsParameterSet)]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParentObjectParameterSet,
            HelpMessage = "The name of the ANF pool")]
        [ValidateNotNullOrEmpty]
        [Alias("SnapshotPolicyName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/snapshotPolicies",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The resource id of the ANF Snapshot Policy")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Snapshot Policy object")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesSnapshotPolicy SnaphotPolicyObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                var parentResources = resourceIdentifier.ParentResource.Split('/');
                AccountName = parentResources[1];
                Name = resourceIdentifier.ResourceName;
            }
            if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = SnaphotPolicyObject.ResourceGroupName;
                var NameParts = SnaphotPolicyObject.Name.Split('/');
                AccountName = NameParts[0];
                Name = NameParts[1];
            }

            try
            {
                var anfSnapshotPoliciesVolumeList = AzureNetAppFilesManagementClient.SnapshotPolicies.ListVolumes(ResourceGroupName, AccountName, Name);
                WriteObject(anfSnapshotPoliciesVolumeList.Value.Select(e => e.ToPsNetAppFilesVolume()), true);
            }
            catch (ErrorResponseException ex)
            {
                throw new CloudException(ex.Body.Error.Message, ex);
            }
        }
    }
}
