﻿// ----------------------------------------------------------------------------------
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
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsData.Import, "AzureRmDataLakeStoreItem", SupportsShouldProcess = true, DefaultParameterSetName = BaseParameterSetName), OutputType(typeof(string))]
    [Alias("Import-AdlStoreItem")]
    public class ImportAzureDataLakeStoreItem : DataLakeStoreFileSystemCmdletBase
    {
        // define parameter sets.
        internal const string BaseParameterSetName = "No diagnostic logging";
        internal const string DiagnosticParameterSetName = "Include diagnostic logging";

        // default number of threads
        private int numThreadsPerFile = 10;
        private int fileCount = 5;
        private LogLevel logLevel = LogLevel.Error;

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
            HelpMessage =
                "Indicates that the file(s) being copied are a continuation of a previous upload. This will cause the system to attempt to resume from the last file that was not fully uploaded.",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage =
                "Indicates that the file(s) being copied are a continuation of a previous upload. This will cause the system to attempt to resume from the last file that was not fully uploaded.",
            ParameterSetName = DiagnosticParameterSetName)]
        public SwitchParameter Resume { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = false,
            HelpMessage =
                "Indicates that the file(s) being copied should be copied with no concern for new line preservation across appends",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = false,
            HelpMessage =
                "Indicates that the file(s) being copied should be copied with no concern for new line preservation across appends",
            ParameterSetName = DiagnosticParameterSetName)]
        public SwitchParameter ForceBinary { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 6, Mandatory = false,
            HelpMessage = "Indicates the maximum number of threads to use per file. Default is 10",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 6, Mandatory = false,
            HelpMessage = "Indicates the maximum number of threads to use per file. Default is 10",
            ParameterSetName = DiagnosticParameterSetName)]
        public int PerFileThreadCount
        {
            get { return numThreadsPerFile; }
            set { numThreadsPerFile = value; }
        }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 7, Mandatory = false,
            HelpMessage = "Indicates the maximum number of files to upload in parallel for a folder upload. Default is 5",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 7, Mandatory = false,
            HelpMessage = "Indicates the maximum number of files to upload in parallel for a folder upload. Default is 5",
            ParameterSetName = DiagnosticParameterSetName)]
        public int ConcurrentFileCount
        {
            get { return fileCount; }
            set { fileCount = value; }
        }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 8, Mandatory = false,
            HelpMessage = "Indicates that, if the file or folder exists, it should be overwritten",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 8, Mandatory = false,
            HelpMessage = "Indicates that, if the file or folder exists, it should be overwritten",
            ParameterSetName = DiagnosticParameterSetName)]
        public SwitchParameter Force { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "Optionally indicates the diagnostic log level to use to record events during the file or folder import. Default is Error.",
            ParameterSetName = DiagnosticParameterSetName)]
        public LogLevel DiagnosticLogLevel
        {
            get { return logLevel; }
            set { logLevel = value; }
        }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true,
            HelpMessage = "Specifies the path for the diagnostic log to record events to during the file or folder import.",
            ParameterSetName = DiagnosticParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string DiagnosticLogPath { get; set; }

        public override void ExecuteCmdlet()
        {
            var powerShellSourcePath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(Path);
            ConfirmAction(
                Resources.UploadFileMessage,
                Destination.TransformedPath,
                () =>
                {
                    DataLakeStoreTraceLogger logger = null;
                    var originalLevel = AdalTrace.TraceSource.Switch.Level;
                    var originalLegacyLevel = AdalTrace.LegacyTraceSwitch.Level;
                    try
                    {
                        if (ParameterSetName.Equals(DiagnosticParameterSetName) && DiagnosticLogLevel != LogLevel.None)
                        {
                            var diagnosticPath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(DiagnosticLogPath);
                            logger = new DataLakeStoreTraceLogger(this, diagnosticPath, DiagnosticLogLevel);                            
                        }

                        if (Directory.Exists(powerShellSourcePath))
                        {
                            DataLakeStoreFileSystemClient.CopyDirectory(
                                Destination.TransformedPath,
                                Account,
                                powerShellSourcePath,
                                CmdletCancellationToken,
                                ConcurrentFileCount,
                                PerFileThreadCount,
                                Recurse,
                                Force,
                                Resume, ForceBinary, ForceBinary, cmdletRunningRequest: this);
                        }
                        else if (File.Exists(powerShellSourcePath))
                        {
                            DataLakeStoreFileSystemClient.CopyFile(
                                Destination.TransformedPath,
                                Account,
                                powerShellSourcePath,
                                CmdletCancellationToken,
                                PerFileThreadCount,
                                Force,
                                Resume,
                                ForceBinary,
                                cmdletRunningRequest: this);
                        }
                        else
                        {
                            throw new FileNotFoundException(string.Format(Resources.FileOrFolderDoesNotExist, powerShellSourcePath));
                        }

                        // only attempt to write output if this cmdlet hasn't been cancelled.
                        if (!CmdletCancellationToken.IsCancellationRequested && !Stopping)
                        {
                            WriteObject(Destination.OriginalPath);
                        }
                    }
                    finally
                    {
                        if (logger != null)
                        {
                            // dispose and free the logger.
                            logger.Dispose();
                            logger = null;
                        }
                    }
                });
        }
    }
}