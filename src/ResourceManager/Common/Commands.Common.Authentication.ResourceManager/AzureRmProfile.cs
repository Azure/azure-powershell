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
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Xml.Serialization;
using Microsoft.Azure.Commands.ResourceManager.Common.Serialization;
using System.Collections.Concurrent;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;

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
                if (!string.IsNullOrEmpty(DefaultContextKey) && Contexts != null && Contexts.ContainsKey(DefaultContextKey))
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
            var session = AzureSession.Instance;
            var store = session.DataStore;
            if (!store.DirectoryExists(session.ProfileDirectory))
            {
                store.CreateDirectory(session.ProfileDirectory);
            }

            if (!store.DirectoryExists(session.ARMProfileDirectory))
            {
                store.CreateDirectory(session.ARMProfileDirectory);
            }

            if (store.FileExists(ProfilePath))
            {
                string contents = GetJsonText(store.ReadFileAsText(ProfilePath));
                LegacyAzureRmProfile oldProfile;
                AzureRmProfile profile = null;
                if ((SafeDeserializeObject<LegacyAzureRmProfile>(contents, out oldProfile)
                     && oldProfile.TryConvert(out profile))
                    || SafeDeserializeObject<AzureRmProfile>(contents, out profile, new AzureRmProfileConverter()))
                {
                    Initialize(profile);
                }
            }
        }

        private void Load(IFileProvider provider)
        {
            this.ProfilePath = provider.FilePath;
            string contents = provider.CreateReader().ReadToEnd();
            LegacyAzureRmProfile oldProfile;
            AzureRmProfile profile = null;
            if (!(SafeDeserializeObject<LegacyAzureRmProfile>(contents, out oldProfile)
                && oldProfile.TryConvert(out profile))
                && !SafeDeserializeObject<AzureRmProfile>(contents, out profile, new AzureRmProfileConverter(false)))
            {
                return;
            }

            Initialize(profile);
        }

        bool SafeDeserializeObject<T>(string serialization, out T result, JsonConverter converter = null)
        {
            result = default(T);
            bool success = false;
            try
            {
                result = converter == null? JsonConvert.DeserializeObject<T>(serialization) : JsonConvert.DeserializeObject<T>(serialization, converter);
                success = true;
            }
            catch (JsonException)
            {

            }

            return success;
        }

        private void Initialize(AzureRmProfile profile)
        {
            EnvironmentTable.Clear();
            // Adding predefined environments
            foreach (var env in AzureEnvironment.PublicEnvironments)
            {
                EnvironmentTable[env.Key] = env.Value;
            }

            Contexts.Clear();
            DefaultContextKey = "Default";
            if (profile != null)
            {
                foreach (var environment in profile.EnvironmentTable)
                {
                    EnvironmentTable[environment.Key] = environment.Value;
                }

                foreach (var context in profile.Contexts)
                {
                    context.Value.TokenCache = AzureSession.Instance.TokenCache;
                    this.Contexts.Add(context.Key, context.Value);
                }

                DefaultContextKey = profile.DefaultContextKey ?? "Default";
            }
        }

        private void LoadImpl(string contents)
        {
        }


        /// <summary>
        /// Creates new instance of AzureRMProfile.
        /// </summary>
        public AzureRmProfile()
        {
            EnvironmentTable = new ConcurrentDictionary<string, IAzureEnvironment>(StringComparer.CurrentCultureIgnoreCase);

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
        public void Save(IFileProvider provider, bool serializeCache = true)
        {
            foreach (string env in AzureEnvironment.PublicEnvironments.Keys)
            {
                EnvironmentTable.Remove(env);
            }

            try
            {
                string contents = ToString(serializeCache);
                string diskContents = string.Empty;
                diskContents = provider.CreateReader().ReadToEnd();

                if (diskContents != contents)
                {
                    var writer = provider.CreateWriter();
                    writer.Write(contents);
                    writer.Flush();

                    // When writing to a stream, ensure that the file is truncated
                    // so that previous data is overwritten
                    provider.Stream.SetLength(provider.Stream.Position);
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
        /// <returns>The serialization of the Profile.</returns>
        public override string ToString()
        {
            return ToString(true);
        }

        /// <summary>
        /// Serializes the current profile, including or not including the token cache
        /// </summary>
        /// <param name="serializeCache">true if the TokenCache should be serialized, false otherwise</param>
        /// <returns>The serialization of the Profile</returns>
        public string ToString(bool serializeCache)
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new AzureRmProfileConverter(serializeCache));
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
            if (context != null)
            {
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
            }

            return result;
        }

        public bool TryGetContextName(IAzureContext context, out string name)
        {
            bool result = false;
            name = null;
            if (context != null)
            {

                if (context.Subscription != null)
                {
                    name = string.Format("{0} - {1}", context.Subscription.Name, context.Subscription.Id);
                    result = true;
                }
                else
                {
                    name = "Default";
                    result = true;
                }
            }

            return result;
        }

        public bool TryRemoveContext(string name)
        {
            bool result = Contexts.Remove(name);
            if (string.Equals(name, DefaultContextKey))
            {
                DefaultContextKey = Contexts.Keys.FirstOrDefault() ?? "Default";
            }

            return result;
        }

        public bool TryRenameContext(string sourceName, string targetName)
        {
            bool result = false;

            if (Contexts.ContainsKey(sourceName) && !Contexts.ContainsKey(targetName))
            {
                Contexts[targetName] = Contexts[sourceName];
                if (string.Equals(sourceName, DefaultContextKey, StringComparison.OrdinalIgnoreCase))
                {
                    DefaultContextKey = targetName;
                }

                result = TryRemoveContext(sourceName);
            }

            return result;
        }

        public bool TrySetContext(string name, IAzureContext context)
        {
            bool result = false;
            if (Contexts!= null)
            {
                Contexts[name] = context;
                result = true;
            }

            return result;
        }

        public bool TrySetContext(IAzureContext context, out string name)
        {
            bool result = false;
            if (TryFindContext(context, out name) && Contexts != null && Contexts.ContainsKey(name))
            {
                Contexts[name].Update(context);
                result = true;
            }
            else
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

            if (context != null && (TryFindContext(context, out contextName) || TryAddContext(context, out contextName)))
            {
                if (TrySetDefaultContext(contextName) && DefaultContext != null)
                {
                    DefaultContext.Update(context);
                    result = true;
                }
            }

            return result;
        }

        public bool TrySetDefaultContext(string name, IAzureContext context)
        {
            bool result = false;
            if (context != null)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    result = TrySetDefaultContext(context);
                }
                else if (TrySetContext(name, context))
                {
                    result = TrySetDefaultContext(name);
                }
            }

            return result;
        }

        public bool TrySetEnvironment(IAzureEnvironment environment, out IAzureEnvironment mergedEnvironment)
        {
            bool result = false;
            mergedEnvironment = environment;
            if (environment != null && !AzureEnvironment.PublicEnvironments.ContainsKey(environment.Name))
            {

                if (EnvironmentTable.ContainsKey(environment.Name))
                {
                    mergedEnvironment = mergedEnvironment.Merge( EnvironmentTable[environment.Name]);
                }

                EnvironmentTable[environment.Name] = mergedEnvironment;
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
            foreach (var environment in other.EnvironmentTable.Where((e) => !AzureEnvironment.PublicEnvironments.ContainsKey(e.Key)))
            {
                this.EnvironmentTable.Add(environment.Key, environment.Value);
            }

            foreach (var context in other.Contexts)
            {
                TrySetContext(context.Key, context.Value);
            }

            if (other.DefaultContext != null)
            {
                this.TrySetDefaultContext(other.DefaultContext);
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

        static string GetJsonText(string text)
        {
            string result = string.Empty;
            if (text != null)
            {
                int i = text.IndexOf('{');

                if ( i >= 0 && i < text.Length)
                {
                    result = text.Substring(i);
                }
            }

            return result;
        }
    }
}
