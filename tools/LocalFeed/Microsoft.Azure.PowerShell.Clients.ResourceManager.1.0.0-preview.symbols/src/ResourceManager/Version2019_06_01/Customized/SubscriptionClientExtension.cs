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

using Microsoft.Azure.Commands.ResourceManager.Common.Paging;
using Microsoft.Azure.Management.ResourceManager.Version2019_06_01;
using Microsoft.Azure.Management.ResourceManager.Version2019_06_01.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Version2019_06_01.Customized
{
    public static class SubscriptionClientExtension
    {
        public static GenericPageEnumerable<Subscription> ListAllSubscriptions(this ISubscriptionClient client)
        {
            return new GenericPageEnumerable<Subscription>(client.Subscriptions.List, client.Subscriptions.ListNext, ulong.MaxValue, 0);
        }
    }
}
