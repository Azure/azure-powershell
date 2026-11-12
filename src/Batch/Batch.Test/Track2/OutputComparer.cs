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

using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Microsoft.Azure.Commands.Batch.Test.Track2
{
    /// <summary>
    /// Compares two PS objects (one filled from Track 1, one from Track 2) by their public properties: values, .NET types
    /// (including DateTime.Kind), dictionaries, lists and nesting. Returns one line per difference.
    /// </summary>
    internal static class OutputComparer
    {
        public static List<string> Compare(object track1, object track2, string path)
        {
            List<string> differences = new List<string>();
            CompareInto(track1, track2, path, differences, 0);
            return differences;
        }

        private static void CompareInto(object a, object b, string path, List<string> differences, int depth)
        {
            if (depth > 15 || (a == null && b == null))
            {
                return;
            }

            if (a == null || b == null)
            {
                differences.Add(string.Format("{0}: track1={1} track2={2}", path, Show(a), Show(b)));
                return;
            }

            Type ta = a.GetType();
            Type tb = b.GetType();
            if (IsSimple(ta) || IsSimple(tb))
            {
                if (ta != tb)
                {
                    differences.Add(string.Format("{0}: type track1={1} track2={2} ({3} / {4})", path, ta.FullName, tb.FullName, Show(a), Show(b)));
                }
                else if (a is DateTime da && b is DateTime db && (da != db || da.Kind != db.Kind))
                {
                    differences.Add(string.Format("{0}: track1={1:o} ({2}) track2={3:o} ({4})", path, da, da.Kind, db, db.Kind));
                }
                else if (!a.Equals(b))
                {
                    differences.Add(string.Format("{0}: track1={1} track2={2}", path, Show(a), Show(b)));
                }

                return;
            }

            if (a is JToken || b is JToken)
            {
                if (ta != tb || !JToken.DeepEquals(a as JToken, b as JToken))
                {
                    differences.Add(string.Format("{0}: track1={1} ({2}) track2={3} ({4})", path, Show(a), ta.Name, Show(b), tb.Name));
                }

                return;
            }

            if (a is IDictionary dictionaryA && b is IDictionary dictionaryB)
            {
                if (ta != tb)
                {
                    differences.Add(string.Format("{0}: type track1={1} track2={2}", path, ta.Name, tb.Name));
                }

                foreach (object key in dictionaryA.Keys.Cast<object>().Union(dictionaryB.Keys.Cast<object>()).Distinct())
                {
                    if (dictionaryA.Contains(key) != dictionaryB.Contains(key))
                    {
                        differences.Add(string.Format("{0}[{1}]: in track1={2} in track2={3}", path, key, dictionaryA.Contains(key), dictionaryB.Contains(key)));
                        continue;
                    }

                    CompareInto(dictionaryA[key], dictionaryB[key], path + "[" + key + "]", differences, depth + 1);
                }

                return;
            }

            if (a is IEnumerable listA && b is IEnumerable listB)
            {
                if (ta != tb)
                {
                    differences.Add(string.Format("{0}: type track1={1} track2={2}", path, ta.FullName, tb.FullName));
                }

                List<object> itemsA = listA.Cast<object>().ToList();
                List<object> itemsB = listB.Cast<object>().ToList();
                if (itemsA.Count != itemsB.Count)
                {
                    differences.Add(string.Format("{0}: count track1={1} track2={2}", path, itemsA.Count, itemsB.Count));
                }

                for (int i = 0; i < Math.Min(itemsA.Count, itemsB.Count); i++)
                {
                    CompareInto(itemsA[i], itemsB[i], path + "[" + i + "]", differences, depth + 1);
                }

                return;
            }

            if (ta != tb)
            {
                differences.Add(string.Format("{0}: type track1={1} track2={2}", path, ta.FullName, tb.FullName));
                return;
            }

            foreach (PropertyInfo property in ta.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.GetIndexParameters().Length == 0))
            {
                CompareInto(Get(property, a), Get(property, b), path + "." + property.Name, differences, depth + 1);
            }
        }

        private static object Get(PropertyInfo property, object target)
        {
            try
            {
                return property.GetValue(target);
            }
            catch (TargetInvocationException e)
            {
                return "<throws " + e.InnerException?.GetType().Name + ": " + e.InnerException?.Message + ">";
            }
        }

        private static bool IsSimple(Type type)
        {
            return type.IsPrimitive || type.IsEnum || type == typeof(string) || type == typeof(DateTime) || type == typeof(TimeSpan)
                || type == typeof(DateTimeOffset) || type == typeof(decimal) || type == typeof(Guid);
        }

        private static string Show(object value)
        {
            if (value == null)
            {
                return "<null>";
            }

            if (value is double d)
            {
                return d.ToString("R", CultureInfo.InvariantCulture);
            }

            string text = value.ToString().Replace("\r", " ").Replace("\n", " ");
            return text.Length > 120 ? text.Substring(0, 120) + "..." : text;
        }
    }
}
