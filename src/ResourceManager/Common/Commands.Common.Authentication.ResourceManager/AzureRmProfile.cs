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
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Collections;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Xml.Serialization;
using Microsoft.Azure.Commands.ResourceManager.Common.Serialization;

namespace Microsoft.Azure.Commands.Common.Authentication.Models
{
    /// <summary>
    /// Represents Azure Resource Manager profile structure with default context, environments and token cache.
    /// </summary>
    [Serializable]
    public class AzureRmProfile : IAzureContextContainer
    {
        public const string DefaultContextKey = "Default";
        /// <summary>
        /// Gets or sets Azure environments.
        /// </summary>
        public Dictionary<string, IAzureEnvironment> EnvironmentTable { get; set; } = new Dictionary<string, IAzureEnvironment>(StringComparer.CurrentCultureIgnoreCase);

        public Dictionary<string, IAzureContext> Contexts { get; set; } = new Dictionary<string, IAzureContext>(StringComparer.CurrentCultureIgnoreCase);

        /// <summary>
        /// Gets the path of the profile file. 
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        public string ProfilePath { get; protected set; }

        /// <summary>
        /// Gets the default context
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        public virtual IAzureContext DefaultContext
        {
            get
            {
                IAzureContext result = null;
                if (this.Contexts.ContainsKey(DefaultContextKey))
                {
                    result = this.Contexts[DefaultContextKey];
                }

                return result;
            }
            set
            {
                this.Contexts[DefaultContextKey] = value;
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        public IEnumerable<IAzureEnvironment> Environments
        {
            get
            {
                return EnvironmentTable.Values;
            }
        }

        [JsonIgnore]
        public IEnumerable<IAzureSubscription> Subscriptions
        {
            get
            {
                return Contexts.Values.Select((c) => c.Subscription);
            }
        }

        [JsonIgnore]
        public IEnumerable<IAzureAccount> Accounts
        {
            get
            {
                return Contexts.Values.Select((c) => c.Account);
            }
        }

        public IDictionary<string, string> ExtendedProperties { get; set;} = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        private void Load(string path)
        {
            this.ProfilePath = path;

            if (!AzureSession.Instance.DataStore.DirectoryExists(AzureSession.Instance.ProfileDirectory))
            {
                AzureSession.Instance.DataStore.CreateDirectory(AzureSession.Instance.ProfileDirectory);
            }

            if (AzureSession.Instance.DataStore.FileExists(ProfilePath))
            {
                string contents = AzureSession.Instance.DataStore.ReadFileAsText(ProfilePath);
                var oldProfile = JsonConvert.DeserializeObject<LegacyAzureRmProfile>(contents);
                AzureRmProfile profile;
                if (!oldProfile.TryConvert(out profile))
                {
                    profile = JsonConvert.DeserializeObject<IAzureContextContainer>(contents, new AzureRmProfileConverter()) as AzureRmProfile;
                }
                Debug.Assert(profile != null);
                EnvironmentTable.Clear();
                foreach (var environment in profile.EnvironmentTable)
                {
                    EnvironmentTable[environment.Key] = environment.Value;
                }

                Contexts.Clear();
                foreach (var context in profile.Contexts)
                {
                    this.Contexts.Add(context.Key, context.Value);
                }
            }
        }

        /// <summary>
        /// Creates new instance of AzureRMProfile.
        /// </summary>
        public AzureRmProfile()
        {
            EnvironmentTable = new Dictionary<string, IAzureEnvironment>(StringComparer.CurrentCultureIgnoreCase);

            // Adding predefined environments
            foreach (var env in AzureEnvironment.PublicEnvironments)
            {
                EnvironmentTable[env.Key] = env.Value;
            }
        }

        /// <summary>
        /// Initializes a new instance of AzureRMProfile and loads its content from specified path.
        /// </summary>
        /// <param name="path">The location of profile file on disk.</param>
        public AzureRmProfile(string path) : this()
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

            // Removing predefined environments
            foreach (string env in AzureEnvironment.PublicEnvironments.Keys)
            {
                EnvironmentTable.Remove(env);
            }

            try
            {
                string contents = ToString();
                string diskContents = string.Empty;
                if (AzureSession.Instance.DataStore.FileExists(path))
                {
                    diskContents = AzureSession.Instance.DataStore.ReadFileAsText(path);
                }

                if (diskContents != contents)
                {
                    AzureSession.Instance.DataStore.WriteFile(path, contents);
                }
            }
            finally
            {
                // Adding back predefined environments
                foreach (AzureEnvironment env in AzureEnvironment.PublicEnvironments.Values)
                {
                    EnvironmentTable[env.Name] = env;
                }
            }
        }

        /// <summary>
        /// Serializes the current profile and return its contents.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new AzureRmProfileConverter());
        }

        /// <summary>
        /// Set the contaienr to its defautl state
        /// </summary>
        public void Clear()
        {
            Contexts.Clear();
            DefaultContext = new AzureContext();
            EnvironmentTable.Clear();
            foreach (var environment in AzureEnvironment.PublicEnvironments)
            {
                EnvironmentTable.Add(environment.Key, environment.Value);
            }
        }
    }
}
