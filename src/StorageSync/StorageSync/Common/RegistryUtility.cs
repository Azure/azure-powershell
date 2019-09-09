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

namespace Microsoft.Azure.Commands.StorageSync.Common
{
    using Microsoft.Win32;
    using System;

    /// <summary>
    /// Helper class for handling all registry related operations.
    /// </summary>
    public static class RegistryUtility
    {

        /// <summary>
        /// This function will read the key in the given registry path and returns the value to it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Registry key</param>
        /// <param name="path">Path</param>
        /// <param name="value">The value.</param>
        /// <param name="kind">The kind.</param>
        /// <param name="options">The options.</param>
        /// <param name="registryView">The registry view.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool TryGetValue<T>(string key, string path, out T value, RegistryValueKind kind, RegistryValueOptions options = RegistryValueOptions.None, RegistryView registryView = RegistryView.Default)
        {
            
            var success = true;
            value = default(T);
            try
            {
                using (var view = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
                {
                    using (var registryKey = view.OpenSubKey(path))
                    {
                        if (registryKey != null)
                        {
                            object registryValue = registryKey.GetValue(key, null, options);

                            if (registryValue != null)
                            {
                                value = (T)Convert.ChangeType(registryValue, typeof(T));
                            }
                            else
                            {
                                success = false;
                            }
                        }
                        else
                        {
                            success = false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                value = default(T);
                success = false;
            }

            return success;
        }

        /// <summary>
        /// This function writes into registry.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="path">Path</param>
        /// <param name="value">Value to write</param>
        /// <param name="kind">Registry Value Kind</param>
        /// <param name="throwException">Whether to throw exception or not.</param>
        public static void WriteValue(string key, string path, object value, RegistryValueKind kind, bool throwException = true)
        {
            try
            {
                using (var registryKey = Registry.LocalMachine.CreateSubKey(path))
                {
                    if (registryKey != null)
                    {
                        registryKey.SetValue(key, value, kind);
                    }
                }
            }
            catch (Exception) when (!throwException)
            {
                // Absorb the exception when input parameter throw exception is false
            }
        }
    }
}