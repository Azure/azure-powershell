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

using System;
using Microsoft.Azure.Commands.DataLakeStore.Models;
using Microsoft.Azure.Commands.DataLakeStore.Properties;
using System.Management.Automation;
using Microsoft.Azure.DataLake.Store;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsData.Import, "AzureRmDataLakeStoreItem", SupportsShouldProcess = true, DefaultParameterSetName = BaseParameterSetName), OutputType(typeof(string))]
    [Alias("Import-AdlStoreItem")]
    public class ImportAzureDataLakeStoreItem : DataLakeStoreFileSystemCmdletBase
    {
        // define parameter sets.
        internal const string BaseParameterSetName = "NoDiagnosticLogging";
        internal const string DiagnosticParameterSetName = "IncludeDiagnosticLogging";

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The DataLakeStore account to execute the filesystem operation in",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The DataLakeStore account to execute the filesystem operation in",
            ParameterSetName = DiagnosticParameterSetName)]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "The local path to the file or folder to copy",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "The local path to the file or folder to copy",
            ParameterSetName = DiagnosticParameterSetName)]
        [ValidateNotNull]
        public string Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = true,
            HelpMessage = "The path in the specified Data Lake account where the file or folder should be copied to. " +
                          "In the format '/folder/file.txt', " +
                          "where the first '/' after the DNS indicates the root of the file system.",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = true,
            HelpMessage = "The path in the specified Data Lake account where the file or folder should be copied to. " +
                          "In the format '/folder/file.txt', " +
                          "where the first '/' after the DNS indicates the root of the file system.",
            ParameterSetName = DiagnosticParameterSetName)]
        [ValidateNotNullOrEmpty]
        public DataLakeStorePathInstance Destination { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage =
                "Optionally indicates that this the folder being copied should be copied to DataLakeStore recursively",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage =
                "Optionally indicates that this the folder being copied should be copied to DataLakeStore recursively",
            ParameterSetName = DiagnosticParameterSetName)]
        public SwitchParameter Recurse { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage = "Indicates that the file(s) being copied are a continuation of a previous upload. This will cause the system to attempt to resume from the last file that was not fully uploaded.",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage = "Indicates that the file(s) being copied are a continuation of a previous upload. This will cause the system to attempt to resume from the last file that was not fully uploaded.",
            ParameterSetName = DiagnosticParameterSetName)]
        public SwitchParameter Resume { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = false,
            HelpMessage = "Indicates that the file(s) being copied should be copied with no concern for new line preservation across appends",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = false,
            HelpMessage = "Indicates that the file(s) being copied should be copied with no concern for new line preservation across appends",
            ParameterSetName = DiagnosticParameterSetName)]
        public SwitchParameter ForceBinary { get; set; }

        [Obsolete("Parameter PerFileThreadCount of ImportAzureRmDataLakeStoreItem is deprecated. This parameter will be removed in future releases. Please use Concurrency parameter instead.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 6, Mandatory = false,
            HelpMessage =
                "Indicates the maximum number of threads to use per file.  Default will be computed as a best effort based on folder and file size",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 6, Mandatory = false,
            HelpMessage = "Indicates the maximum number of threads to use per file.  Default will be computed as a best effort based on folder and file size",
            ParameterSetName = DiagnosticParameterSetName)]
        public int PerFileThreadCount { get; set; } = -1;

        [Obsolete("Parameter ConcurrentFileCount of ImportAzureRmDataLakeStoreItem is deprecated. This parameter will be removed in future releases. Please use Concurrency parameter instead.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 7, Mandatory = false,
            HelpMessage = "Indicates the maximum number of files to upload in parallel for a folder upload.  Default will be computed as a best effort based on folder and file size",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 7, Mandatory = false,
            HelpMessage = "Indicates the maximum number of files to upload in parallel for a folder upload.  Default will be computed as a best effort based on folder and file size",
            ParameterSetName = DiagnosticParameterSetName)]
        public int ConcurrentFileCount { get; set; } = -1;

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 8, Mandatory = false,
            HelpMessage = "Indicates that, if the file or folder exists, it should be overwritten",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 8, Mandatory = false,
            HelpMessage = "Indicates that, if the file or folder exists, it should be overwritten",
            ParameterSetName = DiagnosticParameterSetName)]
        public SwitchParameter Force { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage =
                "Indicates the number of files or chunks to upload in parallel. Default will be computed as a best effort based on system specifications.",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage =
                "Indicates the number of files or chunks to upload in parallel. Default will be computed as a best effort based on system specification.",
            ParameterSetName = DiagnosticParameterSetName)]
        public int Concurrency { get; set; } = -1;

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "Optionally indicates the diagnostic log level to use to record events during the file or folder import. Default is Error.",
            ParameterSetName = DiagnosticParameterSetName)]
        public LogLevel DiagnosticLogLevel { get; set; } = LogLevel.Error;

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            HelpMessage = "Specifies the path for the diagnostic log to record events to during the file or folder import.",
            ParameterSetName = DiagnosticParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string DiagnosticLogPath { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ConcurrentFileCount != -1)
            {
                WriteWarning(Resources.IncorrectConcurrentFileCountWarning);
            }
            if (PerFileThreadCount != -1)
            {
                WriteWarning(Resources.IncorrectPerFileThreadCountWarning);
            }
            var powerShellSourcePath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(Path);
            ConfirmAction(
                Resources.UploadFileMessage,
                Destination.TransformedPath,
                () =>
                {
                    try
                    {
                        if (ParameterSetName.Equals(DiagnosticParameterSetName) && DiagnosticLogLevel != LogLevel.None)
                        {
                            var diagnosticPath =
                                SessionState.Path.GetUnresolvedProviderPathFromPSPath(DiagnosticLogPath);
                            DataLakeStoreFileSystemClient.SetupFileLogging(DiagnosticLogLevel, diagnosticPath);
                        }

                        int threadCount;
                        // If concurrency is specified then accept that
                        if (Concurrency > 0)
                        {
                            threadCount = Concurrency;
                        }
                        else if (ConcurrentFileCount > 0 && PerFileThreadCount <= 0)
                        {
                            threadCount = ConcurrentFileCount;
                        }
                        else if (ConcurrentFileCount <= 0 && PerFileThreadCount > 0)
                        {
                            threadCount = PerFileThreadCount;
                        }
                        else
                        {
                            threadCount = Math.Min(PerFileThreadCount * ConcurrentFileCount, DataLakeStoreFileSystemClient.ImportExportMaxThreads);
                        }
                        DataLakeStoreFileSystemClient.BulkCopy(Destination.TransformedPath, Account,
                            powerShellSourcePath, CmdletCancellationToken, threadCount, Recurse, Force, Resume, false, this, ForceBinary);
                        // only attempt to write output if this cmdlet hasn't been cancelled.
                        if (!CmdletCancellationToken.IsCancellationRequested && !Stopping)
                        {
                            WriteObject(Destination.OriginalPath);
                        }
                    }
                    catch (AdlsException exp)
                    {
                        throw new CloudException("ADLSException: " + exp.Message);
                    }
                });
        }
    }
}