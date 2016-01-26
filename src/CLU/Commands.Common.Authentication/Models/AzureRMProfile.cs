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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Microsoft.Azure.Commands.Common.Authentication.Models
{
    /// <summary>
    /// Represents Azure Resource Manager profile structure with default context, environments and token cache.
    /// </summary>
    public sealed class AzureRMProfile : IAzureProfile
    {
        private IDataStore _dataStore;

        /// <summary>
        /// Creates new instance of AzureRMProfile.
        /// </summary>
        public AzureRMProfile() : this(new DiskDataStore())
        {
        }

        /// <summary>
        /// Initializes a new instance of AzureRMProfile and loads its content from specified path.
        /// </summary>
        /// <param name="path">The location of profile file on disk.</param>
        /// <param name="dataStore">The location of profile file on disk.</param>
        public AzureRMProfile(string path, IDataStore dataStore) : this(dataStore)
        {
            Load(path);
        }

        public AzureRMProfile(IDataStore dataStore)
        {
            _dataStore = dataStore;
            Environments = new Dictionary<string, AzureEnvironment>(StringComparer.CurrentCultureIgnoreCase);

            // Adding predefined environments
            foreach (AzureEnvironment env in AzureEnvironment.PublicEnvironments.Values)
            {
                Environments[env.Name] = env;
            }
        }

        /// <summary>
        /// Gets or sets Azure environments.
        /// </summary>
        public Dictionary<string, AzureEnvironment> Environments { get; set; }

        /// <summary>
        /// Gets or sets the default azure context object.
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Gets the path of the profile file. 
        /// </summary>
        [JsonIgnore]
        public string ProfilePath { get; private set; }

        /// <summary>
        /// When set to true, collects telemetry information.
        /// </summary>
        public bool? IsTelemetryCollectionEnabled { get; set; }
        
        private void Load(string path)
        {
            this.ProfilePath = path;
            if (_dataStore.FileExists(ProfilePath))
            {
                string contents = _dataStore.ReadFileAsText(ProfilePath);
                JsonConvert.PopulateObject(contents, this);
            }
        }

        /// <summary>
        /// Writes profile to the disk it was opened from disk.
        /// </summary>
        public void Save()
        {
            if (!string.IsNullOrEmpty(ProfilePath))
            {
                Save(ProfilePath);
            }
        }

        /// <summary>
        /// Writes profile to a specified path.
        /// </summary>
        /// <param name="path">File path on disk to save profile to</param>
        public void Save(string path)
        {
            Save(_dataStore, path);
        }

        public void Save(IDataStore store, string path)
        {

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            if (store == null)
            {
                return;
            }

            // Removing predefined environments
            foreach (string env in AzureEnvironment.PublicEnvironments.Keys)
            {
                Environments.Remove(env);
            }

            try
            {
                string contents = ToString();
                string diskContents = string.Empty;
                if (store.FileExists(path))
                {
                    diskContents = store.ReadFileAsText(path);
                }

                if (diskContents != contents)
                {
                    store.WriteFile(path, contents);
                }
            }
            finally
            {
                // Adding back predefined environments
                foreach (AzureEnvironment env in AzureEnvironment.PublicEnvironments.Values)
                {
                    Environments[env.Name] = env;
                }
            }
        }

        /// <summary>
        /// Serializes the current profile and return its contents.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
