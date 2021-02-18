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

using Microsoft.Azure.Management.Support.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Support
{
    public static partial class MicrosoftSupportClientExtensions
    {
        public static SupportTicketDetails CreateSupportTicketForSubscription(
            this IMicrosoftSupportClient operations, 
            string supportTicketName, 
            SupportTicketDetails createSupportTicketParameters,
            Dictionary<string, List<string>> customHeaders = null)
        {
            return operations.CreateSupportTicketForSubscriptionAsync(supportTicketName, createSupportTicketParameters, customHeaders).GetAwaiter().GetResult();
        }

        public static async Task<SupportTicketDetails> CreateSupportTicketForSubscriptionAsync(this IMicrosoftSupportClient operations, string supportTicketName, SupportTicketDetails createSupportTicketParameters, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.SupportTickets.CreateWithHttpMessagesAsync(supportTicketName, createSupportTicketParameters, customHeaders, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
