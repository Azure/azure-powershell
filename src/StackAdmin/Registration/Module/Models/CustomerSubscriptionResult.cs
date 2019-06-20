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

namespace Microsoft.Azure.Commands.AzureStack.Models
{
    using Microsoft.Azure.Management.AzureStack.Models;

    public class CustomerSubscriptionResult
    {
        public CustomerSubscriptionResult(CustomerSubscription subscription)
        {
            this.Name = subscription.Name;
            this.Id = subscription.Id;
            this.TenantId = subscription.TenantId;
        }

        public CustomerSubscriptionResult() { }

        public string Name { get; protected set; }

        public string Id { get; protected set; }

        public string TenantId { get; protected set; }
    }
}