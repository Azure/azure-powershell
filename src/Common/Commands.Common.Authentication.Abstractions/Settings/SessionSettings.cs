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
    /// The settings for the current session
    /// </summary>
    public class SessionSettings : IExtensibleSettings
    {
        /// <summary>
        /// The settings for the client factory
        /// </summary>
        public ClientFactorySettings ClientSettings { get; set; }

        /// <summary>
        /// The settings for the authentication factory
        /// </summary>
        public AuthenticationFactorySettings AuthenticationSettings { get; set; }

        /// <summary>
        /// The settigns for the data store
        /// </summary>
        public DataStorageSettings DataSettings { get; set; }

        /// <summary>
        /// The extended settings for the session
        /// </summary>
        public IDictionary<string, string> Settings { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    }
}
