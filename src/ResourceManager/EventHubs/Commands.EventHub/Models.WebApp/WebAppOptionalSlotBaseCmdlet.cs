using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps
{
    // For some cmdlets, the slot is optional, but will be used if specified.
    public class WebAppOptionalSlotBaseCmdlet : WebAppBaseClientCmdLet
    {
        protected const string ParameterSet1Name = "FromResourceName";
        protected const string ParameterSet2Name = "FromWebApp";

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 0, Mandatory = true,
            HelpMessage = "The name of the resource group.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 1, Mandatory = true,
            HelpMessage = "The name of the web app.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 2, Mandatory = false,
            HelpMessage = "The name of the web app slot.", ValueFromPipelineByPropertyName = true)]
        public string Slot { get; set; }

        [Parameter(ParameterSetName = ParameterSet2Name, Position = 0, Mandatory = true,
            HelpMessage = "The web app object", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Site WebApp { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSet1Name:
                    string webAppName, slotName;
                    if (CmdletHelpers.TryParseAppAndSlotNames(Name, out webAppName, out slotName))
                    {
                        Name = webAppName;

                        // We have to choose between the slot name embedded in the name parameter or the slot parameter. 
                        // The choice for now is to prefer the embeeded slot name over the slot parameter. 
                        Slot = slotName;
                    }
                    break;
                case ParameterSet2Name:
                    string rg, name, slot;
                    CmdletHelpers.TryParseWebAppMetadataFromResourceId(WebApp.Id, out rg, out name, out slot);

                    ResourceGroupName = rg;
                    Name = name;
                    Slot = slot;
                    break;
            }
        }
    }
}