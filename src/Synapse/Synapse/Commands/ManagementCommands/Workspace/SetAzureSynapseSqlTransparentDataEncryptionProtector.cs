using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Sql + SynapseConstants.TransparentDataEncryptionProtector,
        DefaultParameterSetName = SetByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSEncryptionProtector))]
    public class SetAzureSynapseSqlTransparentDataEncryptionProtector : SynapseManagementCmdletBase
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";

        [Parameter(ParameterSetName = SetByNameParameterSet, Mandatory = false,
            HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = SetByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByInputObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessages.EncryptionProtectorType)]
        [ValidateNotNullOrEmpty]
        public EncryptionProtectorType Type { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.KeyId)]
        [ValidateNotNullOrEmpty]
        public string KeyId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                var resourceIdentifier = new ResourceIdentifier(this.InputObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ResourceName;
            }

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.ResourceGroupName = this.SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(this.WorkspaceName);
            }

            EncryptionProtector parameters = new EncryptionProtector()
            {
                ServerKeyType = this.Type.ToString(),
                ServerKeyName = CreateServerKeyNameFromKeyId(this.KeyId)
            };

            if (this.ShouldProcess(this.WorkspaceName, string.Format(Resources.SettingSqlTransparentDataEncryptionProtector, this.WorkspaceName)))
            {
                var result = new PSEncryptionProtector(SynapseAnalyticsClient.CreateOrUpdateWorkspaceTransparentDataEncryptionProtector(this.ResourceGroupName, this.WorkspaceName, parameters),
                    this.ResourceGroupName, this.WorkspaceName);
                WriteObject(result);
            }
        }

        private string CreateServerKeyNameFromKeyId(string keyId)
        {
            if (string.IsNullOrEmpty(keyId))
            {
                return ServerKeyType.ServiceManaged.ToString();
            }

            // Validate that the url is a keyvault url and has a key and version
            Regex r = new Regex(@"https://(.)+\.(managedhsm.azure.net|managedhsm-preview.azure.net|vault.azure.net|vault-int.azure-int.net|vault.azure.cn|managedhsm.azure.cn|vault.usgovcloudapi.net|managedhsm.usgovcloudapi.net|vault.microsoftazure.de|managedhsm.microsoftazure.de|vault.cloudapi.eaglex.ic.gov|vault.cloudapi.microsoft.scloud)(:443)?\/keys/[^\/]+\/[0-9a-zA-Z]+$", RegexOptions.IgnoreCase);
            if (!r.IsMatch(keyId))
            {
                // Throw an error here, since we don't want to use a non keyvault url
                //
                throw new ArgumentException(message: String.Format(Resources.InvalidKeyId, keyId), paramName: "KeyId");
            }

            var uri = new Uri(keyId);

            string vault = uri.Host.Split('.').First();
            string key = uri.Segments[2].TrimEnd('/');
            string version = uri.Segments.Last();

            return String.Format("{0}_{1}_{2}", vault, key, version);
        }
    }
}
