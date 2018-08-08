using Microsoft.Azure.Commands.BotService.ManagementClient;
using Microsoft.Azure.Commands.BotService.Model;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.BotService;
using Microsoft.Azure.Management.BotService.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.BotService.BotService
{
    public abstract class BotServiceBaseCmdlet : AzureRMCmdlet
    {
        private BotManagementClientPsAdapter botManagementClientPsAdapter;

        protected const string BotServiceNounStr = "AzureRmBot";
        protected const string BotServiceChannelNounStr = BotServiceNounStr + "Channel";
        protected const string BotServiceConnectionNounStr = BotServiceNounStr + "Connection";

        protected const string BotServiceKind = "sdk";
        protected const string BotServiceLocation = "global";

        public IAzureBotServiceClient BotServiceClient
        {
            get
            {
                if (botManagementClientPsAdapter == null)
                {
                    botManagementClientPsAdapter = new BotManagementClientPsAdapter(DefaultProfile.DefaultContext);
                }

                botManagementClientPsAdapter.VerboseLogger = WriteVerboseWithTimestamp;
                botManagementClientPsAdapter.ErrorLogger = WriteErrorWithTimestamp;
                return botManagementClientPsAdapter.AzureBotServiceClient;
            }

            set { botManagementClientPsAdapter = new BotManagementClientPsAdapter(value); }
        }

        public string SubscriptionId
        {
            get
            {
                return DefaultProfile.DefaultContext.Subscription.Id.ToString();
            }
        }

        /// <summary>
        /// Run Cmdlet with Error Handling 
        /// </summary>
        /// <param name="action"></param>
        protected void RunCmdLet(Action action)
        {
            try
            {
                action();
            }
            catch (ErrorException ex)
            {
                throw new PSInvalidOperationException(ex.Body.ErrorProperty.Message, ex);
            }
        }

        protected void WriteBot(Bot bot)
        {
            if (bot != null)
            {
                WriteObject(PSBot.Create(bot));
            }
        }

        protected void WriteBotChannel(BotChannel channel)
        {
            if (channel != null)
            {
                WriteObject(channel);
            }
        }

        protected void WriteBotList(IEnumerable<Bot> bots)
        {
            var output = new List<PSBot>();

            if (bots != null)
            {
                bots.ForEach(bot => output.Add(PSBot.Create(bot)));
            }

            WriteObject(output, true);
        }
    }
}
