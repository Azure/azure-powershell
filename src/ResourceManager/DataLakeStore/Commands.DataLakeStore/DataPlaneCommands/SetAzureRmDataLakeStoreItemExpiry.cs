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
using System;
using System.Management.Automation;
using Microsoft.Azure.DataLake.Store;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsCommon.Set, "AzureRmDataLakeStoreItemExpiry", SupportsShouldProcess = true, DefaultParameterSetName = BaseParameterSetName), OutputType(typeof(DataLakeStoreItem))]
    [Alias("Set-AdlStoreItemExpiry")]
    public class SetAzureRmDataLakeStoreItemExpiry : DataLakeStoreFileSystemCmdletBase
    {
        internal const string BaseParameterSetName = "SetAbsoluteNeverExpireExpiry";
        internal const string RelativeExpiryParameterSetName = "SetRelativeExpiry";
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0,ParameterSetName = BaseParameterSetName, Mandatory = true,
            HelpMessage = "The Data Lake Store account to perform the action in")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, ParameterSetName = RelativeExpiryParameterSetName, Mandatory = true,
            HelpMessage = "The Data Lake Store account to perform the action in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1,ParameterSetName = BaseParameterSetName, Mandatory = true,
            HelpMessage = "The name of the firewall rule.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, ParameterSetName = RelativeExpiryParameterSetName, Mandatory = true,
            HelpMessage = "The name of the firewall rule.")]
        [ValidateNotNullOrEmpty]
        public DataLakeStorePathInstance Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, ParameterSetName = BaseParameterSetName, Mandatory = false,
            HelpMessage =
                "The expiration time for the specified file. If no value or set to MaxValue, the file will never expire.")]
        [ValidateNotNullOrEmpty]
        public DateTimeOffset Expiration { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2,ParameterSetName = RelativeExpiryParameterSetName, Mandatory = true,
            HelpMessage = "Relative expiry options. RelativeToNow or RelativeToCreationDate are current options")]
        [ValidateNotNullOrEmpty]
        public DataLakeStoreEnums.PathRelativeExpiryOptions RelativeFileExpiryOption { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, ParameterSetName = RelativeExpiryParameterSetName, Mandatory = false,
            HelpMessage = "The relative time in milliseconds with respect to now or creation time. By default it will be zero.")]
        [ValidateNotNullOrEmpty]
        public long RelativeTime { get; set; }

        public override void ExecuteCmdlet()
        {
            DirectoryEntryType filetype;
            if (!DataLakeStoreFileSystemClient.TestFileOrFolderExistence(Path.TransformedPath, Account, out filetype) || filetype == DirectoryEntryType.DIRECTORY)
            {
                throw new InvalidOperationException(string.Format(Resources.InvalidExpiryPath, Path.OriginalPath));
            }
            ExpiryOption? exop=null;
            long tickValue;
            if (ParameterSetName.Equals(RelativeExpiryParameterSetName))
            {
                exop = RelativeFileExpiryOption == DataLakeStoreEnums.PathRelativeExpiryOptions.RelativeToCreationDate
                        ? ExpiryOption.RelativeToCreationDate
                        : ExpiryOption
                            .RelativeToNow;
                tickValue = RelativeTime;
            }
            else
            {
                if (!MyInvocation.BoundParameters.ContainsKey(nameof(Expiration)))
                {
                    Expiration = DateTimeOffset.MaxValue;
                }
                tickValue = DataLakeStoreFileSystemClient.ToUnixTimeStampMs(Expiration);
            }
            ConfirmAction(
                string.Format(Resources.SetFileExpiry, Path.OriginalPath, ParameterSetName.Equals(RelativeExpiryParameterSetName) ? $"{exop} {RelativeTime}" : Expiration.ToString()),
                Path.OriginalPath,
                () =>
                    WriteObject(new DataLakeStoreItem(DataLakeStoreFileSystemClient.SetExpiry(Path.TransformedPath, Account, tickValue, exop)))
            );
        }
    }
}