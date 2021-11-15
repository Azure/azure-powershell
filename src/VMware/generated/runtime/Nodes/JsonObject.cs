/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json
{
    public partial class JsonObject : JsonNode, IDictionary<string, JsonNode>
    {
        private readonly Dictionary<string, JsonNode> items;

        internal JsonObject()
        {
            items = new Dictionary<string, JsonNode>();
        }

        internal JsonObject(IEnumerable<KeyValuePair<string, JsonNode>> properties)
        {
            if (properties == null) throw new ArgumentNullException(nameof(properties));

            items = new Dictionary<string, JsonNode>();

            foreach (var field in properties)
            {
                items.Add(field.Key, field.Value);
            }
        }

        #region IDictionary Constructors

        internal JsonObject(IDictionary<string, string> dic)
        {
            items = new Dictionary<string, JsonNode>(dic.Count);

            foreach (var pair in dic)
            {
                Add(pair.Key, pair.Value);
            }
        }

        #endregion

        internal override JsonType Type => JsonType.Object;

        #region Add Overloads

        public void Add(string name, JsonNode value) =>
            items.Add(name, value);

        public void Add(string name, byte[] value) =>
            items.Add(name, new XBinary(value));

        public void Add(string name, DateTime value) =>
            items.Add(name, new JsonDate(value));

        public void Add(string name, int value) =>
            items.Add(name, new JsonNumber(value.ToString()));

        public void Add(string name, long value) =>
            items.Add(name, new JsonNumber(value.ToString()));

        public void Add(string name, float value) =>
            items.Add(name, new JsonNumber(value.ToString()));

        public void Add(string name, double value) =>
            items.Add(name, new JsonNumber(value.ToString()));

        public void Add(string name, string value) =>
            items.Add(name, new JsonString(value));

        public void Add(string name, bool value) =>
            items.Add(name, new JsonBoolean(value));

        public void Add(string name, Uri url) =>
            items.Add(name, new JsonString(url.AbsoluteUri));

        public void Add(string name, string[] values) =>
          items.Add(name, new XImmutableArray<string>(values));

        public void Add(string name, int[] values) =>
            items.Add(name, new XImmutableArray<int>(values));

        #endregion

        #region ICollection<KeyValuePair<string,JsonNode>> Members

        void ICollection<KeyValuePair<string, JsonNode>>.Add(KeyValuePair<string, JsonNode> item)
        {
            items.Add(item.Key, item.Value);
        }

        void ICollection<KeyValuePair<string, JsonNode>>.Clear()
        {
            items.Clear();
        }

        bool ICollection<KeyValuePair<string, JsonNode>>.Contains(KeyValuePair<string, JsonNode> item) =>
            throw new NotImplementedException();

        void ICollection<KeyValuePair<string, JsonNode>>.CopyTo(KeyValuePair<string, JsonNode>[] array, int arrayIndex) =>
            throw new NotImplementedException();


        int ICollection<KeyValuePair<string, JsonNode>>.Count => items.Count;

        bool ICollection<KeyValuePair<string, JsonNode>>.IsReadOnly => false;

        bool ICollection<KeyValuePair<string, JsonNode>>.Remove(KeyValuePair<string, JsonNode> item) =>
            throw new NotImplementedException();

        #endregion

        #region IDictionary<string,JsonNode> Members

        public bool ContainsKey(string key) => items.ContainsKey(key);

        public ICollection<string> Keys => items.Keys;

        public bool Remove(string key) => items.Remove(key);

        public bool TryGetValue(string key, out JsonNode value) =>
            items.TryGetValue(key, out value);

        public ICollection<JsonNode> Values => items.Values;

        public override JsonNode this[string key]
        {
            get => items[key];
            set => items[key] = value;
        }

        #endregion

        #region IEnumerable

        IEnumerator<KeyValuePair<string, JsonNode>> IEnumerable<KeyValuePair<string, JsonNode>>.GetEnumerator()
         => items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => items.GetEnumerator();

        #endregion

        #region Helpers

        internal static new JsonObject FromObject(object instance) =>
            (JsonObject)new JsonSerializer().Serialize(instance);

        #endregion

        #region Static Constructors

        internal static JsonObject FromStream(Stream stream)
        {
            using (var tr = new StreamReader(stream))
            {
                return (JsonObject)Parse(tr);
            }
        }

        internal static new JsonObject Parse(string text)
        {
            return (JsonObject)JsonNode.Parse(text);
        }

        #endregion
    }
}