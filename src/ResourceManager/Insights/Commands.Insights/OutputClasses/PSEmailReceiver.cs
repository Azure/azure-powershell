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

using Microsoft.Azure.Management.Monitor.Management.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wraps the EmailReceiver class.
    /// </summary>
    public class PSEmailReceiver : PSActionGroupReceiverBase
    {
        /// <summary>
        /// Gets or sets the receiver's address.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the receiver's status.
        /// </summary>
        public ReceiverStatus? Status { get; set; }

        /// <summary>Initializes a new instance of the PSEmailReceiver class</summary>
        public PSEmailReceiver()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PSEmailReceiver class.
        /// </summary>
        /// <param name="receiver">The receiver to wrap.</param>
        public PSEmailReceiver(EmailReceiver receiver)
        {
            this.Name = receiver.Name;
            this.EmailAddress = receiver.EmailAddress;
            this.Status = receiver.Status;
        }
    }
}
