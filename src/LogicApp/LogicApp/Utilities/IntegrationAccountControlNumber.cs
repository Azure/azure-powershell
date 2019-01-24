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

namespace Microsoft.Azure.Commands.LogicApp.Utilities
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// The Replicable control number content.
    /// </summary>
    /// <remarks>This type is to be kept identical to the B2B Connector type ReplicableControlNumberContent.</remarks>
    public class IntegrationAccountControlNumber
    {
        /// <summary>
        /// Gets or sets the control number
        /// </summary>
        [JsonProperty]
        public string ControlNumber { get; set; }

        /// <summary>
        /// Gets or sets the message received time
        /// </summary>
        /// <remarks>
        /// Will be null for generated ICN's
        /// </remarks>
        [JsonProperty(ItemConverterType = typeof(IsoDateTimeConverter))]
        public DateTime ControlNumberChangedTime { get; set; }

        /// <summary>
        /// Gets or sets whether the message processing failed.
        /// </summary>
        [JsonProperty]
        public bool? IsMessageProcessingFailed { get; set; }

        /// <summary>
        /// Gets or sets the message type.
        /// </summary>
        [JsonProperty]
        public MessageType? MessageType { get; set; }
    }
}
