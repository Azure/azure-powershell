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
using Microsoft.Azure.Commands.DataLakeStore.Properties;
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.PowerShell.Commands;
using System;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsCommon.Set, "AzureRmDataLakeStoreItemExpiry", SupportsShouldProcess = true), OutputType(typeof(DataLakeStoreItem))]
    [Alias("Set-AdlStoreItemExpiry")]
    public class SetAzureRmDataLakeStoreItemExpiry : DataLakeStoreFileSystemCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The Data Lake Store account to perform the action in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "The name of the firewall rule.")]
        [ValidateNotNullOrEmpty]
        public DataLakeStorePathInstance Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            HelpMessage = "The absolute expiration time for the specified file. If no value or set to MaxValue, the file will never expire.")]
        [ValidateNotNullOrEmpty]
        public DateTimeOffset? Expiration { get; set; }

        public override void ExecuteCmdlet()
        {
            FileType filetype;
            if(!DataLakeStoreFileSystemClient.TestFileOrFolderExistence(Path.TransformedPath, Account, out filetype) || filetype == FileType.DIRECTORY)
            {
                throw new InvalidOperationException(string.Format(Resources.InvalidExpiryPath, Path.OriginalPath));
            }

            if (!Expiration.HasValue)
            {
                Expiration = DateTimeOffset.MaxValue;
            }

            var tickValue = DataLakeStoreFileSystemClient.ToUnixTimeStampMs(Expiration.GetValueOrDefault());
            var itemName =
                    Path.TransformedPath.Substring(
                        Path.TransformedPath.LastIndexOf("/", StringComparison.InvariantCultureIgnoreCase) + 1);
            ConfirmAction(
                string.Format(Resources.SetFileExpiry, Path.OriginalPath, Expiration.GetValueOrDefault().ToString()),
                Path.OriginalPath,
                () =>
                    WriteObject(new DataLakeStoreItem(
                        DataLakeStoreFileSystemClient.SetExpiry(
                            Path.TransformedPath,
                            Account,
                            tickValue),
                        itemName,
                        Path.OriginalPath))
            );
        }
    }
}