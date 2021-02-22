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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageAccountManagementPolicyAction", DefaultParameterSetName = BaseBlobParameterSet), OutputType(typeof(PSManagementPolicyActionGroup))]
    public class AddAzureStorageAccountManagementPolicyActionCommand : StorageAccountBaseCmdlet
    {
        protected const string BaseBlobParameterSet = "BaseBlob";
        protected const string SnapshotParameterSet = "Snapshot";
        protected const string BlobVersionParameterSet = "BlobVersion";

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
            ManagementPolicyAction.TierToArchive,
            ManagementPolicyAction.TierToCool,
            IgnoreCase = true)]
        public string SnapshotAction { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The management policy action for blob version.",
            ParameterSetName = BlobVersionParameterSet)]
        [ValidateSet(ManagementPolicyAction.Delete,
            ManagementPolicyAction.TierToArchive,
            ManagementPolicyAction.TierToCool,
            IgnoreCase = true)]
        public string BlobVersionAction { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Integer value indicating the age in days after creation.",
            ParameterSetName = SnapshotParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Integer value indicating the age in days after creation.",
            ParameterSetName = BlobVersionParameterSet)]
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
                    switch (SnapshotAction)
                    {
                        case ManagementPolicyAction.Delete:
                            action.Snapshot.Delete = new PSDateAfterCreation(this.DaysAfterCreationGreaterThan);
                            break;
                        case ManagementPolicyAction.TierToCool:
                            action.Snapshot.TierToCool = new PSDateAfterCreation(this.DaysAfterCreationGreaterThan);
                            break;
                        case ManagementPolicyAction.TierToArchive:
                            action.Snapshot.TierToArchive = new PSDateAfterCreation(this.DaysAfterCreationGreaterThan);
                            break;
                        default:
                            throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid SnapshotAction: {0}", this.SnapshotAction));
                    }
                    break;
                case BlobVersionParameterSet:
                    if (action.Version is null)
                    {
                        action.Version = new PSManagementPolicyVersion();
                    }
                    switch (BlobVersionAction)
                    {
                        case ManagementPolicyAction.Delete:
                            action.Version.Delete = new PSDateAfterCreation(this.DaysAfterCreationGreaterThan);
                            break;
                        case ManagementPolicyAction.TierToCool:
                            action.Version.TierToCool = new PSDateAfterCreation(this.DaysAfterCreationGreaterThan);
                            break;
                        case ManagementPolicyAction.TierToArchive:
                            action.Version.TierToArchive = new PSDateAfterCreation(this.DaysAfterCreationGreaterThan);
                            break;
                        default:
                            throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid BlobVersionAction: {0}", this.BlobVersionAction));
                    }
                    break;
                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ParameterSet: {0}", this.ParameterSetName));
            }

            WriteObject(action);
        }
    }
}
