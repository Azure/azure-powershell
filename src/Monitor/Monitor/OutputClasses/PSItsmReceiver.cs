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

using Microsoft.Azure.Commands.Insights.TransitionalClasses;
using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wraps the ItsmReceiver class.
    /// </summary>
    public class PSItsmReceiver : PSActionGroupReceiverBase
    {
        /// <summary>Gets or sets the itsm workspace id of this receiver.</summary>
        public string WorkspaceId { get; set; }

        /// <summary>Gets or sets the itsm connection id of this receiver.</summary>
        public string ConnectionId { get; set; }

        /// <summary>Gets or sets the itsm ticket configuration of this receiver.</summary>
        public string TicketConfiguration { get; set; }

        /// <summary>Gets or sets the itsm region of this receiver.</summary>
        public string Region { get; set; }

        /// <summary>Initializes a new instance of the PSItsmReceiver class</summary>
        public PSItsmReceiver()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PSItsmReceiver class.
        /// </summary>
        /// <param name="receiver">The receiver to wrap.</param>
        public PSItsmReceiver(ItsmReceiver receiver)
        {
            this.Name = receiver.Name;
            this.WorkspaceId = receiver.WorkspaceId;
            this.ConnectionId = receiver.ConnectionId;
            this.TicketConfiguration = receiver.TicketConfiguration;
            this.Region = receiver.Region;
        }
    }
}
