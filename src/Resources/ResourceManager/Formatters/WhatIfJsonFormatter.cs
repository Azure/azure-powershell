namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;

    public class WhatIfJsonFormatter
    {
        private const int IndentSize = 2;

        private const string NullValue = "null";

        protected ColorStringBuilder Builder { get; } = new ColorStringBuilder();

        public string Result => this.Builder.ToString();

        public void FormatJson(JToken value, string path = null, int maxPathLength = 0, int indentLevel = 0)
        {
            switch (value)
            {
                case null:
                    this.FormatHead(path, maxPathLength, indentLevel);
                    this.FormatPrimitive(null);
                    break;

                case JValue primitiveValue:
                    this.FormatHead(path, maxPathLength, indentLevel);
                    this.FormatPrimitive(primitiveValue);
                    break;

                // Handle empty array and empty object. They should behave like primitive values.
                case JArray arrayValue when arrayValue.Count == 0:
                case JObject objectValue when objectValue.Count == 0:
                    this.FormatHead(path, maxPathLength, indentLevel);
                    this.Builder.Append(value);
                    break;

                case JArray arrayValue:
                    // Override maxPathLength for array, since we don't align left bracket.
                    this.FormatHead(path, path?.Length ?? 0, indentLevel);
                    this.FormatArray(arrayValue, indentLevel);
                    break;

                case JObject objectValue:
                    this.FormatObject(objectValue, path, maxPathLength, indentLevel);
                    break;

                default:
                    // If this happens, value is malformed. Instead of throwing an exception,
                    // we handle it gracefully by printing out whatever it is.
                    using (this.Builder.NewColorScope(Color.Red))
                    {
                        this.Builder
                            .AppendLine()
                            .AppendLine("Unexpected malformed property change:")
                            .AppendLine(value.ToString())
                            .AppendLine();
                    }
                    break;
            }
        }

        protected static bool IsLeaf(JToken value)
        {
            return value is JValue ||
                   value is JArray arrayValue && arrayValue.Count == 0 ||
                   value is JObject objectValue && objectValue.Count == 0;
        }

        protected static string Indent(int indentLevel = 1)
        {
            return new string(Symbol.WhiteSpace.ToChar(), IndentSize * indentLevel);
        }

        protected void FormatIndent(int indentLevel)
        {
            this.Builder.Append(Indent(indentLevel));
        }

        protected void FormatPath(string path)
        {
            if (path == null)
            {
                return;
            }

            this.Builder
                .Append(path)
                .Append(Symbol.Colon, Color.Reset);
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
                if (IsLeaf(arrayValue[i]))
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
                if (property.Value is JArray arrayValue && arrayValue.Count > 0)
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

                int currentPathLength = property.Value is JObject nextObjectValue
                    ? property.Key.Length + GetMaxPathLength(nextObjectValue) + 1
                    : property.Key.Length;

                maxPathLength = Math.Max(maxPathLength, currentPathLength);
            }

            return maxPathLength;
        }

        private void FormatPrimitive(JValue primitiveValue)
        {
            if (primitiveValue == null || primitiveValue.Type == JTokenType.Null)
            {
                this.Builder.Append(NullValue);
                return;
            }

            switch (primitiveValue.Type)
            {
                case JTokenType.Boolean:
                    this.Builder.Append(primitiveValue.ToString().ToLowerInvariant());
                    return;

                case JTokenType.Integer:
                case JTokenType.Float:
                    this.Builder.Append(primitiveValue);
                    return;

                default:
                    this.Builder
                        .Append(Symbol.Quote)
                        .Append(primitiveValue)
                        .Append(Symbol.Quote);
                    return;
            }
        }

        private void FormatArray(JArray arrayValue, int indentLevel)
        {
            // [
            this.Builder
                .Append(Symbol.LeftSquareBracket, Color.Reset)
                .AppendLine();

            int maxPathLength = GetMaxPathLength(arrayValue);

            for (var index = 0; index < arrayValue.Count; index++)
            {
                JToken itemValue = arrayValue[index];
                string itemPath = index.ToString();

                if (itemValue is JObject objectValue && objectValue.Count > 0)
                {
                    this.FormatIndent(indentLevel + 1);
                    this.FormatPath(itemPath);
                    this.FormatObject(objectValue, null, 0, indentLevel + 1);
                }
                else
                {
                    this.FormatJson(itemValue, itemPath, maxPathLength, indentLevel + 1);
                }

                this.Builder.AppendLine();
            }

            // ]
            this.Builder
                .Append(Indent(indentLevel))
                .Append(Symbol.RightSquareBracket, Color.Reset);
        }

        private void FormatObject(JObject objectValue, string path, int maxPathLength, int indentLevel)
        {
            bool isRoot = string.IsNullOrEmpty(path);

            if (isRoot)
            {
                // Object start.
                this.Builder.AppendLine().AppendLine();

                maxPathLength = GetMaxPathLength(objectValue);
                indentLevel++;
            }

            // Unwrap nested values.
            foreach (KeyValuePair<string, JToken> property in objectValue)
            {
                string childPath = isRoot ? property.Key : $"{path}{Symbol.Dot}{property.Key}";
                this.FormatJson(property.Value, childPath, maxPathLength, indentLevel);

                if (!(property.Value is JObject))
                {
                    // Object end.
                    this.Builder.AppendLine();
                }
            }
        }

        private void FormatHead(string path, int maxPathLength, int indentLevel)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            this.FormatIndent(indentLevel);
            this.FormatPath(path);

            // Add one for white space.
            int paddingWidth = maxPathLength - path.Length + 1;
            this.FormatPadding(paddingWidth);
        }
    }
}
