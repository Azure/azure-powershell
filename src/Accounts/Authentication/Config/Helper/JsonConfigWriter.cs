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

using Microsoft.Azure.Commands.Common.Authentication.Config.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    /// <summary>
    /// Helper for updating the config JSON file.
    /// </summary>
    internal class JsonConfigWriter
    {
        private readonly string _jsonConfigPath;
        private readonly IDataStore _dataStore;

        public JsonConfigWriter(string jsonConfigPath, IDataStore dataStore)
        {
            _jsonConfigPath = jsonConfigPath;
            _dataStore = dataStore;
        }

        /// <summary>
        /// Update a config value.
        /// </summary>
        /// <param name="key">The full path of the config.</param>
        /// <param name="value">The value to update.</param>
        internal void Update(string key, object value) => TryUpdate(key, true, (JObject parent, string propertyName) =>
        {
            var prop = parent.Property(propertyName);

            if (prop == null)
            {
                prop = new JProperty(propertyName, value);

                parent.Add(prop);
            }
            else
            {
                prop.Value = IsMultiContent(value) ? new JArray(value) : JToken.FromObject(value);
            }
        });

        private bool IsMultiContent(object value)
        {
            return value is Array;
        }

        /// <summary>
        /// Locates the node by key in the JSON object, and performs a general update (add, modify or remove a property).
        /// </summary>
        /// <param name="key">The full path to the config.</param>
        /// <param name="createWhenNotExist">Whether to create the JSON node when part of the path is missing.</param>
        /// <param name="updateAction">The concrete action to perform. First argument is the parent node in the JSON object, second is the name of the property to update.</param>
        /// <returns>Whether the update is successful.</returns>
        private bool TryUpdate(string key, bool createWhenNotExist, Action<JObject, string> updateAction)
        {
            string json = _dataStore.ReadFileAsText(_jsonConfigPath);
            JObject root = JObject.Parse(json);

            string[] segments = key.Split(ConfigurationPath.KeyDelimiter.ToCharArray());
            JObject parent = LocateParentNode(root, segments, createWhenNotExist);
            if (parent == null)
            {
                return false;
            }

            string propertyName = segments[segments.Length - 1];

            updateAction(parent, propertyName);

            // hack: to avoid last version of the config remaining in the file, empty it first
            _dataStore.WriteFile(_jsonConfigPath, string.Empty);

            JsonSerializer serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };
            using (Stream fs = _dataStore.OpenForExclusiveWrite(_jsonConfigPath))
            using (StreamWriter sw = new StreamWriter(fs))
            using (var writer = new JsonTextWriter(sw) { Indentation = 4 })
            {
                serializer.Serialize(writer, root);
            }

            return true;
        }

        private static JObject LocateParentNode(JObject root, string[] segments, bool createWhenNotExist)
        {
            JObject node = root;
            for (int i = 0; i < segments.Length - 1; ++i)
            {
                string segment = segments[i];
                // JObject.TryGetValue() supports case insensitivity
                // otherwise we might get duplicated keys with different casing in the config file
                if (node.TryGetValue(segment, StringComparison.OrdinalIgnoreCase, out JToken match))
                {
                    node = (JObject)match;
                }
                else
                {
                    if (createWhenNotExist)
                    {
                        node[segment] = new JObject();
                        node = (JObject)node[segment];
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return node;
        }

        /// <summary>
        /// Clear a config by key.
        /// </summary>
        /// <param name="key">The full path to the config.</param>
        internal void Clear(string key) => TryUpdate(key, false, (parent, propertyName) =>
        {
            if (parent.Property(propertyName) != null)
            {
                parent.Remove(propertyName);
            }
            // if the config is never set, there's no need to clear.
        });

        /// <summary>
        /// Clear all the configs.
        /// </summary>
        internal void ClearAll()
        {
            _dataStore.WriteFile(_jsonConfigPath, @"{}");
        }
    }
}
