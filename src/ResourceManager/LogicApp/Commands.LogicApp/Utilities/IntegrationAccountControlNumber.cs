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
    using System.Management.Automation;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// LogicApp client partial class for integration account control number types.
    /// </summary>
    public partial class IntegrationAccountClient
    {
        /// <summary>
        /// Enumeration to specify the control number types
        /// </summary>
        public enum ControlNumberType
        {
            /// <summary>
            /// Interchange control number
            /// </summary>
            Icn,

            /// <summary>
            /// Group control number
            /// </summary>
            Gcn,

            /// <summary>
            /// Transaction set control number
            /// </summary>
            Tscn,
        }

        /// <summary>
        /// Converts session content to integration account control number.
        /// </summary>
        /// <param name="sessionContent">The session content.</param>
        /// <param name="integrationAccountAgreementName">The integration account agreement name.</param>
        /// <returns>The <see cref="IntegrationAccountControlNumber"/>.</returns>
        /// <exception cref="PSInvalidOperationException">If the session content is not in the expected format.</exception>
        private static IntegrationAccountControlNumber SessionContentToIntegrationAccountControlNumber(object sessionContent, string integrationAccountAgreementName, string controlNumber = null)
        {
            var content = sessionContent as JObject;
            if (content != null)
            {
                try
                {
                    return content.ToObject<IntegrationAccountControlNumber>();
                }
                catch (FormatException)
                {
                }
                catch (JsonException)
                {
                }
            }

            if (string.IsNullOrEmpty(controlNumber))
            {
                throw new PSInvalidOperationException(message: string.Format(
                    Properties.Resource.GeneratedControlNumberInvalidFormat,
                    integrationAccountAgreementName));
            }
            else
            {
                throw new PSInvalidOperationException(message: string.Format(
                    Properties.Resource.ReceivedControlNumberInvalidFormat,
                    controlNumber,
                    integrationAccountAgreementName));
            }
        }

        /// <summary>
        /// The control number qualified with agreement name.
        /// </summary>
        public class QualifiedIntegrationAccountControlNumber : IntegrationAccountControlNumber
        {
            /// <summary>
            /// Creates a new instance for the base class and an agreement name.
            /// </summary>
            public QualifiedIntegrationAccountControlNumber(IntegrationAccountControlNumber icn, string agreementName)
            {
                this.ControlNumber = icn.ControlNumber;
                this.ControlNumberChangedTime = icn.ControlNumberChangedTime;
                this.AgreementName = agreementName;
            }

            /// <summary>
            /// Gets or sets the agreement name
            /// </summary>
            public string AgreementName { get; set; }
        }

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
        }
    }
}
