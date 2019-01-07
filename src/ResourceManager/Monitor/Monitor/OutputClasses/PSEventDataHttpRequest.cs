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

using System.Text;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the EventDataHttpRequest to provide a better output format for the PS command lets.
    /// </summary>
    public class PSEventDataHttpRequest
    {
        /// <summary>
        /// Gets or sets the clientId
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the method
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the clientIpAddress
        /// </summary>
        public string ClientIpAddress { get; set; }

        /// <summary>
        /// A string representation of the PSEventDataHttpRequest
        /// </summary>
        /// <returns>A string representation of the PSEventDataHttpRequest</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine();
            output.AppendLine("ClientId        : " + ClientId);
            output.AppendLine("Method          : " + Method);
            output.AppendLine("Url             : " + Url);
            output.Append("ClientIpAddress : " + ClientIpAddress);
            return output.ToString();
        }
    }
}
