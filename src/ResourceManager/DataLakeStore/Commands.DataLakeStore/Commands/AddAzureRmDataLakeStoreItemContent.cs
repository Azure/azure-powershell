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
using Microsoft.PowerShell.Commands;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsCommon.Add, "AzureRmDataLakeStoreItemContent"), OutputType(typeof(bool))]
    [Alias("Add-AdlStoreItemContent")]
    public class AddAzureDataLakeStoreItemContent : DataLakeStoreFileSystemCmdletBase
    {
        private FileSystemCmdletProviderEncoding _encoding = FileSystemCmdletProviderEncoding.UTF8;

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The DataLakeStore account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage =
                "The path in the specified Data Lake account that should be appended to. Can only be a file " +
                "in the format '/folder/file.txt', " +
                "where the first '/' after the DNS indicates the root of the file system.")]
        [ValidateNotNull]
        public DataLakeStorePathInstance Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Position = 2, Mandatory = true,
            HelpMessage = "The content, as bytes, that should be appended to the file specified.")]
        [ValidateNotNull]
        public object Value { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage =
                "Optionally indicates the encoding for the content being uploaded as part of 'Value'. Default is UTF8")]
        public FileSystemCmdletProviderEncoding Encoding
        {
            get { return _encoding; }
            set { _encoding = value; }
        }

        public override void ExecuteCmdlet()
        {
            DataLakeStoreFileSystemClient.AppendToFile(Path.TransformedPath, Account, new MemoryStream(GetBytes(Value, Encoding)));
            WriteObject(true);
        }
    }
}