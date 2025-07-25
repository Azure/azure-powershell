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

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.ManagementGroups.Models;

namespace Microsoft.Azure.Commands.Resources.Models.ManagementGroups
{
    public class PSManagementGroupSubscription
    {
        public string Id { get; private set; }

        public string Type { get; private set; }

        public string Tenant { get; private set; }

        public string DisplayName { get; private set; }

        public string Parent { get; set; }

        public string State { get; private set; }

        public PSManagementGroupSubscription()
        {
        }

        public PSManagementGroupSubscription(SubscriptionUnderManagementGroup subscriptionUnderManagementGroup)
        {
            Id = subscriptionUnderManagementGroup.Id;
            Type = subscriptionUnderManagementGroup.Type;
            Tenant = subscriptionUnderManagementGroup.Tenant;
            DisplayName = subscriptionUnderManagementGroup.DisplayName;
            Parent = subscriptionUnderManagementGroup.Parent.Id;
            State = subscriptionUnderManagementGroup.State;
        }
    }
}
