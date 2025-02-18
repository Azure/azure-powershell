/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;
using System.IO;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json
{
    

    public abstract partial class JsonNode
    {
        internal abstract JsonType Type { get; }

        public virtual JsonNode this[int index] => throw new NotImplementedException();

        public virtual JsonNode this[string name]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        #region Type Helpers
        
        internal bool IsArray  => Type == JsonType.Array;

        internal bool IsDate   => Type == JsonType.Date;

        internal bool IsObject => Type == JsonType.Object;

        internal bool IsNumber => Type == JsonType.Number;

        internal bool IsNull   => Type == JsonType.Null;

        #endregion

        internal void WriteTo(TextWriter textWriter, bool pretty = true)
        {
            var writer = new JsonWriter(textWriter, pretty); 

            writer.WriteNode(this);
        }

        internal T As<T>()
            where T : new()
            => new JsonSerializer().Deseralize<T>((JsonObject)this);

        internal T[] ToArrayOf<T>()
        {
            return (T[])new JsonSerializer().DeserializeArray(typeof(T[]), (JsonArray)this);
        }

        #region ToString Overrides

        public override string ToString() => ToString(pretty: true);

        internal string ToString(bool pretty)
        {
            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                WriteTo(writer, pretty);

                return sb.ToString();
            }
        }

        #endregion

        #region Static Constructors

        internal static JsonNode Parse(string text)
        {
            return Parse(new SourceReader(new StringReader(text)));
        }

        internal static JsonNode Parse(TextReader textReader)
            => Parse(new SourceReader(textReader));

        private static JsonNode Parse(SourceReader sourceReader)
        {
            using (var parser = new JsonParser(sourceReader))
            {
                return parser.ReadNode();
            }
        }

        internal static JsonNode FromObject(object instance)
            => new JsonSerializer().Serialize(instance);

        #endregion

        #region Implict Casts

        public static implicit operator string(JsonNode node) => node.ToString();

        #endregion

        #region Explict Casts

        public static explicit operator DateTime(JsonNode node)
        {
            switch (node.Type)
            {
                case JsonType.Date:
                    return ((JsonDate)node).ToDateTime();

                case JsonType.String:
                    return JsonDate.Parse(node.ToString()).ToDateTime();

                case JsonType.Number:
                    var num = (JsonNumber)node;

                    if (num.IsInteger)
                    {
                        return DateTimeOffset.FromUnixTimeSeconds(num).UtcDateTime;
                    }
                    else
                    {
                        return DateTimeOffset.FromUnixTimeMilliseconds((long)((double)num * 1000)).UtcDateTime;
                    }
            }

            throw new ConversionException(node, typeof(DateTime));
        }

        public static explicit operator DateTimeOffset(JsonNode node)
        {
            switch (node.Type)
            {
                case JsonType.Date   : return ((JsonDate)node).ToDateTimeOffset();
                case JsonType.String : return JsonDate.Parse(node.ToString()).ToDateTimeOffset();

                case JsonType.Number:
                    var num = (JsonNumber)node;

                    if (num.IsInteger)
                    {
                        return DateTimeOffset.FromUnixTimeSeconds(num);
                    }
                    else
                    {
                        return DateTimeOffset.FromUnixTimeMilliseconds((long)((double)num * 1000));
                    }

            }

            throw new ConversionException(node, typeof(DateTimeOffset));
        }

        public static explicit operator float(JsonNode node)
        {
            switch (node.Type)
            {
                case JsonType.Number : return (JsonNumber)node;
                case JsonType.String : return float.Parse(node.ToString());
            }

            throw new ConversionException(node, typeof(float));
        }

        public static explicit operator double(JsonNode node)
        {
            switch (node.Type)
            {
                case JsonType.Number : return (JsonNumber)node;
                case JsonType.String : return double.Parse(node.ToString());
            }

            throw new ConversionException(node, typeof(double));
        }

        public static explicit operator decimal(JsonNode node)
        {
            switch (node.Type)
            {
                case JsonType.Number: return (JsonNumber)node;
                case JsonType.String: return decimal.Parse(node.ToString());
            }
            
            throw new ConversionException(node, typeof(decimal));
        }

        public static explicit operator Guid(JsonNode node)
            => new Guid(node.ToString());

        public static explicit operator short(JsonNode node)
        {
            switch (node.Type)
            {
                case JsonType.Number : return (JsonNumber)node;
                case JsonType.String : return short.Parse(node.ToString());
            }

            throw new ConversionException(node, typeof(short));
        }

        public static explicit operator int(JsonNode node)
        {
            switch (node.Type)
            {
                case JsonType.Number : return (JsonNumber)node;
                case JsonType.String : return int.Parse(node.ToString());
            }

            throw new ConversionException(node, typeof(int));
        }

        public static explicit operator long(JsonNode node)
        {
            switch (node.Type)
            {
                case JsonType.Number: return (JsonNumber)node;
                case JsonType.String: return long.Parse(node.ToString());
            }

            throw new ConversionException(node, typeof(long));
        }

        public static explicit operator bool(JsonNode node)
           => ((JsonBoolean)node).Value;

        public static explicit operator ushort(JsonNode node)
            => (JsonNumber)node;

        public static explicit operator uint(JsonNode node)
            => (JsonNumber)node;

        public static explicit operator ulong(JsonNode node)
            => (JsonNumber)node;

        public static explicit operator TimeSpan(JsonNode node)
            => TimeSpan.Parse(node.ToString());

        public static explicit operator Uri(JsonNode node)
        {
            if (node.Type == JsonType.String)
            {
                return new Uri(node.ToString());
            }

            throw new ConversionException(node, typeof(Uri));
        }

        #endregion
    }
}