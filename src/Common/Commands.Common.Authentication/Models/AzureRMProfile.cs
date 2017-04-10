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

namespace Microsoft.Azure.Commands.Common.Authentication.Models
{
    /// <summary>
    /// Represents Azure Resource Manager profile structure with default context, environments and token cache.
    /// </summary>
    [Serializable]
    public sealed class AzureRMProfile : IAzureContextContainer
    {
        /// <summary>
        /// Gets or sets Azure environments.
        /// </summary>
        public Dictionary<string, AzureEnvironment> EnvironmentTable { get; set; }

        public Dictionary<string, AzureContext> Contexts = new Dictionary<string, AzureContext>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Gets the path of the profile file. 
        /// </summary>
        [JsonIgnore]
        public string ProfilePath { get; private set; }

        /// <summary>
        /// Gets the default context
        /// </summary>
        public AzureContext DefaultContext { get; set;}

        public IEnumerable<AzureEnvironment> Environments
        {
            get
            {
                return EnvironmentTable.Values;
            }
        }

        public IEnumerable<AzureSubscription> Subscriptions
        {
            get
            {
                return Contexts.Values.Select((c) => c.Subscription);
            }
        }

        public IEnumerable<AzureAccount> Accounts
        {
            get
            {
                return Contexts.Values.Select((c) => c.Account);
            }
        }

        public IAuthenticationStore TokenStore { get; set; } = new AuthenticationStoreTokenCache(new AuthenticationStore());

        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public ICollection<string> Keys
        {
            get
            {
                return Contexts.Keys;
            }
        }

        public ICollection<AzureContext> Values
        {
            get
            {
                return Contexts.Values;
            }
        }

        public int Count
        {
            get
            {
                return Contexts.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public AzureContext this[string key]
        {
            get
            {
                return Contexts[key];
            }

            set
            {
                Contexts[key] = value;
            }
        }

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
                var profile = JsonConvert.DeserializeObject<IAzureContextContainer>(contents);
                Debug.Assert(profile != null);
                DefaultContext = profile.DefaultContext;
                EnvironmentTable.Clear();
                foreach (var environment in profile.Environments)
                {
                    EnvironmentTable[environment.Name] = environment;
                }
            }
        }

        /// <summary>
        /// Creates new instance of AzureRMProfile.
        /// </summary>
        public AzureRMProfile()
        {
            EnvironmentTable = new Dictionary<string, AzureEnvironment>(StringComparer.InvariantCultureIgnoreCase);

            // Adding predefined environments
            foreach (AzureEnvironment env in AzureEnvironment.PublicEnvironments.Values)
            {
                EnvironmentTable[env.Name] = env;
            }
        }

        /// <summary>
        /// Initializes a new instance of AzureRMProfile and loads its content from specified path.
        /// </summary>
        /// <param name="path">The location of profile file on disk.</param>
        public AzureRMProfile(string path) : this()
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
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public bool ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        public void Add(string key, AzureContext value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, out AzureContext value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<string, AzureContext> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<string, AzureContext> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<string, AzureContext>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, AzureContext> item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, AzureContext>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
