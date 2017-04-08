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

using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Microsoft.Azure.Commands.Common.Authentication.Models
{
    /// <summary>
    /// Represents Azure profile structure with multiple environments, subscriptions, and accounts.
    /// </summary>
    [Serializable]
    public sealed class AzureSMProfile : IAzureContextContainer
    {
        Dictionary<string, AzureContext> _contexts = new Dictionary<string, AzureContext>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        /// Gets Azure Accounts
        /// </summary>
        public Dictionary<string, AzureAccount> AccountTable { get; set; }

        [JsonProperty(PropertyName="Subscriptions")]
        /// <summary>
        /// Gets Azure Subscriptions
        /// </summary>
        public Dictionary<Guid, AzureSubscription> SubscriptionTable { get; set; }

        [JsonIgnore]
        public IEnumerable<AzureSubscription> Subscriptions
        {
            get
            {
                return SubscriptionTable.Values;
            }
        }
        /// <summary>
        /// Gets or sets current Azure Subscription
        /// </summary>
        public AzureSubscription DefaultSubscription
        {
            get
            {
                return SubscriptionTable.Values.FirstOrDefault(
                    s => s.ExtendedProperties.ContainsKey(AzureSubscription.Property.Default));
            }

            set
            {
                if (value == null)
                {
                    foreach (var subscription in SubscriptionTable.Values)
                    {
                        subscription.SetProperty(AzureSubscription.Property.Default, null);
                    }
                }
                else
                {
                    var subscriptionGuid = Guid.Parse(value.Id);
                    if (SubscriptionTable.ContainsKey(subscriptionGuid))
                    {
                        foreach (var subscription in SubscriptionTable.Values)
                        {
                            subscription.SetProperty(AzureSubscription.Property.Default, null);
                        }

                        SubscriptionTable[subscriptionGuid].ExtendedProperties[AzureSubscription.Property.Default] = "True";
                        value.ExtendedProperties[AzureSubscription.Property.Default] = "True";
                    }
                }
            }
        }

        /// <summary>
        /// Gets Azure Environments
        /// </summary>
        [JsonProperty(PropertyName ="Environments")]
        public Dictionary<string, AzureEnvironment> EnvironmentTable { get; set; }

        /// <summary>
        /// Gets the default azure context object.
        /// </summary>
        [JsonIgnore]
        public AzureContext Context
        {
            get
            {
                var context = new AzureContext(null, null, null, null);

                if (DefaultSubscription != null)
                {
                    AzureAccount account = null;
                    AzureEnvironment environment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
                    var subscriptionAccount = DefaultSubscription.GetProperty(AzureSubscription.Property.Account);
                    if (subscriptionAccount != null &&
                        AccountTable.ContainsKey(subscriptionAccount))
                    {
                        account = AccountTable[subscriptionAccount];
                    }
                    else
                    {
                        TracingAdapter.Information(Resources.NoAccountInContext, subscriptionAccount, DefaultSubscription.Id);
                    }

                    var subscriptionEnvironment = DefaultSubscription.ExtendedProperties[AzureSubscription.Property.Environment];

                    if (subscriptionEnvironment != null &&
                        EnvironmentTable.ContainsKey(subscriptionEnvironment))
                    {
                        environment = EnvironmentTable[subscriptionEnvironment];
                    }
                    else
                    {
                        TracingAdapter.Information(Resources.NoEnvironmentInContext, subscriptionEnvironment, DefaultSubscription.Id);
                    }

                    context = new AzureContext(DefaultSubscription, account, environment);
                }

                return context;
            }
        }

        /// <summary>
        /// Gets errors from loading the profile.
        /// </summary>
        public List<string> ProfileLoadErrors { get; private set; }

        /// <summary>
        /// Location of the profile file. 
        /// </summary>
        public string ProfilePath { get; private set; }

        [JsonIgnore]
        public AzureContext DefaultContext
        {
            get
            {
                return Context;
            }

            set
            {
                // do nothing, we should not set the context through AzureSMProfile
            }
        }

        [JsonIgnore]
        IEnumerable<Abstractions.AzureEnvironment> IAzureContextContainer.Environments
        {
            get
            {
                return EnvironmentTable.Values;
            }
        }

        [JsonIgnore]
        public IAuthenticationStore TokenStore { get; set; } = new AuthenticationStore();

        [JsonIgnore]
        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        [JsonIgnore]
        public ICollection<string> Keys
        {
            get
            {
                return _contexts.Keys;
            }
        }

        [JsonIgnore]
        public ICollection<Abstractions.AzureContext> Values
        {
            get
            {
                return _contexts.Values;
            }
        }

        [JsonIgnore]
        public int Count
        {
            get
            {
                return _contexts.Count;
            }
        }

        [JsonIgnore]
        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        [JsonIgnore]
        public Abstractions.AzureContext this[string key]
        {
            get
            {
                return _contexts[key];
            }

            set
            {
                _contexts[key] = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of AzureSMProfile
        /// </summary>
        public AzureSMProfile()
        {
            EnvironmentTable = new Dictionary<string, AzureEnvironment>(StringComparer.InvariantCultureIgnoreCase);
            SubscriptionTable = new Dictionary<Guid, AzureSubscription>();
            AccountTable = new Dictionary<string, AzureAccount>(StringComparer.InvariantCultureIgnoreCase);

            // Adding predefined environments
            foreach (AzureEnvironment env in AzureEnvironment.PublicEnvironments.Values)
            {
                EnvironmentTable[env.Name] = env;
            }
        }

        /// <summary>
        /// Initializes a new instance of AzureSMProfile and loads its content from specified path.
        /// Any errors generated in the process are stored in ProfileLoadErrors collection.
        /// </summary>
        /// <param name="path">Location of profile file on disk.</param>
        public AzureSMProfile(string path) : this()
        {
            ProfilePath = path;
            ProfileLoadErrors = new List<string>();

            if (!AzureSession.Instance.DataStore.DirectoryExists(AzureSession.Instance.ProfileDirectory))
            {
                AzureSession.Instance.DataStore.CreateDirectory(AzureSession.Instance.ProfileDirectory);
            }

            if (AzureSession.Instance.DataStore.FileExists(ProfilePath))
            {
                string contents = AzureSession.Instance.DataStore.ReadFileAsText(ProfilePath);

                IProfileSerializer serializer;

                if (CloudException.IsXml(contents))
                {
                    serializer = new XmlProfileSerializer();
                    if (!serializer.Deserialize(contents, this))
                    {
                        ProfileLoadErrors.AddRange(serializer.DeserializeErrors);
                    }
                }
                else if (CloudException.IsJson(contents))
                {
                    serializer = new JsonProfileSerializer();
                    if (!serializer.Deserialize(contents, this))
                    {
                        ProfileLoadErrors.AddRange(serializer.DeserializeErrors);
                    }
                }
            }
        }

        /// <summary>
        /// Writes profile to a ProfilePath
        /// </summary>
        public void Save()
        {
            Save(ProfilePath);
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

        public override string ToString()
        {
            JsonProfileSerializer jsonSerializer = new JsonProfileSerializer();
            return jsonSerializer.Serialize(this);
        }

        public bool ContainsKey(string key)
        {
            return _contexts.ContainsKey(key);
        }

        public void Add(string key, Abstractions.AzureContext value)
        {
            _contexts.Add(key, value);
        }

        public bool Remove(string key)
        {
           return _contexts.Remove(key);
        }

        public bool TryGetValue(string key, out Abstractions.AzureContext value)
        {
            return _contexts.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<string, Abstractions.AzureContext> item)
        {
            if (item.Key != null && item.Value != null)
            {
                _contexts.Add(item.Key, item.Value);
            }
        }

        public void Clear()
        {
            _contexts.Clear();
        }

        public bool Contains(KeyValuePair<string, Abstractions.AzureContext> item)
        {
            return _contexts.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, Abstractions.AzureContext>[] array, int arrayIndex)
        {
            if (array != null && arrayIndex >= 0)
            {
                for (int i = arrayIndex; i < array.Length; ++i)
                {
                    _contexts.Add(array[i].Key, array[i].Value);
                }
            }
        }

        public bool Remove(KeyValuePair<string, Abstractions.AzureContext> item)
        {
            return _contexts.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<string, Abstractions.AzureContext>> GetEnumerator()
        {
           return  _contexts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _contexts.GetEnumerator();
        }
    }
}
