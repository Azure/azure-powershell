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
using Microsoft.PowerShell.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsCommon.Get, "AzureRmDataLakeStoreItemContent", SupportsShouldProcess = true, DefaultParameterSetName = BaseParameterSetName), 
        OutputType(typeof(byte[]), typeof(string))]
    [Alias("Get-AdlStoreItemContent")]
    public class GetAzureDataLakeStoreContent : DataLakeStoreFileSystemCmdletBase
    {
        private FileSystemCmdletProviderEncoding _encoding = FileSystemCmdletProviderEncoding.UTF8;
        internal const string BaseParameterSetName = "PreviewFileContent";
        internal const string HeadRowParameterSetName = "PreviewFileRowsFromHead";
        internal const string TailRowParameterSetName = "PreviewFileRowsFromTail";

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, ParameterSetName = BaseParameterSetName, Mandatory = true,
            HelpMessage = "The DataLakeStore account to execute the filesystem operation in")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, ParameterSetName = HeadRowParameterSetName, Mandatory = true,
            HelpMessage = "The DataLakeStore account to execute the filesystem operation in")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, ParameterSetName = TailRowParameterSetName, Mandatory = true,
            HelpMessage = "The DataLakeStore account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, ParameterSetName = BaseParameterSetName, Mandatory = true,
            HelpMessage = "The path in the specified Data Lake account that should be read from. Can only be a file " +
                          "in the format '/folder/file.txt', " +
                          "where the first '/' after the DNS indicates the root of the file system.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, ParameterSetName = HeadRowParameterSetName, Mandatory = true,
            HelpMessage = "The path in the specified Data Lake account that should be read from. Can only be a file " +
                          "in the format '/folder/file.txt', " +
                          "where the first '/' after the DNS indicates the root of the file system.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, ParameterSetName = TailRowParameterSetName, Mandatory = true,
            HelpMessage = "The path in the specified Data Lake account that should be read from. Can only be a file " +
                          "in the format '/folder/file.txt', " +
                          "where the first '/' after the DNS indicates the root of the file system.")]
        [ValidateNotNull]
        public DataLakeStorePathInstance Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, ParameterSetName = HeadRowParameterSetName, Mandatory = false,
            HelpMessage =
                "The number of rows (new line delimited) from the beginning of the file to preview. If no new line is encountered in the first 4mb of data, only that data will be returned."
            )]
        [ValidateRange(1, int.MaxValue)]
        public int Head { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, ParameterSetName = TailRowParameterSetName, Mandatory = false,
            HelpMessage = "The number of rows (new line delimited) from the end of the file to preview. If no new line is encountered in the first 4mb of data, only that data will be returned.")]
        [ValidateRange(1, int.MaxValue)]
        public int Tail { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, ParameterSetName = BaseParameterSetName, Mandatory = false,
            HelpMessage =
                "Where in the file to begin reading from. This value is specified in bytes from the beginning of the file."
            )]
        public long Offset { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, ParameterSetName = BaseParameterSetName, Mandatory = false,
            HelpMessage = "The number of bytes to read from the file.")]
        public long Length { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, ParameterSetName = BaseParameterSetName, Mandatory = false,
            HelpMessage = "Optionally indicates the encoding for the content being downloaded. Default is UTF8")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, ParameterSetName = HeadRowParameterSetName, Mandatory = false,
            HelpMessage = "Optionally indicates the encoding for the content being downloaded. Default is UTF8")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, ParameterSetName = TailRowParameterSetName, Mandatory = false,
            HelpMessage = "Optionally indicates the encoding for the content being downloaded. Default is UTF8")]
        public FileSystemCmdletProviderEncoding Encoding
        {
            get { return _encoding; }
            set { _encoding = value; }
        }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, ParameterSetName = BaseParameterSetName, Mandatory = false,
            HelpMessage = "If the length parameter is not specified or is less than or equal to zero, force returns all content of the file, otherwise it does nothing.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals(BaseParameterSetName, StringComparison.OrdinalIgnoreCase))
            {
                ConfirmAction(
                    Resources.DownloadFileDataMessage,
                    Path.TransformedPath,
                    () =>
                    {
                        byte[] byteArray;
                        if (Length <= 0)
                        {
                            Length = (long)DataLakeStoreFileSystemClient.GetFileStatus(Path.TransformedPath, Account).Length - Offset;
                            if (Length > 1 * 1024 * 1024 && !Force)
                            // If content is greater than 1MB throw an error to the user to let them know they must pass in a length to preview this much content
                            {
                                throw new InvalidOperationException(string.Format(Resources.FilePreviewTooLarge, 1 * 1024 * 1024, Length));
                            }
                        }

                        using (var memStream = ((MemoryStream)DataLakeStoreFileSystemClient.PreviewFile(Path.TransformedPath, Account, Length, Offset,
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
                    });
            }
            else if (this.ParameterSetName.Equals(HeadRowParameterSetName, StringComparison.OrdinalIgnoreCase))
            {                
                var encoding = GetEncoding(Encoding);
                WriteObject(DataLakeStoreFileSystemClient.GetStreamRows(Path.TransformedPath, Account, Head, encoding), true);
            }
            else
            {
                var encoding = GetEncoding(Encoding);
                WriteObject(DataLakeStoreFileSystemClient.GetStreamRows(Path.TransformedPath, Account, Tail, encoding, reverse: true), true);
            }
        }
    }
}
