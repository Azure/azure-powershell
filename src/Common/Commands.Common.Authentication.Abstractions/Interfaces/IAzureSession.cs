﻿// ----------------------------------------------------------------------------------
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
using System.Diagnostics;
using System.IO;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// Represents current Azure session.
    /// </summary>
    public interface IAzureSession : IExtensibleModel
    {
        /// <summary>
        /// Gets or sets Azure client factory.
        /// </summary>
        IClientFactory ClientFactory { get; set; }

        /// <summary>
        /// Gets or sets Azure authentication factory.
        /// </summary>
        IAuthenticationFactory AuthenticationFactory { get; set; }

        /// <summary>
        /// Gets or sets data persistence store.
        /// </summary>
        IDataStore DataStore { get; set; }

        /// <summary>
        /// Gets or sets the token cache store.
        /// </summary>
        IAzureTokenCache TokenCache { get; set; }

        /// <summary>
        /// Gets or sets profile directory.
        /// </summary>
        string ProfileDirectory { get; set; }

        /// <summary>
        /// Gets or sets token cache file path.
        /// </summary>
        string TokenCacheFile { get; set; }

        /// <summary>
        /// Gets or sets profile file name.
        /// </summary>
        string ProfileFile { get; set; }

        /// <summary>
        /// Gets or sets file name for the migration backup.
        /// </summary>
        string OldProfileFileBackup { get; set; }

        /// <summary>
        /// Gets or sets old profile file name.
        /// </summary>
        string OldProfileFile { get; set; }

        /// <summary>
        /// The directory contianing the ARM Profile
        /// </summary>
        string ARMProfileDirectory { get; set; }

        /// <summary>
        /// The file name of the ARM Profile file
        /// </summary>
        string ARMProfileFile { get; set; }

        /// <summary>
        /// The trace level for authentication
        /// </summary>
        TraceLevel AuthenticationLegacyTraceLevel { get; set; }

        /// <summary>
        /// The trace source levels for authentication
        /// </summary>
        SourceLevels AuthenticationTraceSourceLevel { get; set; }

        /// <summary>
        /// The trace listeners for authentication traces
        /// </summary>
        TraceListenerCollection AuthenticationTraceListeners { get; }

    }
}
