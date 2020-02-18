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

using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;

namespace Microsoft.Azure.Commands.Support.Models
{
    public class PSSupportTicketCommunication
    {
        /// <summary>
        ///  Gets or sets the resource Id of the resource.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource.
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets the type of the resource.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets communication type. Possible values include: 'web', 'phone'
        /// </summary>
        public string CommunicationType { get; set; }

        /// <summary>
        /// Gets direction of communication. Possible values include:
        /// 'inbound', 'outbound'
        /// </summary>
        public string CommunicationDirection { get; set; }

        /// <summary>
        /// Gets or sets sender of the communication.
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string Sender { get; set; }

        /// <summary>
        /// Gets or sets subject of the communication.
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets body of the communication.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets time in UTC (ISO 8601 format) when the communication was
        /// created.
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public DateTime? CreatedDate { get; set; }

    }
}
