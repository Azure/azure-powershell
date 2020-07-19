using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Synapse.Models.Exceptions;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Rest;
using System;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseCmdletBase : AzureRMCmdlet
    {
        internal static TClient CreateSynapseClient<TClient>(IAzureContext context, string endpoint, bool parameterizedBaseUri = false) where TClient : ServiceClient<TClient>
        {
            if (context == null)
            {
                throw new SynapseException(Resources.NoSubscriptionInContext);
            }

            var creds = AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context, endpoint);
            var clientFactory = AzureSession.Instance.ClientFactory;
            var newHandlers = clientFactory.GetCustomHandlers();
            TClient client;
            if (!parameterizedBaseUri)
            {
                client = (newHandlers == null || newHandlers.Length == 0)
                    ? clientFactory.CreateCustomArmClient<TClient>(context.Environment.GetEndpointAsUri(endpoint), creds)
                    : clientFactory.CreateCustomArmClient<TClient>(context.Environment.GetEndpointAsUri(endpoint), creds, clientFactory.GetCustomHandlers());
            }
            else
            {
                client = (newHandlers == null || newHandlers.Length == 0)
                    ? clientFactory.CreateCustomArmClient<TClient>(creds)
                    : clientFactory.CreateCustomArmClient<TClient>(creds, clientFactory.GetCustomHandlers());
            }

            var subscriptionId = typeof(TClient).GetProperty("SubscriptionId");
            if (subscriptionId != null && context.Subscription != null)
            {
                subscriptionId.SetValue(client, context.Subscription.Id.ToString());
            }

            return client;
        }

        protected string ConvertToUnsecureString(System.Security.SecureString securePassword)
        {
            var unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        protected void UpdateProgress(Task task, ProgressRecord progress)
        {
            while (!task.IsCompleted && !task.IsCanceled && !task.IsFaulted)
            {
                if (progress.PercentComplete < 100)
                {
                    progress.PercentComplete++;
                }
                WriteProgress(progress);

                task.Wait(TimeSpan.FromSeconds(15));
            }

            if (progress.PercentComplete < 100)
            {
                progress.PercentComplete = 100;
                WriteProgress(progress);
            }
        }
    }
}