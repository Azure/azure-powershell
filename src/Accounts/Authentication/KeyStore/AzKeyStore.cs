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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public class AzKeyStore : IDisposable
    {
        public const string Name = "AzKeyStore";

        internal class KeyStoreElement
        {
            public string keyType;
            public string keyStoreKey;
            public string valueType;
            public string keyStoreValue;
        }

        private static IDictionary<Type, string> _typeNameMap = new ConcurrentDictionary<Type, string>();

        private static IDictionary<string, JsonConverter> _elementConverterMap = new ConcurrentDictionary<string, JsonConverter>();

        public static void RegisterJsonConverter(Type type, string typeName, JsonConverter converter = null)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                throw new ArgumentNullException($"typeName cannot be empty.");
            }
            if (_typeNameMap.ContainsKey(type))
            {
                if (string.Compare(_typeNameMap[type], typeName) != 0)
                {
                    throw new ArgumentException($"{typeName} has conflict with {_typeNameMap[type]} with reference to {type}.");
                }
            }
            else
            {
                _typeNameMap[type] = typeName;
            }
            if (converter != null)
            {
                _elementConverterMap[_typeNameMap[type]] = converter;
            }
        }

        private IDictionary<IKeyStoreKey, Object> _credentials = new ConcurrentDictionary<IKeyStoreKey, Object>();
        private IStorage _storage = null;

        private bool autoSave = true;
        private Exception lastError = null;

        public IStorage Storage
        {
            get => _storage;
            set => _storage = value;
        }

        public bool IsProtected
        {
            get => Storage.IsProtected;
        }

        public AzKeyStore()
        {

        }

        public AzKeyStore(string directory, string fileName, bool loadStorage = true, bool autoSaveEnabled = true, IStorage inputStorage = null)
        {
            autoSave = autoSaveEnabled;
            Storage = inputStorage ?? new StorageWrapper()
            {
                FileName = fileName,
                Directory = directory
            };
            Storage.Create();

            if (loadStorage&&!LoadStorage())
            {
                throw new InvalidOperationException("Failed to load keystore from storage.");
            }
        }

        private object Deserialize(string typeName, string value)
        {
            Type t = null;
            t = _typeNameMap.FirstOrDefault(item => item.Value == typeName).Key;

            if (t != null)
            {
                if (_elementConverterMap.ContainsKey(typeName))
                {
                    return JsonConvert.DeserializeObject(value, t, _elementConverterMap[typeName]);
                }
                else
                {
                    return JsonConvert.DeserializeObject(value, t);
                }
            }
            return null;
        }

        public bool LoadStorage()
        {
            try
            {
                var data = Storage.ReadData();
                if (data != null && data.Length > 0)
                {
                    var rawJsonString = Encoding.UTF8.GetString(data);
                    var serializableKeyStore = JsonConvert.DeserializeObject(rawJsonString, typeof(List<KeyStoreElement>)) as List<KeyStoreElement>;
                    if (serializableKeyStore != null)
                    {
                        foreach (var item in serializableKeyStore)
                        {
                            IKeyStoreKey keyStoreKey = Deserialize(item.keyType, item.keyStoreKey) as IKeyStoreKey;
                            if (keyStoreKey == null)
                            {
                                throw new ArgumentException($"Cannot parse the keystore {item.keyStoreKey} with the type {item.keyType}.");
                            }
                            var keyStoreValue = Deserialize(item.valueType, item.keyStoreValue);
                            if (keyStoreValue == null)
                            {
                                throw new ArgumentException($"Cannot parse the keystore {item.keyStoreValue} with the type {item.valueType}.");
                            }
                            _credentials[keyStoreKey] = keyStoreValue;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                lastError = e;
                return false;
            }
            return true;
        }

        public void ClearCache()
        {
            _credentials.Clear();
        }

        public void Clear()
        {
            ClearCache();
            Storage.Clear();
        }

        public void Flush()
        {
            IList<KeyStoreElement> serializableKeyStore = new List<KeyStoreElement>();
            foreach (var item in _credentials)
            {
                var keyType = _typeNameMap[item.Key.GetType()];
                var key = _elementConverterMap.ContainsKey(keyType) ?
                      JsonConvert.SerializeObject(item.Key, _elementConverterMap[keyType]) : JsonConvert.SerializeObject(item.Key);
                if (!string.IsNullOrEmpty(key))
                {
                    var valueType = _typeNameMap[item.Value.GetType()];
                    serializableKeyStore.Add(new KeyStoreElement()
                    {
                        keyType = keyType,
                        keyStoreKey = key,
                        valueType = valueType,
                        keyStoreValue = _elementConverterMap.ContainsKey(valueType) ?
                                        JsonConvert.SerializeObject(item.Value, _elementConverterMap[valueType]) : JsonConvert.SerializeObject(item.Value),
                    }) ;
                }
            }
            var JsonString = JsonConvert.SerializeObject(serializableKeyStore);
            Storage.WriteData(Encoding.UTF8.GetBytes(JsonString));
        }

        public void Dispose()
        {
            if (autoSave)
            {
                Flush();
            }
            ClearCache();
        }

        public void SaveKey<T>(IKeyStoreKey key, T value)
        {
            if (!_typeNameMap.ContainsKey(key.GetType()) || !_typeNameMap.ContainsKey(value.GetType()))
            {
                throw new InvalidOperationException("Please register key & values type before save it.");
            }
            _credentials[key] = value;
        }

        public T GetKey<T>(IKeyStoreKey key)
        {
            if (!_credentials.ContainsKey(key))
            {
                throw new ArgumentException($"{key.ToString()} is not stored in AzKeyStore yet.");
            }
            return (T)_credentials[key];
        }

        public bool DeleteKey(IKeyStoreKey key)
        {
            return _credentials.Remove(key);
        }

        public void EnableAutoSaving()
        {
            autoSave = true;
        }

        public void DisableAutoSaving()
        {
            autoSave = false;
        }

        public Exception GetLastError()
        {
            return lastError;
        }
    }
}
