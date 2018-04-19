using Microsoft.Azure.Commands.Management.CognitiveServices.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Get Usages for Cognitive Services Account
    /// </summary>
    [Cmdlet(VerbsCommon.Get, CognitiveServicesAccountUsagesNounStr, DefaultParameterSetName = "ResourceNameParameterSet"),
     OutputType(typeof(PSCognitiveServicesUsage))]
    public class GetAzureCognitiveServicesAccountUsageCommand : CognitiveServicesAccountBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "InputObjectParameterSet",
            HelpMessage = "Cognitive Services Account Object.")]
        [ValidateNotNullOrEmpty]
        public PSCognitiveServicesAccount InputObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "ResourceIdParameterSet",
            HelpMessage = "Cognitive Services Account Resource ID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "ResourceNameParameterSet",
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = "ResourceNameParameterSet",
            HelpMessage = "Cognitive Services Account Name.")]
        [Alias(CognitiveServicesAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            RunCmdLet(() =>
            {
                if (ParameterSetName.Equals("InputObjectParameterSet", StringComparison.InvariantCulture))
                {
                    this.ResourceGroupName = InputObject.ResourceGroupName;
                    this.Name = InputObject.AccountName;
                }
                else if (ParameterSetName.Equals("ResourceIdParameterSet", StringComparison.InvariantCulture))
                {
                    var id = new ResourceIdentifier(this.ResourceId);
                    this.ResourceGroupName = id.ResourceGroupName;
                    this.Name = id.ResourceName;
                }

                var cognitiveServicesUsages = this.CognitiveServicesClient.Accounts
                                                   .GetUsages(ResourceGroupName, Name)
                                                   .Value?.Select(u => new PSCognitiveServicesUsage(u));

                if (cognitiveServicesUsages != null)
                {
                    WriteObject(cognitiveServicesUsages, true);
                }
            });
        }
    }
}
