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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Azure.Commands.Batch.Track2
{
    /// <summary>
    /// Converts between the Track 1 enums the PS objects expose (Microsoft.Azure.Batch.Common) and Track 2's
    /// (Azure.Compute.Batch) text-based values. Names match ignoring case, "_" and "-" ("standard_lrs" = StandardLRS).
    /// </summary>
    internal static class Track2Enums
    {
        private static readonly ConcurrentDictionary<Type, IReadOnlyList<object>> KnownTrack2Values =
            new ConcurrentDictionary<Type, IReadOnlyList<object>>();

        /// <summary>
        /// Track 2 value -> Track 1 enum. Null for no value, or for a value the Track 1 enum doesn't have (a newer one).
        /// </summary>
        internal static TEnum? ToTrack1<TEnum>(object track2Value) where TEnum : struct, Enum
        {
            string value = track2Value?.ToString();
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            string normalized = Normalize(value);
            foreach (string name in Enum.GetNames(typeof(TEnum)))
            {
                if (Normalize(name) == normalized)
                {
                    return (TEnum)Enum.Parse(typeof(TEnum), name);
                }
            }

            return null;
        }

        /// <summary>
        /// Track 1 enum -> Track 2 value: the Track 2 value with the same name, otherwise the Track 1 name as it is.
        /// </summary>
        internal static T2 ToTrack2<T2>(Enum track1Value) where T2 : struct
        {
            string name = track1Value.ToString();
            string normalized = Normalize(name);
            foreach (object known in KnownValues(typeof(T2)))
            {
                if (Normalize(known.ToString()) == normalized)
                {
                    return (T2)known;
                }
            }

            return (T2)Activator.CreateInstance(typeof(T2), name);
        }

        internal static T2? ToTrack2OrNull<T2>(Enum track1Value) where T2 : struct
        {
            return track1Value == null ? (T2?)null : ToTrack2<T2>(track1Value);
        }

        /// <summary>
        /// A PS text property (for example PSContainerHostBatchBindMountEntry.Source) -> the Track 2 value with exactly
        /// that text, which is what Track 1 sends.
        /// </summary>
        internal static T2? FromString<T2>(string value) where T2 : struct
        {
            return value == null ? (T2?)null : (T2)Activator.CreateInstance(typeof(T2), value);
        }

        private static IReadOnlyList<object> KnownValues(Type type)
        {
            return KnownTrack2Values.GetOrAdd(type, t =>
            {
                List<object> values = new List<object>();
                foreach (PropertyInfo property in t.GetProperties(BindingFlags.Public | BindingFlags.Static))
                {
                    if (property.PropertyType == t)
                    {
                        values.Add(property.GetValue(null));
                    }
                }

                return values;
            });
        }

        private static string Normalize(string value)
        {
            return value.Replace("_", string.Empty).Replace("-", string.Empty).ToLowerInvariant();
        }
    }
}
