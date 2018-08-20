using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.BotService;
using System;

namespace Microsoft.Azure.Commands.BotService.ManagementClient
{
    public partial class BotManagementClientPsAdapter
    {
        public IAzureBotServiceClient AzureBotServiceClient { get; set; }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public BotManagementClientPsAdapter(IAzureContext context)
            : this(AzureSession.Instance.ClientFactory.CreateArmClient<AzureBotServiceClient>(context, AzureEnvironment.Endpoint.ResourceManager)) { }

        public BotManagementClientPsAdapter(IAzureBotServiceClient resourceManagementClient)
        {
            AzureBotServiceClient = resourceManagementClient;
        }
    }
}
