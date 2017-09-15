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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// Autosave settings for the context
    /// </summary>
    public class ContextAutosaveSettings : IExtensibleSettings
    {
        public const string AutoSaveSettingsFile = "AzureRmContextSettings.json";
        IDictionary<string, string> _extendedSettings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Autosave mode
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// Directory where the context should be saved
        /// </summary>
        public string ContextDirectory { get; set; }

        /// <summary>
        /// Fiel name for the context file
        /// </summary>
        public string ContextFile { get; set; }

        /// <summary>
        /// The directory where a disk cache should be saved
        /// </summary>
        public string CacheDirectory { get; set; }

        /// <summary>
        /// The name of the cache file
        /// </summary>
        public string CacheFile { get; set; }


        /// <summary>
        /// Extensible settings for autosave
        /// </summary>
        public IDictionary<string, string> Settings
        {
            get
            {
                return _extendedSettings;
            }
            set
            {
                _extendedSettings = value;
            }
        }
    }
}
