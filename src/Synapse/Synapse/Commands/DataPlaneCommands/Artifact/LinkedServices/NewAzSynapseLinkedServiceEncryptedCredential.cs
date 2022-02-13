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
using System.Collections.Generic;
using System.Text;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Globalization;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.LinkedServiceEncryptedCredential,
        DefaultParameterSetName = CreateByName, SupportsShouldProcess = true)]
    [OutputType(typeof(string))]
    public class NewAzSynapseLinkedServiceEncryptedCredential : SynapseManagementCmdletBase
    {
        private const string CreateByName = "CreateByName";
        private const string CreateByObject = "CreateByObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByName,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeName)]
        [ValidateNotNullOrEmpty]
        public string IntegrationRuntimeName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false,
            Mandatory = true, HelpMessage = HelpMessages.JsonFilePath)]
        [ValidateNotNullOrEmpty]
        public string DefinitionFile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.Force)]
        public SwitchParameter Force { get; set; }

        private static readonly Version supportedPSVersion = new Version(7, 0);

        public override void ExecuteCmdlet()
        {
            if (Host.Version < supportedPSVersion)
            {
                throw new PSNotSupportedException($"PowerShell {supportedPSVersion} or higher is required");
            }

            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            // ValidationNotNullOrEmpty doesn't handle whitespaces well
            if (IntegrationRuntimeName.IsEmptyOrWhiteSpace())
            {
                throw new PSArgumentNullException("IntegrationRuntimeName");
            }

            string rawJsonContent = SynapseAnalyticsClient.ReadJsonFileContent(this.TryResolvePath(DefinitionFile));
            string encrypted = null;

            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.EncryptConfirm),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.Encrypting),
                DefinitionFile,
                () =>
                {
                    encrypted = SynapseAnalyticsClient.IntegrationRuntimeEncryptCredential(ResourceGroupName, WorkspaceName, IntegrationRuntimeName, rawJsonContent);
                });

            WriteObject(encrypted);
        }
    }
}
