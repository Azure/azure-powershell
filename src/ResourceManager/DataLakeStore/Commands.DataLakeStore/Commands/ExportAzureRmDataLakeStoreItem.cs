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
using Microsoft.Rest.Azure;
using System.Management.Automation;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsData.Export, "AzureRmDataLakeStoreItem", SupportsShouldProcess = true, DefaultParameterSetName = BaseParameterSetName), OutputType(typeof(string))]
    [Alias("Export-AdlStoreItem")]
    public class ExportAzureDataLakeStoreItem : DataLakeStoreFileSystemCmdletBase
    {
        // define parameter sets.
        internal const string BaseParameterSetName = "NoDiagnosticLogging";
        internal const string DiagnosticParameterSetName = "IncludeDiagnosticLogging";

        // default number of threads
        private int numThreadsPerFile = -1;
        private int fileCount = -1;
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
            HelpMessage = "The path to the file or folder to download",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "The path to the file or folder to download",
            ParameterSetName = DiagnosticParameterSetName)]
        [ValidateNotNull]
        public DataLakeStorePathInstance Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = true,
            HelpMessage = "The local path to download the file or folder to",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = true,
            HelpMessage = "The local path to download the file or folder to",
            ParameterSetName = DiagnosticParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string Destination { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage = "Indicates if the download should be recursive for folder downloads. The default is false.",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage = "Indicates if the download should be recursive for folder downloads. The default is false.",
            ParameterSetName = DiagnosticParameterSetName)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Recurse { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage =
                "Indicates that the file(s) being copied are a continuation of a previous download. This will cause the system to attempt to resume from the last file that was not fully downloaded.",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage =
                "Indicates that the file(s) being copied are a continuation of a previous download. This will cause the system to attempt to resume from the last file that was not fully downloaded.",
            ParameterSetName = DiagnosticParameterSetName)]
        public SwitchParameter Resume { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = false,
            HelpMessage = "Indicates the maximum number of threads to use per file. Default will be computed as a best effort based on folder and file size",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = false,
            HelpMessage = "Indicates the maximum number of threads to use per file. Default will be computed as a best effort based on folder and file size",
            ParameterSetName = DiagnosticParameterSetName)]
        public int PerFileThreadCount
        {
            get { return numThreadsPerFile; }
            set { numThreadsPerFile = value; }
        }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 6, Mandatory = false,
            HelpMessage = "Indicates the maximum number of files to download in parallel for a folder download.  Default will be computed as a best effort based on folder and file size",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 6, Mandatory = false,
            HelpMessage = "Indicates the maximum number of files to download in parallel for a folder download.  Default will be computed as a best effort based on folder and file size",
            ParameterSetName = DiagnosticParameterSetName)]
        public int ConcurrentFileCount
        {
            get { return fileCount; }
            set { fileCount = value; }
        }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 7, Mandatory = false,
            HelpMessage = "Indicates that, if the file or folder exists, it should be overwritten",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 7, Mandatory = false,
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
            // We will let this throw itself if the path they give us is invalid
            // TODO: perhaps in the future catch this and throw a cmdlet specific exception
            var powerShellReadyPath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(Destination);

            FileType type;
            ConfirmAction(
                VerbsData.Export,
                Path.TransformedPath,
                () =>
                {
                    if (!DataLakeStoreFileSystemClient.TestFileOrFolderExistence(Path.TransformedPath, Account, out type))
                    {
                        throw new CloudException(string.Format(Resources.InvalidExportPathType, Path.TransformedPath));
                    }

                    DataLakeStoreTraceLogger logger = null;
                    var previousTracing = ServiceClientTracing.IsEnabled;
                    try
                    {
                        if (ParameterSetName.Equals(DiagnosticParameterSetName) && DiagnosticLogLevel != LogLevel.None)
                        {
                            var diagnosticPath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(DiagnosticLogPath);
                            logger = new DataLakeStoreTraceLogger(this, diagnosticPath, DiagnosticLogLevel);
                        }

                        if (logger == null)
                        {
                            // if the caller does not explicitly want logging, we will explicitly turn it off
                            // for performance reasons
                            ServiceClientTracing.IsEnabled = false;
                        }

                        if (type == FileType.FILE)
                        {
                            DataLakeStoreFileSystemClient.CopyFile(powerShellReadyPath, Account, Path.TransformedPath, CmdletCancellationToken,
                                isDownload: true, overwrite: Force, cmdletRunningRequest: this, threadCount: PerFileThreadCount, resume: Resume);
                        }
                        else
                        {
                            DataLakeStoreFileSystemClient.CopyDirectory(powerShellReadyPath, Account, Path.TransformedPath,
                                CmdletCancellationToken,
                                isDownload: true, overwrite: Force, cmdletRunningRequest: this,
                                perFileThreadCount: PerFileThreadCount, concurrentFileCount: ConcurrentFileCount, recursive: Recurse, resume: Resume);
                        }

                        WriteObject(powerShellReadyPath);
                    }
                    finally
                    {
                        // set service client tracing back always
                        ServiceClientTracing.IsEnabled = previousTracing;
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