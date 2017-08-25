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
        /// Gets or sets token cache file path.
        /// </summary>
        string TokenCacheFile { get; set; }

        /// <summary>
        /// The directory containing the disk token cache
        /// </summary>
        string TokenCacheDirectory { get; set; }

        /// <summary>
        /// Gets or sets profile directory.
        /// </summary>
        string ProfileDirectory { get; set; }

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
        /// The scope of context persistece, for now "Process" or "CurrentUser"
        /// </summary>
        string ARMContextSaveMode { get; set; }

        /// <summary>
        /// Try to get the shared component registered in this session with the given type and name
        /// </summary>
        /// <typeparam name="T">The type of the custom component</typeparam>
        /// <param name="componentName">The name of the custom component</param>
        /// <param name="component">If the component is found, the registered component, otherwise null</param>
        /// <returns>True if the component is found, False otherwise</returns>
        bool TryGetComponent<T>(string componentName, out T component) where T : class;

        /// <summary>
        /// Register the given shared component in this session, if it is not already registered
        /// </summary>
        /// <typeparam name="T">The type of the shared component</typeparam>
        /// <param name="componentName">The name of the shared component</param>
        /// <param name="componentInitializer"></param>
        void RegisterComponent<T>(string componentName, Func<T> componentInitializer) where T : class;

        /// <summary>
        /// Register the given shared componente
        /// </summary>
        /// <typeparam name="T">The type of the shared component</typeparam>
        /// <param name="componentName">The name of the shared component</param>
        /// <param name="componentInitializer">The initializer for the component</param>
        /// <param name="overwrite">Whether to overwrite an existing component with the new one</param>
        void RegisterComponent<T>(string componentName, Func<T> componentInitializer, bool overwrite) where T: class;

        /// <summary>
        /// Remove the provided component from the shared components registry
        /// </summary>
        /// <typeparam name="T">The type of the component</typeparam>
        /// <param name="componentName">The component name</param>
        void UnregisterComponent<T>(string componentName) where T: class;

        /// <summary>
        /// Remove all components from the session shared component registry
        /// </summary>
        void ClearComponents();

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
