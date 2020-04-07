using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoor" + "HeaderActionObject"), OutputType(typeof(PSHeaderAction))]
    public class NewFrontDoorHeaderActionObject : AzureFrontDoorCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of the header this action will apply to.")]
        public string HeaderName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Which type of manipulation to apply to the header.")]
        [PSArgumentCompleter("Append", "Delete", "Overwrite")]
        public PSHeaderActionType HeaderActionType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The value to update the given header name with. This value is not used if the actionType is Delete.")]
        public string Value { get; set; }

        public override void ExecuteCmdlet()
        {
            var headerAction = new PSHeaderAction
            {
                HeaderName = HeaderName,
                HeaderActionType = HeaderActionType,
                Value = this.IsParameterBound(c => c.Value) ? Value : ""
            };

            WriteObject(headerAction);
        }
    }
}
