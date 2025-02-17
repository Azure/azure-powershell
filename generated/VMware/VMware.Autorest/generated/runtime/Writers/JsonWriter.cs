/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json
{
    internal class JsonWriter
    {
        const string indentation = "  ";  // 2 spaces

        private readonly bool pretty;
        private readonly TextWriter writer;

        protected int currentLevel = 0;

        internal JsonWriter(TextWriter writer, bool pretty = true)
        {
            this.writer = writer ?? throw new ArgumentNullException(nameof(writer));
            this.pretty = pretty;
        }

        internal void WriteNode(JsonNode node)
        {
            switch (node.Type)
            {
                case JsonType.Array: WriteArray((IEnumerable<JsonNode>)node); break;
                case JsonType.Object: WriteObject((JsonObject)node); break;

                // Primitives
                case JsonType.Binary: WriteBinary((XBinary)node); break;
                case JsonType.Boolean: WriteBoolean((bool)node); break;
                case JsonType.Date: WriteDate((JsonDate)node); break;
                case JsonType.Null: WriteNull(); break;
                case JsonType.Number: WriteNumber((JsonNumber)node); break;
                case JsonType.String: WriteString(node); break;
            }
        }

        internal void WriteArray(IEnumerable<JsonNode> array)
        {
            currentLevel++;

            writer.Write('[');

            bool doIndentation = false;

            if (pretty)
            {
                foreach (var node in array)
                {
                    if (node.Type == JsonType.Object || node.Type == JsonType.Array)
                    {
                        doIndentation = true;

                        break;
                    }
                }
            }

            bool isFirst = true;

            foreach (JsonNode node in array)
            {
                if (!isFirst) writer.Write(',');

                if (doIndentation)
                {
                    WriteIndent();
                }
                else if (pretty)
                {
                    writer.Write(' ');
                }

                WriteNode(node);

                isFirst = false;
            }

            currentLevel--;

            if (doIndentation)
            {
                WriteIndent();
            }
            else if (pretty)
            {
                writer.Write(' ');
            }

            writer.Write(']');
        }

        internal void WriteIndent()
        {
            if (pretty)
            {
                writer.Write(Environment.NewLine);

                for (int level = 0; level < currentLevel; level++)
                {
                    writer.Write(indentation);
                }
            }
        }

        internal void WriteObject(JsonObject obj)
        {
            currentLevel++;

            writer.Write('{');

            bool isFirst = true;

            foreach (var field in obj)
            {
                if (!isFirst) writer.Write(',');

                WriteIndent();

                WriteFieldName(field.Key);

                writer.Write(':');

                if (pretty)
                {
                    writer.Write(' ');
                }

                // Write the field value
                WriteNode(field.Value);

                isFirst = false;
            }

            currentLevel--;

            WriteIndent();

            writer.Write('}');
        }

        internal void WriteFieldName(string fieldName)
        {
            writer.Write('"');
            writer.Write(HttpUtility.JavaScriptStringEncode(fieldName));
            writer.Write('"');
        }

        #region Primitives

        internal void WriteBinary(XBinary value)
        {
            writer.Write('"');
            writer.Write(value.ToString());
            writer.Write('"');
        }

        internal void WriteBoolean(bool value)
        {
            writer.Write(value ? "true" : "false");
        }

        internal void WriteDate(JsonDate date)
        {
            if (date.ToDateTime().Year == 1)
            {
                WriteNull();
            }
            else
            {
                writer.Write('"');
                writer.Write(date.ToIsoString());
                writer.Write('"');
            }
        }

        internal void WriteNull()
        {
            writer.Write("null");
        }

        internal void WriteNumber(JsonNumber number)
        {
            if (number.Overflows)
            {
                writer.Write('"');
                writer.Write(number.Value);
                writer.Write('"');
            }
            else
            {
                writer.Write(number.Value);
            }
        }

        internal void WriteString(string text)
        {
            if (text == null)
            {
                WriteNull();
            }
            else
            {
                writer.Write('"');

                writer.Write(HttpUtility.JavaScriptStringEncode(text));

                writer.Write('"');
            }
        }

        #endregion
    }
}


// TODO: Replace with System.Text.Json when available
