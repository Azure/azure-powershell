// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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
