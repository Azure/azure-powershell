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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataLakeStoreDeletedItem", DefaultParameterSetName = DefaultParameterSet), OutputType(typeof(DataLakeStoreDeletedItem))]
    [Alias("Get-AdlStoreDeletedItem")]
    public class GetAzureDataLakeStoreDeletedItem : DataLakeStoreFileSystemCmdletBase
    {
        private const string DefaultParameterSet = "Default";

        [Parameter(ValueFromPipelineByPropertyName = true,
            Position = 0,
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "The Data Lake Store account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true,
            Position = 1,
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "The query string to match during search")]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Minimum number of entries to search for")]
        public int Count { get; set; } = 100;

        [Parameter(Mandatory = false,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            var toReturn = DataLakeStoreFileSystemClient.EnumerateDeletedItems(Account, Filter, Count, CmdletCancellationToken).Select(entry => new DataLakeStoreDeletedItem(entry)).ToList();
            WriteObject(toReturn);
        }
    }
}

