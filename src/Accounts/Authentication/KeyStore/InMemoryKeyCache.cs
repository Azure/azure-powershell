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
    internal class InMemoryKeyCache : IKeyCache
    {
        internal class KeyStoreElement
        {
            public string keyType;
            public string keyStoreKey;
            public string valueType;
            public string keyStoreValue;
        }

        private static IDictionary<Type, string> _typeNameMap = new ConcurrentDictionary<Type, string>();

        private static IDictionary<string, JsonConverter> _elementConverterMap = new ConcurrentDictionary<string, JsonConverter>();

        private IDictionary<IKeyStoreKey, Object> _credentials = new ConcurrentDictionary<IKeyStoreKey, Object>();

        private readonly object lockObj = new object();

        internal KeyStoreCallbak BeforeAccess = null;

        internal KeyStoreCallbak OnUpdate = null;

        public void SaveKey<T>(IKeyStoreKey key, T value)
        {
            var args = new KeyStoreNotificationArgs()
            {
                KeyCache = this
            };
            BeforeAccess?.Invoke(args) ;
            if (!_typeNameMap.ContainsKey(key.GetType()) || !_typeNameMap.ContainsKey(value.GetType()))
            {
                throw new InvalidOperationException("Please register key & values type before save it.");
            }
            _credentials[key] = value;
            OnUpdate?.Invoke(args);
        }

        public T GetKey<T>(IKeyStoreKey key)
        {
            var args = new KeyStoreNotificationArgs()
            {
                KeyCache = this
            };
            BeforeAccess?.Invoke(args);

            object value = null;
            if ( _credentials.TryGetValue(key, out value))
            {
                return (T) value;
            }

            try
            {
                var fallBackKey = _credentials.Keys.First(x => x.BeEquivalent(key));
                return (T)_credentials[fallBackKey];
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException($"{key.ToString()} is not stored in AzKeyStore yet.");
            }
        }

        public bool DeleteKey(IKeyStoreKey key)
        {
            var args = new KeyStoreNotificationArgs()
            {
                KeyCache = this
            };
            BeforeAccess?.Invoke(args);
            bool ret = false;
            ret = _credentials.Remove(key);
            OnUpdate?.Invoke(args);
            return ret;
        }

        public void Deserialize(byte[] data, bool shouldClearExistingCache)
        {
            lock(lockObj)
            {
                if (shouldClearExistingCache)
                {
                    _credentials.Clear();
                }
                if (data != null && data.Length > 0)
                {
                    var rawJsonString = Encoding.UTF8.GetString(data);
                    var serializableKeyStore = JsonConvert.DeserializeObject(rawJsonString, typeof(List<KeyStoreElement>)) as List<KeyStoreElement>;
                    if (serializableKeyStore != null)
                    {
                        foreach (var item in serializableKeyStore)
                        {
                            IKeyStoreKey keyStoreKey = DeserializeItem(item.keyType, item.keyStoreKey) as IKeyStoreKey;
                            if (keyStoreKey == null)
                            {
                                throw new ArgumentException($"Cannot parse the keystore {item.keyStoreKey} with the type {item.keyType}.");
                            }
                            var keyStoreValue = DeserializeItem(item.valueType, item.keyStoreValue);
                            if (keyStoreValue == null)
                            {
                                throw new ArgumentException($"Cannot parse the keystore {item.keyStoreValue} with the type {item.valueType}.");
                            }
                            _credentials[keyStoreKey] = keyStoreValue;
                        }
                    }
                }
            }
        }

        public byte[] Serialize()
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
                    });
                }
            }
            var JsonString = JsonConvert.SerializeObject(serializableKeyStore);
            return Encoding.UTF8.GetBytes(JsonString);
        }

        public void Clear()
        {
            var args = new KeyStoreNotificationArgs()
            {
                KeyCache = this
            };
            BeforeAccess?.Invoke(args);
            _credentials.Clear();
            OnUpdate?.Invoke(args);

        }

        private static object DeserializeItem(string typeName, string value)
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

        public void SetBeforeAccess(KeyStoreCallbak beforeAccess)
        {
            BeforeAccess = beforeAccess;
        }

        public void SetOnUpdate(KeyStoreCallbak onUpdate)
        {
            OnUpdate = onUpdate;
        }
    }
}
