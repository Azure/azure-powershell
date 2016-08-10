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

namespace Microsoft.Azure.Commands.Scheduler.Models
{
    using System;
    using SchedulerModels = Microsoft.Azure.Management.Scheduler.Models;

    public class PSServiceBusJobActionDetails : PSJobActionDetails
    {
        /// <summary>
        /// Gets or sets the authentication.
        /// </summary>
        public PSServiceBusJobActionAuthenticationDetails ServiceBusAuthentication { get; internal set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string ServiceBusMessage { get; internal set; }

        /// <summary>
        /// Gets or sets the namespace.
        /// </summary>
        public string ServiceBusNamespaceProperty { get; internal set; }

        /// <summary>
        /// Gets or sets the transport type. Possible values include: 'NotSpecified','NetMessaging', 'AMQP'
        /// </summary>
        public string ServiceBusTransportType { get; internal set; }

        /// <summary>
        /// Gets or sets the queue name.
        /// </summary>
        public string ServiceBusQueueName { get; internal set; }

        /// <summary>
        /// Gets or sets the topic path.
        /// </summary>
        public string ServiceBusTopicPath { get; internal set; }

        public PSServiceBusJobActionDetails(SchedulerModels.JobActionType actionType)
        {
            if (actionType != SchedulerModels.JobActionType.ServiceBusQueue &&
                actionType != SchedulerModels.JobActionType.ServiceBusTopic)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.JobActionType = actionType;
        }
    }
}
