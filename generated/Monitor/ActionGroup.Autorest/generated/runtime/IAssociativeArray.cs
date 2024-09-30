/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
#define DICT_PROPERTIES
namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime
{
    /// <summary>A subset of IDictionary that doesn't implement IEnumerable or IDictionary to work around PowerShell's aggressive formatter</summary>
    public interface IAssociativeArray<T>
    {
#if DICT_PROPERTIES
        System.Collections.Generic.IEnumerable<string> Keys { get; }
        System.Collections.Generic.IEnumerable<T> Values { get; }
        int Count { get; }
#endif
        System.Collections.Generic.IDictionary<string, T> AdditionalProperties { get; }
        T this[string index] { get; set; }
        void Add(string key, T value);
        bool ContainsKey(string key);
        bool Remove(string key);
        bool TryGetValue(string key, out T value);
        void Clear();
    }
}