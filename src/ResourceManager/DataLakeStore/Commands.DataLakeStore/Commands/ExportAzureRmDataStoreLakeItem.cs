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
using Microsoft.Azure.Commands.DataLakeStore.Models;
using Microsoft.Azure.Commands.DataLakeStore.Properties;
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsData.Export, "AzureRmDataLakeStoreItem"), OutputType(typeof (string))]
    public class ExportAzureDataLakeStoreItem : DataLakeStoreFileSystemCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The DataLakeStore account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "The path to the file or folder to download")]
        [ValidateNotNull]
        public DataLakeStorePathInstance Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = true,
            HelpMessage = "The local path to download the file or folder to")]
        [ValidateNotNullOrEmpty]
        public string Destination { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage = "Indicates that, if the file or folder exists, it should be overwritten")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            // We will let this throw itself if the path they give us is invalid
            // TODO: perhaps in the future catch this and throw a cmdlet specific exception
            var powerShellReadyPath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(Destination);

            FileType type;

            if (!DataLakeStoreFileSystemClient.TestFileOrFolderExistence(Path.TransformedPath, Account, out type) ||
                type != FileType.File)
            {
                throw new CloudException(string.Format(Resources.InvalidExportPathType, Path.TransformedPath));
            }

            DataLakeStoreFileSystemClient.DownloadFile(Path.TransformedPath, Account, powerShellReadyPath, CmdletCancellationToken,
                Force, this);

            WriteObject(powerShellReadyPath);
        }
    }
}