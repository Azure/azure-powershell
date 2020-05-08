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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Newtonsoft.Json.Linq;

    public class WhatIfJsonFormatter
    {
        private const int IndentSize = 2;

        protected ColoredStringBuilder Builder { get; }

        public WhatIfJsonFormatter(ColoredStringBuilder builder)
        {
            this.Builder = builder;
        }

        public static string FormatJson(JToken value)
        {
            var builder = new ColoredStringBuilder();
            var formatter = new WhatIfJsonFormatter(builder);

            formatter.FormatJson(value, "");

            return builder.ToString();
        }

        protected void FormatJson(JToken value, string path = "", int maxPathLength = 0, int indentLevel = 0)
        {
            if (value.IsLeaf())
            {
                this.FormatJsonPath(path, maxPathLength - path.Length + 1, indentLevel);
                this.FormatLeaf(value);
            }
            else if (value.IsNonEmptyArray())
            {
                this.FormatJsonPath(path, 1, indentLevel);
                this.FormatNonEmptyArray(value as JArray, indentLevel);
            }
            else if (value.IsNonEmptyObject())
            {
                this.FormatNonEmptyObject(value as JObject, path, maxPathLength, indentLevel);
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Invalid JSON value: {value}");
            }
        }

        protected static string Indent(int indentLevel = 1)
        {
            return new string(Symbol.WhiteSpace.ToChar(), IndentSize * indentLevel);
        }

        protected void FormatIndent(int indentLevel)
        {
            this.Builder.Append(Indent(indentLevel));
        }

        protected void FormatPath(string path, int paddingWidth, int indentLevel, Action formatHead = null, Action formatTail = null)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            this.FormatIndent(indentLevel);
            formatHead?.Invoke();
            this.Builder.Append(path);
            formatTail?.Invoke();
            this.Builder.Append(new string(Symbol.WhiteSpace.ToChar(), paddingWidth));
        }

        protected void FormatColon()
        {
            this.Builder.Append(Symbol.Colon, Color.Reset);
        }

        protected void FormatPadding(int paddingWidth)
        {
            this.Builder.Append(new string(Symbol.WhiteSpace.ToChar(), paddingWidth));
        }

        private static int GetMaxPathLength(JArray arrayValue)
        {
            var maxLengthIndex = 0;

            for (var i = 0; i < arrayValue.Count; i++)
            {
                if (arrayValue[i].IsLeaf())
                {
                    maxLengthIndex = i;
                }
            }

            return maxLengthIndex.ToString().Length;
        }

        private static int GetMaxPathLength(JObject objectValue)
        {
            var maxPathLength = 0;

            foreach (KeyValuePair<string, JToken> property in objectValue)
            {
                if (property.Value.IsNonEmptyArray())
                {
                    // Ignore array paths to avoid long padding like this:
                    //
                    //   short.path:                   "foo"
                    //   another.short.path:           "bar"
                    //   very.very.long.path.to.array: [
                    //     ...
                    //   ]
                    //   path.after.array:             "foobar"
                    //
                    // Instead, the following is preferred:
                    //
                    //   short.path:         "foo"
                    //   another.short.path: "bar"
                    //   very.very.long.path.to.array: [
                    //     ...
                    //   ]
                    //   path.after.array:   "foobar"
                    //
                    continue;
                }

                int currentPathLength = property.Value.IsNonEmptyObject()
                    // Add one for dot.
                    ? property.Key.Length + 1 + GetMaxPathLength(property.Value as JObject)
                    : property.Key.Length;

                maxPathLength = Math.Max(maxPathLength, currentPathLength);
            }

            return maxPathLength;
        }

        private void FormatLeaf(JToken value)
        {
            value = value ?? JValue.CreateNull();

            switch (value.Type)
            {
                case JTokenType.Null:
                    this.Builder.Append("null");
                    return;

                case JTokenType.Boolean:
                    this.Builder.Append(value.ToString().ToLowerInvariant());
                    return;

                case JTokenType.String:
                    this.Builder
                        .Append(Symbol.Quote)
                        .Append(value)
                        .Append(Symbol.Quote);
                    return;

                default:
                    this.Builder.Append(value);
                    return;
            }
        }

        private void FormatNonEmptyArray(JArray value, int indentLevel)
        {
            // [
            this.Builder
                .Append(Symbol.LeftSquareBracket, Color.Reset)
                .AppendLine();

            int maxPathLength = GetMaxPathLength(value);

            for (var index = 0; index < value.Count; index++)
            {
                JToken childValue = value[index];
                string childPath = index.ToString();

                if (childValue.IsNonEmptyObject())
                {
                    this.FormatJsonPath(childPath, 0, indentLevel + 1);
                    this.FormatNonEmptyObject(childValue as JObject, indentLevel: indentLevel + 1);
                }
                else
                {
                    this.FormatJson(childValue, childPath, maxPathLength, indentLevel + 1);
                }

                this.Builder.AppendLine();
            }

            // ]
            this.Builder
                .Append(Indent(indentLevel))
                .Append(Symbol.RightSquareBracket, Color.Reset);
        }

        private void FormatNonEmptyObject(JObject value, string path = "", int maxPathLength = 0, int indentLevel = 0)
        {
            bool isRoot = string.IsNullOrEmpty(path);

            if (isRoot)
            {
                this.Builder.AppendLine().AppendLine();

                maxPathLength = GetMaxPathLength(value);
                indentLevel++;
            }

            // Unwrap nested values.
            foreach (KeyValuePair<string, JToken> property in value)
            {
                string childPath = isRoot ? property.Key : $"{path}{Symbol.Dot}{property.Key}";
                this.FormatJson(property.Value, childPath, maxPathLength, indentLevel);

                if (!property.Value.IsNonEmptyObject())
                {
                    this.Builder.AppendLine();
                }
            }
        }

        private void FormatJsonPath(string path, int paddingWidth, int indentLevel) =>
            this.FormatPath(path, paddingWidth, indentLevel, formatTail: this.FormatColon);
    }
}

