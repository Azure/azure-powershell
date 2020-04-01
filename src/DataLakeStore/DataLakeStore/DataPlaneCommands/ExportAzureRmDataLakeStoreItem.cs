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
using Microsoft.Rest.Azure;
using System.Management.Automation;
using Microsoft.Azure.DataLake.Store;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [GenericBreakingChange("For store side export failures, Export-AzDataLakeStoreItem will throw exception instead of printing message on screen", "2.0.0", "05/18/2020")]
    [Cmdlet("Export", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataLakeStoreItem", SupportsShouldProcess = true, DefaultParameterSetName = BaseParameterSetName), OutputType(typeof(string))]
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
            // We will let this throw itself if the path they give us is invalid
            var powerShellReadyPath = ResolveUserPath(Destination);
            ConfirmAction(
                VerbsData.Export,
                Path.TransformedPath,
                () =>
                {
                    try
                    {
                        if (ParameterSetName.Equals(DiagnosticParameterSetName) && DiagnosticLogLevel != LogLevel.None)
                        {
                            var diagnosticPath = ResolveUserPath(DiagnosticLogPath);
                            DataLakeStoreFileSystemClient.SetupFileLogging(DiagnosticLogLevel, diagnosticPath);
                        }

                        // Currently SDK default thread calculation is not correct, so pass a default thread count
                        int threadCount = Concurrency == -1 ? DataLakeStoreFileSystemClient.ImportExportMaxThreads : Concurrency;
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
