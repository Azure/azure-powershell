using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet("Import", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintWithArtifacts",
         DefaultParameterSetName = BlueprintConstants.ParameterSetNames.SubscriptionScope), OutputType(typeof(string))]
    public class ImportAzureRmBlueprint : BlueprintDefinitionCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = true, HelpMessage = "Name of the blueprint to import. ", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string BlueprintName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "File path to blueprint and ", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string InputPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Scope for the blueprint ", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Scope for the blueprint ", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }
        #endregion

        #region Cmdlet Overrides
        public override void ExecuteCmdlet()
        {
            string scope = this.IsParameterBound(c => c.ManagementGroupId) 
                ? Utils.GetScopeForManagementGroup(ManagementGroupId) 
                : Utils.GetScopeForSubscription(SubscriptionId ?? DefaultContext.Subscription.Id);
          
            ImportBlueprint(BlueprintName, scope, InputPath, Force);
            ImportArtifacts(BlueprintName, scope, InputPath);
        }
        #endregion
    }
}
