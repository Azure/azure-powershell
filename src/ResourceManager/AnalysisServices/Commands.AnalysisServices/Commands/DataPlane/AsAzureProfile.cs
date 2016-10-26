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

namespace Microsoft.Azure.Commands.AnalysisServices
{
    /// <summary>
    /// Represents Azure Resource Manager profile structure with default context, environments and token cache.
    /// </summary>
    [Serializable]
    public sealed class AsAzureProfile
    {
        /// <summary>
        /// Gets or sets Azure environments.
        /// </summary>
        public Dictionary<string, AsAzureEnvironment> Environments { get; set; }

        /// <summary>
        /// Gets or sets the default azure context object.
        /// </summary>
        public AsAzureContext Context { get; set; }

        /// <summary>
        /// Gets the path of the profile file. 
        /// </summary>
        [JsonIgnore]
        public string ProfilePath { get; private set; }

        private void Load(string path)
        {
            this.ProfilePath = path;

            if (!AsAzureClientUtility.DataStore.DirectoryExists(AsAzureClientUtility.ProfileDirectory))
            {
                AsAzureClientUtility.DataStore.CreateDirectory(AsAzureClientUtility.ProfileDirectory);
            }

            if (AsAzureClientUtility.DataStore.FileExists(ProfilePath))
            {
                string contents = AsAzureClientUtility.DataStore.ReadFileAsText(ProfilePath);
                AsAzureProfile profile = JsonConvert.DeserializeObject<AsAzureProfile>(contents);
                Debug.Assert(profile != null);
                this.Context = profile.Context;
                this.Environments = profile.Environments;
            }
            else
            {
                this.Environments = new Dictionary<string, AsAzureEnvironment>();
            }
        }

        /// <summary>
        /// Initializes a new instance of AzureRMProfile and loads its content from specified path.
        /// </summary>
        /// <param name="path">The location of profile file on disk.</param>
        public AsAzureProfile()
        {
            this.Environments = new Dictionary<string, AsAzureEnvironment>();
        }

        /// <summary>
        /// Initializes a new instance of AzureRMProfile and loads its content from specified path.
        /// </summary>
        /// <param name="path">The location of profile file on disk.</param>
        public AsAzureProfile(string path)
        {
            Load(path);
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
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            try
            {
                string contents = ToString();
                string diskContents = string.Empty;
                if (AsAzureClientUtility.DataStore.FileExists(path))
                {
                    diskContents = AsAzureClientUtility.DataStore.ReadFileAsText(path);
                }

                if (diskContents != contents)
                {
                    AsAzureClientUtility.DataStore.WriteFile(path, contents);
                }
            }
            finally
            {
                // Adding back predefined environments
                //foreach (AzureEnvironment env in AzureEnvironment.PublicEnvironments.Values)
                //{
                //    Environments[env.Name] = env;
                //}
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

        public AsAzureEnvironment CreateEnvironment(string environmentName)
        {
            var env = new AsAzureEnvironment(environmentName);
            env.Endpoints.Add(AsAzureEnvironment.AsRolloutEndpoints.AdAuthorityBaseUrl, "https://login.windows-ppe.net/common");
            env.Endpoints.Add(AsAzureEnvironment.AsRolloutEndpoints.RestartEndpointFormat, "/webapi/servers/{0}/restart?api-version=2016-10-01");

            return env;
        }
    }
}
