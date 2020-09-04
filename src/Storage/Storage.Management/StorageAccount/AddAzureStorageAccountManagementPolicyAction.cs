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
        protected const string BaseBlobLastAccessTimeParameterSet = "BaseBlobLastAccessTime";
        protected const string SnapshotParameterSet = "Snapshot";

        [Parameter(Mandatory = true,
            HelpMessage = "The management policy action for baseblob.",
            ParameterSetName = BaseBlobParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "The management policy action for baseblob.",
            ParameterSetName = BaseBlobLastAccessTimeParameterSet)]
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
        public int DaysAfterModificationGreaterThan
        {
            get
            {
                return daysAfterModificationGreaterThan is null ? 0 : daysAfterModificationGreaterThan.Value;
            }
            set
            {
                daysAfterModificationGreaterThan = value;
            }
        }
        public int? daysAfterModificationGreaterThan;

        [Parameter(Mandatory = true,
            HelpMessage = "Integer value indicating the age in days after last blob access. This property can only be used in conjuction with last access time tracking policy.",
            ParameterSetName = BaseBlobLastAccessTimeParameterSet)]
        [ValidateNotNullOrEmpty]
        public int DaysAfterLastAccessTimeGreaterThan
        {
            get
            {
                return daysAfterLastAccessTimeGreaterThan is null ? 0 : daysAfterLastAccessTimeGreaterThan.Value;
            }
            set
            {
                daysAfterLastAccessTimeGreaterThan = value;
            }
        }
        public int? daysAfterLastAccessTimeGreaterThan;

        [Parameter(Mandatory = false,
            HelpMessage = "Enables auto tiering of a blob from cool to hot on a blob access. It only works with TierToCool action and DaysAfterLastAccessTimeGreaterThan.",
            ParameterSetName = BaseBlobLastAccessTimeParameterSet)]
        public SwitchParameter EnableAutoTierToHotFromCool { get; set; }
        //{
        //    get
        //    {
        //        return enableAutoTierToHotFromCool is null ? false : enableAutoTierToHotFromCool.Value;
        //    }
        //    set
        //    {
        //        enableAutoTierToHotFromCool = value;
        //    }
        //}
        //public bool? enableAutoTierToHotFromCool;

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
                case BaseBlobLastAccessTimeParameterSet:
                    if (action.BaseBlob is null)
                    {
                        action.BaseBlob = new PSManagementPolicyBaseBlob();
                    }
                    switch (BaseBlobAction)
                    {
                        case ManagementPolicyAction.Delete:
                            action.BaseBlob.Delete = new PSDateAfterModification(this.daysAfterModificationGreaterThan, this.daysAfterLastAccessTimeGreaterThan);
                            break;
                        case ManagementPolicyAction.TierToCool:
                            action.BaseBlob.TierToCool = new PSDateAfterModification(this.daysAfterModificationGreaterThan, this.daysAfterLastAccessTimeGreaterThan);
                            break;
                        case ManagementPolicyAction.TierToArchive:
                            action.BaseBlob.TierToArchive = new PSDateAfterModification(this.daysAfterModificationGreaterThan, this.daysAfterLastAccessTimeGreaterThan);
                            break;
                        default:
                            throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid BaseBlobAction: {0}", this.BaseBlobAction));
                    }
                    if (this.EnableAutoTierToHotFromCool.IsPresent)
                    {
                        action.BaseBlob.EnableAutoTierToHotFromCool = true;
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
