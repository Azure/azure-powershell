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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components
{
    using Newtonsoft.Json;
    using System.Collections;

    /// <summary>
    /// Response with next link signifying continuation.
    /// </summary>
    /// <typeparam name="T">Type of response.</typeparam>
    public class ResponseWithContinuation<T> where T : IEnumerable
    {
        /// <summary>
        /// Gets or sets the value of response.
        /// </summary>
        [JsonProperty]
        public T Value
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the next link to query to get the remaining results.
        /// </summary>
        [JsonProperty]
        public string NextLink
        {
            get;
            set;
        }
    }
}
