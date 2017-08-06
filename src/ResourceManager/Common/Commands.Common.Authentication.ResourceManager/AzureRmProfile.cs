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
using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Xml.Serialization;
using Microsoft.Azure.Commands.ResourceManager.Common.Serialization;
using System.Collections.Concurrent;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication.Models
{
    /// <summary>
    /// Represents Azure Resource Manager profile structure with default context, environments and token cache.
    /// </summary>
    [Serializable]
    public class AzureRmProfile : IAzureContextContainer, IProfileOperations
    {
        public string DefaultContextKey { get; set; } = "Default";
        /// <summary>
        /// Gets or sets Azure environments.
        /// </summary>
        public IDictionary<string, IAzureEnvironment> EnvironmentTable { get; set; } = new ConcurrentDictionary<string, IAzureEnvironment>(StringComparer.CurrentCultureIgnoreCase);

        public IDictionary<string, IAzureContext> Contexts { get; set; } = new ConcurrentDictionary<string, IAzureContext>(StringComparer.CurrentCultureIgnoreCase);

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
                return EnvironmentTable.Values.ToList();
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

        public IDictionary<string, string> ExtendedProperties { get; set; } = new ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

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
                LoadImpl(contents);
            }
        }

        private void Load(IFileProvider provider)
        {
            this.ProfilePath = provider.FilePath;
            LoadImpl(provider.Reader.ReadToEnd());
        }

        private void LoadImpl(string contents)
        {
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
                context.Value.TokenCache = AzureSession.Instance.TokenCache;
                this.Contexts.Add(context.Key, context.Value);
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
        /// Initializes a new instance of AzureRmProfile using a specialized file provider
        /// </summary>
        /// <param name="provider">The file provider that allows retrieving profile contents</param>
        public AzureRmProfile(IFileProvider provider)
        {
            Load(provider);
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

            using (var provider = ProtectedFileProvider.CreateFileProvider(path, FileProtection.ExclusiveWrite))
            {
                Save(provider);
            }
        }

        /// <summary>
        /// Writes the profile using the specified file provider
        /// </summary>
        /// <param name="provider">The file provider used to save the profile</param>
        public void Save(IFileProvider provider)
        {
            foreach (string env in AzureEnvironment.PublicEnvironments.Keys)
            {
                EnvironmentTable.Remove(env);
            }

            try
            {
                string contents = ToString();
                string diskContents = string.Empty;
                diskContents = provider.Reader.ReadToEnd();

                if (diskContents != contents)
                {
                    provider.Writer.Write(contents);
                    provider.Writer.Flush();
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

        public AzureRmProfile Profile { get { return this; } }

        public bool TryAddContext(IAzureContext context, out string name)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            bool result = false;
            if (!TryFindContext(context, out name) && TryGetContextName(context, out name))
            {
                result = TryAddContext(name, context);
            }

            return result;
        }

        public bool TryAddContext(string name, IAzureContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            bool result = false;
            if (!Contexts.ContainsKey(name))
            {
                Contexts[name] = context;
                result = true;
            }

            return result;
        }

        public bool TryFindContext(IAzureContext context, out string name)
        {
            bool result = false;
            name = null;
            var foundContext = Contexts.FirstOrDefault((c) =>
                c.Value != null
                && (
                    (c.Value.Account != null && context.Account != null && string.Equals(c.Value.Account.Id, context.Account.Id, StringComparison.OrdinalIgnoreCase))
                    || (c.Value.Account == context.Account))
                && (
                    (c.Value.Tenant != null && context.Tenant != null && c.Value.Tenant.GetId() == context.Tenant.GetId())
                    || (c.Value.Tenant == context.Tenant))
                && (
                    (c.Value.Subscription != null && context.Subscription != null && c.Value.Subscription.GetId() == context.Subscription.GetId())
                    || (c.Value.Subscription == context.Subscription)));
            if (!string.IsNullOrEmpty(foundContext.Key))
            {
                name = foundContext.Key;
                result = true;
            }

            return result;
        }

        public bool TryGetContextName(IAzureContext context, out string name)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            bool result = false;
            name = null;
            if ((context.Account != null && !string.IsNullOrWhiteSpace(context.Account.Id)) || context.Subscription != null)
            {
                List<string> components = new List<string>();
                if (context.Account != null && !string.IsNullOrWhiteSpace(context.Account.Id))
                {
                    components.Add(context.Account.Id);
                }

                if (context.Subscription != null)
                {
                    components.Add(context.Subscription.GetId().ToString());
                }

                name = string.Format("[{0}]", string.Join(", ", components));
                result = true;
            }

            return result;
        }

        public bool TryRemoveContext(string name)
        {
            return Contexts.Remove(name);
        }

        public bool TryRenameContext(string sourceName, string targetName)
        {
            bool result = false;

            if (Contexts.ContainsKey(sourceName) && !Contexts.ContainsKey(targetName))
            {
                Contexts[targetName] = Contexts[sourceName];
                result = TryRemoveContext(sourceName);
            }

            return result;
        }

        public bool TrySetContext(string name, IAzureContext context)
        {
            bool result = false;
            if (Contexts.ContainsKey(name))
            {
                Contexts[name] = context;
                result = true;
            }

            return result;
        }

        public bool TrySetContext(IAzureContext context, out string name)
        {
            bool result = false;
            if (!TryFindContext(context, out name))
            {
                result = TryAddContext(context, out name);
            }

            return result;
        }

        public bool TrySetDefaultContext(string name)
        {
            bool result = false;
            if (Contexts.ContainsKey(name))
            {
                DefaultContextKey = name;
                result = true;
            }

            return result;
        }

        public bool TrySetDefaultContext(IAzureContext context)
        {
            bool result = false;
            string contextName;
            if (TryFindContext(context, out contextName) || TryAddContext(context, out contextName))
            {
                result = TrySetDefaultContext(contextName);
            }

            return result;
        }

        public bool TrySetEnvironment(IAzureEnvironment environment, out IAzureEnvironment mergedEnvironment)
        {
            bool result = false;
            mergedEnvironment = environment;
            if (environment != null && !AzureEnvironment.PublicEnvironments.ContainsKey(environment.Name))
            {

                if (Profile.EnvironmentTable.ContainsKey(environment.Name))
                {
                    mergedEnvironment = mergedEnvironment.Merge( Profile.EnvironmentTable[environment.Name]);
                }

                Profile.EnvironmentTable[environment.Name] = mergedEnvironment;
                result = true;
            }

            return result;
        }

        public bool HasEnvironment(string name)
        {
            return EnvironmentTable.ContainsKey(name);
        }

        public bool TryGetEnvironment(string name, out IAzureEnvironment environment)
        {
            bool result = false;
            environment = null;
            if (HasEnvironment(name))
            {
                environment = EnvironmentTable[name];
                result = true;
            }

            return result;
        }

        public bool TryRemoveEnvironment(string name, out IAzureEnvironment environment)
        {
            bool result = false;
            if (TryGetEnvironment(name, out environment))
            {
                result = EnvironmentTable.Remove(name);
            }

            return result;
        }

        public bool TryCopyProfile(AzureRmProfile other)
        {
            this.Clear();
            foreach (var environment in other.EnvironmentTable)
            {
                this.EnvironmentTable.Add(environment.Key, environment.Value);
            }

            foreach (var context in other.Contexts)
            {
                this.Contexts.Add(context.Key, context.Value);
            }

            this.CopyPropertiesFrom(other);
            return true;
        }

        public AzureRmProfile ToProfile()
        {
            return this;
        }

        protected virtual void Dispose( bool disposing)
        {
            // do nothing
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
