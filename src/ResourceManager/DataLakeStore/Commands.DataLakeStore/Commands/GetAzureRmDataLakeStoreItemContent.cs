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

using System.IO;
using System.Management.Automation;
using Microsoft.Azure.Commands.DataLakeStore.Models;
using Microsoft.PowerShell.Commands;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsCommon.Get, "AzureRmDataLakeStoreItemContent"), OutputType(typeof (byte[]), typeof (string))]
    public class GetAzureDataLakeStoreContent : DataLakeStoreFileSystemCmdletBase
    {
        private FileSystemCmdletProviderEncoding _encoding = FileSystemCmdletProviderEncoding.UTF8;

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The DataLakeStore account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "The path in the specified Data Lake account that should be read from. Can only be a file " +
                          "in the format '/folder/file.txt', " +
                          "where the first '/' after the DNS indicates the root of the file system.")]
        [ValidateNotNull]
        public DataLakeStorePathInstance Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            HelpMessage =
                "Where in the file to begin reading from. This value is specified in bytes from the beginning of the file."
            )]
        public long Offset { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = true,
            HelpMessage = "The number of bytes to read from the file.")]
        public long Length { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage = "Optionally indicates the encoding for the content being downloaded. Default is UTF8")]
        public FileSystemCmdletProviderEncoding Encoding
        {
            get { return _encoding; }
            set { _encoding = value; }
        }

        protected override void ProcessRecord()
        {
            byte[] byteArray;
            using (var memStream = ((MemoryStream) DataLakeStoreFileSystemClient.PreviewFile(Path.Path, Account, Length,
                CmdletCancellationToken, this)))
            {
                byteArray = memStream.ToArray();
            }

            if (UsingByteEncoding(Encoding))
            {
                WriteObject(byteArray);
            }
            else
            {
                WriteObject(BytesToString(byteArray, Encoding));
            }
        }
    }
}