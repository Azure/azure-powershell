using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.Compute
{
    public partial class ComputeManagementClient : Microsoft.Azure.Commands.Common.Strategies.IClient
    {
        public ComputeManagementClient()
        {

        }

        public ComputeManagementClient(Commands.Common.Strategies.IClient other)
        {
            SubscriptionId = other.SubscriptionId;
            Sender = other.Sender;
            Listener = other.Listener;
        }

        public string SubscriptionId { get; set; }

        public ISendAsync Sender { get; set; }

        public IEventListener Listener { get; set; }

        public T GetAutorestClient<T>() where T : class, IClient, new()
        {
            return this as T;
        }

        public T GetClient<T>() where T : ServiceClient<T>
        {
            throw new NotImplementedException();
        }
    }
}
