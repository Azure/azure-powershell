using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Reservations;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Internal.Resources;

namespace Microsoft.Azure.Commands.Reservations.Common
{
    /// <summary>
    /// Base class of Azure Reservations Auto Register Cmdlet.
    /// </summary>
    public abstract class AzureReservationsAutoRegisterCmdletBase : AzureReservationsCmdletBase
    {
        //Register for compute is required for Reservations commands inheriting this class
        private string ComputeProviderNamespace = "Microsoft.Compute";

        protected abstract bool ShouldRegister { get; }

        protected override void BeginProcessing()
        {
            AzureSession.Instance.ClientFactory.RemoveHandler(typeof(AzureReservationsAutoRegisterDelegatingHandler));
            IAzureContext context;
            if (TryGetDefaultContext(out context)
                && context.Account != null
                && context.Subscription != null)
            {
                AzureSession.Instance.ClientFactory.AddHandler(new AzureReservationsAutoRegisterDelegatingHandler(
                    ComputeProviderNamespace,
                    ShouldRegister,
                    () =>
                    {
                        var client = new ResourceManagementClient(
                            context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                            AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context, AzureEnvironment.Endpoint.ResourceManager));
                        client.SubscriptionId = context.Subscription.Id;
                        return client;
                    },
                    s => DebugMessages.Enqueue(s)));
            }

            base.BeginProcessing();
        }
    }
}