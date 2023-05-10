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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.ServiceBus.Models
{
    public class PSCorrelationFilterAttributes
    {
        /// <summary>
        /// Initializes a new instance of the CorrelationFilter class.
        /// </summary>
        public PSCorrelationFilterAttributes()
        {
            Properties = new Dictionary<string, string>();
        }

        /// <summary>
        /// Initializes a new instance of the CorrelationFilter class.
        /// </summary>
        /// <param name="correlationFilter">Properties of
        /// correlationFilter</param>
        public PSCorrelationFilterAttributes(Management.ServiceBus.Models.CorrelationFilter correlationFilter)
        {
            if (correlationFilter != null)
            {
                CorrelationId = correlationFilter.CorrelationId;
                MessageId = correlationFilter.MessageId;
                To = correlationFilter.To;
                ReplyTo = correlationFilter.ReplyTo;
                Label = correlationFilter.Label;
                SessionId = correlationFilter.SessionId;
                ReplyToSessionId = correlationFilter.ReplyToSessionId;
                ContentType = correlationFilter.ContentType;
                RequiresPreprocessing = correlationFilter.RequiresPreprocessing;
                Properties = correlationFilter.Properties;
            }
            else
            {
                Properties = new Dictionary<string, string>();
            }
        }

        /// <summary>
        /// Gets or sets identifier of the correlation.
        /// </summary>
        public string CorrelationId { get; set; }

        /// <summary>
        /// Gets or sets identifier of the message.
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets address to send to.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Gets or sets address of the queue to reply to.
        /// </summary>
        public string ReplyTo { get; set; }

        /// <summary>
        /// Gets or sets application specific label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets session identifier.
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// Gets or sets session identifier to reply to.
        /// </summary>
        public string ReplyToSessionId { get; set; }

        /// <summary>
        /// Gets or sets content type of the message.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets value that indicates whether the rule action requires
        /// preprocessing.
        /// </summary>
        public bool? RequiresPreprocessing { get; set; }

        /// <summary>
        /// Gets or sets resource tags
        /// </summary>
        public IDictionary<string, string> Properties { get; set; }

    }
}
