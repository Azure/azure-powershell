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

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// Stores the serialiable state of a client factory
    /// </summary>
    public class ClientFactorySettings : IExtensibleSettings
    {
        /// <summary>
        /// The user agents in the current client factory
        /// </summary>
        public IEnumerable<UserAgentSettings> UserAgents { get; }

        /// <summary>
        /// The set of custom delegating handlers
        /// </summary>
        public IDictionary<string, HandlerSettings> DelegatingHandlers { get; }

        /// <summary>
        /// The set of custom client actions
        /// </summary>
        public IEnumerable<ClientActionSettings> ClientActions { get; }

        /// <summary>
        /// The extensible settings for the Client factory
        /// </summary>
        public IDictionary<string, string> Settings { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    }
}
