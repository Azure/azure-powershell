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
using Microsoft.Azure.Commands.DataLakeStore.Properties;
using Microsoft.Azure.Commands.DataLakeStore.Models;
using Microsoft.Rest.Azure;
using System.Management.Automation;
using Microsoft.Azure.DataLake.Store;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsData.Export, "AzureRmDataLakeStoreItem", SupportsShouldProcess = true, DefaultParameterSetName = BaseParameterSetName), OutputType(typeof(string))]
    [Alias("Export-AdlStoreItem")]
    public class ExportAzureDataLakeStoreItem : DataLakeStoreFileSystemCmdletBase
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

        [Obsolete("Parameter PerFileThreadCount of ExportAzureRmDataLakeStoreItem is deprecated. This parameter will be removed in future releases. Please use Concurrency parameter instead.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = false,
            HelpMessage = "Indicates the maximum number of threads to use per file.  Default will be computed as a best effort based on folder and file size",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = false,
            HelpMessage = "Indicates the maximum number of threads to use per file.  Default will be computed as a best effort based on folder and file size",
            ParameterSetName = DiagnosticParameterSetName)]
        public int PerFileThreadCount { get; set; } = -1;

        [Obsolete("Parameter ConcurrentFileCount of ExportAzureRmDataLakeStoreItem is deprecated. This parameter will be removed in future releases. Please use Concurrency parameter instead.")]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 6, Mandatory = false,
            HelpMessage =
                "Indicates the maximum number of files to download in parallel for a folder download.  Default will be computed as a best effort based on folder and file size",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 6, Mandatory = false,
            HelpMessage =
                "Indicates the maximum number of files to download in parallel for a folder download.  Default will be computed as a best effort based on folder and file size",
            ParameterSetName = DiagnosticParameterSetName)]
        public int ConcurrentFileCount { get; set; } = -1;

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 7, Mandatory = false,
            HelpMessage = "Indicates that, if the file or folder exists, it should be overwritten",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 7, Mandatory = false,
            HelpMessage = "Indicates that, if the file or folder exists, it should be overwritten",
            ParameterSetName = DiagnosticParameterSetName)]
        public SwitchParameter Force { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage =
                "Indicates the number of files or chunks to download in parallel. Default will be computed as a best effort based on system specifications.",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage =
                "Indicates the number of files or chunks to download in parallel. Default will be computed as a best effort based on system specification.",
            ParameterSetName = DiagnosticParameterSetName)]
        public int Concurrency { get; set; } = -1;

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage =
                "Optionally indicates the diagnostic log level to use to record events during the file or folder import. Default is Error.",
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
            // We will let this throw itself if the path they give us is invalid
            var powerShellReadyPath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(Destination);
            ConfirmAction(
                VerbsData.Export,
                Path.TransformedPath,
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
                        DataLakeStoreFileSystemClient.BulkCopy(powerShellReadyPath, Account,
                            Path.TransformedPath, CmdletCancellationToken, threadCount, Recurse, Force, Resume, true, this);
                        WriteObject(powerShellReadyPath);
                    }
                    catch (AdlsException exp)
                    {
                        throw new CloudException("ADLSException: " + exp.Message);
                    }
                });
        }
    }
}