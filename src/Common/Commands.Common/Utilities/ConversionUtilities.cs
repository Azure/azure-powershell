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
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Common
{
    public static class ConversionUtilities
    {
        public static Dictionary<string, object> ToDictionary(this Hashtable hashtable,
            bool addValueLayer)
        {
            if (hashtable == null)
            {
                return null;
            }
            else
            {
                var dictionary = new Dictionary<string, object>();
                foreach (var entry in hashtable.Cast<DictionaryEntry>())
                {
                    var valueAsHashtable = entry.Value as Hashtable;

                    if (valueAsHashtable != null)
                    {
                        dictionary[(string)entry.Key] =
                            valueAsHashtable.ToDictionary(addValueLayer);
                    }
                    else
                    {
                        object value = entry.Value;

                        if (entry.Value is SecureString)
                        {
                            value = SecureStringToString(entry.Value as SecureString);
                        }

                        if (addValueLayer)
                        {
                            dictionary[(string)entry.Key] = new Hashtable { { "value", value } };
                        }
                        else
                        {
                            dictionary[(string)entry.Key] = value;
                        }
                    }
                }
                return dictionary;
            }
        }

        public static Hashtable ToHashtable<TV>(this IDictionary<string, TV> dictionary)
        {
            if (dictionary == null)
            {
                return null;
            }
            else
            {
                return new Hashtable((Dictionary<string, TV>)dictionary);
            }
        }

        /// <summary>
        /// Convert the given array into string.
        /// </summary>
        /// <typeparam name="T">The type of the object array is holding</typeparam>
        /// <param name="array">The collection</param>
        /// <param name="delimiter">The used delimiter between array elements</param>
        /// <returns>The array into string representation</returns>
        public static string ArrayToString<T>(this T[] array, string delimiter)
        {
            return (array == null) ? null : (array.Length == 0) ? String.Empty
                : array.Skip(1).Aggregate(new StringBuilder(array[0].ToString()),
                (s, i) => s.Append(delimiter).Append(i), s => s.ToString());
        }

        public static string SecureStringToString(SecureString secureString)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
    }
}
