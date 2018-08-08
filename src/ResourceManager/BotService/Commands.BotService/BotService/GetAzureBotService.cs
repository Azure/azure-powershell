using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.BotService;
using Microsoft.Azure.Management.BotService.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.BotService.BotService
{
    [Cmdlet(VerbsCommon.Get, BotServiceNounStr), OutputType(typeof(string))]
    public class GetAzureBotService : BotServiceBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Bot Service Name.")]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                if (string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    var bots = GetWithPaging(this.BotServiceClient.Bots.List(), false);

                    WriteBotList(bots);
                }
                else if (string.IsNullOrEmpty(this.Name))
                {
                    var bots = GetWithPaging(this.BotServiceClient.Bots.ListByResourceGroup(this.ResourceGroupName), true);
                    if (bots == null)
                    {
                        WriteWarningWithTimestamp("Received empty bot list");
                    }
                    WriteBotList(bots);
                }
                else
                {
                    var bot = this.BotServiceClient.Bots.Get(ResourceGroupName, Name);

                    WriteBot(bot);
                }
            });
        }

        private IEnumerable<Bot> GetWithPaging(IPage<Bot> firstPage, bool isResourceGroup)
        {
            var bots = new List<Bot>(firstPage);
            bool foundMoreResults = true;
            IPage<Bot> nextPage = null;

            for (var nextLink = firstPage.NextPageLink; foundMoreResults; nextLink = nextPage.NextPageLink)
            {
                if (isResourceGroup)
                {
                    nextPage = this.BotServiceClient.Bots.ListByResourceGroupNext(nextLink);
                }
                else
                {
                    nextPage = this.BotServiceClient.Bots.ListNext(nextLink);
                }

                bots.AddRange(nextPage);

                if (nextPage == null || nextPage.Count() == 0)
                {
                    foundMoreResults = false;
                }
            }

            return bots;
        }
    }
}
