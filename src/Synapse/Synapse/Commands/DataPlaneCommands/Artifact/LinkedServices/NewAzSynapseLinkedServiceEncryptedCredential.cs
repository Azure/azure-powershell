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

namespace Microsoft.Azure.Commands.Synapse.Commands.DataPlaneCommands.Artifact.LinkedServices
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.LinkedServiceEncryptedCredential,
        DefaultParameterSetName = GetByName)]
    [OutputType(typeof(string))]
    public class NewAzSynapseLinkedServiceEncryptedCredential : SynapseManagementCmdletBase
    {
        private const string GetByName = "GetByName";
        private const string GetByObject = "GetByObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByName,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByObject,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }


        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }


        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByName,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeName)] //??
        [ValidateNotNullOrEmpty]
        public string IntegrationRuntimeName { get; set; }


        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByName,
            Mandatory = true, HelpMessage = HelpMessages.JsonFilePath)] //??
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByObject,
            HelpMessage = HelpMessages.JsonFilePath)]
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

            // ValidationNotNullOrEmpty doesn't handle whitespaces well
            if (IntegrationRuntimeName.IsEmptyOrWhiteSpace())
            {
                throw new PSArgumentNullException("IntegrationRuntimeName");
            }

            //SynapseAnalyticsManagementClient
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
