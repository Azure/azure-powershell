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

namespace NetCorePsd1Sync.Utility
{
    internal static class HashtableExtensions
    {
        public static string GetValueAsString(this Hashtable hashtable, string key) => GetValueAsStringOrDefault(hashtable, key) ?? String.Empty;

        public static string GetValueAsStringOrDefault(this Hashtable hashtable, string key) => hashtable[key]?.ToString();

        public static Version GetValueAsVersion(this Hashtable hashtable, string key) => GetValueAsVersionOrDefault(hashtable, key) ?? new Version();

        public static Version GetValueAsVersionOrDefault(this Hashtable hashtable, string key)
        {
            var valueAsString = GetValueAsStringOrDefault(hashtable, key);
            if (valueAsString == null || !Version.TryParse(valueAsString, out var version)) return null;
            return version;
        }

        public static object[] GetValueAsArray(this Hashtable hashtable, string key) => GetValueAsArrayOrDefault(hashtable, key) ?? new object[]{};

        public static object[] GetValueAsArrayOrDefault(this Hashtable hashtable, string key) => hashtable[key] as object[];

        public static Hashtable GetValueAsHashtable(this Hashtable hashtable, string key) => hashtable[key] as Hashtable ?? new Hashtable();

        public static List<string> GetValueAsStringList(this Hashtable hashtable, string key) => GetValueAsStringListOrDefault(hashtable, key) ?? new List<string>();

        public static List<string> GetValueAsStringListOrDefault(this Hashtable hashtable, string key)
        {
            if (hashtable[key] is string stringValue)
            {
                return new List<string> { stringValue };
            }
            return hashtable.GetValueAsArrayOrDefault(key)?.OfType<string>().ToList();
        }

        public static bool Any(this Hashtable hashtable) => hashtable.Count > 0;
    }
}
