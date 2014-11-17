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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;
using Microsoft.WindowsAzure.Commands.Common.Properties;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common.Authentication
{
    /// <summary>
    /// Class that implements <see cref="System.Collections.Generic.IDictionary{String,String}"/>
    /// while storing the actual data in a Windows Registry hive.
    /// </summary>
    public class RegistryBackedDictionary : IDictionary<string, string>
    {
        private readonly RegistryKey rootKey;
        private readonly string hivePath;

        public RegistryBackedDictionary(RegistryKey rootKey, string hivePath)
        {
            this.rootKey = rootKey;
            this.hivePath = hivePath;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ICollection<string> Values
        {
            get
            {
                return this.Select(kvp => kvp.Value).ToList();
            }
        }

        public ICollection<string> Keys
        {
            get
            {
                return this.Select(kvp => kvp.Key).ToList();
            }
        }

        public string this[string key]
        {
            get
            {
                string value;
                TryGetValue(key, out value);
                return value;
            }
            set { AddOrOverwrite(new KeyValuePair<string, string>(key, value)); }
        }

        public bool TryGetValue(string key, out string value)
        {
            using (RegistryKey regKey = GetKey(false))
            {
                value = (string)regKey.GetValue(key);
                return value != null;
            }
        }

        public void Add(string key, string value)
        {
            Add(new KeyValuePair<string, string>(key, value));
        }

        public bool ContainsKey(string key)
        {
            EnsureNotNull("key", key);

            using (RegistryKey regKey = GetKey(false))
            {
                return regKey.GetValueNames().Any(k => string.Compare(k, key, StringComparison.OrdinalIgnoreCase) == 0);
            }
        }

        public bool Remove(string key)
        {
            EnsureNotNull("key", key);

            return Remove(new KeyValuePair<string, string>(key, null));
        }

        public bool IsReadOnly { get { return false; } }
        public int Count
        {
            get
            {
                using (RegistryKey regKey = GetKey(false))
                {
                    return regKey.ValueCount;
                }
            }
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            EnsureNotNull("item.key", item.Key);
            using (RegistryKey key = GetKey(true))
            {
                key.DeleteValue(item.Key, false);
                return true;
            }
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            using (RegistryKey regKey = GetKey(false))
            {
                var value = (string)regKey.GetValue(item.Key);
                if (value == null) return false;
                return string.Compare(item.Value, value, StringComparison.Ordinal) == 0;
            }
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("arrayIndex", Resources.DictionaryCopyToArrayIndexLessThanZero);
            }
            if (arrayIndex + Count > array.Length)
            {
                throw new ArgumentException(Resources.DictionaryCopyToArrayTooShort);
            }

            foreach (var kvp in this)
            {
                array[arrayIndex++] = kvp;
            }
        }

        public void Clear()
        {
            using (RegistryKey regKey = GetKey(true))
            {
                foreach (var value in regKey.GetValueNames())
                {
                    regKey.DeleteValue(value);
                }
            }
        }

        public void Add(KeyValuePair<string, string> item)
        {
            if (ContainsKey(item.Key))
            {
                throw new ArgumentException(Resources.DictionaryAddAlreadyContainsKey);
            }
            AddOrOverwrite(item);
        }

        private void AddOrOverwrite(KeyValuePair<string, string> item)
        {
            using (RegistryKey regKey = GetKey(true))
            {
                regKey.SetValue(item.Key, item.Value, RegistryValueKind.String);
            }
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            using (RegistryKey key = GetKey(false))
            {
                foreach (string valueName in key.GetValueNames())
                {
                    yield return new KeyValuePair<string, string>(valueName, (string) key.GetValue(valueName));
                }
            }
        }

        private RegistryKey GetKey(bool forWriting)
        {
            RegistryKeyPermissionCheck permissions = forWriting
                ? RegistryKeyPermissionCheck.ReadWriteSubTree
                : RegistryKeyPermissionCheck.Default;

            RegistryKey key = rootKey.OpenSubKey(hivePath, permissions) ??
                rootKey.CreateSubKey(hivePath, permissions);

            return key;
        }

        // ReSharper disable UnusedParameter.Local
        private static void EnsureNotNull(string paramName, string value)
        // ReSharper restore UnusedParameter.Local
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }         
    }
}
