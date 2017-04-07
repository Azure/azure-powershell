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
        /// <summary>
        /// Gets Azure Accounts
        /// </summary>
        public Dictionary<string, AzureAccount> Accounts { get; set; }

        /// <summary>
        /// Gets Azure Subscriptions
        /// </summary>
        public Dictionary<Guid, AzureSubscription> Subscriptions { get; set; }

        /// <summary>
        /// Gets or sets current Azure Subscription
        /// </summary>
        public AzureSubscription DefaultSubscription
        {
            get
            {
                return Subscriptions.Values.FirstOrDefault(
                    s => s.Properties.ContainsKey(AzureSubscription.Property.Default));
            }

            set
            {
                if (value == null)
                {
                    foreach (var subscription in Subscriptions.Values)
                    {
                        subscription.SetProperty(AzureSubscription.Property.Default, null);
                    }
                }
                else if (Subscriptions.ContainsKey(value.Id))
                {
                    foreach (var subscription in Subscriptions.Values)
                    {
                        subscription.SetProperty(AzureSubscription.Property.Default, null);
                    }

                    Subscriptions[value.Id].Properties[AzureSubscription.Property.Default] = "True";
                    value.Properties[AzureSubscription.Property.Default] = "True";
                }
            }
        }

        /// <summary>
        /// Gets Azure Environments
        /// </summary>
        public Dictionary<string, AzureEnvironment> Environments { get; set; }

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
                    if (DefaultSubscription.Account != null &&
                        Accounts.ContainsKey(DefaultSubscription.Account))
                    {
                        account = Accounts[DefaultSubscription.Account];
                    }
                    else
                    {
                        TracingAdapter.Information(Resources.NoAccountInContext, DefaultSubscription.Account, DefaultSubscription.Id);
                    }

                    if (DefaultSubscription.Environment != null &&
                        Environments.ContainsKey(DefaultSubscription.Environment))
                    {
                        environment = Environments[DefaultSubscription.Environment];
                    }
                    else
                    {
                        TracingAdapter.Information(Resources.NoEnvironmentInContext, DefaultSubscription.Environment, DefaultSubscription.Id);
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

        public AzureContext DefaultContext
        {
            get
            {
                return Context;
            }

            set
            {
                Context = value;
            }
        }

        IEnumerable<Abstractions.AzureEnvironment> IAzureContextContainer.Environments
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public AuthenticationStore TokenStore
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IDictionary<string, string> ExtendedProperties
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<string> Keys
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<Abstractions.AzureContext> Values
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Abstractions.AzureContext this[string key]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Initializes a new instance of AzureSMProfile
        /// </summary>
        public AzureSMProfile()
        {
            Environments = new Dictionary<string, AzureEnvironment>(StringComparer.InvariantCultureIgnoreCase);
            Subscriptions = new Dictionary<Guid, AzureSubscription>();
            Accounts = new Dictionary<string, AzureAccount>(StringComparer.InvariantCultureIgnoreCase);

            // Adding predefined environments
            foreach (AzureEnvironment env in AzureEnvironment.PublicEnvironments.Values)
            {
                Environments[env.Name] = env;
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
                Environments.Remove(env);
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
                    Environments[env.Name] = env;
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
            throw new NotImplementedException();
        }

        public void Add(string key, Abstractions.AzureContext value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, out Abstractions.AzureContext value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<string, Abstractions.AzureContext> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<string, Abstractions.AzureContext> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<string, Abstractions.AzureContext>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, Abstractions.AzureContext> item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, Abstractions.AzureContext>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
