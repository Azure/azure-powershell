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

using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.WorkspacePackages;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Synapse.Commands
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.WorkspacePackage,
        DefaultParameterSetName = CreateByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseWorkspacePackage))]
    public class NewAzureSynapseWorkspacePackage : SynapseDataMovementCmdletBase
    {
        private const string CreateByNameParameterSet = "CreateByNameParameterSet";
        private const string CreateByObjectParameterSet = "CreateByObjectParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateByObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Alias("FullName")]
        [Parameter(Mandatory = true, HelpMessage = HelpMessages.WorkspacePackageFile,
            ValueFromPipelineByPropertyName = true)]
        public string Package
        {
            get { return packageFile; }
            set { packageFile = value; }
        }

        private string packageFile = string.Empty;

        private readonly PackageUploadRequestQueue UploadRequests = new PackageUploadRequestQueue();

        private string resolvedFileName;

        protected override void ProcessRecord()
        {
            resolvedFileName = this.GetUnresolvedProviderPathFromPSPath(string.IsNullOrWhiteSpace(this.packageFile) ? "." : this.packageFile);
            base.ProcessRecord();
        }

        protected override void DoExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (ShouldProcess(resolvedFileName, String.Format(Resources.UploadingWorkspacePackage, this.resolvedFileName, this.WorkspaceName)))
            {
                EnqueueUploadRequest(resolvedFileName);
            }
        }

        protected override void DoEndProcessing()
        {
            while (!UploadRequests.IsEmpty())
            {
                if (UploadRequests.TryDequeueRequest(out PackageUploadRequest uploadRequest))
                {
                    Task taskGenerator(long taskId) => UploadAndWriteWorkspacePackage(taskId, uploadRequest.FilePath, uploadRequest.PackageName);
                    RunTask(taskGenerator);
                }
            }

            base.DoEndProcessing();
        }

        /// <summary>
        /// Add request to queue. These requests will be processed later using multi-thread
        /// </summary>
        /// <param name="filePath">local file path</param>
        private void EnqueueUploadRequest(string filePath)
        {
            bool isFile = UploadRequests.EnqueueRequest(filePath);
            if (!isFile)
            {
                throw new AzPSInvalidOperationException(String.Format(Resources.CannotSendDirectory, filePath));
            }
        }

        /// <summary>
        /// Upload workspace package then write output
        /// </summary>
        /// <param name="taskId">Task id </param>
        /// <param name="filePath">Local file path to the workspace</param>
        /// <param name="packageName">Package name</param>
        /// <returns></returns>
        private async Task UploadAndWriteWorkspacePackage(long taskId, string filePath, string packageName)
        {
            await UploadWorkspacePackage(taskId, filePath, packageName);
            LibraryResource packageInfo = await this.SynapseAnalyticsClient.GetPackageAsync(packageName);
            PSSynapseWorkspacePackage workspacePackage = new PSSynapseWorkspacePackage(packageInfo, this.WorkspaceName);
            OutputStream.WriteObject(taskId, workspacePackage);
        }
    }
}
