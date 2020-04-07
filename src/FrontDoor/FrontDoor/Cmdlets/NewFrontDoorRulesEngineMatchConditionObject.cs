using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoor" + "RulesEngineMatchConditionObject"), OutputType(typeof(PSRulesEngineMatchCondition))]
    public class NewFrontDoorRulesEngineMatchConditionObject : AzureFrontDoorCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Match Variable")]
        [PSArgumentCompleter("IsMobile", "RemoteAddr", "RequestMethod", "QueryString", "PostArg", "RequestUri",
            "RequestPath", "RequestFilename", "RequestFilenameExtension", "RequestHeader", "RequestBody", "RequestScheme")]
        public PSRulesEngineMatchVariable MatchVariable { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Match values to match against. The operator will apply to each value in here with OR semantics. If any of them match the variable with the given operator this match condition is considered a match.")]
        public string[] MatchValue { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of selector in RequestHeader or RequestBody to be matched")]
        public string Selector { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Describes operator to apply to the match condition.")]
        [PSArgumentCompleter("Any", "IPMatch", "GeoMatch", "Equal", "Contains", "LessThan", "GreaterThan",
            "LessThanOrEqual", "GreaterThanOrEqual", "BeginsWith", "EndsWith")]
        public PSRulesEngineOperator Operator { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Describes if this is negate condition or not")]
        public bool NegateCondition { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "List of what transforms are applied before matching")]
        public PSTransform[] Transforms { get; set; }

        public override void ExecuteCmdlet()
        {
            var matchCondition = new PSRulesEngineMatchCondition
            {
                RulesEngineMatchVariable = MatchVariable,
                RulesEngineMatchValue = MatchValue.ToList(),
            };

            if (this.IsParameterBound(c => c.Selector))
            {
                matchCondition.Selector = Selector;
            }

            if (this.IsParameterBound(c => c.Operator))
            {
                matchCondition.RulesEngineOperator = Operator;
            }

            if (this.IsParameterBound(c => c.NegateCondition))
            {
                matchCondition.NegateCondition = NegateCondition;
            }

            if (this.IsParameterBound(c => c.Transforms))
            {
                matchCondition.Transforms = Transforms.ToList();
            }

            WriteObject(matchCondition);
        }
    }
}
