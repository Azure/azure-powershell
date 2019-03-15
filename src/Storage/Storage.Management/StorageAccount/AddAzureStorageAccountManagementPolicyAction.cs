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

using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageAccountManagementPolicyAction", DefaultParameterSetName = BaseBlobParameterSet), OutputType(typeof(PSManagementPolicyActionGroup))]
    public class AddAzureStorageAccountManagementPolicyActionCommand : StorageAccountBaseCmdlet
    {
        protected const string BaseBlobParameterSet = "BaseBlob";
        protected const string SnapshotParameterSet = "Snapshot";

        [Parameter(Mandatory = true,
            HelpMessage = "The management policy action for baseblob.",
            ParameterSetName = BaseBlobParameterSet)]
        [ValidateSet(ManagementPolicyAction.Delete,
            ManagementPolicyAction.TierToArchive,
            ManagementPolicyAction.TierToCool,
            IgnoreCase = true)]
        public string BaseBlobAction { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The management policy action for snapshot.",
            ParameterSetName = SnapshotParameterSet)]
        [ValidateSet(ManagementPolicyAction.Delete,
            IgnoreCase = true)]
        public string SnapshotAction { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Integer value indicating the age in days after creation.",
            ParameterSetName = SnapshotParameterSet)]
        [ValidateNotNullOrEmpty]
        public int DaysAfterCreationGreaterThan { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Integer value indicating the age in days after last modification.",
            ParameterSetName = BaseBlobParameterSet)]
        [ValidateNotNullOrEmpty]
        public int DaysAfterModificationGreaterThan { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "If input the ManagementPolicy Action object, will set the action to the input action object. If not input, will create a new action object.",
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSManagementPolicyActionGroup InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            PSManagementPolicyActionGroup action = InputObject;
            if (action is null)
            {
                action = new PSManagementPolicyActionGroup();
            }
            switch (this.ParameterSetName)
            {
                case BaseBlobParameterSet:
                    if (action.BaseBlob is null)
                    {
                        action.BaseBlob = new PSManagementPolicyBaseBlob();
                    }
                    switch (BaseBlobAction)
                    {
                        case ManagementPolicyAction.Delete:
                            action.BaseBlob.Delete = new PSDateAfterModification(this.DaysAfterModificationGreaterThan);
                            break;
                        case ManagementPolicyAction.TierToCool:
                            action.BaseBlob.TierToCool = new PSDateAfterModification(this.DaysAfterModificationGreaterThan);
                            break;
                        case ManagementPolicyAction.TierToArchive:
                            action.BaseBlob.TierToArchive = new PSDateAfterModification(this.DaysAfterModificationGreaterThan);
                            break;
                        default:
                            throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid BaseBlobAction: {0}", this.BaseBlobAction));
                    }
                    break;
                case SnapshotParameterSet:
                    if (action.Snapshot is null)
                    {
                        action.Snapshot = new PSManagementPolicySnapShot();
                    }
                    action.Snapshot.Delete = new PSDateAfterCreation(this.DaysAfterCreationGreaterThan);
                    break;
                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ParameterSet: {0}", this.ParameterSetName));
            }

            WriteObject(action);
        }
    }
}
