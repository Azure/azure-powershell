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

using Microsoft.Azure.Commands.DataLakeStore.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataLakeStoreDeletedItem",
        DefaultParameterSetName = DefaultParameterSet, SupportsShouldProcess = true),
        OutputType(typeof(DataLakeStoreDeletedItem))]
    [Alias("Restore-AdlStoreDeletedItem")]
    public class RestoreAzureDataLakeStoreDeletedItem : DataLakeStoreFileSystemCmdletBase
    {
        #region Parameter Set Names

        private const string DefaultParameterSet = "Default";
        private const string InputObjectParameterSet = "InputObject";

        #endregion

        [Parameter(ValueFromPipelineByPropertyName = true,
            Position = 0,
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "The Data Lake Store account to execute the filesystem operation in")]
        [Parameter(ValueFromPipelineByPropertyName = true,
            Position = 0,
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            HelpMessage = "The Data Lake Store account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true,
            Position = 1,
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "The trash directory path in enumeratedeleteditems response")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true,
            Position = 2,
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Path to where the entry should be restored")]
        [ValidateNotNullOrEmpty]
        public string Destination { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true,
            Position = 3, Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Type of the entry which is being restored. \"file\" or \"folder\"")]
        public string Type { get; set; }

        [Parameter(ValueFromPipeline = true,
            Position = 1,
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            HelpMessage = "The deleted item object returned by Get-AzDataLakeStoreDeletedItem")]
        public DataLakeStoreDeletedItem DeletedItem { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = DefaultParameterSet,
            Mandatory = false,
            HelpMessage = "Action to take during destination name conflicts - \"overwrite\" or \"copy\"")]
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = InputObjectParameterSet,
            Mandatory = false,
            HelpMessage = "Action to take during destination name conflicts - \"overwrite\" or \"copy\"")]
        public string RestoreAction { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = DefaultParameterSet)]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectParameterSet)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Restore the stream or directory")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectParameterSet,
            HelpMessage = "Restore the stream or directory")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == DefaultParameterSet)
            {
                if (Force.IsPresent || ShouldContinue(string.Format("From - {0}\nTo   - {1}\nType - {2}", Path, Destination, Type), "Restore user data ?"))
                {
                    DataLakeStoreFileSystemClient.RestoreDeletedItem(Account, Path, Destination, Type, RestoreAction, CmdletCancellationToken);
                }
            }
            else if(ParameterSetName == InputObjectParameterSet)
            {
                if (Force.IsPresent || ShouldContinue(string.Format("From - {0}\nTo   - {1}\nType - {2}", DeletedItem.TrashDirPath, DeletedItem.OriginalPath, DeletedItem.Type == DataLakeStoreEnums.FileType.FILE ? "file" : "folder"), "Restore user data ?"))
                {
                    DataLakeStoreFileSystemClient.RestoreDeletedItem(Account, DeletedItem.TrashDirPath, DeletedItem.OriginalPath, (DeletedItem.Type == DataLakeStoreEnums.FileType.FILE ? "file" : "folder"), RestoreAction, CmdletCancellationToken);
                }
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
