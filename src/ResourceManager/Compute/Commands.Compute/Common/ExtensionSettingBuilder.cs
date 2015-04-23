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

namespace Microsoft.Azure.Commands.Compute.Common
{
    public class JsonSettingBuilder
    {
        private const char SingleQuote = '\'';
        private const char DoubleQuote = '"';
        private const char LeftBracket = '[';
        private const char RightBracket = ']';
        private const char LeftCurly = '{';
        private const char RightCurly = '}';
        private const char Colon = ':';
        private const char Comma = ',';

        private IDictionary<string, string> settings;

        public JsonSettingBuilder()
        {
            this.settings = new Dictionary<string, string>();
        }

        public JsonSettingBuilder(IDictionary<string, string> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException();
            }

            this.settings = settings;
        }

        public JsonSettingBuilder(Hashtable hashtable)
        {
            if (hashtable == null)
            {
                throw new ArgumentNullException();
            }

            this.settings = new Dictionary<string, string>();
            foreach (var key in hashtable.Keys)
            {
                this.settings.Add(key.ToString(), hashtable[key].ToString());
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(LeftCurly);

            var settings = this.settings.Keys.Select(k => BuildSetting(k, this.settings[k]));
            sb.Append(string.Join(Comma.ToString(), settings));

            sb.Append(RightCurly);

            return sb.ToString();
        }

        private string BuildSetting(string key, string value)
        {
            var sb = new StringBuilder();

            sb.Append(NormalizeKey(key));
            sb.Append(Colon);
            sb.Append(NormalizeKey(value));

            return sb.ToString();
        }

        private string NormalizeKey(string key)
        {
            var sb = new StringBuilder();

            if (IsWrappedByDoubleQuotes(key))
            {
                sb.Append(key);
            }
            else if (IsWrappedBySingleQuotes(key))
            {
                sb.Replace(SingleQuote, DoubleQuote, 0, 1);
                sb.Replace(SingleQuote, DoubleQuote, sb.Length - 1, 1);
            }
            else
            {
                sb.Append(DoubleQuote).Append(key).Append(DoubleQuote);
            }

            return sb.ToString();
        }

        private string NormalizeValue(string value)
        {
            var sb = new StringBuilder();

            if (IsWrappedByBrackets(value))
            {
                sb.Append(value);
            }
            else
            {
                sb.Append(NormalizeKey(value));
            }

            return sb.ToString();
        }

        private bool IsWrappedByDoubleQuotes(string str)
        {
            return IsWrappedByCharacters(str, DoubleQuote);
        }

        private bool IsWrappedBySingleQuotes(string str)
        {
            return IsWrappedByCharacters(str, SingleQuote);
        }

        private bool IsWrappedByBrackets(string str)
        {
            return IsWrappedByCharacters(str, LeftBracket, RightBracket)
                || IsWrappedByCharacters(str, LeftCurly, RightCurly);
        }

        private bool IsWrappedByCharacters(string str, char ch, StringComparison sc = StringComparison.OrdinalIgnoreCase)
        {
            return IsWrappedByCharacters(str, ch, ch, sc);
        }

        private bool IsWrappedByCharacters(string str, char start, char end, StringComparison sc = StringComparison.OrdinalIgnoreCase)
        {
            if (!string.IsNullOrEmpty(str) && str.Length >= 2)
            {
                return str.StartsWith(start.ToString(), sc) && str.EndsWith(end.ToString(), sc);
            }

            return false;
        }
    }
}
