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
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public static class TagsHelper
    {
        public static Dictionary<string, string> ConvertToDictionary(this Hashtable tags)
        {
            Dictionary<string, string> tagsDictionary = new Dictionary<string, string>();
            foreach (DictionaryEntry tag in tags)
            {
                string key = tag.Key as string;
                if (string.IsNullOrWhiteSpace(key))
                    throw new ArgumentException("Invalid tag name");

                if (tag.Value != null && !(tag.Value is string))
                    throw new ArgumentException("Tag has invalid value");
                string value = (tag.Value == null) ? string.Empty : (string)tag.Value;
                tagsDictionary[key] = value;
            }

            return tagsDictionary;
        }

        public static Hashtable ConvertToHashtable(this IDictionary<string, string> tags)
        {
            Hashtable tagsHashtable = new Hashtable();
            foreach (var tag in tags)
                tagsHashtable[tag.Key] = tag.Value;

            return tagsHashtable;
        }
        public static string ConvertToTagsTable(this Hashtable tags)
        {
            string tagsTable = null;
            if (tags.Count > 0)
            {
                int maxNameLength = tags.Keys.OfType<string>().Max(key => key.Length);
                int maxValueLength = tags.Values.OfType<string>().Max(value => value.Length);

                tagsTable = Format(maxNameLength, maxValueLength, () => { return EnumerateTag(tags); });
            }

            return tagsTable;
        }

        public static string ConvertToTagsTable(this IDictionary<string, string> tags)
        {
            string tagsTable = null;
            if (tags.Count > 0)
            {
                int maxNameLength = tags.Keys.Max(key => key.Length);
                int maxValueLength = tags.Values.Max(value => value.Length);

                tagsTable = Format(maxNameLength, maxValueLength, () => { return EnumerateTag(tags); });
            }

            return tagsTable;
        }

        private static IEnumerable<KeyValuePair<string, string>> EnumerateTag(Hashtable tags)
        {
            foreach (DictionaryEntry tag in tags)
            {
                var key = tag.Key as string;
                if (string.IsNullOrWhiteSpace(key))
                    continue;

                if (tag.Value != null && !(tag.Value is string))
                    continue;
                var value = (tag.Value == null) ? string.Empty : (string)tag.Value;

                yield return new KeyValuePair<string, string>(key, value);
            }
        }

        private static IEnumerable<KeyValuePair<string, string>> EnumerateTag(IDictionary<string, string> tags)
        {
            foreach (var tag in tags)
            {
                if (string.IsNullOrWhiteSpace(tag.Key))
                    continue;
                var value = tag.Value ?? string.Empty;

                yield return new KeyValuePair<string, string>(tag.Key, value);
            }
        }

        private static string Format(int maxNameLength, int maxValueLength, Func<IEnumerable<KeyValuePair<string, string>>> enumeratorGenerator)
        {
            string nameField = "Name";
            string valueField = "Value";
            StringBuilder builder = new StringBuilder();

            maxNameLength = Math.Max(maxNameLength, nameField.Length);
            maxValueLength = Math.Max(maxValueLength, valueField.Length);
            string rowFormat = "{0, -" + maxNameLength + "}  {1, -" + maxValueLength + "}\r\n";
            builder.AppendFormat(rowFormat, nameField, valueField);

            IEnumerable<KeyValuePair<string, string>> enumerator = enumeratorGenerator();

            foreach (var pair in enumerator)
            {
                builder.AppendFormat(rowFormat, pair.Key, pair.Value);
            }
            return builder.ToString();
        }
    }
}
