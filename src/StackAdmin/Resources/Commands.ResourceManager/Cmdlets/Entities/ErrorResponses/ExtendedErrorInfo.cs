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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.ErrorResponses
{
    using Newtonsoft.Json;

    /// <summary>
    /// The extended error information.
    /// </summary>
    public class ExtendedErrorInfo
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Target { get; set; }

        /// <summary>
        /// Gets or sets the detailed error message details.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public ExtendedErrorInfo[] Details { get; set; }
    }
}
