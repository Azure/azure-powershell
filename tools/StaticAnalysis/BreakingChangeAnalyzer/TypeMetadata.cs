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

using System;
using System.Collections.Generic;

namespace StaticAnalysis.BreakingChangeAnalyzer
{
    /// <summary>
    /// Encapsulates the important information about a type without requiring the assembly containing the
    /// type to be loaded. Used for transferring type metadat across AppDomain boundaries.
    /// </summary>
    [Serializable]
    public class TypeMetadata
    {
        /// <summary>
        /// Allow easy conversion between types and type metadata objects.
        /// </summary>
        /// <param name="typeToProcess"></param>
        /// <returns>The capture type metadata</returns>
        public static implicit operator TypeMetadata(Type typeToProcess)
        {
            return new TypeMetadata(typeToProcess);
        }

        public TypeMetadata()
        {

        }

        public TypeMetadata(Type inputType)
        {
            Namespace = inputType.Namespace;
            Name = inputType.Name;
            AssemblyQualifiedName = inputType.AssemblyQualifiedName;

            Properties = new SerializableMap<string, string>();

            var properties = inputType.GetProperties();
            foreach (var property in properties)
            {
                bool found = false;

                foreach (var key in Properties.Keys)
                {
                    if (property.Name.Equals(key))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Properties.Put(property.Name, property.PropertyType.ToString());
                }
            }
        }

        public string Namespace { get; set; }
        public string Name { get; set; }
        public string AssemblyQualifiedName { get; set; }
        public SerializableMap<string, string> Properties { get; set; }

    }

    [Serializable]
    public class SerializableMap<K, V>
    {
        private List<K> _keys = new List<K>();
        private List<Pair<K, V>> _pairs = new List<Pair<K, V>>();

        public List<K> Keys { get { return _keys; } }
        public List<Pair<K, V>> Pairs { get { return _pairs; } }

        public V Get(K key)
        {
            foreach (var pair in _pairs)
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }

            return default(V);
        }

        public void Put(K key, V value)
        {
            foreach (var pair in _pairs)
            {
                if (pair.Key.Equals(key))
                {
                    pair.Value = value;
                    return;
                }
            }

            _pairs.Add(new Pair<K, V>
            {
                Key = key,
                Value = value
            });

            _keys.Add(key);
        }
    }

    [Serializable]
    public class Pair<E, T>
    {
        public E Key { get; set; }
        public T Value { get; set; }
    }
}
