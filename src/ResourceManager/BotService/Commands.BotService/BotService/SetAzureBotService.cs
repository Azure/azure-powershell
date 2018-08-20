using Microsoft.Azure.Commands.BotService.Resources;
using Microsoft.Azure.Commands.BotService.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.BotService;
using Microsoft.Azure.Management.BotService.Models;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.BotService.BotService
{
    [Cmdlet(VerbsCommon.Set, BotServiceNounStr), OutputType(typeof(string))]
    public class SetAzureBotService : BotServiceBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Bot Service Name.")]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Bot Service Display Name.")]
        public string DisplayName { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Bot Service Description.")]
        public string Description { get; set; }

        [Parameter(
            Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Bot Service Endpoint Https URL.")]
        public string Endpoint { get; set; }

        [Parameter(
            Position = 5,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Bot Service Icon Url.")]
        public string IconUrl { get; set; }

        [Parameter(
            Position = 6,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Bot Service Microsoft Application Id.")]
        public string MsaAppId { get; set; }

        [Parameter(
            Position = 7,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Bot Service Sku Name.")]
        public SkuName SkuName { get; set; }

        [Parameter(
            Position = 8,
            Mandatory = false,
            HelpMessage = "Bot Service Tags.")]
        [ValidateNotNull]
        [AllowEmptyCollection]
        public Hashtable[] Tags { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                var botProperties = new BotProperties()
                {
                    Description = Description,
                    DisplayName = DisplayName,
                    Endpoint = Endpoint,
                    IconUrl = IconUrl,
                    Kind = BotServiceKind,
                    Location = BotServiceLocation,
                    MsaAppId = MsaAppId,
                    MsaAppPassword = string.Empty, // The service does not need the password for SDK bots
                    Sku = new Sku(this.SkuName.ToString()),
                    Tags = TagBuilder.CreateTagDictionary(Tags)
                };

                if (Force.IsPresent || ShouldProcess(
                    this.Name, string.Format(CultureInfo.CurrentCulture, BotPowerShellMessages.NewBot_ProcessMessage, this.Name, this.SkuName)))
                {
                    var updateBotResponse = this.BotServiceClient.Bots.Update(
                                    this.ResourceGroupName,
                                    this.Name,
                                    tags: TagBuilder.CreateTagDictionary(Tags),
                                    sku: new Sku(SkuName.ToString()),
                                    properties: botProperties);

                    this.WriteBot(updateBotResponse);
                }
            });
        }
    }
}
