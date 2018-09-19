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

namespace Microsoft.Azure.Commands.ServiceBus.Models
{
    using Azure.Management.ServiceBus.Models;
    using System;

    /// <summary>
    /// Description of a Check Name availability request properties.
    /// </summary>
    public partial class PSCheckNameAvailabilityResultAttributes
    {
        /// <summary>
        /// Initializes a new instance of the CheckNameAvailabilityResult
        /// class.
        /// </summary>
        public PSCheckNameAvailabilityResultAttributes() { }

        /// <summary>
        /// Initializes a new instance of the CheckNameAvailabilityResult
        /// class.
        /// </summary>
        /// <param name="nameAvailable">Value indicating namespace is
        /// availability, true if the namespace is available; otherwise,
        /// false.</param>
        /// <param name="reason">The reason for unavailability of a namespace.
        /// Possible values include: 'None', 'InvalidName',
        /// 'SubscriptionIsDisabled', 'NameInUse', 'NameInLockdown',
        /// 'TooManyNamespaceInCurrentSubscription'</param>
        /// <param name="message">The detailed info regarding the reason
        /// associated with the namespace.</param>
        public PSCheckNameAvailabilityResultAttributes(bool? nameAvailable = default(bool?), UnavailableReasonAttributes? reason = default(UnavailableReasonAttributes?), string message = default(string))
        {
            NameAvailable = nameAvailable;
            Reason = reason;
            Message = message;
        }


        public PSCheckNameAvailabilityResultAttributes(CheckNameAvailabilityResult checkNameAvailabilityResult)
        {
            NameAvailable = checkNameAvailabilityResult.NameAvailable;
            //if (checkNameAvailabilityResult.Reason)
            //{
                Reason = (UnavailableReasonAttributes)Enum.Parse(typeof(UnavailableReasonAttributes), checkNameAvailabilityResult.Reason.ToString(), true);
            //}

            Message = checkNameAvailabilityResult.Message;
        }

        /// <summary>
        /// Gets or sets value indicating namespace is availability, true if
        /// the namespace is available; otherwise, false.
        /// </summary>
        public bool? NameAvailable { get; set; }

        /// <summary>
        /// Gets or sets the reason for unavailability of a namespace. Possible
        /// values include: 'None', 'InvalidName', 'SubscriptionIsDisabled',
        /// 'NameInUse', 'NameInLockdown',
        /// 'TooManyNamespaceInCurrentSubscription'
        /// </summary>
        public UnavailableReasonAttributes? Reason { get; set; }

        /// <summary>
        /// Gets the detailed info regarding the reason associated with the
        /// namespace.
        /// </summary>
        public string Message { get; protected set; }

    }
}
