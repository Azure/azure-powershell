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
    [Cmdlet(VerbsCommon.Get, "AzureRmDataLakeStoreItem"), OutputType(typeof(DataLakeStoreItem))]
    [Alias("Get-AdlStoreItem")]
    public class GetAzureDataLakeStoreItem : DataLakeStoreFileSystemCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The DataLakeStore account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage =
                "The path in the specified Data Lake account that should be retrieved. Can be a file or folder " +
                "In the format '/folder/file.txt', " +
                "where the first '/' after the DNS indicates the root of the file system.")]
        [ValidateNotNull]
        public DataLakeStorePathInstance Path { get; set; }

        public override void ExecuteCmdlet()
        {
            var toReturn = DataLakeStoreFileSystemClient.GetFileStatus(Path.TransformedPath, Account);
            var itemName = string.Empty;
            if (!string.IsNullOrEmpty(Path.TransformedPath))
            {
                // In the event that there is no "/" the full string will be returned.
                itemName =
                    Path.TransformedPath.Substring(
                        Path.TransformedPath.LastIndexOf("/", StringComparison.InvariantCultureIgnoreCase) + 1);
            }

            WriteObject(new DataLakeStoreItem(toReturn, itemName, "/" + Path.TransformedPath));
        }
    }
}